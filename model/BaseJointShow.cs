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

        public object ShowOrderDataSource { get { return _importedShows; } }
        public object ImportedShowsDataSource { get { return _showOrderList; } }

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
