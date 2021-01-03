// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using SsdtProjectHelper.Common;
using SsdtProjectHelper.Common.Interfaces;

[assembly: InternalsVisibleTo("SsdtProjectHelper.Tests")]

namespace FilesProcessor
{
    public class SiblingFilesManager : ISiblingFilesManager
    {
        public IList<ProcessingResult> ProcessingResults { get; private set; }
        public string ProjectRootFolder { get; private set; }
        public IEnumerable<string> SiblingPathsRelativeToProject { get; }
        public string ReferenceFilePath { get; }
        public string MainDatapatchPattern { get; }

        public SiblingFilesManager(string referenceFilePath, string mainDatapatchPattern, string projectRootFolder)
        {
            ReferenceFilePath = referenceFilePath;
            ProjectRootFolder = projectRootFolder;
            MainDatapatchPattern = mainDatapatchPattern;
            ProcessingResults = new List<ProcessingResult>();
            SiblingPathsRelativeToProject = GetAllSiblings().Select(s => FileUtils.GetRelativePath(ProjectRootFolder, s.FullName));
        }

        public IList<ProcessingResult> ProcessAllFiles()
        {
            foreach (var targetFilePartialPath in SiblingPathsRelativeToProject)
            {
                ProcessSingleFileAsPartialPath(targetFilePartialPath);
            }

            return ProcessingResults;
        }

        public void ProcessSingleFileAsPartialPath(string targetFilePartialPath)
        {
            try
            {
                var projectRootFolderParent = Directory.GetParent(ProjectRootFolder).FullName;
                var targetFileFullName = Path.Combine(projectRootFolderParent, targetFilePartialPath);
                var referenceString = BuildReferenceString(targetFileFullName);
                var result = AddDatapatchReference(targetFileFullName, referenceString);
                ProcessingResults.Add(result);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                ProcessingResults.Add(new ProcessingResult(ResultType.Error, dirNotFound.Message));
            }
            catch (UnauthorizedAccessException unAuthDir)
            {
                ProcessingResults.Add(new ProcessingResult(ResultType.Error, unAuthDir.Message));
            }
            catch (PathTooLongException longPath)
            {
                ProcessingResults.Add(new ProcessingResult(ResultType.Error, longPath.Message));
            }
        }

        private IEnumerable<FileInfo> GetAllSiblings()
        {
            var referenceFileFolder = new DirectoryInfo(ReferenceFilePath).Parent;

            return referenceFileFolder.Parent.EnumerateFiles(MainDatapatchPattern, SearchOption.AllDirectories);
        }

        private string BuildReferenceString(string currentFilePath)
        {
            var relativePath = currentFilePath.GetRelativePath(ReferenceFilePath);

            return $":r {relativePath}";
        }

        internal ProcessingResult AddDatapatchReference(string targetFileFullPath, string referenceString)
        {
            using (var streamReader = new StreamReader(targetFileFullPath))
            {
                var contents = streamReader.ReadToEnd();

                if (contents.Contains(referenceString, StringComparison.OrdinalIgnoreCase))
                {
                    return new ProcessingResult(ResultType.Warning, targetFileFullPath);
                }
            }

            using (var streamWriter = new StreamWriter(targetFileFullPath, true))
            {
                streamWriter.WriteLine(referenceString);
            }

            return new ProcessingResult(ResultType.Info, targetFileFullPath);
        }
    }
}
