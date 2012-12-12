using System;
using System.Windows.Forms;

namespace BridgePresenter
{
    public partial class JointShowWindow : Form, IJointShowWindow
    {
        public event EventHandler<EventArgs> CloseWindowRequested;
        public event EventHandler<EventArgs> ShowRequested;
        public event EventHandler<EventArgs> CreateJointShowRequested;
        public event EventHandler<ShowEventArgs> EditShowRequested;
        public event EventHandler<ShowEventArgs> RemoveShowRequested;
        public event EventHandler<ShowEventArgs> CopyShowRequested;

        private string SelectedItemString { get { return jointShowList.SelectedItem.ToString(); } }

        private IJointShowModel _model;

        public JointShowWindow(IJointShowModel model)
        {
            _model = model;

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
                editShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        protected void OnRemoveShowRequested()
        {
            EventHandler<ShowEventArgs> removeShowRequested = RemoveShowRequested;

            if (removeShowRequested != null)
                removeShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        protected void OnCopyShowRequested()
        {
            EventHandler<ShowEventArgs> copyShowRequested = CopyShowRequested;

            if (copyShowRequested != null)
                copyShowRequested(this, new ShowEventArgs(SelectedItemString));
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}
