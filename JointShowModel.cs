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

        public void AddJointShow()
        {
            throw new NotImplementedException();
        }

        public void RemoveJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void EditJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void CopyJointShow(string showName)
        {
            throw new NotImplementedException();
        }
    }
}
