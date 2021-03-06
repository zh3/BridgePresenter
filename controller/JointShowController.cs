﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public class JointShowController
    {
        private IJointShowWindow _showWindow;
        private IJointShows _showModel;
        private IJointShowEditorWindowFactory _editorWindowFactory;
        private IMessageShower _messageShower;

        public JointShowController(IJointShowWindow showWindow, IJointShows showModel)
            : this(showWindow, showModel, new JointShowEditorWindowFactory(), new MessageShower())
        {
        }

        public JointShowController(IJointShowWindow showWindow, IJointShows showModel, IJointShowEditorWindowFactory factory, IMessageShower messageShower)
        {
            _showWindow = showWindow;
            _showModel = showModel;

            _showWindow.CloseWindowRequested += showWindow_CloseWindowRequested;
            _showWindow.ShowRequested += showWindow_ShowRequested;
            _showWindow.GenerateRequested += showWindow_GenerateRequested;
            _showWindow.CreateJointShowRequested += showWindow_CreateJointShowRequested;
            _showWindow.EditShowRequested += showWindow_EditShowRequested;
            _showWindow.RemoveShowRequested += showWindow_RemoveShowRequested;
            _showWindow.CopyShowRequested += showWindow_CopyShowRequested;

            _editorWindowFactory = factory;
            _messageShower = messageShower;
        }

        protected void showWindow_CloseWindowRequested(object sender, EventArgs e)
        {
            _showWindow.CloseWindow();
        }

        protected void showWindow_ShowRequested(object sender, EventArgs e)
        {
            DispatchGeneratePresentationToModel(true);
        }

        protected void showWindow_GenerateRequested(object sender, EventArgs e)
        {
            DispatchGeneratePresentationToModel(false);
        }

        private void DispatchGeneratePresentationToModel(bool show)
        {
            IJointShow selectedShow = _showWindow.SelectedShow;
            if (selectedShow == null)
            {
                _messageShower.ShowErrorMessage("No presentation selected", "Please select a presentation");
                return;
            }

            HashSet<IShow> invalidShows = selectedShow.InvalidShowOrderShows;
            if (invalidShows.Count == 0)
                _showModel.GeneratePresentation(selectedShow, show);
            else
                _messageShower.ShowErrorMessage("Missing presentations",
                    string.Format("Could not find presentations:\n {0}", DisplayInvalidPaths(invalidShows)));
        }

        private string DisplayInvalidPaths(IEnumerable<IShow> invalidShows)
        {
            return invalidShows.Aggregate(string.Empty, (current, invalidShow) => current + (invalidShow.Path + "\n"));
        }

        protected void showWindow_CreateJointShowRequested(object sender, EventArgs e)
        {
            IJointShow jointShow = _showModel.CreateJointShow();
            Tuple<IJointShowEditorWindow, JointShowEditorController> mwc = _editorWindowFactory.CreateEditorWindow(jointShow);
            mwc.Item1.AcceptRequested += window_AcceptRequested;
            mwc.Item1.CancelRequested += delegate
            {
                if (jointShow.Name == string.Empty)
                    _showModel.RemoveJointShow(jointShow);
            };
            mwc.Item1.ShowWindow();
        }

        protected void showWindow_EditShowRequested(object sender, JointShowEventArgs e)
        {
            if (_showWindow.SelectedShow != null)
            {
                Tuple<IJointShowEditorWindow, JointShowEditorController> mwc = _editorWindowFactory.CreateEditorWindow(_showWindow.SelectedShow);
                mwc.Item1.AcceptRequested += window_AcceptRequested;
                mwc.Item1.CancelRequested += window_CancelReqested;

                mwc.Item1.ShowWindow();
            }
        }

        void window_AcceptRequested(object sender, EventArgs e)
        {
            _showModel.CommitToFile();
        }

        void window_CancelReqested(object sender, EventArgs e)
        {
            _showModel.LoadFromFile();
        }

        protected void showWindow_RemoveShowRequested(object sender, JointShowEventArgs e)
        {
            if (_showWindow.SelectedShow != null)
            {
                _showModel.RemoveJointShow(_showWindow.SelectedShow);
                _showModel.CommitToFile();
            }
        }

        protected void showWindow_CopyShowRequested(object sender, JointShowEventArgs e)
        {
            _showModel.CopyJointShow(_showWindow.SelectedShow);
        }
    }
}
