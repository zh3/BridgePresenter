﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public abstract class BaseJointShowEditorWindow : BaseForm, IJointShowEditorWindow
    {
        private IJointShow _showModel;
        private bool _accepted;

        public abstract string ShowName { get; }
        public event EventHandler<EventArgs> AcceptRequested;
        public event EventHandler<EventArgs> CancelRequested;
        public event EventHandler<EventArgs> ImportRequested;
        public event EventHandler<ShowEventArgs> AddToShowRequested;
        public event EventHandler<ShowEventArgs> RemoveFromShowRequested;
        public event EventHandler<ShowEventArgs> DeletePresentationRequested;
        public event EventHandler<ShowEventArgs> MovePresentationUpRequested;
        public event EventHandler<ShowEventArgs> MovePresentationDownRequested;
        public abstract int ShowOrderSelectedShowIndex { get; set; }
        public abstract IShow ImportedSelectedShow { get; }

        protected BaseJointShowEditorWindow(IJointShow showModel)
        {
            _showModel = showModel;
        }

        protected void OnAcceptRequested()
        {
            _accepted = true;
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
            EventHandler<ShowEventArgs> addToShowRequested = AddToShowRequested;

            if (addToShowRequested != null)
                addToShowRequested(this, new ShowEventArgs());
        }

        protected void OnRemoveFromShowRequested()
        {
            EventHandler<ShowEventArgs> removeFromShowRequested = RemoveFromShowRequested;

            if (removeFromShowRequested != null)
                removeFromShowRequested(this, new ShowEventArgs());
        }

        protected void OnDeleteRequested()
        {
            EventHandler<ShowEventArgs> deletePresentationRequested = DeletePresentationRequested;

            if (deletePresentationRequested != null)
                deletePresentationRequested(this, new ShowEventArgs());
        }

        protected void OnMovePresentationUpRequested()
        {
            EventHandler<ShowEventArgs> onMovePresentationUpRequested = MovePresentationUpRequested;

            if (onMovePresentationUpRequested != null)
                onMovePresentationUpRequested(this, new ShowEventArgs());
        }

        protected void OnMovePresentationDownRequested()
        {
            EventHandler<ShowEventArgs> onMovePresentationDownRequested = MovePresentationDownRequested;

            if (onMovePresentationDownRequested != null)
                onMovePresentationDownRequested(this, new ShowEventArgs());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!_accepted)
                OnCancelRequested();
        }

        public abstract void CloseWindow();
        public abstract string[] PromptForPresentationsToImport();
        public abstract void ShowWindow();
    }
}
