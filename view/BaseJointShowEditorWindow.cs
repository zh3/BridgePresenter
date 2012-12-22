using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public abstract class BaseJointShowEditorWindow : Form, IJointShowEditorWindow
    {
        private IJointShow _showModel;

        public abstract string ShowName { get; }
        public event EventHandler<EventArgs> AcceptRequested;
        public event EventHandler<EventArgs> CancelRequested;
        public event EventHandler<EventArgs> ImportRequested;
        public event EventHandler<PresentationEventArgs> AddToShowRequested;
        public event EventHandler<PresentationEventArgs> RemoveFromShowRequested;
        public event EventHandler<PresentationEventArgs> DeletePresentationRequested;
        public event EventHandler<PresentationEventArgs> MovePresentationUpRequested;
        public event EventHandler<PresentationEventArgs> MovePresentationDownRequested;

        protected BaseJointShowEditorWindow(IJointShow showModel)
        {
            _showModel = showModel;
        }

        protected void OnAcceptRequested()
        {
            EventHandler<EventArgs> acceptRequested = AcceptRequested;

            if (acceptRequested != null)
                acceptRequested(this, new EventArgs());
        }

        protected void OnCancelRequested()
        {
            EventHandler<EventArgs> cancelRequested = CancelRequested;

            if (cancelRequested != null)
                cancelRequested(this, new EventArgs());
        }

        protected void OnImportRequested()
        {
            EventHandler<EventArgs> importRequested = ImportRequested;

            if (importRequested != null)
                importRequested(this, new EventArgs());
        }

        protected void OnAddToShowRequested()
        {
            EventHandler<PresentationEventArgs> addToShowRequested = AddToShowRequested;

            if (addToShowRequested != null)
                addToShowRequested(this, new PresentationEventArgs());
        }

        protected void OnRemoveFromShowRequested()
        {
            EventHandler<PresentationEventArgs> removeFromShowRequested = RemoveFromShowRequested;

            if (removeFromShowRequested != null)
                removeFromShowRequested(this, new PresentationEventArgs());
        }

        protected void OnDeleteRequested()
        {
            EventHandler<PresentationEventArgs> deletePresentationRequested = DeletePresentationRequested;

            if (deletePresentationRequested != null)
                deletePresentationRequested(this, new PresentationEventArgs());
        }

        protected void OnMovePresentationUpRequested()
        {
            EventHandler<PresentationEventArgs> onMovePresentationUpRequested = MovePresentationUpRequested;

            if (onMovePresentationUpRequested != null)
                onMovePresentationUpRequested(this, new PresentationEventArgs());
        }

        protected void OnMovePresentationDownRequested()
        {
            EventHandler<PresentationEventArgs> onMovePresentationDownRequested = MovePresentationDownRequested;

            if (onMovePresentationDownRequested != null)
                onMovePresentationDownRequested(this, new PresentationEventArgs());
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            OnCancelRequested();
            
            base.OnClosing(e);
        }

        public virtual void CloseWindow()
        {
            OnCancelRequested();
        }

        public abstract void ShowWindow();
    }
}
