using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindow : MockJointShowEditorWindow
    {
        public string JointShowName;
        private System.Windows.Forms.ListBox fakeImportedShowListBox;
        private System.Windows.Forms.ListBox fakeShowOrderListBox;
        public string[] PresentationsToImport;

        public override string ShowName
        {
            get { return JointShowName; }
        }

        public FakeJointShowEditorWindow(IJointShow showModel) : base(showModel)
        {
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
