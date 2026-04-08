using System.Threading;
using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace UniCli.Server.Editor.Handlers
{
    [Module("GameObject")]
    public sealed class RemoveComponentHandler : CommandHandler<RemoveComponentRequest, RemoveComponentResponse>
    {
        public override string CommandName => "GameObject.RemoveComponent";
        public override string Description => "Remove a component from a GameObject by instance ID";

        protected override bool TryWriteFormatted(RemoveComponentResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Removed {response.typeName} from {response.gameObjectName}");
            else
                writer.WriteLine("Failed to remove component");

            return true;
        }

        protected override ValueTask<RemoveComponentResponse> ExecuteAsync(RemoveComponentRequest request, CancellationToken cancellationToken)
        {
            if (request.componentInstanceId == 0)
                throw new ArgumentException("componentInstanceId is required");

            var obj = EditorUtility.InstanceIDToObject(request.componentInstanceId);
            if (obj is not Component component)
            {
                throw new CommandFailedException(
                    $"Component not found for instanceId={request.componentInstanceId}",
                    new RemoveComponentResponse());
            }

            if (component is Transform)
            {
                throw new CommandFailedException(
                    "Cannot remove Transform component",
                    new RemoveComponentResponse());
            }

            var goName = component.gameObject.name;
            var typeName = component.GetType().FullName;
            var instanceId = component.GetInstanceID();

            Undo.DestroyObjectImmediate(component);

            return new ValueTask<RemoveComponentResponse>(new RemoveComponentResponse
            {
                gameObjectName = goName,
                typeName = typeName,
                componentInstanceId = instanceId
            });
        }
    }

    [Module("GameObject")]
    public sealed class RemoveComponentByTypeHandler : CommandHandler<RemoveComponentByTypeRequest, RemoveComponentByTypeResponse>
    {
        public override string CommandName => "GameObject.RemoveComponentByType";
        public override string Description => "Remove a component from a GameObject by component type name";

        protected override bool TryWriteFormatted(RemoveComponentByTypeResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Removed {response.typeName} from {response.gameObjectName}");
            else
                writer.WriteLine("Failed to remove component by type");

            return true;
        }

        protected override ValueTask<RemoveComponentByTypeResponse> ExecuteAsync(RemoveComponentByTypeRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.typeName))
                throw new ArgumentException("typeName is required");

            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new RemoveComponentByTypeResponse());
            }

            var components = go.GetComponents<Component>();
            Component matched = null;
            foreach (var component in components)
            {
                if (component == null) continue;
                var type = component.GetType();
                if (type.FullName == request.typeName || type.Name == request.typeName)
                {
                    matched = component;
                    break;
                }
            }

            if (matched == null)
            {
                throw new CommandFailedException(
                    $"Component type '{request.typeName}' not found on '{go.name}'",
                    new RemoveComponentByTypeResponse());
            }

            if (matched is Transform)
            {
                throw new CommandFailedException(
                    "Cannot remove Transform component",
                    new RemoveComponentByTypeResponse());
            }

            var typeName = matched.GetType().FullName;
            var componentInstanceId = matched.GetInstanceID();
            Undo.DestroyObjectImmediate(matched);

            return new ValueTask<RemoveComponentByTypeResponse>(new RemoveComponentByTypeResponse
            {
                gameObjectName = go.name,
                typeName = typeName,
                componentInstanceId = componentInstanceId
            });
        }
    }

    [Serializable]
    public class RemoveComponentRequest
    {
        public int componentInstanceId;
    }

    [Serializable]
    public class RemoveComponentResponse
    {
        public string gameObjectName;
        public string typeName;
        public int componentInstanceId;
    }

    [Serializable]
    public class RemoveComponentByTypeRequest
    {
        public int instanceId;
        public string path = "";
        public string typeName = "";
    }

    [Serializable]
    public class RemoveComponentByTypeResponse
    {
        public string gameObjectName;
        public string typeName;
        public int componentInstanceId;
    }
}
