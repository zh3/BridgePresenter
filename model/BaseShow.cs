using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public class BaseShow : IShow
    {
        protected string Path;

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
