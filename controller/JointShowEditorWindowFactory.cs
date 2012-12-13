using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowEditorWindowFactory : IJointShowEditorWindowFactory
    {
        public Tuple<IJointShowEditorWindow, JointShowEditorController> CreateEditorWindow(IJointShowModel model)
        {
            JointShowEditorWindow window = new JointShowEditorWindow(model);
            JointShowEditorController controller = new JointShowEditorController(window, model);

            return new Tuple<IJointShowEditorWindow, JointShowEditorController>(window, controller);
        }
    }
}
