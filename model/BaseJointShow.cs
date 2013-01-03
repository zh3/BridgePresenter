using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    [Serializable]
    public class BaseJointShow : IJointShow
    {
        private string _name;
        private BindingList<IShow> _importedShows;
        private BindingList<IShow> _showOrderList;

        [field:NonSerialized]
        public event EventHandler<EventArgs> ShowUpdated;

        public object ShowOrderDataSource { get { return _showOrderList; } }
        public object ImportedShowsDataSource { get { return _importedShows; } }
        public int ShowOrderShowsCount { get { return _showOrderList.Count; } }
        public int ImportedShowsCount { get { return _importedShows.Count; } }
        public List<IShow> ShowOrderShows { get { return _showOrderList.ToList(); } }
        public HashSet<IShow> InvalidShowOrderShows 
        {
            get
            {
                HashSet<IShow> invalidShows = new HashSet<IShow>();

                foreach (IShow show in ShowOrderShows)
                    if (!File.Exists(show.Path))
                        invalidShows.Add(show);

                return invalidShows;
            }
        }

        public string Name
        {
            get { return _name; } 
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnShowUpdated();
                }
            }
        }

        public IShow AddShow(string path)
        {
            IShow newShow = new Show(path);
            _importedShows.Add(new Show(path));
            return newShow;
        }

        public IShow[] AddShows(string[] paths)
        {
            IShow[] shows = new IShow[paths.Length];
            for (int i = 0; i < paths.Length; i++ )
                shows[i] = AddShow(paths[i]);

            return shows;
        }

        public void DeleteShow(string path)
        {
            DeleteShow(_importedShows.First((show) => show.Path == path));
        }

        public void DeleteShow(IShow show)
        {
            while (_showOrderList.Remove(show))
                ;

            while (_importedShows.Remove(show))
                ;
        }

        public void AddShowToShowOrder(IShow show)
        {
            _showOrderList.Add(show);
        }

        public void RemoveShowFromShowOrder(int showIndex)
        {
            _showOrderList.RemoveAt(showIndex);
        }

        public void MoveShowUpInShowOrder(int showIndex)
        {
            SwapShows(showIndex, showIndex - 1);
        }

        public void MoveShowDownInShowOrder(int showIndex)
        {
            SwapShows(showIndex, showIndex + 1);
        }

        private void SwapShows(int index1, int index2)
        {
            IShow temp = _showOrderList[index1];
            _showOrderList[index1] = _showOrderList[index2];
            _showOrderList[index2] = temp;
        }

        public BaseJointShow(string name)
        {
            _name = name;

            _importedShows = new BindingList<IShow>();
            _showOrderList = new BindingList<IShow>();
        }

        protected virtual void OnShowUpdated()
        {
            EventHandler<EventArgs> showUpdated = ShowUpdated;

            if (showUpdated != null)
                showUpdated(this, new EventArgs());
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
