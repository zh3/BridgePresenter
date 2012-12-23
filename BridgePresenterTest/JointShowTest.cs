using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgePresenter.Controller;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class JointShowTest
    {
        private const string OrigName1 = "Original name";
        private const string NewName1 = "new name";
        private readonly string[] PresentationPaths = new[] { "file 1", "file 2", "file 3" };

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
            SetupPresentations();
        }

        [Test]
        public void TestJointShowDelete()
        {
            SetupPresentations();

            _fakeJointShowEditorWindow.FireDeletePresentationRequested();
            Assert.AreEqual(2, _fakeJointShowEditorWindow.NumImportedShowsDisplayed, "Show not correctly deleted");

            _fakeJointShowEditorWindow.FireDeletePresentationRequested();
            Assert.AreEqual(1, _fakeJointShowEditorWindow.NumImportedShowsDisplayed, "Show not correctly deleted");

            _fakeJointShowEditorWindow.FireDeletePresentationRequested();
            Assert.AreEqual(0, _fakeJointShowEditorWindow.NumImportedShowsDisplayed, "Show not correctly deleted");

            _fakeJointShowEditorWindow.FireDeletePresentationRequested();
            Assert.AreEqual(0, _fakeJointShowEditorWindow.NumImportedShowsDisplayed, "Deletion incorrect when shows empty");
        }

        private void SetupPresentations()
        {
            _fakeJointShowEditorWindow.PresentationsToImport = PresentationPaths;
            _fakeJointShowEditorWindow.FireOnImportRequested();
            Assert.AreEqual(3, _fakeJointShowEditorWindow.NumImportedShowsDisplayed, "Shows not correctly imported");
        }

        [Test]
        public void TestAddToShowOrder()
        {
            SetupPresentations();

            _fakeJointShowEditorWindow.FireOnAddToShowRequested();
            AddPresentationToShowOrder(PresentationPaths[0]);

            Assert.IsTrue(ContainsPresentationWithPath(_fakeJointShowEditorWindow.ShowOrderItems, PresentationPaths[0]),
                "Presentation not added successfully");
        }

        private static bool ContainsPresentationWithPath(IEnumerable<IShow> shows, string path)
        {
            return shows.Any(show => show.Path == path);
        }

        [Test]
        public void TestRemoveShowFromShowOrder()
        {
            SetupPresentations();

            AddPresentationToShowOrder(PresentationPaths[0]);
            AddPresentationToShowOrder(PresentationPaths[1]);
            AddPresentationToShowOrder(PresentationPaths[2]);
            AddPresentationToShowOrder(PresentationPaths[0]);

            RemovePresentationFromShowOrder(2);

            List<IShow> shows = _fakeJointShowEditorWindow.ShowOrderItems;
            Assert.AreEqual(PresentationPaths[0], shows[0].Path);
            Assert.AreEqual(PresentationPaths[1], shows[1].Path);
            Assert.AreEqual(PresentationPaths[0], shows[2].Path);
        }

        private void AddPresentationToShowOrder(string path)
        {
            _fakeJointShowEditorWindow.SelectImportedPresentation(path);
            _fakeJointShowEditorWindow.FireOnAddToShowRequested();
        }

        public void RemovePresentationFromShowOrder(int index)
        {
            _fakeJointShowEditorWindow.SelectShowOrderPresentation(index);
            _fakeJointShowEditorWindow.FireOnRemoveFromShowRequested();
        }
    }
}
