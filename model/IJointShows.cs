using System;
using System.Drawing;

namespace BridgePresenter.Model
{
    public interface IJointShows
    {
        event EventHandler<EventArgs> ShowUpdated;
        object DataSource { get; }

        void GeneratePresentation(IJointShow jointShow, bool launchPresentation);
        IJointShow CreateJointShow();
        void RemoveJointShow(IJointShow show);
        void CopyJointShow(IJointShow show);
        void CommitToFile();
        void LoadFromFile();
    }
}
