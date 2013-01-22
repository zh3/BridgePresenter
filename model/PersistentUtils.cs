using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BridgePresenter.Model
{
    public static class PersistentUtils
    {
        private static readonly string BridgePresenterDataPath
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BridgePresenter");

        public static void ResetFile(string fileName)
        {
            string fullPath = Path.Combine(BridgePresenterDataPath, fileName);

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public static void StoreObject<T>(string fileName, T obj)
        {
            string filePath = Path.Combine(BridgePresenterDataPath, fileName);
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Directory != null)
                fileInfo.Directory.Create();

            Stream testFileStream = File.Create(filePath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, obj);

            testFileStream.Close();
        }

        public static T LoadObject<T>(string fileName) where T : new()
        {
            if (File.Exists(Path.Combine(BridgePresenterDataPath, fileName)))
            {
                Stream testFileStream = File.OpenRead(Path.Combine(BridgePresenterDataPath, fileName));
                BinaryFormatter deserializer = new BinaryFormatter();
                T obj = (T)deserializer.Deserialize(testFileStream);
                testFileStream.Close();
                return obj;
            }

            return new T();
        }
    }
}
