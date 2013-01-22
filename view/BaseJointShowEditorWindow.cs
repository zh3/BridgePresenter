using System;
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

        //public int ShowOrderSelectedShowIndex 
        //{
        //    get { return ShowOrderView.SelectedRows.Count > 0 ? ShowOrderView.SelectedRows[0].Index : -1; }
        //    set { ShowOrderView.Rows[value].Selected = true; }
        //}

        //public IShow ImportedSelectedShow
        //{
        //    get { return ImportedShowsView.SelectedRows[0].DataBoundItem as IShow; }
        //}

        public int ShowOrderSelectedShowIndex
        {
            get { return ShowOrderView.SelectedRows.Count > 0 ? ShowOrderView.SelectedRows[0].Index : -1; }
            set
            {
                if (value == -1)
                {
                    foreach (DataGridViewRow row in ShowOrderView.SelectedRows)
                        row.Selected = false;
                }
                else
                {
                    ShowOrderView.Rows[value].Selected = true;
                }
            }
        }

        public IShow ImportedSelectedShow
        {
            get
            {
                return ImportedShowsView.SelectedRows.Count > 0
                  ? ImportedShowsView.SelectedRows[0].DataBoundItem as IShow : null;
            }
        }

        protected abstract DataGridView ShowOrderView { get; }
        protected abstract DataGridView ImportedShowsView { get; }

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
