using System;
using System.Windows.Forms;
using BridgePresenter;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeShowWindow : BaseShowWindow
    {
        private ListBox _fakeShowListBox;
        private IJointShow _fakeSelectedShow;

        public int NumDisplayedJointShows { get { return _fakeShowListBox.Items.Count; } }
        public bool WindowClosed { get; private set; }

        public IJointShow FakeSelectedShow
        {
            get { return _fakeSelectedShow; }
            set { _fakeSelectedShow = value; }
        }

        public override IJointShow SelectedShow
        {
            get { return _fakeSelectedShow; }
        }

        public FakeShowWindow(IJointShows model) : base(model)
        {
            WindowClosed = false;

            _fakeShowListBox = new ListBox();
            _fakeShowListBox.DataSource = model.DataSource;
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
    }
}
