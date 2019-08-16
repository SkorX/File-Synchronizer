using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    public partial class AddSynchronizingFoldersForm : Form
    {
        public delegate void FoldersChosenHandler(object sender, FoldersChosenEventArgs e);

        public event FoldersChosenHandler FoldersChosen;


        public AddSynchronizingFoldersForm()
        {
            InitializeComponent();
        }

        private void sourceBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = sourceFolder.ShowDialog();
            if (result == DialogResult.OK)
                sourceFolderPathText.Text = sourceFolder.SelectedPath;
        }

        private void destBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = destFolder.ShowDialog();
            if (result == DialogResult.OK)
                destFolderPathText.Text = destFolder.SelectedPath;
        }

        private void sourceFolder_HelpRequest(object sender, EventArgs e)
        {
            //sourceFolderPathText.Text = sourceFolder.SelectedPath;
        }

        private void destFolder_HelpRequest(object sender, EventArgs e)
        {
            //destFolderPathText.Text = destFolder.SelectedPath;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            FoldersChosen(this, new FoldersChosenEventArgs(sourceFolderPathText.Text, destFolderPathText.Text, twoWayCheckbox.Checked));
            this.Dispose();
        }
    }

    public class FoldersChosenEventArgs : System.EventArgs
    {
        private string srcFolder;
        private string destFolder;
        private bool   twoWay;

        public FoldersChosenEventArgs(string srcF, string destF, bool twoWay = false)
        {
            this.srcFolder  = srcF;
            this.destFolder = destF;
            this.twoWay     = twoWay;
        }

        public string SourceFolder
        {
            get
            {
                return srcFolder;
            }
        }

        public string DestinationFolder
        {
            get
            {
                return destFolder;
            }
        }

        public bool IsTwoWay
        {
            get
            {
                return twoWay;
            }
        }
    }
}