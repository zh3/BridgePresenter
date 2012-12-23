using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public abstract class BaseJointShowWindow : Form, IJointShowWindow
    {
        protected IJointShows Model;

        public abstract IJointShow SelectedShow { get; }
        public event EventHandler<EventArgs> CloseWindowRequested;
        public event EventHandler<EventArgs> ShowRequested;
        public event EventHandler<EventArgs> CreateJointShowRequested;
        public event EventHandler<JointShowEventArgs> EditShowRequested;
        public event EventHandler<JointShowEventArgs> RemoveShowRequested;
        public event EventHandler<JointShowEventArgs> CopyShowRequested;

        protected BaseJointShowWindow(IJointShows model)
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
            EventHandler<JointShowEventArgs> editShowRequested = EditShowRequested;

            if (editShowRequested != null)
                editShowRequested(this, new JointShowEventArgs(SelectedShow));
        }

        protected void OnRemoveShowRequested()
        {
            EventHandler<JointShowEventArgs> removeShowRequested = RemoveShowRequested;

            if (removeShowRequested != null)
                removeShowRequested(this, new JointShowEventArgs(SelectedShow));
        }

        protected void OnCopyShowRequested()
        {
            EventHandler<JointShowEventArgs> copyShowRequested = CopyShowRequested;

            if (copyShowRequested != null)
                copyShowRequested(this, new JointShowEventArgs(SelectedShow));
        }

        public abstract void CloseWindow();
        public abstract void ShowWindow();
    }
}
