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

        public FakeShows()
        {
            PresentationCount = 0;
        }

        public override void Show()
        {
            PresentationCount++;
        }

        public override void CopyJointShow(IJointShow show)
        {
        }

        protected override void OnShowUpdated()
        {
        }
    }
}
