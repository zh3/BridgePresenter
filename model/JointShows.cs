using System;
using System.ComponentModel;
using System.Linq;

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
            IJointShow showCopy = PresenterUtils.DeepClone(show);
            showCopy.ShowUpdated += newShow_ShowUpdated;
            
            while (_jointShows.Any(jointShow=>jointShow.Name == showCopy.Name))
                showCopy.Name += " - Copy";

            _jointShows.Add(showCopy);
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
