using System;
using System.Collections.Generic;

namespace BridgePresenter.Model
{
    public interface IJointShow
    {
        event EventHandler<EventArgs> ShowUpdated;
        object ShowOrderDataSource { get; }
        object ImportedShowsDataSource { get; }

        int ShowOrderShowsCount { get; }
        int ImportedShowsCount { get; }
        List<IShow> ShowOrderShows { get; }
        HashSet<IShow> InvalidShowOrderShows { get; }
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
