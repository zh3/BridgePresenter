using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace BridgePresenter.Model
{
    public class JointShowPersistentLoader : IJointShowPersistentLoader
    {
        private static readonly string BridgePresenterDataPath 
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BridgePresenter");
        private const string TempFileName = "BridgePresenterTemp.dat";

        public static void ResetFile(string fileName)
        {
            string fullPath = Path.Combine(BridgePresenterDataPath, fileName);

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public void StoreJointShows(string fileName, BindingList<IJointShow> shows)
        {
            string filePath = Path.Combine(BridgePresenterDataPath, fileName);
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Directory != null)
                fileInfo.Directory.Create();

            Stream testFileStream = File.Create(filePath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, shows);

            testFileStream.Close();
        }

        public BindingList<IJointShow> LoadJointShows(string fileName)
        {
            BindingList<IJointShow> shows;
            if (File.Exists(Path.Combine(BridgePresenterDataPath, fileName)))
            {
                Stream testFileStream = File.OpenRead(Path.Combine(BridgePresenterDataPath, fileName));
                BinaryFormatter deserializer = new BinaryFormatter();
                shows = (BindingList<IJointShow>)deserializer.Deserialize(testFileStream);
                testFileStream.Close();
                return shows;
            }

            return new BindingList<IJointShow>();
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
