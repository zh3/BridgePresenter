using System;

namespace BridgePresenter
{
    public interface IJointShowModel
    {
        event EventHandler<JointShowListChangedEventArgs> JointShowListChanged;

        void Show();
        void AddJointShow(string fullPath);
        void RemoveJointShow(string showName);
        void RenameJointShow(string oldName, string newName);
        void CopyJointShow(string showName);
    }
}
