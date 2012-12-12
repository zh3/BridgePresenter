using System;
using System.Windows.Forms;

namespace BridgePresenter
{
// Visual studio designer doesn't support abstract classes one level up from a form class.
// Workaround using an empty intermediate class.
#if DEBUG
    public partial class JointShowWindow : MockShowWindow
#else
    public partial class JointShowWindow : BaseShowWindow
#endif
    {
        protected override string SelectedItemString { get { return jointShowList.SelectedItem.ToString(); } }

        public JointShowWindow(IJointShowModel model) : base(model)
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            OnCreateJointShowRequested();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            OnEditShowRequested();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            OnRemoveShowRequested();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            OnCopyShowRequested();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            OnCloseWindowRequested();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            OnShowRequested();
        }

        public override void CloseWindow()
        {
            Close();
        }
    }
}
