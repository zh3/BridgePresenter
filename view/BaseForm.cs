using System.Drawing;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class BaseForm : Form
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            LoadFormState();
        }

        protected void LoadFormState()
        {
            Rectangle formState = PersistentUtils.LoadObject<Rectangle>(Name + ".dat");

            if (!IsDefaultRect(formState))
            {
                Location = formState.Location;
                Size = formState.Size;
            }
        }

        private bool IsDefaultRect(Rectangle r)
        {
            return (r == new Rectangle());
        }

        protected void SaveFormState()
        {
            Rectangle formState = new Rectangle(Location, Size);

            PersistentUtils.StoreObject(Name + ".dat", formState);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveFormState();

            base.OnClosing(e);
        }
    }
}
