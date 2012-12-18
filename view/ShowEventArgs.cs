using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class ShowEventArgs : EventArgs
    {
        public IJointShow Show { get; private set; }

        public ShowEventArgs(IJointShow show)
        {
            Show = show;
        }
    }
}
