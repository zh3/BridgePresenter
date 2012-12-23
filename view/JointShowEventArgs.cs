using System;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class JointShowEventArgs : EventArgs
    {
        public IJointShow Show { get; private set; }

        public JointShowEventArgs(IJointShow show)
        {
            Show = show;
        }
    }
}
