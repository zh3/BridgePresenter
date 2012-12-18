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
            _jointShows.Add(new JointShow());
            _jointShows.Add(new JointShow());
            _jointShows.Add(new JointShow());
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void CreateJointShow()
        {
            throw new NotImplementedException();
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
