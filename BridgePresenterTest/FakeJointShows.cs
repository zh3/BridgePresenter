using System;
using System.Collections.Generic;
using System.ComponentModel;
using BridgePresenter;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class FakeJointShows : BaseJointShows
    {
        public override object DataSource { get { return _jointShows; } }

        public int PresentationCount { get; private set; }
        public int JointShowCount { get { return _jointShows.Count;  } }

        public FakeJointShows()
        {
            PresentationCount = 0;
        }

        public override void Show(IJointShow selectedShow)
        {
            Assert.NotNull(selectedShow);
            PresentationCount++;
        }

        public override void CopyJointShow(IJointShow show)
        {
        }

        protected override void OnShowUpdated()
        {
        }

        public override void CommitToFile()
        {
        }

        public override void LoadFromFile()
        {
            if (_jointShows == null)
                _jointShows = new BindingList<IJointShow>();
        }
    }
}
