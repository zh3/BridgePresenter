using Microsoft.Office.Tools.Ribbon;

namespace BridgePresenter
{
    public partial class BridgePresenterRibbon
    {
        private void BridgePresenterRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void setupJointShowsButton_Click(object sender, RibbonControlEventArgs e)
        {
            JointShowModel model = new JointShowModel();
            JointShowWindow window = new JointShowWindow(model);
            new JointShowController(window, model);

            window.ShowDialog();
        }
    }
}
