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
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public IJointShow CreateJointShow()
        {
            JointShow newShow = new JointShow("");
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
