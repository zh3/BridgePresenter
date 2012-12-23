using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    public class FakeShow : BaseShow
    {
        public string FilePath { get { return Path; } }

        public FakeShow(string path) : base(path)
        {
        }
    }
}
