using System;

namespace BridgePresenter.Model
{
    public interface IJointShow
    {
        event EventHandler<EventArgs> ShowUpdated;
        object ShowOrderDataSource { get; }
        object ImportedShowsDataSource { get; }

        string Name { get; set; }

        IShow AddShow(string path);
        IShow[] AddShows(string[] paths);
        void RemoveShow(string path);
        void RemoveShow(IShow show);
        void AddShowToShowOrder(IShow show);
        void RemoveShowFromShowOrder(int showIndex);
        void DeleteShow(IJointShow show);
    }
}
