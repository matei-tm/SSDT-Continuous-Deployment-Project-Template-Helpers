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
            this.LabelCombo = new System.Windows.Forms.Label();
            this.LabelPromotionSource = new System.Windows.Forms.Label();
            this.TextBoxPromotionSource = new System.Windows.Forms.TextBox();
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
            this.CheckedListBoxSiblings.Size = new System.Drawing.Size(833, 229);
            this.CheckedListBoxSiblings.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(583, 306);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(128, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(717, 306);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(128, 23);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "Apply changes";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // CheckBoxAddAll
            // 
            this.CheckBoxAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxAddAll.AutoSize = true;
            this.CheckBoxAddAll.Location = new System.Drawing.Point(12, 310);
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
            this.LabelInfo.Size = new System.Drawing.Size(430, 13);
            this.LabelInfo.TabIndex = 4;
            this.LabelInfo.Text = "Choose the destination for promoting. The changes will be applied to all the sele" +
    "cted items";
            // 
            // TextBoxCollectionName
            // 
            this.TextBoxCollectionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxCollectionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TextBoxCollectionName.Location = new System.Drawing.Point(147, 307);
            this.TextBoxCollectionName.MaxLength = 30;
            this.TextBoxCollectionName.Name = "TextBoxCollectionName";
            this.TextBoxCollectionName.Size = new System.Drawing.Size(207, 20);
            this.TextBoxCollectionName.TabIndex = 5;
            this.TextBoxCollectionName.TextChanged += new System.EventHandler(this.TextBoxCollectionName_TextChanged);
            // 
            // ButtonSaveCollection
            // 
            this.ButtonSaveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSaveCollection.Location = new System.Drawing.Point(360, 306);
            this.ButtonSaveCollection.Name = "ButtonSaveCollection";
            this.ButtonSaveCollection.Size = new System.Drawing.Size(128, 23);
            this.ButtonSaveCollection.TabIndex = 6;
            this.ButtonSaveCollection.Text = "Save configuration";
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
            // LabelCombo
            // 
            this.LabelCombo.AutoSize = true;
            this.LabelCombo.Location = new System.Drawing.Point(12, 16);
            this.LabelCombo.Name = "LabelCombo";
            this.LabelCombo.Size = new System.Drawing.Size(129, 13);
            this.LabelCombo.TabIndex = 8;
            this.LabelCombo.Text = "Select a saved collection:";
            // 
            // LabelPromotionSource
            // 
            this.LabelPromotionSource.AutoSize = true;
            this.LabelPromotionSource.Location = new System.Drawing.Point(372, 16);
            this.LabelPromotionSource.Name = "LabelPromotionSource";
            this.LabelPromotionSource.Size = new System.Drawing.Size(60, 13);
            this.LabelPromotionSource.TabIndex = 9;
            this.LabelPromotionSource.Text = "Reference:";
            // 
            // TextBoxPromotionSource
            // 
            this.TextBoxPromotionSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPromotionSource.Location = new System.Drawing.Point(438, 12);
            this.TextBoxPromotionSource.Name = "TextBoxPromotionSource";
            this.TextBoxPromotionSource.ReadOnly = true;
            this.TextBoxPromotionSource.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBoxPromotionSource.Size = new System.Drawing.Size(407, 20);
            this.TextBoxPromotionSource.TabIndex = 10;
            this.TextBoxPromotionSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DestinationPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 339);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxPromotionSource);
            this.Controls.Add(this.LabelPromotionSource);
            this.Controls.Add(this.LabelCombo);
            this.Controls.Add(this.ComboBoxSavedCollections);
            this.Controls.Add(this.ButtonSaveCollection);
            this.Controls.Add(this.TextBoxCollectionName);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.CheckBoxAddAll);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.CheckedListBoxSiblings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 300);
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
        private System.Windows.Forms.Label LabelCombo;
        private System.Windows.Forms.Label LabelPromotionSource;
        private System.Windows.Forms.TextBox TextBoxPromotionSource;
    }
}
