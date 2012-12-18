using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindow : JointShowEditorWindow
    {
        public FakeJointShowEditorWindow(IJointShows model) : base(model)
        {
        }
    }
}
