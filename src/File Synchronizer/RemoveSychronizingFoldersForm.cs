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
    public partial class RemoveSychronizingFoldersForm : Form
    {
        Popup parent;

        private readonly Image oneWayImage;
        private readonly Image twoWayImage;

        public RemoveSychronizingFoldersForm(Popup prnt)
        {
            InitializeComponent();

            parent = prnt;
            oneWayImage = File_Synchronizer.Properties.Resources.ow_sync;
            twoWayImage = File_Synchronizer.Properties.Resources.tw_sync;

            List<string> syncFolders = Program.appSettings.GetSetting("syncFolders");
            if (syncFolders == null)
                return;

            foreach (var pair in syncFolders)
            {
                string[] data = pair.Split(new char[] { '|' }, 3);
                if (data.Length != 3)
                    continue;

                bool isTwoWay;
                Boolean.TryParse(data[2], out isTwoWay);

                foldersList.Rows.Add(data[0], data[1], (!isTwoWay) ? oneWayImage : twoWayImage);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (DialogResult.Yes !=  MessageBox.Show("Do you really want to remove this folders pair?", "Folders remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
            }
            else
                return;


            bool isTwoWay = ((foldersList.Rows[e.RowIndex].Cells[2] as DataGridViewImageCell).Value as Image) == twoWayImage;
            bool result = Program.appSettings.RemoveSettingValue("syncFolders", foldersList.Rows[e.RowIndex].Cells[0].Value + "|" + foldersList.Rows[e.RowIndex].Cells[1].Value + "|" + isTwoWay.ToString());
            if (result)
                foldersList.Rows.RemoveAt(e.RowIndex);
            else
            {
                parent.trayIcon.BalloonTipText = "Folders has not been removed due to internal error";
                parent.trayIcon.ShowBalloonTip(1000);
            }

            if (foldersList.RowCount == 0)
                this.Close();
        }
    }
}
