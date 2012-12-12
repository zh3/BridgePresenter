using System;

namespace BridgePresenter
{
    public class ShowEventArgs : EventArgs
    {
        public string ShowName { get; private set; }

        public ShowEventArgs(string showName)
        {
            ShowName = showName;
        }
    }
}
