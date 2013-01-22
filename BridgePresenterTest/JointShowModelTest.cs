using System.Drawing;
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
        private FakeJointShowWindow _fakeShowWindow;
        private IJointShows _jointShowsModel;
        private FakeJointShowEditorWindowFactory _fakeFactory;
        private JointShowTester _showTester;

        [SetUp]
        public void Setup()
        {
            JointShowTester.ResetTestFile();
            Initialize();
        }
        
        private void Initialize()
        {
            _jointShowsModel = new JointShows(JointShowTester.TestFilename);
            _fakeShowWindow = new FakeJointShowWindow(_jointShowsModel);
            _fakeFactory = new FakeJointShowEditorWindowFactory();
            _controller = new JointShowController(_fakeShowWindow, _jointShowsModel, _fakeFactory, new FakeMessageShower());
            _showTester = new JointShowTester(_fakeShowWindow, _fakeFactory);
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
        public void TestJointShowsShowUpdatedEvent()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows, "Joint show creation failed");

            Assert.AreEqual(1, _fakeShowWindow.ShowUpdateCount, "Update not triggered correctly for creation");
            _showTester.EditorWindowChangeName(OrigName1, NewName1);
            Assert.AreEqual(2, _fakeShowWindow.ShowUpdateCount, "First edit did not trigger update");
            _showTester.EditorWindowChangeName(OrigName1, NewName2);
            Assert.AreEqual(3, _fakeShowWindow.ShowUpdateCount, "Second edit did not trigger update");
        }

        [Test]
        public void TestJointShowsChangesPersist()
        {
            SetupTestJointShow();
            CheckTestJointShowSetup();

            Initialize();

            CheckTestJointShowSetup();
        }

        private void SetupTestJointShow()
        {
            _showTester.CreateFakeJointShow(OrigName1);

            _fakeShowWindow.SelectShow(OrigName1);
            _showTester.EditorWindowImportShows(OrigName1, new[] { "path1", "path2", "path3" });
            _showTester.EditorWindowAddShowsToShowOrder(OrigName1, new[] { "path1", "path2", "path2", "path1", "path3" });
        }

        private void CheckTestJointShowSetup()
        {
            _fakeShowWindow.SelectShow(OrigName1);
            FakeJointShowEditorWindow fakeEditorWindow = _showTester.OpenFakeEditorWindow().Item1;

            Assert.AreEqual(fakeEditorWindow.ShowOrderItems[0].Path, "path1");
            Assert.AreEqual(fakeEditorWindow.ShowOrderItems[1].Path, "path2");
            Assert.AreEqual(fakeEditorWindow.ShowOrderItems[2].Path, "path2");
            Assert.AreEqual(fakeEditorWindow.ShowOrderItems[3].Path, "path1");
            Assert.AreEqual(fakeEditorWindow.ShowOrderItems[4].Path, "path3");
        }

        [Test]
        public void TestRemoveJointShowPersists()
        {
            _showTester.CreateFakeJointShow(OrigName1);
            _showTester.CreateFakeJointShow(NewName1);
            Assert.AreEqual(2, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.FireOnRemoveShowRequested();
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows);

            _fakeShowWindow.CloseWindow();
            Initialize();
            Assert.AreEqual(1, _fakeShowWindow.NumDisplayedJointShows);
        }
    }
}
