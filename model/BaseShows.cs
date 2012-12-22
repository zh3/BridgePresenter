﻿using System;
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
            newShow.ShowUpdated += newShow_ShowUpdated;

            _jointShows.Add(newShow);
            return newShow;
        }

        void newShow_ShowUpdated(object sender, EventArgs e)
        {
            OnShowUpdated();
        }

        public virtual void RemoveJointShow(IJointShow show)
        {
            show.ShowUpdated -= newShow_ShowUpdated;
            _jointShows.Remove(show);
        }
    }
}
