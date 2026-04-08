using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniCli.Protocol;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace UniCli.Server.Editor.Handlers
{
    [Module("Assets")]
    public sealed class AssetRefreshHandler : CommandHandler<Unit, AssetRefreshResponse>
    {
        public override string CommandName => "AssetDatabase.Refresh";
        public override string Description => "Refresh the Unity AssetDatabase";

        protected override ValueTask<AssetRefreshResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            AssetDatabase.Refresh();
            return new ValueTask<AssetRefreshResponse>(new AssetRefreshResponse
            {
                refreshed = true
            });
        }
    }

    [Module("Assets")]
    public sealed class AssetCopyHandler : CommandHandler<AssetCopyRequest, AssetCopyResponse>
    {
        public override string CommandName => "AssetDatabase.Copy";
        public override string Description => "Copy an asset or folder to a new project-relative path";

        protected override bool TryWriteFormatted(AssetCopyResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Copied asset from {response.sourcePath} to {response.destinationPath}");
            else
                writer.WriteLine("Failed to copy asset");

            return true;
        }

        protected override ValueTask<AssetCopyResponse> ExecuteAsync(AssetCopyRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.sourcePath))
                throw new ArgumentException("sourcePath is required");
            if (string.IsNullOrEmpty(request.destinationPath))
                throw new ArgumentException("destinationPath is required");

            var sourceExists = AssetDatabase.LoadMainAssetAtPath(request.sourcePath) != null || AssetDatabase.IsValidFolder(request.sourcePath);
            if (!sourceExists)
            {
                throw new CommandFailedException(
                    $"Source asset not found at \"{request.sourcePath}\"",
                    new AssetCopyResponse());
            }

            if (!AssetDatabase.CopyAsset(request.sourcePath, request.destinationPath))
            {
                throw new CommandFailedException(
                    $"Failed to copy asset from \"{request.sourcePath}\" to \"{request.destinationPath}\"",
                    new AssetCopyResponse());
            }

            AssetDatabase.Refresh();

            return new ValueTask<AssetCopyResponse>(new AssetCopyResponse
            {
                sourcePath = request.sourcePath,
                destinationPath = request.destinationPath
            });
        }
    }

    [Module("Assets")]
    public sealed class AssetMoveHandler : CommandHandler<AssetMoveRequest, AssetMoveResponse>
    {
        public override string CommandName => "AssetDatabase.Move";
        public override string Description => "Move or rename an asset or folder";

        protected override bool TryWriteFormatted(AssetMoveResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Moved asset from {response.sourcePath} to {response.destinationPath}");
            else
                writer.WriteLine("Failed to move asset");

            return true;
        }

        protected override ValueTask<AssetMoveResponse> ExecuteAsync(AssetMoveRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.sourcePath))
                throw new ArgumentException("sourcePath is required");
            if (string.IsNullOrEmpty(request.destinationPath))
                throw new ArgumentException("destinationPath is required");

            var sourceExists = AssetDatabase.LoadMainAssetAtPath(request.sourcePath) != null || AssetDatabase.IsValidFolder(request.sourcePath);
            if (!sourceExists)
            {
                throw new CommandFailedException(
                    $"Source asset not found at \"{request.sourcePath}\"",
                    new AssetMoveResponse());
            }

            var error = AssetDatabase.MoveAsset(request.sourcePath, request.destinationPath);
            if (!string.IsNullOrEmpty(error))
            {
                throw new CommandFailedException(
                    $"Failed to move asset: {error}",
                    new AssetMoveResponse());
            }

            AssetDatabase.Refresh();

            return new ValueTask<AssetMoveResponse>(new AssetMoveResponse
            {
                sourcePath = request.sourcePath,
                destinationPath = request.destinationPath
            });
        }
    }

    [Module("Assets")]
    public sealed class AssetCreateFolderHandler : CommandHandler<AssetCreateFolderRequest, AssetCreateFolderResponse>
    {
        public override string CommandName => "AssetDatabase.CreateFolder";
        public override string Description => "Create a folder under an existing Unity project folder";

        protected override bool TryWriteFormatted(AssetCreateFolderResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Created folder {response.path}");
            else
                writer.WriteLine("Failed to create folder");

            return true;
        }

        protected override ValueTask<AssetCreateFolderResponse> ExecuteAsync(AssetCreateFolderRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.parentFolder))
                throw new ArgumentException("parentFolder is required");
            if (string.IsNullOrEmpty(request.folderName))
                throw new ArgumentException("folderName is required");

            if (!AssetDatabase.IsValidFolder(request.parentFolder))
            {
                throw new CommandFailedException(
                    $"Parent folder not found at \"{request.parentFolder}\"",
                    new AssetCreateFolderResponse());
            }

            var guid = AssetDatabase.CreateFolder(request.parentFolder, request.folderName);
            if (string.IsNullOrEmpty(guid))
            {
                throw new CommandFailedException(
                    $"Failed to create folder \"{request.folderName}\" under \"{request.parentFolder}\"",
                    new AssetCreateFolderResponse());
            }

            var path = AssetDatabase.GUIDToAssetPath(guid);
            return new ValueTask<AssetCreateFolderResponse>(new AssetCreateFolderResponse
            {
                guid = guid,
                path = path
            });
        }
    }

    [Module("Assets")]
    public sealed class AssetRenameHandler : CommandHandler<AssetRenameRequest, AssetRenameResponse>
    {
        public override string CommandName => "AssetDatabase.Rename";
        public override string Description => "Rename an asset or folder while keeping it in the same parent folder";

        protected override bool TryWriteFormatted(AssetRenameResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Renamed asset from {response.oldPath} to {response.newPath}");
            else
                writer.WriteLine("Failed to rename asset");

            return true;
        }

        protected override ValueTask<AssetRenameResponse> ExecuteAsync(AssetRenameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");
            if (string.IsNullOrEmpty(request.newName))
                throw new ArgumentException("newName is required");

            var sourceExists = AssetDatabase.LoadMainAssetAtPath(request.path) != null || AssetDatabase.IsValidFolder(request.path);
            if (!sourceExists)
            {
                throw new CommandFailedException(
                    $"Asset not found at \"{request.path}\"",
                    new AssetRenameResponse());
            }

            var error = AssetDatabase.RenameAsset(request.path, request.newName);
            if (!string.IsNullOrEmpty(error))
            {
                throw new CommandFailedException(
                    $"Failed to rename asset: {error}",
                    new AssetRenameResponse());
            }

            AssetDatabase.Refresh();

            var parentPath = System.IO.Path.GetDirectoryName(request.path)?.Replace("\\", "/") ?? "";
            var newPath = string.IsNullOrEmpty(parentPath)
                ? request.newName
                : $"{parentPath}/{request.newName}";

            var guid = AssetDatabase.AssetPathToGUID(newPath);
            if (string.IsNullOrEmpty(guid) && AssetDatabase.IsValidFolder(newPath))
                guid = AssetDatabase.AssetPathToGUID(newPath);

            return new ValueTask<AssetRenameResponse>(new AssetRenameResponse
            {
                oldPath = request.path,
                newPath = newPath,
                guid = guid ?? ""
            });
        }
    }

    [Module("Assets")]
    public sealed class AssetDuplicateHandler : CommandHandler<AssetDuplicateRequest, AssetDuplicateResponse>
    {
        public override string CommandName => "AssetDatabase.Duplicate";
        public override string Description => "Duplicate an asset or folder, optionally choosing the destination path";

        protected override bool TryWriteFormatted(AssetDuplicateResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Duplicated asset from {response.sourcePath} to {response.destinationPath}");
            else
                writer.WriteLine("Failed to duplicate asset");

            return true;
        }

        protected override ValueTask<AssetDuplicateResponse> ExecuteAsync(AssetDuplicateRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.sourcePath))
                throw new ArgumentException("sourcePath is required");

            var sourceExists = AssetDatabase.LoadMainAssetAtPath(request.sourcePath) != null || AssetDatabase.IsValidFolder(request.sourcePath);
            if (!sourceExists)
            {
                throw new CommandFailedException(
                    $"Source asset not found at \"{request.sourcePath}\"",
                    new AssetDuplicateResponse());
            }

            var destinationPath = string.IsNullOrEmpty(request.destinationPath)
                ? AssetDatabase.GenerateUniqueAssetPath(request.sourcePath)
                : request.destinationPath;

            if (!AssetDatabase.CopyAsset(request.sourcePath, destinationPath))
            {
                throw new CommandFailedException(
                    $"Failed to duplicate asset from \"{request.sourcePath}\" to \"{destinationPath}\"",
                    new AssetDuplicateResponse());
            }

            AssetDatabase.Refresh();

            return new ValueTask<AssetDuplicateResponse>(new AssetDuplicateResponse
            {
                sourcePath = request.sourcePath,
                destinationPath = destinationPath,
                guid = AssetDatabase.AssetPathToGUID(destinationPath) ?? ""
            });
        }
    }

    [Module("Assets")]
    public sealed class CreateTextAssetHandler : CommandHandler<CreateTextAssetRequest, CreateTextAssetResponse>
    {
        public override string CommandName => "AssetDatabase.CreateTextAsset";
        public override string Description => "Create or overwrite a text-based asset file and import it into Unity";

        protected override bool TryWriteFormatted(CreateTextAssetResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Wrote text asset to {response.path}");
            else
                writer.WriteLine("Failed to create text asset");

            return true;
        }

        protected override ValueTask<CreateTextAssetResponse> ExecuteAsync(CreateTextAssetRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");

            var absolutePath = ResolvePath(request.path);
            var directory = Path.GetDirectoryName(absolutePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var finalContent = request.normalizeLineEndings
                ? (request.content ?? string.Empty).Replace("\r\n", "\n").Replace("\n", Environment.NewLine)
                : request.content ?? string.Empty;

            File.WriteAllText(absolutePath, finalContent);
            AssetDatabase.ImportAsset(request.path, ImportAssetOptions.ForceUpdate);
            AssetDatabase.Refresh();

            return new ValueTask<CreateTextAssetResponse>(new CreateTextAssetResponse
            {
                path = request.path,
                bytes = File.Exists(absolutePath) ? new FileInfo(absolutePath).Length : 0,
                imported = true
            });
        }
    }

    [Module("Assets")]
    public sealed class ReadTextAssetHandler : CommandHandler<ReadTextAssetRequest, ReadTextAssetResponse>
    {
        public override string CommandName => "AssetDatabase.ReadTextAsset";
        public override string Description => "Read text content from a project asset path";

        protected override bool TryWriteFormatted(ReadTextAssetResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Read {response.path} ({response.bytes} bytes)");
            else
                writer.WriteLine("Failed to read text asset");

            return true;
        }

        protected override ValueTask<ReadTextAssetResponse> ExecuteAsync(ReadTextAssetRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");

            var absolutePath = ResolvePath(request.path);
            if (!File.Exists(absolutePath))
            {
                throw new CommandFailedException(
                    $"Text asset not found at \"{request.path}\"",
                    new ReadTextAssetResponse());
            }

            var fullContent = File.ReadAllText(absolutePath);
            var truncated = request.maxChars > 0 && fullContent.Length > request.maxChars;
            var content = truncated
                ? fullContent.Substring(0, request.maxChars)
                : fullContent;
            var bytes = new FileInfo(absolutePath).Length;

            return new ValueTask<ReadTextAssetResponse>(new ReadTextAssetResponse
            {
                path = request.path,
                content = content,
                bytes = bytes,
                truncated = truncated
            });
        }
    }

    [Module("Assets")]
    public sealed class WriteTextAssetHandler : CommandHandler<WriteTextAssetRequest, WriteTextAssetResponse>
    {
        public override string CommandName => "AssetDatabase.WriteTextAsset";
        public override string Description => "Write text content to an existing or new project asset path";

        protected override bool TryWriteFormatted(WriteTextAssetResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Wrote text asset to {response.path}");
            else
                writer.WriteLine("Failed to write text asset");

            return true;
        }

        protected override ValueTask<WriteTextAssetResponse> ExecuteAsync(WriteTextAssetRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");

            var absolutePath = ResolvePath(request.path);
            var directory = Path.GetDirectoryName(absolutePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            if (!request.createIfMissing && !File.Exists(absolutePath))
            {
                throw new CommandFailedException(
                    $"Text asset not found at \"{request.path}\"",
                    new WriteTextAssetResponse());
            }

            var finalContent = request.normalizeLineEndings
                ? (request.content ?? string.Empty).Replace("\r\n", "\n").Replace("\n", Environment.NewLine)
                : request.content ?? string.Empty;

            File.WriteAllText(absolutePath, finalContent);
            AssetDatabase.ImportAsset(request.path, ImportAssetOptions.ForceUpdate);
            AssetDatabase.Refresh();

            return new ValueTask<WriteTextAssetResponse>(new WriteTextAssetResponse
            {
                path = request.path,
                bytes = File.Exists(absolutePath) ? new FileInfo(absolutePath).Length : 0,
                imported = true,
                created = request.createIfMissing && File.Exists(absolutePath)
            });
        }
    }

    [Module("Assets")]
    public sealed class CreateMaterialAssetHandler : CommandHandler<CreateMaterialAssetRequest, CreateMaterialAssetResponse>
    {
        public override string CommandName => "AssetDatabase.CreateMaterialAsset";
        public override string Description => "Create a material asset at the given path";

        protected override bool TryWriteFormatted(CreateMaterialAssetResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Created material asset at {response.path} (shader: {response.shaderName})");
            else
                writer.WriteLine("Failed to create material asset");

            return true;
        }

        protected override ValueTask<CreateMaterialAssetResponse> ExecuteAsync(CreateMaterialAssetRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");
            if (!request.path.EndsWith(".mat", StringComparison.OrdinalIgnoreCase))
                throw new CommandFailedException($"path must end with .mat (got \"{request.path}\")", new CreateMaterialAssetResponse());

            var shader = AssetManagementHelper.ResolveShader(request.shader);
            if (shader == null)
            {
                throw new CommandFailedException(
                    string.IsNullOrEmpty(request.shader) ? "No default shader found" : $"Shader not found: \"{request.shader}\"",
                    new CreateMaterialAssetResponse());
            }

            var absolutePath = ResolvePath(request.path);
            var directory = Path.GetDirectoryName(absolutePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var material = new Material(shader);
            AssetDatabase.CreateAsset(material, request.path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return new ValueTask<CreateMaterialAssetResponse>(new CreateMaterialAssetResponse
            {
                path = request.path,
                guid = AssetDatabase.AssetPathToGUID(request.path),
                shaderName = shader.name
            });
        }
    }

    [Module("Assets")]
    public sealed class CreateScriptableObjectAssetHandler : CommandHandler<CreateScriptableObjectAssetRequest, CreateScriptableObjectAssetResponse>
    {
        public override string CommandName => "AssetDatabase.CreateScriptableObjectAsset";
        public override string Description => "Create a ScriptableObject asset by type name";

        protected override bool TryWriteFormatted(CreateScriptableObjectAssetResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Created ScriptableObject asset at {response.path} ({response.typeName})");
            else
                writer.WriteLine("Failed to create ScriptableObject asset");

            return true;
        }

        protected override ValueTask<CreateScriptableObjectAssetResponse> ExecuteAsync(CreateScriptableObjectAssetRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.path))
                throw new ArgumentException("path is required");
            if (string.IsNullOrEmpty(request.typeName))
                throw new ArgumentException("typeName is required");
            if (!request.path.EndsWith(".asset", StringComparison.OrdinalIgnoreCase))
                throw new CommandFailedException($"path must end with .asset (got \"{request.path}\")", new CreateScriptableObjectAssetResponse());

            var type = AssetManagementHelper.FindScriptableObjectType(request.typeName);
            if (type == null)
            {
                throw new CommandFailedException(
                    $"ScriptableObject type not found: \"{request.typeName}\"",
                    new CreateScriptableObjectAssetResponse());
            }

            var absolutePath = ResolvePath(request.path);
            var directory = Path.GetDirectoryName(absolutePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            var asset = ScriptableObject.CreateInstance(type);
            if (asset == null)
            {
                throw new CommandFailedException(
                    $"Failed to instantiate ScriptableObject type \"{type.FullName}\"",
                    new CreateScriptableObjectAssetResponse());
            }

            AssetDatabase.CreateAsset(asset, request.path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            return new ValueTask<CreateScriptableObjectAssetResponse>(new CreateScriptableObjectAssetResponse
            {
                path = request.path,
                guid = AssetDatabase.AssetPathToGUID(request.path),
                typeName = type.FullName
            });
        }
    }

    [Serializable]
    public class AssetRefreshResponse
    {
        public bool refreshed;
    }

    [Serializable]
    public class AssetCopyRequest
    {
        public string sourcePath = "";
        public string destinationPath = "";
    }

    [Serializable]
    public class AssetCopyResponse
    {
        public string sourcePath;
        public string destinationPath;
    }

    [Serializable]
    public class AssetMoveRequest
    {
        public string sourcePath = "";
        public string destinationPath = "";
    }

    [Serializable]
    public class AssetMoveResponse
    {
        public string sourcePath;
        public string destinationPath;
    }

    [Serializable]
    public class AssetCreateFolderRequest
    {
        public string parentFolder = "";
        public string folderName = "";
    }

    [Serializable]
    public class AssetCreateFolderResponse
    {
        public string guid;
        public string path;
    }

    [Serializable]
    public class AssetRenameRequest
    {
        public string path = "";
        public string newName = "";
    }

    [Serializable]
    public class AssetRenameResponse
    {
        public string oldPath;
        public string newPath;
        public string guid;
    }

    [Serializable]
    public class AssetDuplicateRequest
    {
        public string sourcePath = "";
        public string destinationPath = "";
    }

    [Serializable]
    public class AssetDuplicateResponse
    {
        public string sourcePath;
        public string destinationPath;
        public string guid;
    }

    [Serializable]
    public class CreateTextAssetRequest
    {
        public string path = "";
        public string content = "";
        public bool normalizeLineEndings = true;
    }

    [Serializable]
    public class CreateTextAssetResponse
    {
        public string path;
        public long bytes;
        public bool imported;
    }

    [Serializable]
    public class ReadTextAssetRequest
    {
        public string path = "";
        public int maxChars;
    }

    [Serializable]
    public class ReadTextAssetResponse
    {
        public string path;
        public string content;
        public long bytes;
        public bool truncated;
    }

    [Serializable]
    public class WriteTextAssetRequest
    {
        public string path = "";
        public string content = "";
        public bool normalizeLineEndings = true;
        public bool createIfMissing = true;
    }

    [Serializable]
    public class WriteTextAssetResponse
    {
        public string path;
        public long bytes;
        public bool imported;
        public bool created;
    }

    [Serializable]
    public class CreateMaterialAssetRequest
    {
        public string path = "";
        public string shader = "";
    }

    [Serializable]
    public class CreateMaterialAssetResponse
    {
        public string path;
        public string guid;
        public string shaderName;
    }

    [Serializable]
    public class CreateScriptableObjectAssetRequest
    {
        public string path = "";
        public string typeName = "";
    }

    [Serializable]
    public class CreateScriptableObjectAssetResponse
    {
        public string path;
        public string guid;
        public string typeName;
    }

    internal static class AssetManagementHelper
    {
        public static Shader ResolveShader(string shaderName)
        {
            if (!string.IsNullOrEmpty(shaderName))
                return Shader.Find(shaderName);

            var pipeline = GraphicsSettings.currentRenderPipeline;
            if (pipeline != null && pipeline.defaultShader != null)
                return pipeline.defaultShader;

            return Shader.Find("Standard");
        }

        public static Type FindScriptableObjectType(string typeName)
        {
            var types = TypeCache.GetTypesDerivedFrom<ScriptableObject>()
                .Where(t => !t.IsAbstract)
                .ToArray();

            var exact = types.FirstOrDefault(t => t.FullName == typeName);
            if (exact != null) return exact;

            var shortMatch = types.FirstOrDefault(t => t.Name == typeName);
            if (shortMatch != null) return shortMatch;

            return types.FirstOrDefault(t =>
                t.Name.StartsWith(typeName, StringComparison.OrdinalIgnoreCase) ||
                t.FullName.EndsWith("." + typeName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
