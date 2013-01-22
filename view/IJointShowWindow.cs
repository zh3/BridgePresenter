using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public interface IJointShowWindow
    {
        event EventHandler<EventArgs> CloseWindowRequested;
        event EventHandler<EventArgs> ShowRequested;
        event EventHandler<EventArgs> GenerateRequested;

        event EventHandler<EventArgs> CreateJointShowRequested;
        event EventHandler<JointShowEventArgs> EditShowRequested;
        event EventHandler<JointShowEventArgs> RemoveShowRequested;
        event EventHandler<JointShowEventArgs> CopyShowRequested;
        IJointShow SelectedShow { get; }

        void CloseWindow();
        void ShowWindow();
    }
}
