using System;

namespace BridgePresenter.Model
{
    public interface IJointShow
    {
        event EventHandler<EventArgs> ShowUpdated;
        object ShowOrderDataSource { get; }
        object ImportedShowsDataSource { get; }

        string Name { get; set; }
    }
}
