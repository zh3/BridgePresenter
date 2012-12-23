using System;
using System.ComponentModel;

namespace BridgePresenter.Model
{
    public class JointShows : BaseJointShows
    {
        public override object DataSource { get { return _jointShows;  } }

        public override void Show()
        {
            throw new NotImplementedException();
        }

        public override void CopyJointShow(IJointShow show)
        {
            throw new NotImplementedException();
        }
    }
}
