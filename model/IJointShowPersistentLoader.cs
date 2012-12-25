using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public interface IJointShowPersistentLoader
    {
        void StoreJointShows(string path, BindingList<IJointShow> shows);
        BindingList<IJointShow> LoadJointShows(string path);
    }
}
