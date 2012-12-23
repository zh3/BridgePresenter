using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    public class BaseJointShow : IJointShow
    {
        private string _name;
        private BindingList<IShow> _importedShows;
        private BindingList<IShow> _showOrderList;

        public event EventHandler<EventArgs> ShowUpdated;

        public object ShowOrderDataSource { get { return _showOrderList; } }
        public object ImportedShowsDataSource { get { return _importedShows; } }

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
            throw new NotImplementedException();
        }

        public void DeleteShow(IShow show)
        {
            while (_importedShows.Remove(show))
                ;
        }

        public void AddShowToShowOrder(IShow show)
        {
            _showOrderList.Add(show);
        }

        public void RemoveShowFromShowOrder(int showIndex)
        {
            throw new NotImplementedException();
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
