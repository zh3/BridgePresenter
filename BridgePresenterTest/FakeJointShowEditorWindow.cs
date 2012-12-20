using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindow : BaseJointShowEditorWindow
    {
        public string JointShowName { get; set; }
        public override string ShowName
        {
            get { return JointShowName; }
        }

        public FakeJointShowEditorWindow(IJointShow showModel) : base(showModel)
        {
        }

        public void FireOnAcceptRequested()
        {
            OnAcceptRequested();
        }

        public void FireOnCancelRequested()
        {
            OnCancelRequested();
        }

        public void FireOnImportRequested()
        {
            OnImportRequested();
        }

        public void FireOnAddToShowRequested()
        {
            OnAddToShowRequested();
        }

        public void FireOnRemoveFromShowRequested()
        {
            OnRemoveFromShowRequested();
        }

        public void FireDeletePresentationRequested()
        {
            OnDeleteRequested();
        }

        public void FireMovePresentationUpRequested()
        {
            OnMovePresentationUpRequested();
        }

        public void FireMovePresentationDownRequested()
        {
            OnMovePresentationDownRequested();
        }

        public override void ShowWindow()
        {
        }

        public override void CloseWindow()
        {
        }
    }
}
