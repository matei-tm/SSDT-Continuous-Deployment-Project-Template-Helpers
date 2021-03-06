﻿using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SsdtProjectHelper.Common;

namespace FilesProcessor.Integration.Tests
{
    [TestClass]
    public class SiblingFilesManagerIntegrationTests
    {
        private const string MainDatapatchPattern = "main.datapatch.sql";
        private static readonly string s_tempFolder = Path.GetTempPath();
        private readonly string _workingFolder = Path.Combine(s_tempFolder, $"ssdtProjectHelper.Tests.{Guid.NewGuid()}");
        private string _pathProjectRoot;
        private string _pathAll;
        private string _pathSibling01;
        private string _pathSibling02;
        private string _pathReferenceFile;
        private string _pathSibling01File;
        private string _pathSibling02File;

        [TestInitialize]
        public void TestInitialize()
        {
            _pathProjectRoot = Path.Combine(_workingFolder, "test.sqlproj");
            _pathAll = Path.Combine(_workingFolder, "All");
            _pathSibling01 = Path.Combine(_workingFolder, "Sibling01");
            _pathSibling02 = Path.Combine(_workingFolder, "Sibling02");
            _pathReferenceFile = Path.Combine(_pathAll, "test.datapatch.all.sql");

            _pathSibling01File = Path.Combine(_pathSibling01, MainDatapatchPattern);
            _pathSibling02File = Path.Combine(_pathSibling02, MainDatapatchPattern);

            Directory.CreateDirectory(_workingFolder);
            Directory.CreateDirectory(_pathAll);
            Directory.CreateDirectory(_pathSibling01);
            Directory.CreateDirectory(_pathSibling02);

            File.Create(_pathReferenceFile).Close();
            File.Create(_pathSibling01File).Close();
            File.Create(_pathSibling02File).Close();
        }

        [TestMethod()]
        public void ProcessAllFilesReturnsResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.ProcessAllFiles();

            Assert.IsTrue(result.Any());
        }

        [TestMethod()]
        public void ProcessAllFilesHasSibling01FileInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.ProcessAllFiles();

            Assert.IsTrue(result.Where(r => r.Content == _pathSibling01File).Any());
        }

        [TestMethod()]
        public void ProcessAllFilesHasSibling02FileInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.ProcessAllFiles();

            Assert.IsTrue(result.Where(r => r.Content == _pathSibling02File).Any());
        }

        [TestMethod()]
        public void ProcessAllFilesHasInfoInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.ProcessAllFiles();

            Assert.IsTrue(result.Where(r => r.ResultType == ResultType.Info).Count() == 2);
        }


        [TestMethod()]
        public void ProcessFilesReturnsResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling01File, _pathReferenceFile);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ProcessFilesHasSibling01FileInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling01File, _pathReferenceFile);

            Assert.IsTrue(result.Content == _pathSibling01File);
        }

        [TestMethod()]
        public void ProcessFilesHasSibling02FileInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            Assert.IsTrue(result.Content == _pathSibling02File);
        }

        [TestMethod()]
        public void ProcessFilesHasInfoInResultTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            Assert.AreEqual(result.ResultType, ResultType.Info);
        }

        [TestMethod()]
        public void DoesNotApplyDatapatchTwiceTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            var fileHashFirstPass = _pathSibling02File.ComputeMD5HashString();
            siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            var fileHashSecondPass = _pathSibling02File.ComputeMD5HashString();

            Assert.AreEqual(fileHashFirstPass, fileHashSecondPass);
        }

        [TestMethod()]
        public void DoesApplyDatapatchTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);

            var result = siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            Assert.AreEqual(result.Content, _pathSibling02File);
            Assert.AreEqual(result.ResultType, ResultType.Info);
        }

        [TestMethod()]
        public void DoesWarnApplyingTwiceDatapatchTest()
        {
            var siblingFilesManager = new SiblingFilesManager(_pathReferenceFile, MainDatapatchPattern, _pathProjectRoot);

            siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling02File, _pathReferenceFile);

            Assert.AreEqual(result.Content, _pathSibling02File);
            Assert.AreEqual(result.ResultType, ResultType.Warning);
        }

        [TestMethod()]
        public void CheckingForAppliedReferenceIsCaseInsensitiveTest()
        {
            var changedPathReferenceFile = _pathReferenceFile.ToUpper();
            var siblingFilesManager = new SiblingFilesManager(changedPathReferenceFile, MainDatapatchPattern, _pathProjectRoot);
            var result = siblingFilesManager.AddDatapatchReference(_pathSibling01File, _pathReferenceFile);

            Assert.IsTrue(result.ResultType == ResultType.Info);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            Directory.Delete(_workingFolder, true);
        }
    }
}
