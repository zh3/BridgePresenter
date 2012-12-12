using BridgePresenter;
using NUnit.Framework;

namespace BridgePresenterTest
{
    [TestFixture]
    public class JointShowControllerTest
    {
        private JointShowController _controller;
        private FakeShowWindow _fakeShowWindow;

        [TestFixtureSetUp]
        public void Setup()
        {
            _fakeShowWindow = new FakeShowWindow();
            _controller = new JointShowController(_fakeShowWindow);
        }

        [Test]
        public void TestClose()
        {
            _fakeShowWindow.OnCloseRequested();
            Assert.IsTrue(_fakeShowWindow.Closed);
        }
    }
}