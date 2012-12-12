using BridgePresenter;
using NUnit.Framework;

namespace BridgePresenterTest
{
    [TestFixture]
    public class JointShowControllerTest
    {
        private JointShowController _controller;
        private FakeShowWindow _fakeShowWindow;
        private FakeShowModel _fakeShowModel;

        [SetUp]
        public void Setup()
        {
            _fakeShowModel = new FakeShowModel();
            _fakeShowWindow = new FakeShowWindow(_fakeShowModel);
            _controller = new JointShowController(_fakeShowWindow, _fakeShowModel);
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
        public void TestEdit()
        {
            _fakeShowWindow.FireOnEditShowRequested();
            _fakeShowWindow.FireOnEditShowRequested();
            _fakeShowWindow.FireOnEditShowRequested();
            _fakeShowWindow.FireOnEditShowRequested();

            Assert.AreEqual(4, _fakeShowModel.EditShowCount);
        }
    }
}