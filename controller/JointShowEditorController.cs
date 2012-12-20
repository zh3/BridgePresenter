using System;
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

            _window.AcceptRequested += window_AcceptRequested;
            _window.CancelRequested += window_CancelRequested;
            _window.ImportRequested += window_ImportRequested;

            _window.AddToShowRequested += window_AddToShowRequested;
            _window.RemoveFromShowRequested += window_RemoveFromShowRequested;
            _window.DeletePresentationRequested += window_DeletePresentationRequested;
            _window.MovePresentationUpRequested += window_MovePresentationUpRequested;
            _window.MovePresentationDownRequested += window_MovePresentationDownRequested;
        }

        protected void window_AcceptRequested(object sender, EventArgs e)
        {
            _showToEdit.Name = _window.ShowName;
        }

        protected void window_CancelRequested(object sender, EventArgs e)
        {

        }

        protected void window_ImportRequested(object sender, EventArgs e)
        {

        }

        protected void window_AddToShowRequested(object sender, PresentationEventArgs e)
        {
            
        }

        protected void window_RemoveFromShowRequested(object sender, PresentationEventArgs e)
        {

        }

        protected void window_DeletePresentationRequested(object sender, PresentationEventArgs e)
        {

        }

        protected void window_MovePresentationUpRequested(object sender, PresentationEventArgs e)
        {

        }

        protected void window_MovePresentationDownRequested(object sender, PresentationEventArgs e)
        {

        }
    }
}
