// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


namespace SsdtProjectHelper.UI
{
    partial class DestinationPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DestinationPicker));
            this.CheckedListBoxSiblings = new System.Windows.Forms.CheckedListBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.CheckBoxAddAll = new System.Windows.Forms.CheckBox();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.TextBoxCollectionName = new System.Windows.Forms.TextBox();
            this.ButtonSaveCollection = new System.Windows.Forms.Button();
            this.ComboBoxSavedCollections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckedListBoxSiblings
            // 
            this.CheckedListBoxSiblings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBoxSiblings.FormattingEnabled = true;
            this.CheckedListBoxSiblings.HorizontalScrollbar = true;
            this.CheckedListBoxSiblings.Location = new System.Drawing.Point(12, 70);
            this.CheckedListBoxSiblings.Name = "CheckedListBoxSiblings";
            this.CheckedListBoxSiblings.Size = new System.Drawing.Size(801, 184);
            this.CheckedListBoxSiblings.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(657, 265);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(738, 265);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // CheckBoxAddAll
            // 
            this.CheckBoxAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxAddAll.AutoSize = true;
            this.CheckBoxAddAll.Location = new System.Drawing.Point(12, 268);
            this.CheckBoxAddAll.Name = "CheckBoxAddAll";
            this.CheckBoxAddAll.Size = new System.Drawing.Size(83, 17);
            this.CheckBoxAddAll.TabIndex = 3;
            this.CheckBoxAddAll.Text = "Preselect all";
            this.CheckBoxAddAll.UseVisualStyleBackColor = true;
            this.CheckBoxAddAll.CheckedChanged += new System.EventHandler(this.CheckBoxAddAll_CheckedChanged);
            // 
            // LabelInfo
            // 
            this.LabelInfo.AutoSize = true;
            this.LabelInfo.Location = new System.Drawing.Point(12, 54);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(179, 13);
            this.LabelInfo.TabIndex = 4;
            this.LabelInfo.Text = "Choose the destination for promoting";
            // 
            // TextBoxCollectionName
            // 
            this.TextBoxCollectionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxCollectionName.Location = new System.Drawing.Point(147, 265);
            this.TextBoxCollectionName.Name = "TextBoxCollectionName";
            this.TextBoxCollectionName.Size = new System.Drawing.Size(207, 20);
            this.TextBoxCollectionName.TabIndex = 5;
            this.TextBoxCollectionName.TextChanged += new System.EventHandler(this.TextBoxCollectionName_TextChanged);
            // 
            // ButtonSaveCollection
            // 
            this.ButtonSaveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSaveCollection.Location = new System.Drawing.Point(360, 264);
            this.ButtonSaveCollection.Name = "ButtonSaveCollection";
            this.ButtonSaveCollection.Size = new System.Drawing.Size(75, 23);
            this.ButtonSaveCollection.TabIndex = 6;
            this.ButtonSaveCollection.Text = "Save";
            this.ButtonSaveCollection.UseVisualStyleBackColor = true;
            this.ButtonSaveCollection.Click += new System.EventHandler(this.ButtonSaveCollection_Click);
            // 
            // ComboBoxSavedCollections
            // 
            this.ComboBoxSavedCollections.FormattingEnabled = true;
            this.ComboBoxSavedCollections.Location = new System.Drawing.Point(147, 12);
            this.ComboBoxSavedCollections.Name = "ComboBoxSavedCollections";
            this.ComboBoxSavedCollections.Size = new System.Drawing.Size(207, 21);
            this.ComboBoxSavedCollections.TabIndex = 7;
            this.ComboBoxSavedCollections.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSavedCollections_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select a saved collection:";
            // 
            // DestinationPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 303);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxSavedCollections);
            this.Controls.Add(this.ButtonSaveCollection);
            this.Controls.Add(this.TextBoxCollectionName);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.CheckBoxAddAll);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.CheckedListBoxSiblings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DestinationPicker";
            this.Text = "Destination Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckedListBoxSiblings;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.CheckBox CheckBoxAddAll;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.TextBox TextBoxCollectionName;
        private System.Windows.Forms.Button ButtonSaveCollection;
        private System.Windows.Forms.ComboBox ComboBoxSavedCollections;
        private System.Windows.Forms.Label label1;
    }
}
