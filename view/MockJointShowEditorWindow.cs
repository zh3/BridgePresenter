using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockJointShowEditorWindow : BaseJointShowEditorWindow
    {
        public MockJointShowEditorWindow(IJointShow showModel)
            : base(showModel)
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
