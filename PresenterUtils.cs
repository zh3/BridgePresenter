using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
