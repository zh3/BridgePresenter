using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    public class FakeMessageShower : IMessageShower
    {
        public string LastErrorCaption { get; private set; }
        public string LastErrorMessage { get; private set; }
        

        public void ShowErrorMessage(string errorCaption, string errorMessage)
        {
            LastErrorCaption = errorCaption;
            LastErrorMessage = errorMessage;
        }
    }
}
