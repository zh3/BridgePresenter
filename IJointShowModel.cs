using System;

namespace BridgePresenter
{
    public interface IJointShowModel
    {
        event EventHandler<JointShowListChangedEventArgs> JointShowListChanged;

        void Show();
        void AddJointShow();
        void RemoveJointShow(string showName);
        void EditJointShow(string showName);
        void CopyJointShow(string showName);
    }
}
