using System;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenterTest
{
    public class FakeJointShowEditorWindowFactory : IJointShowEditorWindowFactory
    {
        public FakeJointShowEditorWindow FakeWindow { get; private set; }
        public JointShowEditorController FakeEditorController { get; private set; }

        public Tuple<IJointShowEditorWindow, JointShowEditorController> CreateEditorWindow(IJointShow showModel)
        {
            FakeWindow = new FakeJointShowEditorWindow(showModel);
            FakeEditorController = new JointShowEditorController(FakeWindow, showModel);

            return new Tuple<IJointShowEditorWindow, JointShowEditorController>(FakeWindow, FakeEditorController);
        }
    }
}
