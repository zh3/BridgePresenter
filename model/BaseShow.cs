using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    public class BaseShow : IJointShow
    {
        public event EventHandler<EventArgs> ShowUpdated;

        private string _name;
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

        public BaseShow(string name)
        {
            _name = name;
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
