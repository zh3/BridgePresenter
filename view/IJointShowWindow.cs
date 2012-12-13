using System;

namespace BridgePresenter.View
{
    public interface IJointShowWindow
    {
        event EventHandler<EventArgs> CloseWindowRequested;
        event EventHandler<EventArgs> ShowRequested;

        event EventHandler<EventArgs> CreateJointShowRequested;
        event EventHandler<ShowEventArgs> EditShowRequested;
        event EventHandler<ShowEventArgs> RemoveShowRequested;
        event EventHandler<ShowEventArgs> CopyShowRequested;

        void CloseWindow();
        void ShowWindow();
    }
}
