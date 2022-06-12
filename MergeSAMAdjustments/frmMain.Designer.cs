
namespace MergeSAMAdjustments
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSourceFiles = new System.Windows.Forms.DataGridView();
            this.colSourceFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSourceClear = new System.Windows.Forms.Button();
            this.btnSourceDown = new System.Windows.Forms.Button();
            this.btnSourceUp = new System.Windows.Forms.Button();
            this.btnSourceRemove = new System.Windows.Forms.Button();
            this.btnSourceAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOutputSet = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAbout = new System.Windows.Forms.LinkLabel();
            this.btnMergeStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceFiles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvSourceFiles);
            this.groupBox1.Controls.Add(this.btnSourceClear);
            this.groupBox1.Controls.Add(this.btnSourceDown);
            this.groupBox1.Controls.Add(this.btnSourceUp);
            this.groupBox1.Controls.Add(this.btnSourceRemove);
            this.groupBox1.Controls.Add(this.btnSourceAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 261);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source File Paths";
            // 
            // dgvSourceFiles
            // 
            this.dgvSourceFiles.AllowUserToAddRows = false;
            this.dgvSourceFiles.AllowUserToDeleteRows = false;
            this.dgvSourceFiles.AllowUserToResizeColumns = false;
            this.dgvSourceFiles.AllowUserToResizeRows = false;
            this.dgvSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSourceFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSourceFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSourceFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSourceFile});
            this.dgvSourceFiles.Location = new System.Drawing.Point(6, 22);
            this.dgvSourceFiles.Name = "dgvSourceFiles";
            this.dgvSourceFiles.RowHeadersVisible = false;
            this.dgvSourceFiles.RowTemplate.Height = 25;
            this.dgvSourceFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSourceFiles.Size = new System.Drawing.Size(764, 200);
            this.dgvSourceFiles.TabIndex = 6;
            this.dgvSourceFiles.VirtualMode = true;
            this.dgvSourceFiles.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvSourceFiles_CellValueNeeded);
            // 
            // colSourceFile
            // 
            this.colSourceFile.HeaderText = "Filename";
            this.colSourceFile.Name = "colSourceFile";
            this.colSourceFile.ReadOnly = true;
            this.colSourceFile.Width = 735;
            // 
            // btnSourceClear
            // 
            this.btnSourceClear.Location = new System.Drawing.Point(6, 228);
            this.btnSourceClear.Name = "btnSourceClear";
            this.btnSourceClear.Size = new System.Drawing.Size(75, 23);
            this.btnSourceClear.TabIndex = 5;
            this.btnSourceClear.Text = "Clear";
            this.btnSourceClear.UseVisualStyleBackColor = true;
            this.btnSourceClear.Click += new System.EventHandler(this.btnSourceClear_Click);
            // 
            // btnSourceDown
            // 
            this.btnSourceDown.Location = new System.Drawing.Point(512, 228);
            this.btnSourceDown.Name = "btnSourceDown";
            this.btnSourceDown.Size = new System.Drawing.Size(75, 23);
            this.btnSourceDown.TabIndex = 4;
            this.btnSourceDown.Text = "Down";
            this.btnSourceDown.UseVisualStyleBackColor = true;
            this.btnSourceDown.Click += new System.EventHandler(this.btnSourceDown_Click);
            // 
            // btnSourceUp
            // 
            this.btnSourceUp.Location = new System.Drawing.Point(431, 228);
            this.btnSourceUp.Name = "btnSourceUp";
            this.btnSourceUp.Size = new System.Drawing.Size(75, 23);
            this.btnSourceUp.TabIndex = 3;
            this.btnSourceUp.Text = "Up";
            this.btnSourceUp.UseVisualStyleBackColor = true;
            this.btnSourceUp.Click += new System.EventHandler(this.btnSourceUp_Click);
            // 
            // btnSourceRemove
            // 
            this.btnSourceRemove.Location = new System.Drawing.Point(614, 228);
            this.btnSourceRemove.Name = "btnSourceRemove";
            this.btnSourceRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSourceRemove.TabIndex = 2;
            this.btnSourceRemove.Text = "Remove";
            this.btnSourceRemove.UseVisualStyleBackColor = true;
            this.btnSourceRemove.Click += new System.EventHandler(this.btnSourceRemove_Click);
            // 
            // btnSourceAdd
            // 
            this.btnSourceAdd.Location = new System.Drawing.Point(695, 228);
            this.btnSourceAdd.Name = "btnSourceAdd";
            this.btnSourceAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSourceAdd.TabIndex = 1;
            this.btnSourceAdd.Text = "Add..";
            this.btnSourceAdd.UseVisualStyleBackColor = true;
            this.btnSourceAdd.Click += new System.EventHandler(this.btnSourceAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOutputSet);
            this.groupBox2.Controls.Add(this.txtOutputPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output File Path";
            // 
            // btnOutputSet
            // 
            this.btnOutputSet.Location = new System.Drawing.Point(695, 51);
            this.btnOutputSet.Name = "btnOutputSet";
            this.btnOutputSet.Size = new System.Drawing.Size(75, 23);
            this.btnOutputSet.TabIndex = 1;
            this.btnOutputSet.Text = "Set...";
            this.btnOutputSet.UseVisualStyleBackColor = true;
            this.btnOutputSet.Click += new System.EventHandler(this.btnOutputSet_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(6, 22);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(764, 23);
            this.txtOutputPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblAbout);
            this.groupBox3.Controls.Add(this.btnMergeStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 371);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Merge";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(15, 26);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(49, 15);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.TabStop = true;
            this.lblAbout.Text = "About...";
            this.lblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAbout_LinkClicked);
            // 
            // btnMergeStart
            // 
            this.btnMergeStart.Location = new System.Drawing.Point(695, 22);
            this.btnMergeStart.Name = "btnMergeStart";
            this.btnMergeStart.Size = new System.Drawing.Size(75, 23);
            this.btnMergeStart.TabIndex = 0;
            this.btnMergeStart.Text = "Start";
            this.btnMergeStart.UseVisualStyleBackColor = true;
            this.btnMergeStart.Click += new System.EventHandler(this.btnMergeStart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(817, 480);
            this.Name = "frmMain";
            this.Text = "SAM Adjustment Merge Tool by niston";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceFiles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSourceDown;
        private System.Windows.Forms.Button btnSourceUp;
        private System.Windows.Forms.Button btnSourceRemove;
        private System.Windows.Forms.Button btnSourceAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOutputSet;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMergeStart;
        private System.Windows.Forms.Button btnSourceClear;
        private System.Windows.Forms.DataGridView dgvSourceFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceFile;
        private System.Windows.Forms.LinkLabel lblAbout;
    }
}