using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public class BasePresentation : IPresentation
    {
        protected string Path;

        public BasePresentation(string path)
        {
            Path = path;
        }
    }
}
