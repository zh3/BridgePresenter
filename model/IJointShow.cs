using System;

namespace BridgePresenter.Model
{
    public interface IJointShow
    {
        event EventHandler<EventArgs> ShowUpdated;

        string Name { get; set; }
    }
}
