using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowWindowFactory : IJointShowWindowFactory
    {
        public Tuple<IJointShows, IJointShowWindow, JointShowController> CreateJointShowWindow()
        {
            JointShows model = new JointShows();
            JointShowWindow window = new JointShowWindow(model);
            JointShowController controller = new JointShowController(window, model);

            return new Tuple<IJointShows, IJointShowWindow, JointShowController>(model, window, controller);
        }
    }
}
