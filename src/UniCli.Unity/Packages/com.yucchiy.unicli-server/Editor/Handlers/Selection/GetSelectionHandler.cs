using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniCli.Protocol;
using UnityEditor;
using UnityEngine;

namespace UniCli.Server.Editor.Handlers
{
    public sealed class GetSelectionHandler : CommandHandler<Unit, GetSelectionResponse>
    {
        public override string CommandName => "Selection.Get";
        public override string Description => "Get the current selection in the editor";

        protected override bool TryWriteFormatted(GetSelectionResponse response, bool success, IFormatWriter writer)
        {
            if (!success) return true;

            if (response.gameObjects != null && response.gameObjects.Length > 0)
            {
                writer.WriteLine($"Selected GameObjects ({response.gameObjects.Length}):");
                foreach (var go in response.gameObjects)
                    writer.WriteLine($"  {go.path} (instanceId={go.instanceId})");
            }

            if (response.assets != null && response.assets.Length > 0)
            {
                writer.WriteLine($"Selected Assets ({response.assets.Length}):");
                foreach (var asset in response.assets)
                    writer.WriteLine($"  {asset.assetPath} ({asset.typeName})");
            }

            if ((response.gameObjects == null || response.gameObjects.Length == 0) &&
                (response.assets == null || response.assets.Length == 0))
            {
                writer.WriteLine("Nothing selected.");
            }

            return true;
        }

        protected override ValueTask<GetSelectionResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            var gameObjects = new List<SelectedGameObjectInfo>();
            var assets = new List<SelectedAssetInfo>();

            foreach (var obj in UnityEditor.Selection.objects)
            {
                if (obj is GameObject go)
                {
                    gameObjects.Add(new SelectedGameObjectInfo
                    {
                        instanceId = go.GetInstanceID(),
                        name = go.name,
                        path = GameObjectResolver.BuildPath(go.transform)
                    });
                }
                else
                {
                    var assetPath = AssetDatabase.GetAssetPath(obj);
                    if (!string.IsNullOrEmpty(assetPath))
                    {
                        assets.Add(new SelectedAssetInfo
                        {
                            assetPath = assetPath,
                            typeName = obj.GetType().FullName,
                            name = obj.name
                        });
                    }
                }
            }

            return new ValueTask<GetSelectionResponse>(new GetSelectionResponse
            {
                gameObjects = gameObjects.ToArray(),
                assets = assets.ToArray()
            });
        }
    }

    public sealed class PingSelectionHandler : CommandHandler<PingSelectionRequest, PingSelectionResponse>
    {
        public override string CommandName => "Selection.Ping";
        public override string Description => "Ping an asset or GameObject in the editor without changing selection";

        protected override bool TryWriteFormatted(PingSelectionResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Pinged: {response.targetName} ({response.targetType})");
            return true;
        }

        protected override ValueTask<PingSelectionResponse> ExecuteAsync(PingSelectionRequest request, CancellationToken cancellationToken)
        {
            UnityEngine.Object target = null;
            string targetName = "";
            string targetType = "";

            if (!string.IsNullOrEmpty(request.assetPath))
            {
                target = AssetDatabase.LoadMainAssetAtPath(request.assetPath);
                if (target == null)
                {
                    throw new CommandFailedException(
                        $"Asset not found: \"{request.assetPath}\"",
                        new PingSelectionResponse());
                }

                targetName = request.assetPath;
                targetType = target.GetType().FullName;
            }
            else if (request.instanceId != 0 || !string.IsNullOrEmpty(request.path))
            {
                var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
                if (go == null)
                {
                    throw new CommandFailedException(
                        $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                        new PingSelectionResponse());
                }

                target = go;
                targetName = GameObjectResolver.BuildPath(go.transform);
                targetType = typeof(GameObject).FullName;
            }
            else
            {
                throw new CommandFailedException(
                    "Specify assetPath or instanceId/path",
                    new PingSelectionResponse());
            }

            EditorGUIUtility.PingObject(target);

            return new ValueTask<PingSelectionResponse>(new PingSelectionResponse
            {
                targetName = targetName,
                targetType = targetType
            });
        }
    }

    public sealed class FrameSelectionHandler : CommandHandler<FrameSelectionRequest, FrameSelectionResponse>
    {
        public override string CommandName => "Selection.Frame";
        public override string Description => "Frame an asset in Project view or a GameObject in Scene view";

        protected override bool TryWriteFormatted(FrameSelectionResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Framed: {response.targetName} ({response.targetType})");
            return true;
        }

        protected override ValueTask<FrameSelectionResponse> ExecuteAsync(FrameSelectionRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.assetPath))
            {
                var asset = AssetDatabase.LoadMainAssetAtPath(request.assetPath);
                if (asset == null)
                {
                    throw new CommandFailedException(
                        $"Asset not found: \"{request.assetPath}\"",
                        new FrameSelectionResponse());
                }

                Selection.activeObject = asset;
                EditorUtility.FocusProjectWindow();
                EditorGUIUtility.PingObject(asset);

                return new ValueTask<FrameSelectionResponse>(new FrameSelectionResponse
                {
                    targetName = request.assetPath,
                    targetType = asset.GetType().FullName,
                    framedIn = "Project"
                });
            }

            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new FrameSelectionResponse());
            }

            Selection.activeGameObject = go;
            var sceneView = SceneView.lastActiveSceneView;
            var framed = sceneView != null && sceneView.FrameSelected();

            return new ValueTask<FrameSelectionResponse>(new FrameSelectionResponse
            {
                targetName = GameObjectResolver.BuildPath(go.transform),
                targetType = typeof(GameObject).FullName,
                framedIn = framed ? "Scene" : "Selection"
            });
        }
    }

    [Serializable]
    public class GetSelectionResponse
    {
        public SelectedGameObjectInfo[] gameObjects;
        public SelectedAssetInfo[] assets;
    }

    [Serializable]
    public class SelectedGameObjectInfo
    {
        public int instanceId;
        public string name;
        public string path;
    }

    [Serializable]
    public class SelectedAssetInfo
    {
        public string assetPath;
        public string typeName;
        public string name;
    }

    [Serializable]
    public class PingSelectionRequest
    {
        public string assetPath = "";
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class PingSelectionResponse
    {
        public string targetName;
        public string targetType;
    }

    [Serializable]
    public class FrameSelectionRequest
    {
        public string assetPath = "";
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class FrameSelectionResponse
    {
        public string targetName;
        public string targetType;
        public string framedIn;
    }
}
