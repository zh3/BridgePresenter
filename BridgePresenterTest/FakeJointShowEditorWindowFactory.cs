using System;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindowFactory : IJointShowEditorWindowFactory
    {
        public Tuple<IJointShowEditorWindow, JointShowEditorController> CreateEditorWindow(IJointShows model, IJointShow show)
        {
            throw new NotImplementedException();
        }
    }
}
