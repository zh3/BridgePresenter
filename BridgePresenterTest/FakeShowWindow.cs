using System;
using BridgePresenter;

namespace BridgePresenterTest
{
    public class FakeShowWindow : BaseShowWindow
    {
        private string _selectedItemString;
        protected override string SelectedItemString { get { return _selectedItemString; } }

        public bool WindowClosed { get; private set; }
        public string FakeSelectedItemString { get { return SelectedItemString; } set { _selectedItemString = value; } }

        public FakeShowWindow(IJointShowModel model) : base(model)
        {
            WindowClosed = false;
        }

        public override void CloseWindow()
        {
            WindowClosed = true;
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
    }
}
