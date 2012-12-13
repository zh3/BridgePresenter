using System;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using BridgePresenter.View;
using Microsoft.Office.Tools.Ribbon;

namespace BridgePresenter
{
    public partial class BridgePresenterRibbon
    {
        private JointShowWindowFactory _factory;

        private void BridgePresenterRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            _factory = new JointShowWindowFactory();
        }

        private void setupJointShowsButton_Click(object sender, RibbonControlEventArgs e)
        {
            Tuple<IJointShowModel, IJointShowWindow, JointShowController> mwc = _factory.CreateJointShowWindow();
            mwc.Item2.ShowWindow();
        }
    }
}
