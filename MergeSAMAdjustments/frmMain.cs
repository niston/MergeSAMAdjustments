using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

// SAM Adjustment Merge Tool by niston

// kudos:
// isekaijin, river, ihate73 (##math @ libera.irc)
// irwiss, jmer (#csharp @ libera.irc)

// For system.numerics (Left-Handed): 
// Z is forward/back
// Y is up/down
// X is left/right

// For game (Right Handed):
// Z is up/down
// Y is forward/back
// X is left/right

namespace MergeSAMAdjustments
{
    public partial class frmMain : Form
    {
        public BindingList<string> SourceFiles { set; get; }
        public List<NiNode> NodesList { set; get; }

        public frmMain()
        {
            InitializeComponent();

            dgvSourceFiles.AutoGenerateColumns = false;

            SourceFiles = new();
            NodesList = new();           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvSourceFiles.DataSource = SourceFiles;
        }

        private void btnSourceClear_Click(object sender, EventArgs e)
        {
            SourceFiles = new();
            dgvSourceFiles.DataSource = SourceFiles;
        }

        private void btnSourceAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Source File(s)";
            ofd.Filter = "All files (*.*)|*.*|Json Files (*.json)|*.json";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    SourceFiles.Add(filePath);
                }                
            }
        }

        private void btnSourceRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSourceFiles.SelectedRows)
            {
                SourceFiles.RemoveAt(row.Index);
            }
        }

        private void btnSourceUp_Click(object sender, EventArgs e)
        {
            if (dgvSourceFiles.SelectedRows.Count > 0)
            {
                int curIndex = dgvSourceFiles.SelectedRows[0].Index;
                if (curIndex > 0)
                {
                    SourceFiles.Move(curIndex, curIndex - 1);
                    dgvSourceFiles.DataSource = SourceFiles;
                    dgvSourceFiles.Rows[curIndex].Selected = false;
                    dgvSourceFiles.Rows[curIndex - 1].Selected = true;
                }                
            }
        }

        private void btnSourceDown_Click(object sender, EventArgs e)
        {
            if (dgvSourceFiles.SelectedRows.Count > 0)
            {
                int curIndex = dgvSourceFiles.SelectedRows[0].Index;
                if (curIndex < SourceFiles.Count - 1)
                {
                    SourceFiles.Move(curIndex, curIndex + 1);
                    dgvSourceFiles.DataSource = SourceFiles;
                    dgvSourceFiles.Rows[curIndex].Selected = false;
                    dgvSourceFiles.Rows[curIndex + 1].Selected = true;
                }
            }
        }

        private void btnOutputSet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Set Merged Output File";
            sfd.Filter = "All files (*.*)|*.*|Json Files (*.json)|*.json";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = sfd.FileName;
            }
        }

        private void btnMergeStart_Click(object sender, EventArgs e)
        {
            NodesList = new();

            ParseSAMJson parser = new ParseSAMJson();
            foreach (string sourceFile in SourceFiles)
            {
                parser.Parse(NodesList, sourceFile);
            }

            WriteSAMJson writer = new WriteSAMJson();            
            writer.Write(NodesList, txtOutputPath.Text);

            // done
            MessageBox.Show(this, "Wrote merged file to: " + txtOutputPath.Text, "SAM Adjustment Merge Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvSourceFiles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                e.Value = dgvSourceFiles.Rows[e.RowIndex].DataBoundItem.ToString();
            }
            catch { }
        }

        private void lblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog(this);
        }
    }
}
