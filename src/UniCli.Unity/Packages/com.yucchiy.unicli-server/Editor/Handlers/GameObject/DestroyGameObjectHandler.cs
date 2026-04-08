using System.Threading;
using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace UniCli.Server.Editor.Handlers
{
    [Module("GameObject")]
    public sealed class DestroyGameObjectHandler : CommandHandler<DestroyGameObjectRequest, DestroyGameObjectResponse>
    {
        public override string CommandName => "GameObject.Destroy";
        public override string Description => "Destroy a GameObject from the scene";

        protected override bool TryWriteFormatted(DestroyGameObjectResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Destroyed GameObject \"{response.name}\" (instanceId={response.instanceId})");
            else
                writer.WriteLine("Failed to destroy GameObject");

            return true;
        }

        protected override ValueTask<DestroyGameObjectResponse> ExecuteAsync(DestroyGameObjectRequest request, CancellationToken cancellationToken)
        {
            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new DestroyGameObjectResponse());
            }

            var name = go.name;
            var instanceId = go.GetInstanceID();

            Undo.DestroyObjectImmediate(go);

            return new ValueTask<DestroyGameObjectResponse>(new DestroyGameObjectResponse
            {
                name = name,
                instanceId = instanceId
            });
        }
    }

    [Module("GameObject")]
    public sealed class RemoveMissingScriptsHandler : CommandHandler<RemoveMissingScriptsRequest, RemoveMissingScriptsResponse>
    {
        public override string CommandName => "GameObject.RemoveMissingScripts";
        public override string Description => "Remove missing script references from a GameObject";

        protected override bool TryWriteFormatted(RemoveMissingScriptsResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Removed {response.removedCount} missing script(s) from {response.name}");
            else
                writer.WriteLine("Failed to remove missing scripts");

            return true;
        }

        protected override ValueTask<RemoveMissingScriptsResponse> ExecuteAsync(RemoveMissingScriptsRequest request, CancellationToken cancellationToken)
        {
            var go = GameObjectResolver.ResolveByIdOrPath(request.instanceId, request.path);
            if (go == null)
            {
                throw new CommandFailedException(
                    $"GameObject not found (instanceId={request.instanceId}, path=\"{request.path}\")",
                    new RemoveMissingScriptsResponse());
            }

            Undo.RegisterCompleteObjectUndo(go, "Remove Missing Scripts");
            var removedCount = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);

            return new ValueTask<RemoveMissingScriptsResponse>(new RemoveMissingScriptsResponse
            {
                name = go.name,
                instanceId = go.GetInstanceID(),
                removedCount = removedCount
            });
        }
    }

    [Serializable]
    public class DestroyGameObjectRequest
    {
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class DestroyGameObjectResponse
    {
        public string name;
        public int instanceId;
    }

    [Serializable]
    public class RemoveMissingScriptsRequest
    {
        public int instanceId;
        public string path = "";
    }

    [Serializable]
    public class RemoveMissingScriptsResponse
    {
        public string name;
        public int instanceId;
        public int removedCount;
    }
}
