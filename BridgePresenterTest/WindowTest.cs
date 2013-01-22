using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class WindowTest
    {
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
        public void TestWindowSizePersists()
        {
            Size testSize = new Size(500, 700);
            _fakeShowWindow.Size = testSize;
            _fakeShowWindow.CloseWindow();
            Initialize();

            _fakeShowWindow.ShowWindow();
            Assert.AreEqual(testSize, _fakeShowWindow.Size);
        }

        [Test]
        public void TestWindowLocationPersists()
        {
            Point testPoint = new Point(17, 19);
            _fakeShowWindow.Location = testPoint;
            _fakeShowWindow.CloseWindow();
            Initialize();

            _fakeShowWindow.ShowWindow();
            Assert.AreEqual(testPoint, _fakeShowWindow.Location);
        }

        [Test]
        public void TestEditorWindowSizePersists()
        {
            _showTester.CreateFakeJointShow("Test");
            FakeJointShowEditorWindow window = _showTester.OpenFakeEditorWindow().Item1;

            Size testSize = new Size(320, 480);
            window.Size = testSize;

            // Reopen window and check location persists
            window.CloseWindow();
            window = _showTester.OpenFakeEditorWindow().Item1;
            window.ShowWindow();
            Assert.AreEqual(testSize, window.Size);
        }

        [Test]
        public void TestEditorWindowLocationPersists()
        {
            _showTester.CreateFakeJointShow("Test");
            FakeJointShowEditorWindow window = _showTester.OpenFakeEditorWindow().Item1;

            Point testPoint = new Point(17, 19);
            window.Location = testPoint;

            // Reopen window and check location persists
            window.CloseWindow();
            window = _showTester.OpenFakeEditorWindow().Item1;
            window.ShowWindow();
            Assert.AreEqual(testPoint, window.Location);
        }
    }
}
