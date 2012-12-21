using System;
using System.Collections.Generic;
using System.ComponentModel;
using BridgePresenter;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    public class FakeShows : BaseShows
    {
        public override object DataSource { get { return _jointShows; } }

        public int PresentationCount { get; private set; }
        public int JointShowCount { get { return _jointShows.Count;  } }

        private BindingList<IJointShow> _jointShows; 

        public FakeShows()
        {
            PresentationCount = 0;

            _jointShows = new BindingList<IJointShow>();
        }

        public override void Show()
        {
            PresentationCount++;
        }

        public override IJointShow CreateJointShow()
        {
            IJointShow jointShow = new FakeShow("");
            _jointShows.Add(jointShow);
            return jointShow;
        }

        public override void RemoveJointShow(IJointShow show)
        {
            _jointShows.Remove(show);
        }

        public override void CopyJointShow(IJointShow show)
        {
        }

        protected override void OnShowUpdated()
        {
        }
    }
}
