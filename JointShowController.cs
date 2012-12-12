﻿using System;

namespace BridgePresenter
{
    public class JointShowController
    {
        private IJointShowWindow _showWindow;
        private IJointShowModel _showModel;

        public JointShowController(IJointShowWindow showWindow, IJointShowModel showModel)
        {
            _showWindow = showWindow;
            _showModel = showModel;

            _showWindow.CloseWindowRequested += showWindow_CloseWindowRequested;
            _showWindow.ShowRequested += showWindow_ShowRequested;
            _showWindow.CreateJointShowRequested += showWindow_CreateJointShowRequested;
            _showWindow.EditShowRequested += showWindow_EditShowRequested;
            _showWindow.RemoveShowRequested += showWindow_RemoveShowRequested;
            _showWindow.CopyShowRequested += showWindow_CopyShowRequested;
        }

        public void showWindow_CloseWindowRequested(object sender, EventArgs e)
        {
            _showWindow.CloseWindow();
        }

        public void showWindow_ShowRequested(object sender, EventArgs e)
        {
            
        }

        public void showWindow_CreateJointShowRequested(object sender, EventArgs e)
        {
            
        }

        public void showWindow_EditShowRequested(object sender, ShowEventArgs e)
        {
            
        }

        public void showWindow_RemoveShowRequested(object sender, ShowEventArgs e)
        {
            
        }

        public void showWindow_CopyShowRequested(object sender, ShowEventArgs e)
        {
            
        }
    }
}
