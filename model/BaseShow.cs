using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public class BaseShow : IJointShow
    {
        public string Name { get; set; }

        public BaseShow(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
