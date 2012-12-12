using System;

namespace BridgePresenter
{
    class JointShowModel : IJointShowModel
    {
        public event EventHandler<JointShowListChangedEventArgs> JointShowListChanged;

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void AddJointShow(string fullPath)
        {
            throw new NotImplementedException();
        }

        public void RemoveJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void RenameJointShow(string oldName, string newName)
        {
            throw new NotImplementedException();
        }

        public void CopyJointShow(string showName)
        {
            throw new NotImplementedException();
        }
    }
}
