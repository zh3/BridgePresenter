using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    public interface IJointShowPersistentLoader
    {
        void StoreJointShows(string fileName, BindingList<IJointShow> shows);
        BindingList<IJointShow> LoadJointShows(string fileName);
    }
}
