using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowEditorWindowFactory : IJointShowEditorWindowFactory
    {
        public Tuple<IJointShowEditorWindow, JointShowEditorController> CreateEditorWindow(IJointShow showModel)
        {
            JointShowEditorWindow window = new JointShowEditorWindow(showModel);
            JointShowEditorController controller = new JointShowEditorController(window, showModel, new MessageShower());

            return new Tuple<IJointShowEditorWindow, JointShowEditorController>(window, controller);
        }
    }
}
