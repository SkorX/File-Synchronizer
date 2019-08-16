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
    public partial class FailedSynchronizingFilesForm : Form
    {
        public FailedSynchronizingFilesForm()
        {
            InitializeComponent();

            List<string> failedFiles = Program.syncWorker.skippedFilesList;
            if (failedFiles == null)
                return;

            foreach (var filePath in failedFiles)
            {
                failedFilesList.Rows.Add(null, filePath);
            }
        }

        public void UpdateList()
        {
            Invoke((MethodInvoker) delegate() {
                List < string > failedFiles = Program.syncWorker.skippedFilesList;
                if (failedFiles == null)
                    return;

                failedFilesList.Rows.Clear();
                foreach (var filePath in failedFiles)
                {
                    failedFilesList.Rows.Add(null, filePath);
                }
            });
        }
    }
}
