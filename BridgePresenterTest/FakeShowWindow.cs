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
        private string _selectedItemString;
        protected override string SelectedItemString { get { return _selectedItemString; } }

        public int NumDisplayedJointShows { get { return _fakeShowListBox.Items.Count; } }
        public bool WindowClosed { get; private set; }
        public string FakeSelectedItemString { get { return SelectedItemString; } set { _selectedItemString = value; } }

        public FakeShowWindow(IJointShowModel model) : base(model)
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
    }
}
