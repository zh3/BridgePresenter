using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public class BaseShow : IShow
    {
        public string Path { get; private set; }

        public BaseShow(string path)
        {
            Path = path;
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
