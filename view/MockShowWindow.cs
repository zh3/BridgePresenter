using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockShowWindow : BaseShowWindow
    {
        public MockShowWindow() : base(null)
        {
        }

        public MockShowWindow(IJointShows model) : base(model)
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
