using System;

namespace BridgePresenter.Model
{
    [Serializable]
    public class BaseShow : IShow
    {
        public string Name 
        { 
            get { return System.IO.Path.GetFileNameWithoutExtension(Path); } 
        }

        public string Path { get; private set; }

        public BaseShow(string path)
        {
            Path = path;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", System.IO.Path.GetFileName(Path), Path);
        }
    }
}
