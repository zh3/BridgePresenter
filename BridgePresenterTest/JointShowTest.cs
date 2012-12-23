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

        private FakeJointShow _testShow;
        private JointShowEditorController _jointShowController;
        private FakeJointShowEditorWindow _fakeJointShowEditorWindow;
        private FakeMessageShower _fakeMessageShower;

        [SetUp]
        public void SetUp()
        {
            _testShow = new FakeJointShow(OrigName1);
            _fakeJointShowEditorWindow = new FakeJointShowEditorWindow(_testShow);
            _fakeMessageShower = new FakeMessageShower();
            _jointShowController = new JointShowEditorController(_fakeJointShowEditorWindow, _testShow, _fakeMessageShower);
        }

        [Test]
        public void TestJointShowUpdated()
        {
            int updateCount = 0;
            _testShow.ShowUpdated += ((sender, e) => updateCount++);

            _fakeJointShowEditorWindow.JointShowName = NewName1;
            _fakeJointShowEditorWindow.FireOnAcceptRequested();
            Assert.AreEqual(1, updateCount, "Update not registered");

            _fakeJointShowEditorWindow.FireOnAcceptRequested();
            Assert.AreEqual(1, updateCount, "Unexpected update registered");
        }

        [Test]
        public void TestJointShowFilesImported()
        {
            string[] presentationPaths = new [] {"file 1", "file 2", "file 3"};

            _fakeJointShowEditorWindow.PresentationsToImport = presentationPaths;

            
        }
    }
}
