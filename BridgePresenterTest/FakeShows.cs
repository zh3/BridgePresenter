using System;
using System.Collections.Generic;
using System.ComponentModel;
using BridgePresenter;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    public class FakeShows : IJointShows
    {
        public object DataSource { get { return _jointShows; } }

        public int PresentationCount { get; private set; }
        public int JointShowCount { get { return _jointShows.Count;  } }

        private BindingList<IJointShow> _jointShows; 

        public FakeShows()
        {
            PresentationCount = 0;

            _jointShows = new BindingList<IJointShow>();
        }

        public void Show()
        {
            PresentationCount++;
        }

        public IJointShow CreateJointShow()
        {
            IJointShow jointShow = new FakeShow("");
            _jointShows.Add(jointShow);
            return jointShow;
        }

        public void RemoveJointShow(string showName)
        {
            //JointShowCount--;
        }

        public void CopyJointShow(string showName)
        {
            //JointShowCount++;
        }
    }
}
