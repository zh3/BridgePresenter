using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public abstract class BaseShowWindow : Form, IJointShowWindow
    {
        protected IJointShows Model;

        public abstract IJointShow SelectedShow { get; }
        public event EventHandler<EventArgs> CloseWindowRequested;
        public event EventHandler<EventArgs> ShowRequested;
        public event EventHandler<EventArgs> CreateJointShowRequested;
        public event EventHandler<ShowEventArgs> EditShowRequested;
        public event EventHandler<ShowEventArgs> RemoveShowRequested;
        public event EventHandler<ShowEventArgs> CopyShowRequested;

        protected BaseShowWindow(IJointShows model)
        {
            Model = model;
        }

        public void OnCloseWindowRequested()
        {
            EventHandler<EventArgs> closeWindowRequested = CloseWindowRequested;

            if (closeWindowRequested != null)
                closeWindowRequested(this, new EventArgs());
        }

        protected void OnShowRequested()
        {
            EventHandler<EventArgs> showRequested = ShowRequested;

            if (showRequested != null)
                showRequested(this, new EventArgs());
        }

        protected void OnCreateJointShowRequested()
        {
            EventHandler<EventArgs> createJointShowRequested = CreateJointShowRequested;

            if (createJointShowRequested != null)
                createJointShowRequested(this, new EventArgs());
        }

        protected void OnEditShowRequested()
        {
            EventHandler<ShowEventArgs> editShowRequested = EditShowRequested;

            if (editShowRequested != null)
                editShowRequested(this, new ShowEventArgs(SelectedShow));
        }

        protected void OnRemoveShowRequested()
        {
            EventHandler<ShowEventArgs> removeShowRequested = RemoveShowRequested;

            if (removeShowRequested != null)
                removeShowRequested(this, new ShowEventArgs(SelectedShow));
        }

        protected void OnCopyShowRequested()
        {
            EventHandler<ShowEventArgs> copyShowRequested = CopyShowRequested;

            if (copyShowRequested != null)
                copyShowRequested(this, new ShowEventArgs(SelectedShow));
        }

        public abstract void CloseWindow();
        public abstract void ShowWindow();
    }
}
