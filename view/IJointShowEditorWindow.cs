using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public interface IJointShowEditorWindow
    {
        string ShowName { get; }

        event EventHandler<EventArgs> AcceptRequested;
        event EventHandler<EventArgs> CancelRequested;
        event EventHandler<EventArgs> ImportRequested;
        event EventHandler<ShowEventArgs> AddToShowRequested;
        event EventHandler<ShowEventArgs> RemoveFromShowRequested;
        event EventHandler<ShowEventArgs> DeletePresentationRequested;
        event EventHandler<ShowEventArgs> MovePresentationUpRequested;
        event EventHandler<ShowEventArgs> MovePresentationDownRequested;
        IShow ImportedSelectedShow { get; }
        int ShowOrderSelectedShowIndex { get; }

        void ShowWindow();
        void CloseWindow();
        string[] PromptForPresentationsToImport();
    }
}
