using System;

namespace BridgePresenter.Model
{
    public class JointShows : BaseJointShows
    {
        public override object DataSource { get { return _jointShows;  } }

        public override void CopyJointShow(IJointShow show)
        {
            throw new NotImplementedException();
        }
    }
}
