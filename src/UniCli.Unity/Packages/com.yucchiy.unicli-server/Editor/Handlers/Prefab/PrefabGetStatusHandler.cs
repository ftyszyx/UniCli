using System.Threading;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;

namespace UniCli.Server.Editor.Handlers
{
    [Module("Assets")]
    public sealed class PrefabGetStatusHandler : CommandHandler<PrefabGetStatusRequest, PrefabGetStatusResponse>
    {
        public override string CommandName => "Prefab.GetStatus";
        public override string Description => "Get prefab instance status for a GameObject via PrefabUtility";

        protected override bool TryWriteFormatted(PrefabGetStatusResponse response, bool success, IFormatWriter writer)
        {
            if (success)
            {
                writer.WriteLine($"{response.gameObjectName}: status={response.status}, asset={response.assetPath}");
                if (response.isPrefabInstance)
                    writer.WriteLine($"  hasOverrides={response.hasOverrides}");
            }
            else
            {
                writer.WriteLine("Failed to get prefab status");
            }

            return true;
        }

        protected override ValueTask<PrefabGetStatusResponse> ExecuteAsync(PrefabGetStatusRequest request, CancellationToken cancellationToken)
        {
            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new PrefabGetStatusResponse());
            }

            var status = PrefabUtility.GetPrefabInstanceStatus(go);
            var isPrefabInstance = status != PrefabInstanceStatus.NotAPrefab;

            var statusString = status switch
            {
                PrefabInstanceStatus.Connected => "Connected",
                PrefabInstanceStatus.Disconnected => "Disconnected",
                PrefabInstanceStatus.MissingAsset => "MissingAsset",
                _ => "NotAPrefab"
            };

            var assetPath = isPrefabInstance
                ? PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(go)
                : "";

            var hasOverrides = isPrefabInstance && PrefabUtility.HasPrefabInstanceAnyOverrides(go, false);

            return new ValueTask<PrefabGetStatusResponse>(new PrefabGetStatusResponse
            {
                gameObjectName = go.name,
                status = statusString,
                assetPath = assetPath,
                hasOverrides = hasOverrides,
                isPrefabInstance = isPrefabInstance
            });
        }
    }

    [Module("Assets")]
    public sealed class PrefabOverrideStatusHandler : CommandHandler<PrefabOverrideStatusRequest, PrefabOverrideStatusResponse>
    {
        public override string CommandName => "Prefab.OverrideStatus";
        public override string Description => "Inspect override status of a prefab instance";

        protected override bool TryWriteFormatted(PrefabOverrideStatusResponse response, bool success, IFormatWriter writer)
        {
            if (success)
            {
                writer.WriteLine($"{response.gameObjectName}: hasOverrides={response.hasOverrides}, propertyModifications={response.propertyModificationCount}");
                writer.WriteLine($"  prefabRoot={response.prefabRootName}, asset={response.assetPath}");
            }
            else
            {
                writer.WriteLine("Failed to inspect prefab overrides");
            }

            return true;
        }

        protected override ValueTask<PrefabOverrideStatusResponse> ExecuteAsync(PrefabOverrideStatusRequest request, CancellationToken cancellationToken)
        {
            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new PrefabOverrideStatusResponse());
            }

            var status = PrefabUtility.GetPrefabInstanceStatus(go);
            if (status == PrefabInstanceStatus.NotAPrefab)
            {
                throw new CommandFailedException(
                    $"'{go.name}' is not a prefab instance",
                    new PrefabOverrideStatusResponse());
            }

            var root = PrefabUtility.GetNearestPrefabInstanceRoot(go);
            var assetPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(go);
            var hasOverrides = PrefabUtility.HasPrefabInstanceAnyOverrides(go, false);
            var modifications = PrefabUtility.GetPropertyModifications(go);

            return new ValueTask<PrefabOverrideStatusResponse>(new PrefabOverrideStatusResponse
            {
                gameObjectName = go.name,
                prefabRootName = root != null ? root.name : "",
                assetPath = assetPath,
                hasOverrides = hasOverrides,
                propertyModificationCount = modifications != null ? modifications.Length : 0
            });
        }
    }

    [Module("Assets")]
    public sealed class PrefabOverrideDetailsHandler : CommandHandler<PrefabOverrideDetailsRequest, PrefabOverrideDetailsResponse>
    {
        public override string CommandName => "Prefab.OverrideDetails";
        public override string Description => "Get property-level override details of a prefab instance";

        protected override bool TryWriteFormatted(PrefabOverrideDetailsResponse response, bool success, IFormatWriter writer)
        {
            if (success)
            {
                writer.WriteLine($"{response.gameObjectName}: {response.propertyModificationCount} property override(s)");
                if (response.modifications != null)
                {
                    foreach (var modification in response.modifications)
                        writer.WriteLine($"  {modification.propertyPath}: {modification.value}");
                }
            }
            else
            {
                writer.WriteLine("Failed to inspect prefab override details");
            }

            return true;
        }

        protected override ValueTask<PrefabOverrideDetailsResponse> ExecuteAsync(PrefabOverrideDetailsRequest request, CancellationToken cancellationToken)
        {
            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new PrefabOverrideDetailsResponse());
            }

            var status = PrefabUtility.GetPrefabInstanceStatus(go);
            if (status == PrefabInstanceStatus.NotAPrefab)
            {
                throw new CommandFailedException(
                    $"'{go.name}' is not a prefab instance",
                    new PrefabOverrideDetailsResponse());
            }

            var modifications = PrefabUtility.GetPropertyModifications(go) ?? Array.Empty<PropertyModification>();
            var mapped = modifications
                .Take(request.maxResults > 0 ? request.maxResults : modifications.Length)
                .Select(m => new PrefabPropertyModificationInfo
                {
                    targetObjectName = m.target != null ? m.target.name : "",
                    propertyPath = m.propertyPath ?? "",
                    value = m.value ?? "",
                    objectReferenceName = m.objectReference != null ? m.objectReference.name : ""
                })
                .ToArray();

            return new ValueTask<PrefabOverrideDetailsResponse>(new PrefabOverrideDetailsResponse
            {
                gameObjectName = go.name,
                assetPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(go),
                propertyModificationCount = modifications.Length,
                modifications = mapped
            });
        }
    }

    [Serializable]
    public class PrefabGetStatusRequest
    {
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class PrefabGetStatusResponse
    {
        public string gameObjectName;
        public string status;
        public string assetPath;
        public bool hasOverrides;
        public bool isPrefabInstance;
    }

    [Serializable]
    public class PrefabOverrideStatusRequest
    {
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class PrefabOverrideStatusResponse
    {
        public string gameObjectName;
        public string prefabRootName;
        public string assetPath;
        public bool hasOverrides;
        public int propertyModificationCount;
    }

    [Serializable]
    public class PrefabOverrideDetailsRequest
    {
        public int instanceId;
        public string path = "";
        public int maxResults = 100;
    }

    [Serializable]
    public class PrefabOverrideDetailsResponse
    {
        public string gameObjectName;
        public string assetPath;
        public int propertyModificationCount;
        public PrefabPropertyModificationInfo[] modifications;
    }

    [Serializable]
    public class PrefabPropertyModificationInfo
    {
        public string targetObjectName;
        public string propertyPath;
        public string value;
        public string objectReferenceName;
    }
}
