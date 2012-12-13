using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowEditorController
    {
        private IJointShowEditorWindow _window;
        private IJointShowModel _model;

        public JointShowEditorController(IJointShowEditorWindow window, IJointShowModel model)
        {
            _window = window;
            _model = model;
        }
    }
}
