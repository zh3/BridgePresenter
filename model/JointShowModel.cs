using System;
using System.ComponentModel;

namespace BridgePresenter.Model
{
    public class JointShowModel : IJointShowModel
    {
        public event EventHandler<JointShowListChangedEventArgs> JointShowListChanged;
        private BindingList<JointShow> _jointShows;

        public object DataSource { get { return _jointShows;  } }

        public JointShowModel()
        {
            _jointShows = new BindingList<JointShow>();
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
            _jointShows.RemoveAt(0);
            //throw new NotImplementedException();
        }

        public void RemoveJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void EditJointShow(string showName)
        {
            throw new NotImplementedException();
        }

        public void CopyJointShow(string showName)
        {
            throw new NotImplementedException();
        }
    }
}
