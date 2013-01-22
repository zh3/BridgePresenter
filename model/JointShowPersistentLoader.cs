using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    public class JointShowPersistentLoader : IJointShowPersistentLoader
    {
        private const string TempFileName = "BridgePresenterTemp.dat";

        public static void ResetFile(string fileName)
        {
            PersistentUtils.ResetFile(fileName);
        }

        public void StoreJointShows(string fileName, BindingList<IJointShow> shows)
        {
            PersistentUtils.StoreObject(fileName, shows);
        }

        public BindingList<IJointShow> LoadJointShows(string fileName)
        {
            return PersistentUtils.LoadObject<BindingList<IJointShow>>(fileName);
        }

        public void StoreTemporaryJointShows(BindingList<IJointShow> shows)
        {
            StoreJointShows(TempFileName, shows);
        }

        public BindingList<IJointShow> LoadTemporaryJointShows()
        {
            return LoadJointShows(TempFileName);
        }
    }
}
