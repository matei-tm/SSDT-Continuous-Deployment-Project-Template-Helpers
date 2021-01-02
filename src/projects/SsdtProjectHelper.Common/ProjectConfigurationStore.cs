// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SsdtProjectHelper.Common.Interfaces;

namespace SsdtProjectHelper.Common
{
    public class ProjectConfigurationStore : IProjectConfigurationStore
    {
        private Dictionary<string, IList<string>> _promotionSetsDictionary;

        public string ProjectConfigFileName { get; private set; }
        public string DefaultSetName { get; private set; }
        public string ProjectFullName { get; private set; }

        public ProjectConfigurationStore(string projectFullName, string defaultSetName, string projectConfigFileName)
        {
            ProjectFullName = projectFullName;
            DefaultSetName = defaultSetName;
            ProjectConfigFileName = projectConfigFileName;
            ReadConfigFromProject();
        }

        public Dictionary<string, IList<string>> PromotionSetsDictionary
        {
            get { return _promotionSetsDictionary; }
        }

        public bool HasConfiguration
        {
            get
            {
                return _promotionSetsDictionary.Count > 0;
            }
        }

        public void CreateDefaultConfiguration(IList<string> siblingsRelativePathList)
        {
            AddNewPromotionSet(DefaultSetName, siblingsRelativePathList);
        }

        public void SaveCollection(string savedCollectionName, IList<string> newSelectionSet)
        {
            if (PromotionSetsDictionary.ContainsKey(savedCollectionName))
            {
                PromotionSetsDictionary.Remove(savedCollectionName);
            }

            AddNewPromotionSet(savedCollectionName, newSelectionSet);
            PersistPromotionSets();
        }

        private void AddNewPromotionSet(string setName, IList<string> siblingsRelativePathList)
        {
            if (_promotionSetsDictionary.ContainsKey(setName))
            {
                _promotionSetsDictionary[setName] = siblingsRelativePathList;
            }
            else
            {
                _promotionSetsDictionary.Add(setName, siblingsRelativePathList);
            }
        }

        private void ReadConfigFromProject()
        {
            var projectFolder = Path.GetDirectoryName(ProjectFullName);

            var configFile = Path.Combine(projectFolder, ProjectConfigFileName);

            if (File.Exists(configFile))
            {
                var jsonString = File.ReadAllText(configFile);
                _promotionSetsDictionary = JsonConvert.DeserializeObject<Dictionary<string, IList<string>>>(jsonString);
            }
            else
            {
                _promotionSetsDictionary = new Dictionary<string, IList<string>>();
            }
        }

        private void PersistPromotionSets()
        {
            var projectFolder = Path.GetDirectoryName(ProjectFullName);

            var configFile = Path.Combine(projectFolder, ProjectConfigFileName);

            using (var file = File.CreateText(configFile))
            {
                var serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                serializer.Serialize(file, _promotionSetsDictionary);
            }
        }
    }
}
