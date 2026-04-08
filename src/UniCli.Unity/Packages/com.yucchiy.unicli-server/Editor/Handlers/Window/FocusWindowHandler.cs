using System;
using System.Threading;
using System.Threading.Tasks;
using UniCli.Protocol;
using UnityEditor;
using UnityEngine;

namespace UniCli.Server.Editor.Handlers
{
    public sealed class FocusWindowHandler : CommandHandler<FocusWindowRequest, FocusWindowResponse>
    {
        public override string CommandName => "Window.Focus";
        public override string Description => "Focus an already-open EditorWindow by type name";

        protected override bool TryWriteFormatted(FocusWindowResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine($"Focused: {response.typeName}");
            return true;
        }

        protected override ValueTask<FocusWindowResponse> ExecuteAsync(FocusWindowRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.typeName))
            {
                throw new CommandFailedException(
                    "typeName is required",
                    new FocusWindowResponse());
            }

            var type = WindowResolver.FindWindowType(request.typeName);
            if (type == null)
            {
                throw new CommandFailedException(
                    $"EditorWindow type '{request.typeName}' not found. Use Window.List to see available types.",
                    new FocusWindowResponse());
            }

            var windows = Resources.FindObjectsOfTypeAll(type);
            if (windows == null || windows.Length == 0)
            {
                throw new CommandFailedException(
                    $"No open window of type '{type.FullName}'. Use Window.Open to open it first.",
                    new FocusWindowResponse { typeName = type.FullName });
            }

            var window = (EditorWindow)windows[0];
            window.Focus();

            return new ValueTask<FocusWindowResponse>(new FocusWindowResponse { typeName = type.FullName });
        }
    }

    public sealed class FocusProjectWindowHandler : CommandHandler<Unit, FocusWindowResponse>
    {
        public override string CommandName => "Window.FocusProject";
        public override string Description => "Focus the Unity Project window";

        protected override bool TryWriteFormatted(FocusWindowResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine("Focused: UnityEditor.ProjectBrowser");
            return true;
        }

        protected override ValueTask<FocusWindowResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            var type = WindowResolver.FindWindowType("UnityEditor.ProjectBrowser");
            if (type != null)
            {
                EditorWindow.GetWindow(type).Focus();
                return new ValueTask<FocusWindowResponse>(new FocusWindowResponse { typeName = type.FullName });
            }

            EditorUtility.FocusProjectWindow();
            return new ValueTask<FocusWindowResponse>(new FocusWindowResponse { typeName = "UnityEditor.ProjectBrowser" });
        }
    }

    public sealed class FocusHierarchyWindowHandler : CommandHandler<Unit, FocusWindowResponse>
    {
        public override string CommandName => "Window.FocusHierarchy";
        public override string Description => "Focus the Unity Hierarchy window";

        protected override bool TryWriteFormatted(FocusWindowResponse response, bool success, IFormatWriter writer)
        {
            if (success)
                writer.WriteLine("Focused: UnityEditor.SceneHierarchyWindow");
            return true;
        }

        protected override ValueTask<FocusWindowResponse> ExecuteAsync(Unit request, CancellationToken cancellationToken)
        {
            var type = WindowResolver.FindWindowType("UnityEditor.SceneHierarchyWindow");
            if (type == null)
            {
                throw new CommandFailedException(
                    "UnityEditor.SceneHierarchyWindow type not found.",
                    new FocusWindowResponse());
            }

            EditorWindow.GetWindow(type).Focus();
            return new ValueTask<FocusWindowResponse>(new FocusWindowResponse { typeName = type.FullName });
        }
    }

    [Serializable]
    public class FocusWindowRequest
    {
        public string typeName;
    }

    [Serializable]
    public class FocusWindowResponse
    {
        public string typeName;
    }
}
