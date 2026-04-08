using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniCli.Server.Editor.Handlers
{
    [Module("Scene")]
    public sealed class SceneSaveHandler : CommandHandler<SceneSaveRequest, SceneSaveResponse>
    {
        public override string CommandName => "Scene.Save";
        public override string Description => "Save a scene or all open scenes via EditorSceneManager";

        protected override bool TryWriteFormatted(SceneSaveResponse response, bool success, IFormatWriter writer)
        {
            if (success)
            {
                writer.WriteLine($"Saved {response.savedCount} scene(s):");
                if (response.savedScenePaths != null)
                {
                    foreach (var p in response.savedScenePaths)
                        writer.WriteLine($"  {p}");
                }
            }
            else
            {
                writer.WriteLine("Failed to save scene(s)");
            }

            return true;
        }

        protected override ValueTask<SceneSaveResponse> ExecuteAsync(SceneSaveRequest request, CancellationToken cancellationToken)
        {
            if (request.all)
                return SaveAllScenes();

            return SaveSingleScene(request);
        }

        private static ValueTask<SceneSaveResponse> SaveAllScenes()
        {
            var saved = EditorSceneManager.SaveOpenScenes();
            if (!saved)
            {
                throw new CommandFailedException(
                    "Failed to save open scenes",
                    new SceneSaveResponse { savedScenePaths = Array.Empty<string>(), savedCount = 0 });
            }

            var paths = new List<string>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (scene.isLoaded && !string.IsNullOrEmpty(scene.path))
                    paths.Add(scene.path);
            }

            return new ValueTask<SceneSaveResponse>(new SceneSaveResponse
            {
                savedScenePaths = paths.ToArray(),
                savedCount = paths.Count
            });
        }

        private static ValueTask<SceneSaveResponse> SaveSingleScene(SceneSaveRequest request)
        {
            Scene scene;

            if (!string.IsNullOrEmpty(request.name) || !string.IsNullOrEmpty(request.path) || request.sceneIndex >= 0)
            {
                scene = SceneResolver.Resolve(request.name, request.path, request.sceneIndex);
                if (!scene.IsValid())
                {
                    throw new CommandFailedException(
                        $"Scene not found (name=\"{request.name}\", path=\"{request.path}\")",
                        new SceneSaveResponse { savedScenePaths = Array.Empty<string>(), savedCount = 0 });
                }
            }
            else
            {
                scene = SceneManager.GetActiveScene();
            }

            var savePath = !string.IsNullOrEmpty(request.saveAsPath)
                ? request.saveAsPath
                : scene.path;

            var saved = EditorSceneManager.SaveScene(scene, savePath);
            if (!saved)
            {
                throw new CommandFailedException(
                    $"Failed to save scene '{scene.name}' to \"{savePath}\"",
                    new SceneSaveResponse { savedScenePaths = Array.Empty<string>(), savedCount = 0 });
            }

            return new ValueTask<SceneSaveResponse>(new SceneSaveResponse
            {
                savedScenePaths = new[] { savePath },
                savedCount = 1
            });
        }
    }

    [Module("Scene")]
    public sealed class SceneDuplicateHandler : CommandHandler<SceneDuplicateRequest, SceneDuplicateResponse>
    {
        private readonly EditorStateGuard _guard;

        public SceneDuplicateHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "Scene.Duplicate";
        public override string Description => "Duplicate a scene asset to a new path and optionally open it";

        protected override bool TryWriteFormatted(SceneDuplicateResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Duplicated scene from {response.sourcePath} to {response.destinationPath}");
            else
                writer.WriteLine("Failed to duplicate scene");

            return true;
        }

        protected override ValueTask<SceneDuplicateResponse> ExecuteAsync(SceneDuplicateRequest request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            if (string.IsNullOrEmpty(request.destinationPath))
                throw new ArgumentException("destinationPath is required");

            Scene scene;
            if (!string.IsNullOrEmpty(request.name) || !string.IsNullOrEmpty(request.path) || request.sceneIndex >= 0)
            {
                scene = SceneResolver.Resolve(request.name, request.path, request.sceneIndex);
            }
            else
            {
                scene = SceneManager.GetActiveScene();
            }

            if (!scene.IsValid() || string.IsNullOrEmpty(scene.path))
            {
                throw new CommandFailedException(
                    $"Scene not found or has no saved path (name=\"{request.name}\", path=\"{request.path}\")",
                    new SceneDuplicateResponse());
            }

            if (!AssetDatabase.CopyAsset(scene.path, request.destinationPath))
            {
                throw new CommandFailedException(
                    $"Failed to duplicate scene from \"{scene.path}\" to \"{request.destinationPath}\"",
                    new SceneDuplicateResponse());
            }

            AssetDatabase.Refresh();

            string duplicatedSceneName = System.IO.Path.GetFileNameWithoutExtension(request.destinationPath);
            bool opened = false;
            if (request.openAfterDuplicate)
            {
                var duplicatedScene = EditorSceneManager.OpenScene(
                    request.destinationPath,
                    request.additive ? OpenSceneMode.Additive : OpenSceneMode.Single);
                opened = duplicatedScene.IsValid();
                if (opened)
                    duplicatedSceneName = duplicatedScene.name;
            }

            return new ValueTask<SceneDuplicateResponse>(new SceneDuplicateResponse
            {
                sourcePath = scene.path,
                destinationPath = request.destinationPath,
                sceneName = duplicatedSceneName,
                opened = opened
            });
        }
    }

    [Module("Scene")]
    public sealed class SceneRenameHandler : CommandHandler<SceneRenameRequest, SceneRenameResponse>
    {
        private readonly EditorStateGuard _guard;

        public SceneRenameHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "Scene.Rename";
        public override string Description => "Rename a saved scene asset while keeping it in the same folder";

        protected override bool TryWriteFormatted(SceneRenameResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Renamed scene from {response.oldPath} to {response.newPath}");
            else
                writer.WriteLine("Failed to rename scene");

            return true;
        }

        protected override ValueTask<SceneRenameResponse> ExecuteAsync(SceneRenameRequest request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            if (string.IsNullOrEmpty(request.newName))
                throw new ArgumentException("newName is required");

            Scene scene;
            if (!string.IsNullOrEmpty(request.name) || !string.IsNullOrEmpty(request.path) || request.sceneIndex >= 0)
            {
                scene = SceneResolver.Resolve(request.name, request.path, request.sceneIndex);
            }
            else
            {
                scene = SceneManager.GetActiveScene();
            }

            if (!scene.IsValid() || string.IsNullOrEmpty(scene.path))
            {
                throw new CommandFailedException(
                    $"Scene not found or has no saved path (name=\"{request.name}\", path=\"{request.path}\")",
                    new SceneRenameResponse());
            }

            var extension = System.IO.Path.GetExtension(scene.path);
            var normalizedName = request.newName.EndsWith(extension, StringComparison.OrdinalIgnoreCase)
                ? System.IO.Path.GetFileNameWithoutExtension(request.newName)
                : request.newName;

            var error = AssetDatabase.RenameAsset(scene.path, normalizedName);
            if (!string.IsNullOrEmpty(error))
            {
                throw new CommandFailedException(
                    $"Failed to rename scene: {error}",
                    new SceneRenameResponse());
            }

            AssetDatabase.Refresh();

            var parent = System.IO.Path.GetDirectoryName(scene.path)?.Replace("\\", "/") ?? "";
            var newPath = string.IsNullOrEmpty(parent)
                ? normalizedName + extension
                : $"{parent}/{normalizedName}{extension}";

            return new ValueTask<SceneRenameResponse>(new SceneRenameResponse
            {
                oldPath = scene.path,
                newPath = newPath,
                sceneName = normalizedName
            });
        }
    }

    [Module("Scene")]
    public sealed class SceneRemoveMissingScriptsHandler : CommandHandler<SceneRemoveMissingScriptsRequest, SceneRemoveMissingScriptsResponse>
    {
        private readonly EditorStateGuard _guard;

        public SceneRemoveMissingScriptsHandler(EditorStateGuard guard)
        {
            _guard = guard;
        }

        public override string CommandName => "Scene.RemoveMissingScripts";
        public override string Description => "Remove missing scripts from all GameObjects in a loaded scene";

        protected override bool TryWriteFormatted(SceneRemoveMissingScriptsResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Removed {response.removedCount} missing script(s) across {response.gameObjectCount} GameObject(s) in {response.sceneName}");
            else
                writer.WriteLine("Failed to remove missing scripts from scene");

            return true;
        }

        protected override ValueTask<SceneRemoveMissingScriptsResponse> ExecuteAsync(SceneRemoveMissingScriptsRequest request, CancellationToken cancellationToken)
        {
            using var scope = _guard.BeginScope(CommandName, GuardCondition.NotPlaying);

            Scene scene;
            if (!string.IsNullOrEmpty(request.name) || !string.IsNullOrEmpty(request.path) || request.sceneIndex >= 0)
            {
                scene = SceneResolver.Resolve(request.name, request.path, request.sceneIndex);
            }
            else
            {
                scene = SceneManager.GetActiveScene();
            }

            if (!scene.IsValid() || !scene.isLoaded)
            {
                throw new CommandFailedException(
                    $"Scene not found or not loaded (name=\"{request.name}\", path=\"{request.path}\")",
                    new SceneRemoveMissingScriptsResponse());
            }

            var removedCount = 0;
            var gameObjectCount = 0;
            foreach (var root in scene.GetRootGameObjects())
            {
                RemoveMissingScriptsRecursive(root, ref removedCount, ref gameObjectCount);
            }

            return new ValueTask<SceneRemoveMissingScriptsResponse>(new SceneRemoveMissingScriptsResponse
            {
                sceneName = scene.name,
                scenePath = scene.path,
                removedCount = removedCount,
                gameObjectCount = gameObjectCount
            });
        }

        private static void RemoveMissingScriptsRecursive(GameObject go, ref int removedCount, ref int gameObjectCount)
        {
            gameObjectCount++;
            Undo.RegisterCompleteObjectUndo(go, "Remove Missing Scripts");
            removedCount += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);

            var transform = go.transform;
            for (var i = 0; i < transform.childCount; i++)
            {
                RemoveMissingScriptsRecursive(transform.GetChild(i).gameObject, ref removedCount, ref gameObjectCount);
            }
        }
    }

    [Serializable]
    public class SceneSaveRequest
    {
        public string name = "";
        public string path = "";
        public int sceneIndex = -1;
        public string saveAsPath = "";
        public bool all;
    }

    [Serializable]
    public class SceneSaveResponse
    {
        public string[] savedScenePaths;
        public int savedCount;
    }

    [Serializable]
    public class SceneDuplicateRequest
    {
        public string name = "";
        public string path = "";
        public int sceneIndex = -1;
        public string destinationPath = "";
        public bool openAfterDuplicate;
        public bool additive;
    }

    [Serializable]
    public class SceneDuplicateResponse
    {
        public string sourcePath;
        public string destinationPath;
        public string sceneName;
        public bool opened;
    }

    [Serializable]
    public class SceneRenameRequest
    {
        public string name = "";
        public string path = "";
        public int sceneIndex = -1;
        public string newName = "";
    }

    [Serializable]
    public class SceneRenameResponse
    {
        public string oldPath;
        public string newPath;
        public string sceneName;
    }

    [Serializable]
    public class SceneRemoveMissingScriptsRequest
    {
        public string name = "";
        public string path = "";
        public int sceneIndex = -1;
    }

    [Serializable]
    public class SceneRemoveMissingScriptsResponse
    {
        public string sceneName;
        public string scenePath;
        public int removedCount;
        public int gameObjectCount;
    }
}
