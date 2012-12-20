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

        private void CreateFakeJointShow(string showName)
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
        public void TestEditRename()
        {
            string origName = "arbitrary show 123";
            string newName = "renamed show";

            CreateFakeJointShow(origName);
            SelectShow(origName);
            IJointShow fakeShow = _fakeShowWindow.SelectedShow;

            FakeJointShowEditorWindow fakeEditorWindow = OpenFakeEditorWindow();
            fakeEditorWindow.JointShowName = newName;
            fakeEditorWindow.FireOnAcceptRequested();

            Assert.AreEqual(newName, fakeShow.Name);
        }

        private FakeJointShowEditorWindow OpenFakeEditorWindow()
        {
            _fakeShowWindow.FireOnEditShowRequested();
            return _fakeFactory.FakeWindow;
        }
    }
}