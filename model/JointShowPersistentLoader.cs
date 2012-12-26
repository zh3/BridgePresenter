using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace BridgePresenter.Model
{
    public class JointShowPersistentLoader : IJointShowPersistentLoader
    {
        private readonly string _bridgePresenterDataPath 
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BridgePresenter");
        private const string TempFileName = "BridgePresenterTemp.dat";

        public void StoreJointShows(string fileName, BindingList<IJointShow> shows)
        {
            string filePath = Path.Combine(_bridgePresenterDataPath, fileName);
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
            if (File.Exists(Path.Combine(_bridgePresenterDataPath, fileName)))
            {
                Stream testFileStream = File.OpenRead(Path.Combine(_bridgePresenterDataPath, fileName));
                BinaryFormatter deserializer = new BinaryFormatter();
                shows = (BindingList<IJointShow>)deserializer.Deserialize(testFileStream);
                testFileStream.Close();
                return shows;
            }

            throw new FileNotFoundException("File not found: " + fileName);
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
