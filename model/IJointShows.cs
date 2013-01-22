using System;
using System.Drawing;

namespace BridgePresenter.Model
{
    public interface IJointShows
    {
        event EventHandler<EventArgs> ShowUpdated;
        object DataSource { get; }

        void Show(IJointShow show);
        IJointShow CreateJointShow();
        void RemoveJointShow(IJointShow show);
        void CopyJointShow(IJointShow show);
        void CommitToFile();
        void LoadFromFile();
    }
}
