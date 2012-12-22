using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePresenter.Model
{
    public interface IMessageShower
    {
        void ShowErrorMessage(string errorCaption, string errorMessage);
    }
}
