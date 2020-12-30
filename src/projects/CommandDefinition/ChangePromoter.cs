// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using EnvDTE;
using FilesProcessor;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SsdtProjectHelper.Common;
using Task = System.Threading.Tasks.Task;

namespace DatapatchWrapper
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ChangePromoter
    {
        private static DTE _dte;

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0101;
        private const string AllowedFilesPattern = ".all.sql";
        private const string AllowedExtension = ".sql";
        private const string TargetFileForPromotionPattern = "*.main.datapatch.sql";

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("2b5c526e-368f-47c2-81e3-3ea1eb7c79c7");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePromoter"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ChangePromoter(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ChangePromoter Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ChangePromoter's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new ChangePromoter(package, commandService);

            _dte = await package.GetServiceAsync(typeof(DTE)) as DTE;
            Assumes.Present(_dte);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var item = _dte.SelectedItems.Item(1).ProjectItem;

            if (
                item.Properties.Item("BuildAction").Value.ToString() != "None"
                ||
                item.Properties.Item("Extension").Value.ToString() != AllowedExtension
                ||
                !item.Properties.Item("FileName").Value.ToString().Contains(AllowedFilesPattern))
            {
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    Properties.Resource.ChangePromoterUsageWarning,
                    Properties.Resource.ChangePromoterTitle,
                    OLEMSGICON.OLEMSGICON_WARNING,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

                return;
            }
            else
            {
                var answer = VsShellUtilities.ShowMessageBox(
                    this.package,
                    Properties.Resource.ConfirmPromotionMessage,
                    Properties.Resource.ChangePromoterTitle,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_YESNO,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

                if (answer == (int)MessageBoxAnswer.No) { return; }
            }


            var filePath = item.Properties.Item("FullPath").Value.ToString();
            PromoteTheFileToDatapaches(filePath);
        }

        private void PromoteTheFileToDatapaches(string filePath)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var log = Package.GetGlobalService(typeof(SVsActivityLog)) as IVsActivityLog;

            var siblingFilesManager = new SiblingFilesManager(filePath: filePath, mainDatapatchPattern: TargetFileForPromotionPattern);
            var results = siblingFilesManager.ProcessFiles();

            if (log != null && results.Any())
            {
                foreach (var result in results)
                {
                    log.LogEntry(
                    (uint)result.ResultType,
                    ToString(),
                    string.Format(CultureInfo.CurrentCulture, "Promote the file to datapatches log: {0}", result.Content));
                }
            }
        }
    }


}
