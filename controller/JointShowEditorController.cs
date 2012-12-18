using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowEditorController
    {
        private IJointShowEditorWindow _window;
        private IJointShow _showToEdit;

        public JointShowEditorController(IJointShowEditorWindow window, IJointShow showToEdit)
        {
            _window = window;
            _showToEdit = showToEdit;
        }
    }
}
