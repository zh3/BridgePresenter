using BridgePresenter.Model;

namespace BridgePresenter.View
{
    // Designer can't support abstract class 1 level up in hierarchy. Use workaround.
#if DEBUG
    public partial class JointShowEditorWindow : MockJointShowEditorWindow
#else
    public partial class JointShowEditorWindow : BaseJointShowEditorWindow
#endif
    {
        public override string ShowName
        {
            get { return jointShowNameTextBox.Text; }
        }

        public JointShowEditorWindow(IJointShow model) : base(model)
        {
            InitializeComponent();
        }

        public override void ShowWindow()
        {
            ShowDialog();
        }

        public override void CloseWindow()
        {
            Close();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            OnAcceptRequested();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            OnCancelRequested();
        }

        private void importButton_Click(object sender, System.EventArgs e)
        {
            OnImportRequested();
        }

        private void deleteButton_Click(object sender, System.EventArgs e)
        {
            OnDeleteRequested();
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            OnAddToShowRequested();
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            OnRemoveFromShowRequested();
        }

        private void upButton_Click(object sender, System.EventArgs e)
        {
            OnMovePresentationUpRequested();
        }

        private void downButton_Click(object sender, System.EventArgs e)
        {
            OnMovePresentationDownRequested();
        }
    }
}
