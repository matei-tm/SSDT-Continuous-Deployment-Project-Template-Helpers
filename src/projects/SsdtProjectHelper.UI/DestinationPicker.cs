// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell.Interop;
using SsdtProjectHelper.Common;
using SsdtProjectHelper.Common.Interfaces;

namespace SsdtProjectHelper.UI
{
    public partial class DestinationPicker : Form, IConfigurationDialog
    {
        private readonly ISiblingFilesManager _siblingFilesManager;

        private readonly IProjectConfigurationStore _configurationStore;
        private readonly IVsUIShell _uiShell;
        private readonly IVsActivityLog _activityLog;

        public DestinationPicker(IProjectConfigurationStore configurationStore, ISiblingFilesManager siblingFilesManager, IVsUIShell uIShell, IVsActivityLog activityLog)
        {
            _configurationStore = configurationStore;
            _siblingFilesManager = siblingFilesManager;
            _uiShell = uIShell;
            _activityLog = activityLog;

            InitializeComponent();
        }

        public void Invoke()
        {
            InitializeSiblings();

            if (_uiShell == null)
            {
                Debug.Fail("Failed to get SVsUIShell service.");
                return;
            }

            IntPtr hwndOwner = IntPtr.Zero;
            _uiShell.GetDialogOwnerHwnd(out hwndOwner);

            _uiShell.EnableModeless(0);
            try
            {
                ShowDialog(new NativeHwndWrapper(hwndOwner));
            }
            finally
            {
                _uiShell.EnableModeless(1);
            }
        }

        private void InitializeSiblings()
        {
            var siblingsFileInfoList = _siblingFilesManager.SiblingPathsRelativeToProject;

            CheckedListBoxSiblings.Items.AddRange(siblingsFileInfoList.ToArray());

            ComboBoxSavedCollections.Items.AddRange(_configurationStore.PromotionSetsDictionary.Keys.ToArray<string>());
            ComboBoxSavedCollections.SelectedItem = _configurationStore.DefaultSetName;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            PromoteTheFileToDatapaches();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PromoteTheFileToDatapaches()
        {
            if (CheckedListBoxSiblings.CheckedItems.Count != 0)
            {
                for (var i = 0; i < CheckedListBoxSiblings.CheckedItems.Count; i++)
                {
                    var path = CheckedListBoxSiblings.CheckedItems[i].ToString();
                    _siblingFilesManager.ProcessSingleFileAsPartialPath(path);
                }

                var results = _siblingFilesManager.ProcessingResults;
                LogResults(results);
            }
        }

        private void LogResults(IList<ProcessingResult> results)
        {
            if (_activityLog != null && results.Any())
            {
                foreach (var result in results)
                {
                    _activityLog.LogEntry(
                    (uint)result.ResultType,
                    ToString(),
                    string.Format(CultureInfo.CurrentCulture, "Promote the file to datapatches log: {0}", result.Content));
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CheckBoxAddAll_CheckedChanged(object sender, EventArgs e)
        {
            var newValue = CheckBoxAddAll.Checked;
            SwitchCheckedList(newValue);

        }

        private void SwitchCheckedList(bool newValue)
        {
            for (var i = 0; i < CheckedListBoxSiblings.Items.Count; i++)
            {
                CheckedListBoxSiblings.SetItemChecked(i, newValue);
            }
        }

        private void ButtonSaveCollection_Click(object sender, EventArgs e)
        {
            var savedCollectionName = TextBoxCollectionName.Text;
            if (string.IsNullOrEmpty(savedCollectionName))
            {
                return;
            }

            IList<string> newSelectionSet = CheckedListBoxSiblings.CheckedItems.OfType<string>().ToList();
            if (!newSelectionSet.Any()) { return; }

            _configurationStore.SaveCollection(savedCollectionName, newSelectionSet);

            TryAddToComboBoxSavedCollections(savedCollectionName);
        }

        private void TryAddToComboBoxSavedCollections(string savedCollectionName)
        {
            if (!ComboBoxSavedCollections.Items.Contains(savedCollectionName))
            {
                ComboBoxSavedCollections.Items.Add(savedCollectionName);
                ComboBoxSavedCollections.SelectedItem = savedCollectionName;
            }
        }

        private void ComboBoxSavedCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedSet = comboBox.SelectedItem as string;

            RefreshCheckedListBoxSiblings(selectedSet);

            MatchTextBoxCollectionName(selectedSet);
        }

        private void MatchTextBoxCollectionName(string selectedSet)
        {
            if (TextBoxCollectionName.Text != selectedSet)
            {
                TextBoxCollectionName.Text = selectedSet;
            }
        }

        private void RefreshCheckedListBoxSiblings(string selectedSet)
        {
            CheckedListBoxSiblings.ClearSelected();
            SwitchCheckedList(false);

            for (var i = 0; i < CheckedListBoxSiblings.Items.Count; i++)
            {
                var item = CheckedListBoxSiblings.Items[i].ToString();
                if (_configurationStore.PromotionSetsDictionary[selectedSet].Contains(item))
                {
                    CheckedListBoxSiblings.SetItemChecked(i, true);
                }
            }
        }

        private void TextBoxCollectionName_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var textBoxText = textBox.Text;

            ButtonSaveCollection.Enabled = !string.IsNullOrEmpty(textBoxText) && IsTheSetNewOrSelectedExisting(textBoxText);
        }

        private bool IsTheSetNewOrSelectedExisting(string textBoxText)
        {
            return !ComboBoxSavedCollections.Items.Contains(textBoxText) || ComboBoxSavedCollections.SelectedItem.ToString() == textBoxText;
        }
    }
}
