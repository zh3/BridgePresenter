using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public abstract class BaseShows : IJointShows
    {
        protected BindingList<IJointShow> _jointShows;

        public event EventHandler<EventArgs> ShowUpdated;
        public abstract object DataSource { get; }
        public abstract void Show();
        public abstract void CopyJointShow(IJointShow show);

        protected BaseShows()
        {
            _jointShows = new BindingList<IJointShow>();
        }

        protected virtual void OnShowUpdated()
        {
            EventHandler<EventArgs> showUpdated = ShowUpdated;

            if (showUpdated != null)
                showUpdated(this, new EventArgs());
        }

        public virtual IJointShow CreateJointShow()
        {
            JointShow newShow = new JointShow("");
            _jointShows.Add(newShow);
            return newShow;
        }

        public virtual void RemoveJointShow(IJointShow show)
        {
            _jointShows.Remove(show);
        }
    }
}
