using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindow : MockJointShowEditorWindow
    {
        private ListBox fakeImportedShowListBox;
        private ListBox fakeShowOrderListBox;

        public string JointShowName;
        public string[] PresentationsToImport;
        public int NumImportedShowsDisplayed { get { return fakeImportedShowListBox.Items.Count; } }
        public int NumShowsInShowOrderDisplayed { get { return fakeShowOrderListBox.Items.Count; } }

        public List<IShow> ImportedShowItems
        {
            get { return ObjectCollectionToShowList(fakeImportedShowListBox.Items); }
        }

        public List<IShow> ShowOrderItems
        {
            get { return ObjectCollectionToShowList(fakeShowOrderListBox.Items); }
        }

        private List<IShow> ObjectCollectionToShowList(ListBox.ObjectCollection collection)
        {
            return collection.Cast<IShow>().ToList();
        }

        public override int ShowOrderSelectedShowIndex
        {
            get { return fakeShowOrderListBox.SelectedIndex; }
            set { fakeShowOrderListBox.SelectedIndex = value; }
        }

        public override IShow ImportedSelectedShow
        {
            get { return fakeImportedShowListBox.SelectedItem as IShow; }
        }

        public override string ShowName
        {
            get { return JointShowName; }
        }

        public void SelectImportedPresentation(string path)
        {
            SelectPresentation(path, fakeImportedShowListBox);
        }

        private void SelectPresentation(string path, ListBox listBox)
        {
            foreach (IShow show in listBox.Items)
            {
                if (show.Path == path)
                {
                    listBox.SelectedItem = show;
                    return;
                }
            }
        }

        public FakeJointShowEditorWindow(IJointShow showModel) : base(showModel)
        {
            InitializeComponent();

            fakeShowOrderListBox.DataSource = showModel.ShowOrderDataSource;
            fakeImportedShowListBox.DataSource = showModel.ImportedShowsDataSource;
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
        }

        private void InitializeComponent()
        {
            this.fakeImportedShowListBox = new System.Windows.Forms.ListBox();
            this.fakeShowOrderListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fakeImportedShowListBox
            // 
            this.fakeImportedShowListBox.FormattingEnabled = true;
            this.fakeImportedShowListBox.Location = new System.Drawing.Point(13, 13);
            this.fakeImportedShowListBox.Name = "fakeImportedShowListBox";
            this.fakeImportedShowListBox.Size = new System.Drawing.Size(120, 95);
            this.fakeImportedShowListBox.TabIndex = 0;
            // 
            // fakeShowOrderListBox
            // 
            this.fakeShowOrderListBox.FormattingEnabled = true;
            this.fakeShowOrderListBox.Location = new System.Drawing.Point(13, 135);
            this.fakeShowOrderListBox.Name = "fakeShowOrderListBox";
            this.fakeShowOrderListBox.Size = new System.Drawing.Size(120, 95);
            this.fakeShowOrderListBox.TabIndex = 1;
            // 
            // FakeJointShowEditorWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fakeShowOrderListBox);
            this.Controls.Add(this.fakeImportedShowListBox);
            this.Name = "FakeJointShowEditorWindow";
            this.ResumeLayout(false);

        }
    }
}
