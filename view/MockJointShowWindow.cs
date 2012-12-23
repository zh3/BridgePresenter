using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockJointShowWindow : BaseJointShowWindow
    {
        public MockJointShowWindow() : base(null)
        {
        }

        public MockJointShowWindow(IJointShows model) : base(model)
        {
        }

        public override IJointShow SelectedShow
        {
            get { throw new NotImplementedException(); }
        }

        public override void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public override void ShowWindow()
        {
            throw new NotImplementedException();
        }
    }
}
