// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesProcessor
{
    public class SiblingFilesManager
    {
        public string ReferenceFilePath { get; }
        public string MainDatapatchPattern { get; }

        public SiblingFilesManager(string filePath, string mainDatapatchPattern)
        {
            ReferenceFilePath = filePath;
            MainDatapatchPattern = mainDatapatchPattern;
        }

        public void ProcessFiles()
        {
            var siblings = GetAllSiblings();

            if (siblings.Any())
            {
                AppendReferenceString(siblings);
            }
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
                var referenceString = BuildReferenceString();

                foreach (var targetFile in siblingFiles)
                {
                    AddDatapatchReference(targetFile, referenceString);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                // TODO
            }
            catch (UnauthorizedAccessException unAuthDir)
            {
                // TODO
            }
            catch (PathTooLongException longPath)
            {
                // TODO
            }
        }

        private string BuildReferenceString()
        {
            var fileInfo = new System.IO.FileInfo(ReferenceFilePath);
            //todo GetRelativePath 
            return $":r ..\\all\\{fileInfo.Name}";
        }

        private bool AddDatapatchReference(FileInfo fileInfo, string referenceString)
        {
            using (var streamWriter = fileInfo.AppendText())
            {
                streamWriter.WriteLine(referenceString);
            }

            return true;
        }
    }
}
