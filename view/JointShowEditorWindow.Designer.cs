namespace BridgePresenter
{
    partial class JointShowEditorWindow
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
            this.jointShowName = new System.Windows.Forms.Label();
            this.jointShowNameTextBox = new System.Windows.Forms.TextBox();
            this.showOrderLabel = new System.Windows.Forms.Label();
            this.presentationsLabel = new System.Windows.Forms.Label();
            this.presentationListBox = new System.Windows.Forms.ListBox();
            this.orderListBox = new System.Windows.Forms.ListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.presentationsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addRemovePanel = new System.Windows.Forms.Panel();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.importPresentationDialog = new System.Windows.Forms.OpenFileDialog();
            this.importButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.presentationsPanel.SuspendLayout();
            this.addRemovePanel.SuspendLayout();
            this.orderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // jointShowName
            // 
            this.jointShowName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jointShowName.AutoSize = true;
            this.jointShowName.Location = new System.Drawing.Point(13, 13);
            this.jointShowName.Name = "jointShowName";
            this.jointShowName.Size = new System.Drawing.Size(93, 13);
            this.jointShowName.TabIndex = 0;
            this.jointShowName.Text = "Joint Show Name:";
            // 
            // jointShowNameTextBox
            // 
            this.jointShowNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jointShowNameTextBox.Location = new System.Drawing.Point(113, 13);
            this.jointShowNameTextBox.Name = "jointShowNameTextBox";
            this.jointShowNameTextBox.Size = new System.Drawing.Size(432, 20);
            this.jointShowNameTextBox.TabIndex = 1;
            // 
            // showOrderLabel
            // 
            this.showOrderLabel.AutoSize = true;
            this.showOrderLabel.Location = new System.Drawing.Point(292, 0);
            this.showOrderLabel.Name = "showOrderLabel";
            this.showOrderLabel.Size = new System.Drawing.Size(84, 13);
            this.showOrderLabel.TabIndex = 2;
            this.showOrderLabel.Text = "Joint show order";
            // 
            // presentationsLabel
            // 
            this.presentationsLabel.AutoSize = true;
            this.presentationsLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.presentationsLabel.Location = new System.Drawing.Point(3, 0);
            this.presentationsLabel.Name = "presentationsLabel";
            this.presentationsLabel.Size = new System.Drawing.Size(74, 20);
            this.presentationsLabel.TabIndex = 3;
            this.presentationsLabel.Text = "Presentations:";
            // 
            // presentationListBox
            // 
            this.presentationListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.presentationListBox.FormattingEnabled = true;
            this.presentationListBox.Location = new System.Drawing.Point(3, 23);
            this.presentationListBox.Name = "presentationListBox";
            this.presentationListBox.Size = new System.Drawing.Size(193, 177);
            this.presentationListBox.TabIndex = 4;
            // 
            // orderListBox
            // 
            this.orderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderListBox.FormattingEnabled = true;
            this.orderListBox.Location = new System.Drawing.Point(292, 23);
            this.orderListBox.Name = "orderListBox";
            this.orderListBox.Size = new System.Drawing.Size(193, 177);
            this.orderListBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(389, 248);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(470, 248);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(3, 62);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(78, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add >>";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(3, 91);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(78, 23);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // presentationsPanel
            // 
            this.presentationsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.presentationsPanel.ColumnCount = 4;
            this.presentationsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.presentationsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.presentationsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.presentationsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.presentationsPanel.Controls.Add(this.addRemovePanel, 1, 1);
            this.presentationsPanel.Controls.Add(this.presentationListBox, 0, 1);
            this.presentationsPanel.Controls.Add(this.presentationsLabel, 0, 0);
            this.presentationsPanel.Controls.Add(this.orderListBox, 2, 1);
            this.presentationsPanel.Controls.Add(this.showOrderLabel, 2, 0);
            this.presentationsPanel.Controls.Add(this.orderPanel, 3, 1);
            this.presentationsPanel.Location = new System.Drawing.Point(12, 39);
            this.presentationsPanel.Name = "presentationsPanel";
            this.presentationsPanel.RowCount = 2;
            this.presentationsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.presentationsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.presentationsPanel.Size = new System.Drawing.Size(533, 203);
            this.presentationsPanel.TabIndex = 10;
            // 
            // addRemovePanel
            // 
            this.addRemovePanel.Controls.Add(this.addButton);
            this.addRemovePanel.Controls.Add(this.removeButton);
            this.addRemovePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemovePanel.Location = new System.Drawing.Point(202, 23);
            this.addRemovePanel.Name = "addRemovePanel";
            this.addRemovePanel.Size = new System.Drawing.Size(84, 177);
            this.addRemovePanel.TabIndex = 11;
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.downButton);
            this.orderPanel.Controls.Add(this.upButton);
            this.orderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderPanel.Location = new System.Drawing.Point(491, 23);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(39, 177);
            this.orderPanel.TabIndex = 12;
            // 
            // downButton
            // 
            this.downButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downButton.BackgroundImage = global::BridgePresenter.Properties.Resources.downArrow;
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.downButton.Location = new System.Drawing.Point(4, 91);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(33, 33);
            this.downButton.TabIndex = 1;
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.upButton.BackgroundImage = global::BridgePresenter.Properties.Resources.upArrow;
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.upButton.Location = new System.Drawing.Point(4, 52);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(33, 33);
            this.upButton.TabIndex = 0;
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // importPresentationDialog
            // 
            this.importPresentationDialog.FileName = "openFileDialog1";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(12, 248);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 11;
            this.importButton.Text = "Import...";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(93, 248);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // JointShowEditorWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(557, 283);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.presentationsPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.jointShowNameTextBox);
            this.Controls.Add(this.jointShowName);
            this.MinimumSize = new System.Drawing.Size(435, 286);
            this.Name = "JointShowEditorWindow";
            this.Text = "Define Joint Show";
            this.presentationsPanel.ResumeLayout(false);
            this.presentationsPanel.PerformLayout();
            this.addRemovePanel.ResumeLayout(false);
            this.orderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label jointShowName;
        private System.Windows.Forms.TextBox jointShowNameTextBox;
        private System.Windows.Forms.Label showOrderLabel;
        private System.Windows.Forms.Label presentationsLabel;
        private System.Windows.Forms.ListBox presentationListBox;
        private System.Windows.Forms.ListBox orderListBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TableLayoutPanel presentationsPanel;
        private System.Windows.Forms.Panel addRemovePanel;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.OpenFileDialog importPresentationDialog;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button deleteButton;
    }
}