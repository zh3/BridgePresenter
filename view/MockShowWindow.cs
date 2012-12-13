using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockShowWindow : BaseShowWindow
    {
        public MockShowWindow() : base(null)
        {
        }

        public MockShowWindow(IJointShowModel model) : base(model)
        {
        }

        protected override string SelectedItemString
        {
            get { throw new NotImplementedException(); }
        }

        public override void CloseWindow()
        {
            throw new NotImplementedException();
        }
    }
}
