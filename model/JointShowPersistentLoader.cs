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
        public void StoreJointShows(string path, BindingList<IJointShow> shows)
        {
            Stream testFileStream = File.Create(path);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, shows);
            testFileStream.Close();
        }

        public BindingList<IJointShow> LoadJointShows(string path)
        {
            BindingList<IJointShow> shows;
            if (File.Exists(path))
            {
                Stream testFileStream = File.OpenRead(path);
                BinaryFormatter deserializer = new BinaryFormatter();
                shows = (BindingList<IJointShow>)deserializer.Deserialize(testFileStream);
                testFileStream.Close();
                return shows;
            }

            throw new FileNotFoundException("File not found: " + path);
        }
    }
}
