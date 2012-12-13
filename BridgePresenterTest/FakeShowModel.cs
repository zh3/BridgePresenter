using System;
using System.ComponentModel;
using BridgePresenter;

namespace BridgePresenterTest
{
    public class FakeShowModel : IJointShowModel
    {
        public object DataSource { get { return null; } }

        public int PresentationCount { get; private set; }
        public int JointShowCount { get; private set; }
        public int EditShowCount { get; private set; }

        public FakeShowModel()
        {
            PresentationCount = 0;
            EditShowCount = 0;
            JointShowCount = 0;
        }

        public void Show()
        {
            PresentationCount++;
        }

        public void CreateJointShow()
        {
            JointShowCount++;
        }

        public void RemoveJointShow(string showName)
        {
            JointShowCount--;
        }

        public void EditJointShow(string showName)
        {
            EditShowCount++;
        }

        public void CopyJointShow(string showName)
        {
            JointShowCount++;
        }
    }
}
