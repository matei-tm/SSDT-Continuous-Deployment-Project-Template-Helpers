// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using SsdtProjectHelper.Common;
[assembly: InternalsVisibleTo("SsdtProjectHelper.Tests")]

namespace FilesProcessor
{
    public class SiblingFilesManager
    {
        private readonly IList<ProcessingResult> _processingResults;

        public string ReferenceFilePath { get; }
        public string MainDatapatchPattern { get; }

        public SiblingFilesManager(string filePath, string mainDatapatchPattern)
        {
            ReferenceFilePath = filePath;
            MainDatapatchPattern = mainDatapatchPattern;
            _processingResults = new List<ProcessingResult>();
        }

        public IEnumerable<ProcessingResult> ProcessFiles()
        {
            var siblings = GetAllSiblings();

            if (siblings.Any())
            {
                AppendReferenceString(siblings);
            }

            return _processingResults;
        }

        private IEnumerable<FileInfo> GetAllSiblings()
        {
            var referenceFileFolder = new DirectoryInfo(ReferenceFilePath).Parent;

            return referenceFileFolder.Parent.EnumerateFiles(MainDatapatchPattern, SearchOption.AllDirectories);
        }

        private void AppendReferenceString(IEnumerable<FileInfo> siblingFiles)
        {
            try
            {
                foreach (var targetFile in siblingFiles)
                {
                    var referenceString = BuildReferenceString(targetFile);
                    var result = AddDatapatchReference(targetFile, referenceString);
                    _processingResults.Add(result);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                _processingResults.Add(new ProcessingResult(ResultType.Error, dirNotFound.Message));
            }
            catch (UnauthorizedAccessException unAuthDir)
            {
                _processingResults.Add(new ProcessingResult(ResultType.Error, unAuthDir.Message));
            }
            catch (PathTooLongException longPath)
            {
                _processingResults.Add(new ProcessingResult(ResultType.Error, longPath.Message));
            }
        }

        private string BuildReferenceString(FileInfo currentFile)
        {
            var fileInfo = new FileInfo(ReferenceFilePath);
            var referenceFilePath = fileInfo.FullName;
            var currentFilePath = currentFile.FullName;
            var relativePath = currentFilePath.GetRelativePath(referenceFilePath);

            return $":r {relativePath}";
        }

        internal ProcessingResult AddDatapatchReference(FileInfo fileInfo, string referenceString)
        {
            using (var streamReader = new StreamReader(fileInfo.FullName))
            {
                var contents = streamReader.ReadToEnd();

                if (contents.Contains(referenceString))
                {
                    return new ProcessingResult(ResultType.Warning, fileInfo.FullName);
                }
            }

            using (var streamWriter = fileInfo.AppendText())
            {
                streamWriter.WriteLine(referenceString);
            }

            return new ProcessingResult(ResultType.Info, fileInfo.FullName);
        }
    }
}
