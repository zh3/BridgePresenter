using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public interface IJointShowWindowFactory
    {
        Tuple<IJointShows, IJointShowWindow, JointShowController> CreateJointShowWindow();
    }
}
