// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FilesProcessor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SsdtProjectHelper.Common;
using SsdtProjectHelper.Common.Interfaces;
using SsdtProjectHelper.UI;
using Task = System.Threading.Tasks.Task;

namespace DatapatchWrapper
{
    internal sealed class Factory
    {
        private const string DefaultSetName = "all";
        private const string ProjectConfigFileName = "ssdtprojecthelper.config";
        private static readonly Dictionary<string, IProjectConfigurationStore> s_projectStores = new Dictionary<string, IProjectConfigurationStore>();
        private readonly Microsoft.VisualStudio.Shell.IAsyncServiceProvider package;
        public static Factory Instance
        {
            get;
            private set;
        }

        private Factory(AsyncPackage package)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
        }


        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);
            Instance = new Factory(package);
        }


        public IConfigurationDialog GetDialog(string projectFullName, string itemFullPath, string targetFileForPromotionPattern)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var configurationStore = GetProjectConfigurationStore(projectFullName);
            var projectRootFolder = Path.GetDirectoryName(projectFullName);
            var siblingFilesManager = GetSiblingFilesManager(referenceFilePath: itemFullPath, mainDatapatchPattern: targetFileForPromotionPattern, projectRootFolder: projectRootFolder);
            var siblingsFileInfoList = siblingFilesManager.SiblingPathsRelativeToProject;

            if (!configurationStore.HasConfiguration)
            {
                configurationStore.CreateDefaultConfiguration(siblingsFileInfoList.ToList());
            }

            var serviceProvider = (IServiceProvider)ServiceProvider;
            var uiShell = serviceProvider.GetService(typeof(SVsUIShell)) as IVsUIShell;
            var log = serviceProvider.GetService(typeof(SVsActivityLog)) as IVsActivityLog;
            var dialog = new DestinationPicker(configurationStore, siblingFilesManager, uiShell, log) as IConfigurationDialog;

            return dialog;
        }

        public static IProjectConfigurationStore GetProjectConfigurationStore(string projectFullName)
        {

            if (s_projectStores.ContainsKey(projectFullName))
            {
                return s_projectStores[projectFullName];
            }
            else
            {
                IProjectConfigurationStore store;

                store = new ProjectConfigurationStore(projectFullName, DefaultSetName, ProjectConfigFileName);

                s_projectStores.Add(projectFullName, store);
                return store;
            }
        }

        public ISiblingFilesManager GetSiblingFilesManager(string referenceFilePath, string mainDatapatchPattern, string projectRootFolder)
        {
            var filesManager = new SiblingFilesManager(referenceFilePath, mainDatapatchPattern, projectRootFolder);
            return filesManager;
        }

        internal static void Cleanup()
        {
            s_projectStores.Clear();
        }
    }
}
