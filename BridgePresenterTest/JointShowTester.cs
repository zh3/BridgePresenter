using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Controller;
using BridgePresenter.Model;

namespace BridgePresenterTest
{
    class JointShowTester
    {
        public const string TestFilename = "BridgePresenterTest.dat";

        private FakeJointShowWindow _fakeShowWindow;
        private FakeJointShowEditorWindowFactory _fakeFactory;

        public FakeMessageShower FakeMessageShower { get { return _fakeFactory.FakeMessageShower; } }

        public static void ResetTestFile()
        {
            JointShowPersistentLoader.ResetFile(TestFilename);
        }

        public JointShowTester(FakeJointShowWindow fakeShowWindow, FakeJointShowEditorWindowFactory fakeFactory)
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

        public void EditorWindowImportShows(string jointShowName, string[] showPathNames)
        {
            _fakeShowWindow.SelectShow(jointShowName);
            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow().Item1;
            fakeEditorWindow.PresentationsToImport = showPathNames;
            fakeEditorWindow.FireOnImportRequested();

            fakeEditorWindow.FireOnAcceptRequested();
        }

        public void EditorWindowAddShowsToShowOrder(string jointShowName, string[] showPathNames)
        {
            _fakeShowWindow.SelectShow(jointShowName);
            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow().Item1;

            foreach (string pathName in showPathNames)
            {
                fakeEditorWindow.SelectImportedPresentation(pathName);
                fakeEditorWindow.FireOnAddToShowRequested();
            }

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
