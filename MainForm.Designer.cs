
namespace DDSInjector
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ddsFileButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddsFileTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.rootFolderButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exportFolderTextBox = new System.Windows.Forms.TextBox();
            this.exportFolderButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rootFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.exportFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusLabel = new System.Windows.Forms.Label();
            this.injectButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.assetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideFormats = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "DDS to inject";
            // 
            // ddsFileButton
            // 
            this.ddsFileButton.AutoSize = true;
            this.ddsFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddsFileButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ddsFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddsFileButton.Location = new System.Drawing.Point(542, 0);
            this.ddsFileButton.Name = "ddsFileButton";
            this.ddsFileButton.Size = new System.Drawing.Size(52, 23);
            this.ddsFileButton.TabIndex = 2;
            this.ddsFileButton.Text = "Select";
            this.ddsFileButton.UseVisualStyleBackColor = true;
            this.ddsFileButton.Click += new System.EventHandler(this.ddsFileButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.ddsFileTextBox);
            this.panel1.Controls.Add(this.ddsFileButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 28);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 23);
            this.panel1.TabIndex = 2;
            // 
            // ddsFileTextBox
            // 
            this.ddsFileTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddsFileTextBox.Location = new System.Drawing.Point(0, 0);
            this.ddsFileTextBox.Name = "ddsFileTextBox";
            this.ddsFileTextBox.Size = new System.Drawing.Size(542, 23);
            this.ddsFileTextBox.TabIndex = 1;
            this.ddsFileTextBox.TextChanged += new System.EventHandler(this.ddsFileTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.label2.Size = new System.Drawing.Size(157, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Root folder of original assets";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.rootFolderTextBox);
            this.panel2.Controls.Add(this.rootFolderButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 79);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 23);
            this.panel2.TabIndex = 4;
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootFolderTextBox.Location = new System.Drawing.Point(0, 0);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(542, 23);
            this.rootFolderTextBox.TabIndex = 3;
            this.rootFolderTextBox.TextChanged += new System.EventHandler(this.rootFolderTextBox_TextChanged);
            // 
            // rootFolderButton
            // 
            this.rootFolderButton.AutoSize = true;
            this.rootFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rootFolderButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.rootFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rootFolderButton.Location = new System.Drawing.Point(542, 0);
            this.rootFolderButton.Name = "rootFolderButton";
            this.rootFolderButton.Size = new System.Drawing.Size(52, 23);
            this.rootFolderButton.TabIndex = 4;
            this.rootFolderButton.Text = "Select";
            this.rootFolderButton.UseVisualStyleBackColor = true;
            this.rootFolderButton.Click += new System.EventHandler(this.rootFolderButton_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.exportFolderTextBox);
            this.panel3.Controls.Add(this.exportFolderButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 130);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 23);
            this.panel3.TabIndex = 6;
            // 
            // exportFolderTextBox
            // 
            this.exportFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportFolderTextBox.Location = new System.Drawing.Point(0, 0);
            this.exportFolderTextBox.Name = "exportFolderTextBox";
            this.exportFolderTextBox.Size = new System.Drawing.Size(542, 23);
            this.exportFolderTextBox.TabIndex = 3;
            this.exportFolderTextBox.TextChanged += new System.EventHandler(this.exportFolderTextBox_TextChanged);
            // 
            // exportFolderButton
            // 
            this.exportFolderButton.AutoSize = true;
            this.exportFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportFolderButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exportFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportFolderButton.Location = new System.Drawing.Point(542, 0);
            this.exportFolderButton.Name = "exportFolderButton";
            this.exportFolderButton.Size = new System.Drawing.Size(52, 23);
            this.exportFolderButton.TabIndex = 4;
            this.exportFolderButton.Text = "Select";
            this.exportFolderButton.UseVisualStyleBackColor = true;
            this.exportFolderButton.Click += new System.EventHandler(this.exportFolderButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.label3.Size = new System.Drawing.Size(75, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Export folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(10, 153);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.label4.Size = new System.Drawing.Size(138, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Compatible assets found";
            // 
            // rootFolderBrowser
            // 
            this.rootFolderBrowser.Description = "Select the root folder where the original assets are saved";
            this.rootFolderBrowser.UseDescriptionForTitle = true;
            // 
            // exportFolderBrowser
            // 
            this.exportFolderBrowser.Description = "Select where the injected files will be saved";
            this.exportFolderBrowser.UseDescriptionForTitle = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.statusLabel.Location = new System.Drawing.Point(0, 20);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 15);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Status";
            // 
            // injectButton
            // 
            this.injectButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.injectButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.injectButton.Enabled = false;
            this.injectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.injectButton.Location = new System.Drawing.Point(519, 5);
            this.injectButton.MinimumSize = new System.Drawing.Size(0, 30);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(75, 30);
            this.injectButton.TabIndex = 0;
            this.injectButton.Text = "Inject";
            this.injectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.injectButton.UseVisualStyleBackColor = false;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.injectButton);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.statusLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 411);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel5.Size = new System.Drawing.Size(594, 35);
            this.panel5.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(594, 0);
            this.panel7.TabIndex = 10;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assetName,
            this.assetFormat,
            this.assetPath});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(10, 181);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(594, 211);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // assetName
            // 
            this.assetName.HeaderText = "Name";
            this.assetName.Name = "assetName";
            this.assetName.ReadOnly = true;
            this.assetName.Width = 200;
            // 
            // assetFormat
            // 
            this.assetFormat.HeaderText = "Format";
            this.assetFormat.Name = "assetFormat";
            this.assetFormat.ReadOnly = true;
            this.assetFormat.Width = 55;
            // 
            // assetPath
            // 
            this.assetPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.assetPath.HeaderText = "Path";
            this.assetPath.Name = "assetPath";
            this.assetPath.ReadOnly = true;
            // 
            // hideFormats
            // 
            this.hideFormats.AutoSize = true;
            this.hideFormats.Checked = true;
            this.hideFormats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideFormats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideFormats.Location = new System.Drawing.Point(10, 392);
            this.hideFormats.Name = "hideFormats";
            this.hideFormats.Size = new System.Drawing.Size(594, 19);
            this.hideFormats.TabIndex = 16;
            this.hideFormats.Text = "Hide incompatible formats";
            this.hideFormats.UseVisualStyleBackColor = true;
            this.hideFormats.CheckedChanged += new System.EventHandler(this.hideFormats_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 456);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.hideFormats);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.Text = "DDS Injector";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ddsFileButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ddsFileTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Button rootFolderButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox exportFolderTextBox;
        private System.Windows.Forms.Button exportFolderButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog rootFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog exportFolderBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetPath;
        private System.Windows.Forms.CheckBox hideFormats;
    }
}

