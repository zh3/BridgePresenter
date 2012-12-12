using System;
using BridgePresenter;

namespace BridgePresenterTest
{
    public class FakeShowWindow : IJointShowWindow
    {
        public event EventHandler<EventArgs> CloseWindowRequested;
        public event EventHandler<EventArgs> ShowRequested;
        public event EventHandler<EventArgs> CreateJointShowRequested;
        public event EventHandler<ShowEventArgs> EditShowRequested;
        public event EventHandler<ShowEventArgs> RemoveShowRequested;
        public event EventHandler<ShowEventArgs> CopyShowRequested;

        public bool Closed { get; private set; }
        public string SelectedItemString;

        public FakeShowWindow()
        {
            Closed = false;
        }

        public void OnCloseRequested()
        {
            EventHandler<EventArgs> closeRequested = CloseWindowRequested;

            if (closeRequested != null)
                closeRequested(this, new EventArgs());
        }

        public void OnShowRequested()
        {
            EventHandler<EventArgs> showRequested = ShowRequested;

            if (showRequested != null)
                showRequested(this, new EventArgs());
        }

        public void OnCreateJointShowRequested()
        {
            EventHandler<EventArgs> createJointShowRequested = CreateJointShowRequested;

            if (createJointShowRequested != null)
                createJointShowRequested(this, new EventArgs());
        }

        public void OnEditShowRequested()
        {
            EventHandler<ShowEventArgs> editShowRequested = EditShowRequested;

            if (editShowRequested != null)
                editShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        public void OnRemoveShowRequested()
        {
            EventHandler<ShowEventArgs> removeShowRequested = RemoveShowRequested;

            if (removeShowRequested != null)
                removeShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        public void OnCopyShowRequested()
        {
            EventHandler<ShowEventArgs> copyShowRequested = CopyShowRequested;

            if (copyShowRequested != null)
                copyShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        public void CloseWindow()
        {
            Closed = true;
        }
    }
}
