using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public abstract class BaseShows : IJointShows
    {
        public event EventHandler<EventArgs> ShowUpdated;
        public abstract object DataSource { get; }
        public abstract void Show();
        public abstract IJointShow CreateJointShow();
        public abstract void RemoveJointShow(IJointShow show);
        public abstract void CopyJointShow(IJointShow show);

        protected virtual void OnShowUpdated()
        {
            EventHandler<EventArgs> showUpdated = ShowUpdated;

            if (showUpdated != null)
                showUpdated(this, new EventArgs());
        }
    }
}
