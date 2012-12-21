using System;
using System.ComponentModel;

namespace BridgePresenter.Model
{
    public class JointShows : BaseShows
    {
        private BindingList<IJointShow> _jointShows;
        
        public override object DataSource { get { return _jointShows;  } }

        public JointShows()
        {
            _jointShows = new BindingList<IJointShow>();
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }

        public override IJointShow CreateJointShow()
        {
            JointShow newShow = new JointShow("");
            _jointShows.Add(newShow);
            return newShow;
        }

        public override void RemoveJointShow(IJointShow show)
        {
            _jointShows.Remove(show);
        }

        public override void CopyJointShow(IJointShow show)
        {
            throw new NotImplementedException();
        }
    }
}
