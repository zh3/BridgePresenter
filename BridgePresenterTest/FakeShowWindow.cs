using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BridgePresenter;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeShowWindow : MockShowWindow
    {
        private ListBox fakeShowListBox;

        public int NumDisplayedJointShows { get { return fakeShowListBox.Items.Count; } }
        public int ShowUpdateCount { get; private set; }
        public bool WindowClosed { get; private set; }

        public override IJointShow SelectedShow
        {
            get { return (IJointShow)fakeShowListBox.SelectedItem; }
        }

        public FakeShowWindow(IJointShows model) : base(model)
        {
            InitializeComponent();

            WindowClosed = false;
            fakeShowListBox.DataSource = model.DataSource;
            model.ShowUpdated += model_OnShowUpdated;
        }

        private void model_OnShowUpdated(object sender, EventArgs e)
        {
            ShowUpdateCount++;
        }

        public void SelectShow(string showName)
        {
            foreach (IJointShow jointShow in fakeShowListBox.Items)
            {
                if (jointShow.Name == showName)
                {
                    fakeShowListBox.SelectedItem = jointShow;
                    return;
                }
            }
        }

        public void FireOnShowRequested()
        {
            OnShowRequested();
        }

        public void FireOnCreateJointShowRequested()
        {
            OnCreateJointShowRequested();
        }

        public void FireOnEditShowRequested()
        {
            OnEditShowRequested();
        }

        public void FireOnRemoveShowRequested()
        {
            OnRemoveShowRequested();
        }

        public void FireOnCopyShowRequested()
        {
            OnCopyShowRequested();
        }

        public void FireOnCloseWindowRequested()
        {
            OnCloseWindowRequested();
        }

        public override void CloseWindow()
        {
            WindowClosed = true;
        }

        public override void ShowWindow()
        {
            
        }

        private void InitializeComponent()
        {
            this.fakeShowListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fakeShowListBox
            // 
            this.fakeShowListBox.FormattingEnabled = true;
            this.fakeShowListBox.Location = new System.Drawing.Point(12, 12);
            this.fakeShowListBox.Name = "fakeShowListBox";
            this.fakeShowListBox.Size = new System.Drawing.Size(120, 95);
            this.fakeShowListBox.TabIndex = 0;
            // 
            // FakeShowWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fakeShowListBox);
            this.Name = "FakeShowWindow";
            this.ResumeLayout(false);

        }
    }
}
