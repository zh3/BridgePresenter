using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Controller;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    class ShowTester
    {
        private FakeShowWindow _fakeShowWindow;
        private FakeJointShowEditorWindowFactory _fakeFactory;

        public FakeMessageShower FakeMessageShower { get { return _fakeFactory.FakeMessageShower; } }

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
            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow().Item1;
            fakeEditorWindow.JointShowName = newName;
            fakeEditorWindow.FireOnAcceptRequested();
        }

        public Tuple<FakeJointShowEditorWindow, JointShowEditorController, FakeMessageShower> OpenFakeEditorWindow()
        {
            _fakeShowWindow.FireOnEditShowRequested();
            return new Tuple<FakeJointShowEditorWindow, JointShowEditorController, FakeMessageShower>(
                    _fakeFactory.FakeWindow, _fakeFactory.FakeEditorController, _fakeFactory.FakeMessageShower);
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
