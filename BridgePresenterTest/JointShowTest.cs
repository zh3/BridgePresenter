using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Controller;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class JointShowTest
    {
        private const string OrigName1 = "Original name";
        private const string NewName1 = "new name";

        private FakeShow _testShow;
        private JointShowEditorController _jointShowController;
        private FakeJointShowEditorWindow _fakeJointShowEditorWindow;

        [SetUp]
        public void SetUp()
        {
            _testShow = new FakeShow(OrigName1);
            _fakeJointShowEditorWindow = new FakeJointShowEditorWindow(_testShow);
            _jointShowController = new JointShowEditorController(_fakeJointShowEditorWindow, _testShow);
        }

        [Test]
        public void TestShowUpdated()
        {
            int updateCount = 0;
            _testShow.ShowUpdated += ((sender, e) => updateCount++);

            _fakeJointShowEditorWindow.JointShowName = NewName1;
            _fakeJointShowEditorWindow.FireOnAcceptRequested();
            Assert.AreEqual(1, updateCount, "Update not registered");

            _fakeJointShowEditorWindow.FireOnAcceptRequested();
            Assert.AreEqual(1, updateCount, "Unexpected update registered");
        }
    }
}
