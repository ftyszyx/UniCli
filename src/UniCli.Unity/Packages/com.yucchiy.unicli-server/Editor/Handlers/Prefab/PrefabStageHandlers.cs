using System;
using System.Threading;
using System.Threading.Tasks;
using UniCli.Protocol;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UniCli.Server.Editor.Handlers
{
    [Module("Assets")]
    public sealed class PrefabStageOpenHandler : CommandHandler<PrefabStageOpenRequest, PrefabStageInfoResponse>
    {
        private readonly EditorStateGuard _guard;

        public PrefabStageOpenHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "PrefabStage.Open";
        public override string Description => "Open a prefab asset in Prefab Mode";

        protected override bool TryWriteFormatted(PrefabStageInfoResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Opened prefab stage: {response.assetPath}");
            else
                writer.WriteLine("Failed to open prefab stage");

            return true;
        }

        protected override ValueTask<PrefabStageInfoResponse> ExecuteAsync(PrefabStageOpenRequest request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            if (string.IsNullOrEmpty(request.assetPath))
                throw new ArgumentException("assetPath is required");

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(request.assetPath);
            if (prefab == null)
            {
                throw new CommandFailedException(
                    $"Prefab not found at \"{request.assetPath}\"",
                    new PrefabStageInfoResponse());
            }

            AssetDatabase.OpenAsset(prefab);

            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null || !string.Equals(stage.assetPath, request.assetPath, StringComparison.OrdinalIgnoreCase))
            {
                throw new CommandFailedException(
                    $"Failed to open prefab stage for \"{request.assetPath}\"",
                    new PrefabStageInfoResponse());
            }

            return new ValueTask<PrefabStageInfoResponse>(PrefabStageResponseFactory.CreateResponse(stage));
        }
    }

    [Module("Assets")]
    public sealed class PrefabStageGetCurrentHandler : CommandHandler<Unit, PrefabStageInfoResponse>
    {
        public override string CommandName => "PrefabStage.GetCurrent";
        public override string Description => "Get the currently open prefab stage";

        protected override ValueTask<PrefabStageInfoResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null)
            {
                return new ValueTask<PrefabStageInfoResponse>(new PrefabStageInfoResponse
                {
                    isOpen = false
                });
            }

            return new ValueTask<PrefabStageInfoResponse>(PrefabStageResponseFactory.CreateResponse(stage));
        }
    }

    [Module("Assets")]
    public sealed class PrefabStageSaveCurrentHandler : CommandHandler<Unit, PrefabStageInfoResponse>
    {
        private readonly EditorStateGuard _guard;

        public PrefabStageSaveCurrentHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "PrefabStage.SaveCurrent";
        public override string Description => "Save the currently open prefab stage";

        protected override ValueTask<PrefabStageInfoResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null)
            {
                throw new CommandFailedException(
                    "No prefab stage is currently open.",
                    new PrefabStageInfoResponse());
            }

            if (!PrefabStageResponseFactory.SaveStage(stage))
            {
                throw new CommandFailedException(
                    $"Failed to save prefab stage for \"{stage.assetPath}\"",
                    new PrefabStageInfoResponse());
            }

            return new ValueTask<PrefabStageInfoResponse>(PrefabStageResponseFactory.CreateResponse(stage));
        }
    }

    [Module("Assets")]
    public sealed class PrefabStageCloseHandler : CommandHandler<PrefabStageCloseRequest, PrefabStageCloseResponse>
    {
        private readonly EditorStateGuard _guard;

        public PrefabStageCloseHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "PrefabStage.Close";
        public override string Description => "Close the currently open prefab stage";

        protected override bool TryWriteFormatted(PrefabStageCloseResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine("Closed prefab stage");
            else
                writer.WriteLine("Failed to close prefab stage");

            return true;
        }

        protected override ValueTask<PrefabStageCloseResponse> ExecuteAsync(PrefabStageCloseRequest request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null)
            {
                throw new CommandFailedException(
                    "No prefab stage is currently open.",
                    new PrefabStageCloseResponse());
            }

            if (request.saveChanges && !PrefabStageResponseFactory.SaveStage(stage))
            {
                throw new CommandFailedException(
                    $"Failed to save prefab stage for \"{stage.assetPath}\" before closing.",
                    new PrefabStageCloseResponse());
            }

            StageUtility.GoBackToPreviousStage();

            return new ValueTask<PrefabStageCloseResponse>(new PrefabStageCloseResponse
            {
                closed = PrefabStageUtility.GetCurrentPrefabStage() == null,
                saved = request.saveChanges,
                assetPath = stage.assetPath
            });
        }
    }

    [Serializable]
    public class PrefabStageOpenRequest
    {
        public string assetPath = "";
    }

    [Serializable]
    public class PrefabStageCloseRequest
    {
        public bool saveChanges;
    }

    [Serializable]
    public class PrefabStageCloseResponse
    {
        public bool closed;
        public bool saved;
        public string assetPath;
    }

    [Serializable]
    public class PrefabStageInfoResponse
    {
        public bool isOpen;
        public string assetPath;
        public string prefabAssetName;
        public string scenePath;
    }

    internal static class PrefabStageResponseFactory
    {
        public static bool SaveStage(PrefabStage stage)
        {
            if (stage == null || stage.prefabContentsRoot == null || string.IsNullOrEmpty(stage.assetPath))
                return false;

            PrefabUtility.SaveAsPrefabAsset(stage.prefabContentsRoot, stage.assetPath, out var success);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return success;
        }

        public static PrefabStageInfoResponse CreateResponse(PrefabStage stage)
        {
            return new PrefabStageInfoResponse
            {
                isOpen = true,
                assetPath = stage.assetPath,
                prefabAssetName = stage.prefabContentsRoot != null ? stage.prefabContentsRoot.name : "",
                scenePath = stage.scene.path
            };
        }
    }
}
