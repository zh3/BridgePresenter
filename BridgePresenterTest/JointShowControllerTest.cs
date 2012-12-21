using BridgePresenter;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    [TestFixture]
    public class JointShowControllerTest
    {
        private JointShowController _controller;
        private FakeShowWindow _fakeShowWindow;
        private FakeShows _fakeShowModel;
        private FakeJointShowEditorWindowFactory _fakeFactory;

        [SetUp]
        public void Setup()
        {
            _fakeShowModel = new FakeShows();
            _fakeShowWindow = new FakeShowWindow(_fakeShowModel);
            _fakeFactory = new FakeJointShowEditorWindowFactory();
            _controller = new JointShowController(_fakeShowWindow, _fakeShowModel, _fakeFactory);
        }

        [Test]
        public void TestClose()
        {
            _fakeShowWindow.FireOnCloseWindowRequested();
            Assert.IsTrue(_fakeShowWindow.WindowClosed);
        }

        [Test]
        public void TestCreate()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            
            Assert.AreEqual(4, _fakeShowModel.JointShowCount);
        }

        private void CreateFakeJointShow()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            FakeJointShowEditorWindow fakeEditorWindow = _fakeFactory.FakeWindow;
            fakeEditorWindow.FireOnAcceptRequested();
        }

        private void SelectShow(string showName)
        {
            _fakeShowWindow.SelectShow(showName);
        }

        [Test]
        public void TestRemove()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnRemoveShowRequested();

            Assert.AreEqual(1, _fakeShowModel.JointShowCount);
        }

        [Test]
        public void TestShow()
        {
            _fakeShowWindow.FireOnShowRequested();
            _fakeShowWindow.FireOnShowRequested();

            Assert.AreEqual(2, _fakeShowModel.PresentationCount);
        }

        [Test]
        public void TestCreateNamed()
        {
            const string origName = "arbitrary show 123";
            const string newName = "renamed show";

            IJointShow fakeShow = CreateFakeJointShow(origName);

            EditorWindowChangeName(origName, newName);

            Assert.AreEqual(newName, fakeShow.Name);
        }

        private IJointShow GetShow(string name)
        {
            SelectShow(name);
            return _fakeShowWindow.SelectedShow;
        }

        private void EditorWindowChangeName(string origName, string newName)
        {
            SelectShow(origName);
            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow();
            fakeEditorWindow.JointShowName = newName;
            fakeEditorWindow.FireOnAcceptRequested();
        }

        private FakeJointShowEditorWindow OpenFakeEditorWindow()
        {
            _fakeShowWindow.FireOnEditShowRequested();
            return _fakeFactory.FakeWindow;
        }

        private IJointShow CreateFakeJointShow(string showName)
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            FakeJointShowEditorWindow fakeEditorWindow = _fakeFactory.FakeWindow;
            fakeEditorWindow.JointShowName = showName;
            fakeEditorWindow.FireOnAcceptRequested();

            return GetShow(showName);
        }

        [Test]
        public void TestEditNamed()
        {
            const string origName1 = "Fake show 1";
            const string origName2 = "Fake show 2";
            const string newName1 = "Renamed fake show 1";

            CreateFakeJointShow(origName1);
            IJointShow fakeShow1 = GetShow(origName1);
            EditorWindowChangeName(origName1, newName1);

            CreateFakeJointShow(origName2);
            IJointShow fakeShow2 = GetShow(origName2);

            Assert.AreEqual(newName1, fakeShow1.Name);
            Assert.AreEqual(origName2, fakeShow2.Name);
        }
    }
}