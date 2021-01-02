// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace SsdtProjectHelper.Common.Interfaces
{
    public interface IProjectConfigurationStore
    {
        Dictionary<string, IList<string>> PromotionSetsDictionary { get; }

        bool HasConfiguration { get; }
        string ProjectFullName { get; }

        string DefaultSetName { get; }

        void CreateDefaultConfiguration(IList<string> siblingsRelativePathList);

        void SaveCollection(string savedCollectionName, IList<string> newSelectionSet);
    }
}
