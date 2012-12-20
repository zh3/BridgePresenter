using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter
{
    public static class PresenterUtils
    {
        public static void RefreshDataSource(this ListBox listBox)
        {
            ((CurrencyManager)listBox.BindingContext[listBox.DataSource]).Refresh();
        }
    }
}
