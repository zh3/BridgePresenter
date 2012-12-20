using System;
using System.ComponentModel;

namespace BridgePresenter.Model
{
    public class JointShows : IJointShows
    {
        public event EventHandler<JointShowListChangedEventArgs> JointShowsListChanged;
        private BindingList<IJointShow> _jointShows;

        public object DataSource { get { return _jointShows;  } }

        public JointShows()
        {
            _jointShows = new BindingList<IJointShow>();
            _jointShows.Add(new JointShow("hishow"));
            _jointShows.Add(new JointShow("loshow"));
            _jointShows.Add(new JointShow("mrpicolloshow"));
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public IJointShow CreateJointShow()
        {
            JointShow newShow = new JointShow("abc");
            _jointShows.Add(newShow);
            return newShow;
        }

        public void RemoveJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void CopyJointShow(string showName)
        {
            throw new NotImplementedException();
        }
    }
}
