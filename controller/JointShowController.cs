using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowController
    {
        private IJointShowWindow _showWindow;
        private IJointShowModel _showModel;
        private IJointShowEditorWindowFactory _editorWindowFactory;

        public JointShowController(IJointShowWindow showWindow, IJointShowModel showModel)
            : this(showWindow, showModel, new JointShowEditorWindowFactory())
        {
        }

        public JointShowController(IJointShowWindow showWindow, IJointShowModel showModel, IJointShowEditorWindowFactory factory)
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

        public void showWindow_CloseWindowRequested(object sender, EventArgs e)
        {
            _showWindow.CloseWindow();
        }

        public void showWindow_ShowRequested(object sender, EventArgs e)
        {
            _showModel.Show();
        }

        public void showWindow_CreateJointShowRequested(object sender, EventArgs e)
        {
            Tuple<IJointShowEditorWindow, JointShowEditorController> mwc = _editorWindowFactory.CreateEditorWindow(_showModel);
            mwc.Item1.ShowWindow();
        }

        public void showWindow_EditShowRequested(object sender, ShowEventArgs e)
        {
            _showModel.EditJointShow("Fake");
        }

        public void showWindow_RemoveShowRequested(object sender, ShowEventArgs e)
        {
            _showModel.RemoveJointShow("Fake");
        }

        public void showWindow_CopyShowRequested(object sender, ShowEventArgs e)
        {
            _showModel.CopyJointShow("Fake");
        }

        private void OpenEditorWindow()
        {
            JointShowEditorWindow editorWindow = new JointShowEditorWindow(_showModel);
            JointShowEditorController editorController = new JointShowEditorController(editorWindow, _showModel);
            editorWindow.ShowDialog();
        }
    }
}
