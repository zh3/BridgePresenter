using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindow : MockJointShowEditorWindow
    {

        public string JointShowName;
        private DataGridView fakeImportedShowView;
        private DataGridView fakeShowOrderView;
        public string[] PresentationsToImport;
        public int NumImportedShowsDisplayed { get { return fakeImportedShowView.Rows.Count; } }
        public int NumShowsInShowOrderDisplayed { get { return fakeShowOrderView.Rows.Count; } }

        public List<IShow> ImportedShowItems
        {
            get { return (from DataGridViewRow row in fakeImportedShowView.Rows select (IShow) row.DataBoundItem).ToList(); }
        }

        public List<IShow> ShowOrderItems
        {
            get { return (from DataGridViewRow row in fakeShowOrderView.Rows select (IShow)row.DataBoundItem).ToList(); }
        }

        public override int ShowOrderSelectedShowIndex
        {
            get { return fakeShowOrderView.SelectedRows.Count > 0 ? fakeShowOrderView.SelectedRows[0].Index : -1; }
            set
            {
                if (value == -1)
                {
                    foreach (DataGridViewRow row in fakeShowOrderView.SelectedRows)
                        row.Selected = false;
                }
                else
                {
                    fakeShowOrderView.Rows[value].Selected = true;
                }
            }
        }

        public override IShow ImportedSelectedShow
        {
            get { return fakeImportedShowView.SelectedRows.Count > 0 
                    ? fakeImportedShowView.SelectedRows[0].DataBoundItem as IShow : null; }
        }

        public override string ShowName
        {
            get { return JointShowName; }
        }

        public void SelectImportedPresentation(string path)
        {
            SelectPresentation(path, fakeImportedShowView);
        }

        private void SelectPresentation(string path, DataGridView gridView)
        {
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                IShow show = (IShow)gridView.Rows[i].DataBoundItem;

                if (show.Path == path)
                {
                    gridView.Rows[i].Selected = true;
                    return;
                }
            }
        }

        public FakeJointShowEditorWindow(IJointShow showModel) : base(showModel)
        {
            InitializeComponent();

            JointShowName = showModel.Name;
            fakeShowOrderView.DataSource = showModel.ShowOrderDataSource;
            fakeImportedShowView.DataSource = showModel.ImportedShowsDataSource;
        }

        public void FireOnAcceptRequested()
        {
            OnAcceptRequested();
        }

        public void FireOnCancelRequested()
        {
            OnCancelRequested();
        }

        public void FireOnImportRequested()
        {
            OnImportRequested();
        }

        public void FireOnAddToShowRequested()
        {
            OnAddToShowRequested();
        }

        public void FireOnRemoveFromShowRequested()
        {
            OnRemoveFromShowRequested();
        }

        public void FireDeletePresentationRequested()
        {
            OnDeleteRequested();
        }

        public void FireMovePresentationUpRequested()
        {
            OnMovePresentationUpRequested();
        }

        public void FireMovePresentationDownRequested()
        {
            OnMovePresentationDownRequested();
        }

        public override string[] PromptForPresentationsToImport()
        {
            return PresentationsToImport;
        }

        public override void ShowWindow()
        {
            OnLoad(new EventArgs());
        }

        public override void CloseWindow()
        {
            OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false));
            OnClosing(new CancelEventArgs());
        }

        private void InitializeComponent()
        {
            this.fakeImportedShowView = new System.Windows.Forms.DataGridView();
            this.fakeShowOrderView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.fakeImportedShowView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fakeShowOrderView)).BeginInit();
            this.SuspendLayout();
            // 
            // fakeImportedShowView
            // 
            this.fakeImportedShowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fakeImportedShowView.Location = new System.Drawing.Point(44, 37);
            this.fakeImportedShowView.MultiSelect = false;
            this.fakeImportedShowView.Name = "fakeImportedShowView";
            this.fakeImportedShowView.Size = new System.Drawing.Size(194, 54);
            this.fakeImportedShowView.TabIndex = 2;
            // 
            // fakeShowOrderView
            // 
            this.fakeShowOrderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fakeShowOrderView.Location = new System.Drawing.Point(44, 145);
            this.fakeShowOrderView.MultiSelect = false;
            this.fakeShowOrderView.Name = "fakeShowOrderView";
            this.fakeShowOrderView.Size = new System.Drawing.Size(166, 86);
            this.fakeShowOrderView.TabIndex = 3;
            // 
            // FakeJointShowEditorWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fakeShowOrderView);
            this.Controls.Add(this.fakeImportedShowView);
            this.Name = "FakeJointShowEditorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.fakeImportedShowView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fakeShowOrderView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
