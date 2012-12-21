using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    class ShowTester
    {
        private FakeShowWindow _fakeShowWindow;
        private FakeJointShowEditorWindowFactory _fakeFactory;

        public ShowTester(FakeShowWindow fakeShowWindow, FakeJointShowEditorWindowFactory fakeFactory)
        {
            _fakeShowWindow = fakeShowWindow;
            _fakeFactory = fakeFactory;
        }

        public IJointShow GetShow(string name)
        {
            _fakeShowWindow.SelectShow(name);
            return _fakeShowWindow.SelectedShow;
        }

        public void EditorWindowChangeName(string origName, string newName)
        {
            _fakeShowWindow.SelectShow(origName);
            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow();
            fakeEditorWindow.JointShowName = newName;
            fakeEditorWindow.FireOnAcceptRequested();
        }

        public FakeJointShowEditorWindow OpenFakeEditorWindow()
        {
            _fakeShowWindow.FireOnEditShowRequested();
            return _fakeFactory.FakeWindow;
        }

        public IJointShow CreateFakeJointShow(string showName)
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            FakeJointShowEditorWindow fakeEditorWindow = _fakeFactory.FakeWindow;
            fakeEditorWindow.JointShowName = showName;
            fakeEditorWindow.FireOnAcceptRequested();

            return GetShow(showName);
        }
    }
}
