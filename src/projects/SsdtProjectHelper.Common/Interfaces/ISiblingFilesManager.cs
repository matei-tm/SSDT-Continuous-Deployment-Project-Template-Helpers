// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace SsdtProjectHelper.Common.Interfaces
{
    public interface ISiblingFilesManager
    {
        string MainDatapatchPattern { get; }
        IList<ProcessingResult> ProcessingResults { get; }
        string ProjectRootFolder { get; }
        string ReferenceFilePath { get; }
        IEnumerable<string> SiblingPathsRelativeToProject { get; }

        void ProcessSingleFileAsPartialPath(string targetFilePartialPath);
        IList<ProcessingResult> ProcessAllFiles();
    }
}
