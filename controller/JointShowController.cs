using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowController
    {
        private IJointShowWindow _showWindow;
        private IJointShows _showModel;
        private IJointShowEditorWindowFactory _editorWindowFactory;

        public JointShowController(IJointShowWindow showWindow, IJointShows showModel)
            : this(showWindow, showModel, new JointShowEditorWindowFactory())
        {
        }

        public JointShowController(IJointShowWindow showWindow, IJointShows showModel, IJointShowEditorWindowFactory factory)
        {
            _showWindow = showWindow;
            _showModel = showModel;

            _showWindow.CloseWindowRequested += showWindow_CloseWindowRequested;
            _showWindow.ShowRequested += showWindow_ShowRequested;
            _showWindow.CreateJointShowRequested += showWindow_CreateJointShowRequested;
            _showWindow.EditShowRequested += showWindow_EditShowRequested;
            _showWindow.RemoveShowRequested += showWindow_RemoveShowRequested;
            _showWindow.CopyShowRequested += showWindow_CopyShowRequested;

            _editorWindowFactory = factory;
        }

        protected void showWindow_CloseWindowRequested(object sender, EventArgs e)
        {
            _showWindow.CloseWindow();
        }

        protected void showWindow_ShowRequested(object sender, EventArgs e)
        {
            _showModel.Show();
        }

        protected void showWindow_CreateJointShowRequested(object sender, EventArgs e)
        {
            IJointShow jointShow = _showModel.CreateJointShow();
            Tuple<IJointShowEditorWindow, JointShowEditorController> mwc = _editorWindowFactory.CreateEditorWindow(jointShow);
            mwc.Item1.CancelRequested += delegate
            {
                if (jointShow.Name == string.Empty)
                    _showModel.RemoveJointShow(jointShow);
            };
            mwc.Item1.ShowWindow();
        }

        protected void showWindow_EditShowRequested(object sender, JointShowEventArgs e)
        {
            Tuple<IJointShowEditorWindow, JointShowEditorController> mwc = _editorWindowFactory.CreateEditorWindow(_showWindow.SelectedShow);

            mwc.Item1.ShowWindow();
        }

        protected void showWindow_RemoveShowRequested(object sender, JointShowEventArgs e)
        {
            _showModel.RemoveJointShow(_showWindow.SelectedShow);
        }

        protected void showWindow_CopyShowRequested(object sender, JointShowEventArgs e)
        {
            _showModel.CopyJointShow(_showWindow.SelectedShow);
        }
    }
}
