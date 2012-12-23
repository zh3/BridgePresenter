using System;

namespace BridgePresenter.Model
{
    public interface IJointShow
    {
        event EventHandler<EventArgs> ShowUpdated;
        object ShowOrderDataSource { get; }
        object ImportedShowsDataSource { get; }

        int ShowOrderShowsCount { get; }
        int ImportedShowsCount { get; }
        string Name { get; set; }

        IShow AddShow(string path);
        IShow[] AddShows(string[] paths);
        void DeleteShow(string path);
        void DeleteShow(IShow show);
        void AddShowToShowOrder(IShow show);
        void RemoveShowFromShowOrder(int showIndex);
        void MoveShowUpInShowOrder(int showIndex);
        void MoveShowDownInShowOrder(int showIndex);
    }
}
