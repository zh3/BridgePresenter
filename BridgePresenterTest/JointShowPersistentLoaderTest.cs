﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgePresenter.Model;
using NUnit.Framework;

namespace BridgePresenterTest
{
    public class JointShowPersistentLoaderTest
    {
        private const string SaveName = @"BridgePresenterPersistentLoaderTest.dat";
        private JointShowPersistentLoader _loader;

        [SetUp]
        public void Setup()
        {
            JointShowPersistentLoader.ResetFile(SaveName);
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

            _loader.StoreJointShows(SaveName, shows);

            BindingList<IJointShow> loadedShows = _loader.LoadJointShows(SaveName);
            AssertMatchShows(shows, loadedShows);
        }

        [Test]
        public void TestSaveAndLoadJointShowsWithPresentations()
        {
            BindingList<IJointShow> shows = CreateTestShows();

            _loader.StoreJointShows(SaveName, shows);

            BindingList<IJointShow> loadedShows = _loader.LoadJointShows(SaveName);
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
        
        private BindingList<IJointShow> CreateTestShows()
        {
            BindingList<IJointShow> shows = new BindingList<IJointShow>();
            IJointShow testJointShow1 = new JointShow("Test show 1");
            IJointShow testJointShow2 = new JointShow("Test show 2");
            IJointShow testJointShow3 = new JointShow("Test show 3");
            IShow testJointShow1Show1 = testJointShow1.AddShow("Test show test path");
            IShow testJointShow1Show2 = testJointShow1.AddShow("Test show 1 test path 2");
            AppendShowToShowOrder(testJointShow1, testJointShow1Show1);
            AppendShowToShowOrder(testJointShow1, testJointShow1Show2);

            IShow testJointShow2Show1 = testJointShow2.AddShow("Test show test path");
            IShow testJointShow2Show2 = testJointShow2.AddShow("Test show 2 test path 1");
            IShow testJointShow2Show3 = testJointShow2.AddShow("Test show 2 test path 2");
            IShow testJointShow2Show4 = testJointShow2.AddShow("Test show 2 test path 3");
            AppendShowToShowOrder(testJointShow2, testJointShow2Show3);
            AppendShowToShowOrder(testJointShow2, testJointShow2Show1);
            AppendShowToShowOrder(testJointShow2, testJointShow2Show2);
            AppendShowToShowOrder(testJointShow2, testJointShow2Show4);

            IShow testJointShow3Show1 = testJointShow3.AddShow("Test show 3 test path 1");
            AppendShowToShowOrder(testJointShow3, testJointShow3Show1);
            AppendShowToShowOrder(testJointShow3, testJointShow3Show1);
            AppendShowToShowOrder(testJointShow3, testJointShow3Show1);

            shows.Add(testJointShow1);
            shows.Add(testJointShow2);
            shows.Add(testJointShow3);

            return shows;
        }

        private void AppendShowToShowOrder(IJointShow jointShow, IShow show)
        {
            jointShow.AddShowToShowOrder(show, jointShow.ShowOrderShowsCount);
        }

        [Test]
        public void TestTemporarySaveAndLoadJointShows()
        {
            BindingList<IJointShow> shows = CreateTestShows();

            _loader.StoreTemporaryJointShows(shows);

            BindingList<IJointShow> loadedShows = _loader.LoadTemporaryJointShows();
            AssertMatchShows(shows, loadedShows);
        }
    }
}
