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

        public override string ShowName
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int ShowOrderSelectedShowIndex
        {
            get { throw new System.NotImplementedException(); }
        }

        public override IShow ImportedSelectedShow
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string[] PromptForPresentationsToImport()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowWindow()
        {
            throw new System.NotImplementedException();
        }
    }
}
