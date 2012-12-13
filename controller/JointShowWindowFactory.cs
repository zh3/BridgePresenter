using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowWindowFactory : IJointShowWindowFactory
    {
        public Tuple<IJointShowModel, IJointShowWindow, JointShowController> CreateJointShowWindow()
        {
            JointShowModel model = new JointShowModel();
            JointShowWindow window = new JointShowWindow(model);
            JointShowController controller = new JointShowController(window, model);

            return new Tuple<IJointShowModel, IJointShowWindow, JointShowController>(model, window, controller);
        }
    }
}
