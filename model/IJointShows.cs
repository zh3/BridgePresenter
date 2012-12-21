using System;

namespace BridgePresenter.Model
{
    public interface IJointShows
    {
        event EventHandler<EventArgs> ShowUpdated;
        object DataSource { get; }

        void Show();
        IJointShow CreateJointShow();
        void RemoveJointShow(IJointShow show);
        void CopyJointShow(IJointShow show);
    }
}
