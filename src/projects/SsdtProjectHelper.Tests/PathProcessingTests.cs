using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilesProcessor.Tests
{
    [TestClass()]
    public class PathProcessingTests
    {
        [TestMethod()]
        public void GetRelativePathForSameRankSiblingsTest()
        {
            var currentPath = @"C:\Sibling01\file1.sql";
            var referencePath = @"C:\All\other2.sql";

            var relative = currentPath.GetRelativePath(referencePath);

            Assert.AreEqual(@"..\All\other2.sql", relative);
        }

        [TestMethod()]
        public void GetRelativePathForUnevenRankSiblingsTest()
        {
            var currentPath = @"C:\Sibling01\Subfolder\file1.sql";
            var referencePath = @"C:\All\other2.sql";

            var relative = currentPath.GetRelativePath(referencePath);

            Assert.AreEqual(@"..\..\All\other2.sql", relative);
        }

        [TestMethod()]
        public void GetRelativePathForNonSiblingsTest()
        {
            var currentPath = @"C:\Sibling01\Subfolder\file1.sql";
            var referencePath = @"D:\All\other2.sql";

            var relative = currentPath.GetRelativePath(referencePath);

            Assert.AreEqual(@"D:\All\other2.sql", relative);
        }

        [TestMethod()]
        public void GetRelativePathForNullReferencePathTest()
        {
            var currentPath = @"C:\Sibling01\Subfolder\file1.sql";
            string referencePath = null;

            Assert.ThrowsException<ArgumentNullException>(() => currentPath.GetRelativePath(referencePath));
        }

        [TestMethod()]
        public void GetRelativePathForNullCurrentPathTest()
        {
            string currentPath = null;
            var referencePath = @"C:\All\other2.sql";

            Assert.ThrowsException<ArgumentNullException>(() => currentPath.GetRelativePath(referencePath));
        }
    }
}
