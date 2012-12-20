﻿using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
// Visual studio designer doesn't support abstract classes one level up from a form class.
// Workaround using an empty intermediate class.
#if DEBUG
    public partial class JointShowWindow : MockShowWindow
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

                return new NullShow();
            }
        }

        public JointShowWindow(IJointShows model) : base(model)
        {
            InitializeComponent();

            jointShowList.DataSource = model.DataSource;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            OnCreateJointShowRequested();

            jointShowList.RefreshDataSource();
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
            ShowDialog();
        }
    }
}
