using System;

namespace BridgePresenter.View
{
    public interface IJointShowEditorWindow
    {
        event EventHandler<EventArgs> AcceptRequested;
        event EventHandler<EventArgs> CancelRequested;
        event EventHandler<EventArgs> ImportRequested;
        event EventHandler<PresentationEventArgs> AddToShowRequested;
        event EventHandler<PresentationEventArgs> RemoveFromShowRequested;
        event EventHandler<PresentationEventArgs> DeletePresentationRequested;
        event EventHandler<PresentationEventArgs> MovePresentationUpRequested;
        event EventHandler<PresentationEventArgs> MovePresentationDownRequested;

        void ShowWindow();
    }
}
