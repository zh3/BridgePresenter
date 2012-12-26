using System;
using System.ComponentModel;

namespace BridgePresenter.Model
{
    public class JointShows : BaseJointShows
    {
        public JointShows()
        {
        }

        public JointShows(string fileName) : base(fileName)
        {
        }

        public override object DataSource { get { return _jointShows;  } }

        public override void CopyJointShow(IJointShow show)
        {
            throw new NotImplementedException();
        }

        public override void CommitToFile()
        {
            _persistentLoader.StoreJointShows(DataFileName, _jointShows);
        }

        public override void LoadFromFile()
        {
            if (_jointShows == null)
                _jointShows = new BindingList<IJointShow>();

            _jointShows.Clear();
            BindingList<IJointShow> loadedShows = _persistentLoader.LoadJointShows(DataFileName);

            foreach (IJointShow loadedShow in loadedShows)
                _jointShows.Add(loadedShow);
        }
    }
}
