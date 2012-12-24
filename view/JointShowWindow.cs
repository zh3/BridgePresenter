using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
// Visual studio designer doesn't support abstract classes one level up from a form class.
// Workaround using an empty intermediate class.
#if DEBUG
    public partial class JointShowWindow : MockJointShowWindow
#else
    public partial class JointShowWindow : BaseShowWindow
#endif
    {
        public override IJointShow SelectedShow 
        {
            get
            {
                object selectedItem = jointShowList.SelectedItem;
                
                if (selectedItem != null && selectedItem is IJointShow)
                    return jointShowList.SelectedItem as IJointShow;

                return new NullJointShow();
            }
        }

        public JointShowWindow(IJointShows model) : base(model)
        {
            InitializeComponent();

            jointShowList.DataSource = model.DataSource;
            model.ShowUpdated += model_showUpdated;
        }

        private void model_showUpdated(object sender, EventArgs e)
        {
            jointShowList.RefreshDataSource();
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

        public override void ShowWindow()
        {
            Show();
        }
    }
}
