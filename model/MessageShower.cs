using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter.Model
{
    public class MessageShower : IMessageShower
    {
        public void ShowErrorMessage(string errorCaption, string errorMessage)
        {
            MessageBox.Show(errorMessage, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
