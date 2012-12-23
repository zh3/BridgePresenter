﻿using System;
using System.Windows.Forms;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowEditorController
    {
        private IJointShowEditorWindow _window;
        private IJointShow _showToEdit;
        private IMessageShower _messageShower;

        public JointShowEditorController(IJointShowEditorWindow window, IJointShow showToEdit, IMessageShower messageShower)
        {
            _window = window;
            _showToEdit = showToEdit;
            _messageShower = messageShower;
            
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
            if (_window.ShowName != string.Empty)
            {
                _showToEdit.Name = _window.ShowName;

                _window.CloseWindow();
            }
            else
            {
                _messageShower.ShowErrorMessage("Name Error", "Must specify the joint show name");
            }
        }

        protected void window_CancelRequested(object sender, EventArgs e)
        {
        }

        protected void window_ImportRequested(object sender, EventArgs e)
        {
            string[] pathsToImport = _window.PromptForPresentationsToImport();

            _showToEdit.AddShows(pathsToImport);
        }

        protected void window_AddToShowRequested(object sender, ShowEventArgs e)
        {
            _showToEdit.AddShowToShowOrder(_window.ImportedSelectedShow);
        }

        protected void window_RemoveFromShowRequested(object sender, ShowEventArgs e)
        {

        }

        protected void window_DeletePresentationRequested(object sender, ShowEventArgs e)
        {
            _showToEdit.DeleteShow(_window.ImportedSelectedShow);
        }

        protected void window_MovePresentationUpRequested(object sender, ShowEventArgs e)
        {

        }

        protected void window_MovePresentationDownRequested(object sender, ShowEventArgs e)
        {

        }
    }
}
