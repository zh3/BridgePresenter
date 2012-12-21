using BridgePresenter.Controller;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    [TestFixture]
    public class JointShowModelTest
    {
        private const string OrigName1 = "Original Name";
        private const string NewName1 = "Revised Name";
        private const string NewName2 = "Alternate Name";

        private JointShowController _controller;
        private FakeShowWindow _fakeShowWindow;
        private IJointShows _jointShowsModel;
        private FakeJointShowEditorWindowFactory _fakeFactory;
        private ShowTester _showTester;

        [SetUp]
        public void Setup()
        {
            _jointShowsModel = new JointShows();
            _fakeShowWindow = new FakeShowWindow(_jointShowsModel);
            _fakeFactory = new FakeJointShowEditorWindowFactory();
            _controller = new JointShowController(_fakeShowWindow, _jointShowsModel, _fakeFactory);
            _showTester = new ShowTester(_fakeShowWindow, _fakeFactory);
        }

        [Test]
        public void TestCreateJointShow()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            Assert.AreEqual(3, _fakeShowWindow.NumDisplayedJointShows);
        }

        [Test]
        public void TestRemoveJointShow()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            Assert.AreEqual(2, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.FireOnRemoveShowRequested();
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows);
        }

        [Test]
        public void TestEditJointShow()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            Assert.AreEqual(2, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.FireOnEditShowRequested();
            _fakeShowWindow.FireOnEditShowRequested();
            _fakeShowWindow.FireOnEditShowRequested();
            Assert.AreEqual(2, _fakeShowWindow.NumDisplayedJointShows);
        }

        [Test]
        public void TestCopyJointShow()
        {
            _fakeShowWindow.FireOnCreateJointShowRequested();
            _fakeShowWindow.FireOnCreateJointShowRequested();
            Assert.AreEqual(2, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.FireOnCopyShowRequested();
            Assert.AreEqual(3, _fakeShowWindow.NumDisplayedJointShows);
        }

        [Test]
        public void TestShowUpdatedEvent()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows, "Joint show creation failed");

            Assert.AreEqual(0, _fakeShowWindow.ShowUpdateCount, "Update triggered before changes made");
            _showTester.EditorWindowChangeName(OrigName1, NewName1);
            Assert.AreEqual(1, _fakeShowWindow.ShowUpdateCount, "First edit did not trigger update");
            _showTester.EditorWindowChangeName(OrigName1, NewName2);
            Assert.AreEqual(2, _fakeShowWindow.ShowUpdateCount, "Second edit did not trigger update");
        }
    }
}
