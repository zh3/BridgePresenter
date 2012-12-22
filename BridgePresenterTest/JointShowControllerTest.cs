using BridgePresenter;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    [TestFixture]
    public class JointShowControllerTest
    {
        private const string OrigName1 = "Fake show 1";
        private const string OrigName2 = "Fake show 2";
        private const string NewName1 = "Renamed fake show 1";

        private JointShowController _controller;
        private FakeShowWindow _fakeShowWindow;
        private FakeShows _fakeShowModel;
        private FakeJointShowEditorWindowFactory _fakeFactory;
        private ShowTester _showTester;

        [SetUp]
        public void Setup()
        {
            _fakeShowModel = new FakeShows();
            _fakeShowWindow = new FakeShowWindow(_fakeShowModel);
            _fakeFactory = new FakeJointShowEditorWindowFactory();
            _controller = new JointShowController(_fakeShowWindow, _fakeShowModel, _fakeFactory);
            _showTester = new ShowTester(_fakeShowWindow, _fakeFactory);
        }

        [Test]
        public void TestClose()
        {
            _fakeShowWindow.FireOnCloseWindowRequested();
            Assert.IsTrue(_fakeShowWindow.WindowClosed);
        }

        [Test]
        public void TestCreateJointShowFiresModel()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            
            Assert.AreEqual(4, _fakeShowModel.JointShowCount);
        }

        [Test]
        public void TestRemoveJointShowFiresModel()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnRemoveShowRequested();

            Assert.AreEqual(1, _fakeShowModel.JointShowCount);
        }

        [Test]
        public void TestShowFiresModel()
        {
            _fakeShowWindow.FireOnShowRequested();
            _fakeShowWindow.FireOnShowRequested();

            Assert.AreEqual(2, _fakeShowModel.PresentationCount);
        }

        [Test]
        public void TestCreateNamed()
        {
            IJointShow fakeShow = _showTester.CreateFakeJointShow(OrigName1);

            _showTester.EditorWindowChangeName(OrigName1, NewName1);

            Assert.AreEqual(NewName1, fakeShow.Name);
        }

        [Test]
        public void TestEditNamed()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            IJointShow fakeShow1 = _showTester.GetShow(OrigName1);
            _showTester.EditorWindowChangeName(OrigName1, NewName1);

            _showTester.CreateFakeJointShow(OrigName2);
            IJointShow fakeShow2 = _showTester.GetShow(OrigName2);

            Assert.AreEqual(NewName1, fakeShow1.Name);
            Assert.AreEqual(OrigName2, fakeShow2.Name);
        }

        [Test]
        public void TestEditShowToEmptyName()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            _showTester.EditorWindowChangeName(OrigName1, "");
            IJointShow fakeShow1 = _showTester.GetShow(OrigName1);

            Assert.AreEqual(OrigName1, fakeShow1.Name, "Name changed to empty string");

            Assert.AreEqual("Must specify the joint show name", _showTester.FakeMessageShower.LastErrorMessage);
        }

        [Test]
        [Description("Test a show that has no non-empty name committed is removed on cancel")]
        public void TestCancelShowWithEmptyName()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            _showTester.EditorWindowChangeName(OrigName1, "");
            IJointShow fakeShow1 = _showTester.GetShow(OrigName1);

            Assert.AreEqual(OrigName1, fakeShow1.Name, "Name changed to empty string");

            Assert.AreEqual("Must specify the joint show name", _showTester.FakeMessageShower.LastErrorMessage);
        }
    }
}