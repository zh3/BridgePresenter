using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    public class FakePresentation : BaseShow
    {
        public string FilePath { get { return Path; } }

        public FakePresentation(string path) : base(path)
        {
        }
    }
}
