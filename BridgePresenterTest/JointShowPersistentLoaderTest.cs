using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class JointShowPersistentLoaderTest
    {
        private const string SAVE_PATH = @"C:\Windows\Temp\BridgePresenter.dat";
        private JointShowPersistentLoader _loader;

        [SetUp]
        public void Setup()
        {
            _loader = new JointShowPersistentLoader();
        }

        [Test]
        public void TestSaveAndLoadJointShows()
        {
            BindingList<IJointShow> shows = new BindingList<IJointShow>();
            IJointShow testShow1 = new JointShow("Test show 1");
            IJointShow testShow2 = new JointShow("Test show 2");
            IJointShow testShow3 = new JointShow("Test show 3");
            shows.Add(testShow1);
            shows.Add(testShow2);
            shows.Add(testShow3);

            _loader.StoreJointShows(SAVE_PATH, shows);

            BindingList<IJointShow> loadedShows = _loader.LoadJointShows(SAVE_PATH);
            AssertMatchShows(shows, loadedShows);
        }

        [Test]
        public void TestSaveAndLoadJointShowsWithPresentations()
        {
            BindingList<IJointShow> shows = new BindingList<IJointShow>();
            IJointShow testJointShow1 = new JointShow("Test show 1");
            IJointShow testJointShow2 = new JointShow("Test show 2");
            IJointShow testJointShow3 = new JointShow("Test show 3");
            IShow testJointShow1Show1 = testJointShow1.AddShow("Test show test path");
            IShow testJointShow1Show2 = testJointShow1.AddShow("Test show 1 test path 2");
            testJointShow1.AddShowToShowOrder(testJointShow1Show1);
            testJointShow1.AddShowToShowOrder(testJointShow1Show2);

            IShow testJointShow2Show1 = testJointShow2.AddShow("Test show test path");
            IShow testJointShow2Show2 = testJointShow2.AddShow("Test show 2 test path 1");
            IShow testJointShow2Show3 = testJointShow2.AddShow("Test show 2 test path 2");
            IShow testJointShow2Show4 = testJointShow2.AddShow("Test show 2 test path 3");
            testJointShow2.AddShowToShowOrder(testJointShow2Show3);
            testJointShow2.AddShowToShowOrder(testJointShow2Show1);
            testJointShow2.AddShowToShowOrder(testJointShow2Show2);
            testJointShow2.AddShowToShowOrder(testJointShow2Show4);

            IShow testJointShow3Show1 = testJointShow3.AddShow("Test show 3 test path 1");
            testJointShow3.AddShowToShowOrder(testJointShow3Show1);
            testJointShow3.AddShowToShowOrder(testJointShow3Show1);
            testJointShow3.AddShowToShowOrder(testJointShow3Show1);

            shows.Add(testJointShow1);
            shows.Add(testJointShow2);
            shows.Add(testJointShow3);

            _loader.StoreJointShows(SAVE_PATH, shows);

            BindingList<IJointShow> loadedShows = _loader.LoadJointShows(SAVE_PATH);
            AssertMatchShows(shows, loadedShows);
        }

        private void AssertMatchShows(BindingList<IJointShow> sourceShows, BindingList<IJointShow> loadedShows)
        {
            Assert.AreEqual(sourceShows.Count, loadedShows.Count);

            foreach (IJointShow jointShow in loadedShows)
            {
                IJointShow matchingSourceShow = sourceShows.First(sourceShow => sourceShow.Name == jointShow.Name);
                Assert.NotNull(matchingSourceShow);

                BindingList<IShow> importedShows = (BindingList<IShow>)matchingSourceShow.ImportedShowsDataSource;
                BindingList<IShow> showOrderShows = (BindingList<IShow>)matchingSourceShow.ShowOrderDataSource;
                foreach (IShow showOrderShow in jointShow.ShowOrderShows)
                    Assert.IsTrue(importedShows.Any(show => show.Path == showOrderShow.Path));

                foreach (IShow importedShow in showOrderShows)
                    Assert.IsTrue(importedShows.Any(show => show.Path == importedShow.Path));
            }
        }
    }
}
