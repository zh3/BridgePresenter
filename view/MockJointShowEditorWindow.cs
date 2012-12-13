using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockJointShowEditorWindow : BaseJointShowEditorWindow
    {
        public MockJointShowEditorWindow(IJointShowModel model)
            : base(model)
        {
        }

        public MockJointShowEditorWindow()
            : base(null)
        {
        }

        public override void ShowWindow()
        {
            throw new System.NotImplementedException();
        }
    }
}
