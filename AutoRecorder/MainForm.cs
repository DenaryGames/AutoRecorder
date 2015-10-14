using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRecorder
{
    public partial class MainForm : Form
    {

        RecordingList RecList;
        Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();
            this.AddColumns();
            listView.Update();

        }

        //Upload
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upload();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void ShowRecordings(RecordingList list)
        {
            listView.Clear();
            listView.Update();
            this.AddColumns();
            listView.Update();
            foreach (Recording record in list.Records)
            {
                String[] row = { Convert.ToString(record.Enabled), record.DayNames, record.TimeString, record.Channel, record.Directory };
                listView.Items.Add(record.Title).SubItems.AddRange(row);
            }
            listView.Update();
        }

        private void AddColumns()
        {
            listView.Columns.Add("Title", 200);
            listView.Columns.Add("Enabled", 60);
            listView.Columns.Add("Days", 200);
            listView.Columns.Add("Time", 150);
            listView.Columns.Add("Channel", 70);
            listView.Columns.Add("Directory", 200);
        }

        private void Download()
        {
            toolStatus.Text = "Connecting...";
            this.Refresh();
            settings.ReadSettings();
            TelnetHandler telnet = new TelnetHandler(settings);

            toolProgress.Value = 10;
            this.Refresh();
            telnet.Connect(toolStatus, toolProgress);
            this.Refresh();

            toolProgress.Value = 85;
            toolStatus.Text = "Parsing file...";
            this.Refresh();

            RecordingList list = new RecordingList();
            RecordFileReader reader = new RecordFileReader(list);
            RecList = list;

            if (reader.CheckFile(@".\AutomaattiOut.py"))
            {
                reader.ReadRecords(@".\AutomaattiOut.py");

                this.ShowRecordings(list);
            }
            else
            {
                MessageBox.Show("File download failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            toolProgress.Value = 0;
            toolStatus.Text = "Ready";
        }

        private void Upload()
        {
            if (RecList.RecordCount > 0)
            {
                RecordFileWriter writer = new RecordFileWriter(@".\AutomaattiIn.py", RecList);
                writer.WriteToFile();
            }
            else
            {
                MessageBox.Show("No records found!", "Error");
            }

            TelnetHandler telnet = new TelnetHandler(settings);
            toolStatus.Text = "Connecting...";
            this.Refresh();
            telnet.UploadConfig(toolStatus, toolProgress);
            this.Refresh();
            MessageBox.Show("Configuration updated");

        }

        //Download
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Download();
            
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView.SelectedItems;

                ListViewItem lvItem = items[0];
                int pos = lvItem.Index;

                AddEditForm form = new AddEditForm(RecList.RecordingNumber(pos), true, settings.Channels);
                form.ShowDialog(this);

                if (form.DialogResult == DialogResult.OK)
                {
                    this.ShowRecordings(RecList);
                    form.Dispose();
                }
                else
                {
                    form.Dispose();
                }
            }
        }

        //Upload
        private void toolUpload_Click(object sender, EventArgs e)
        {
            Upload();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(false, settings.Channels, RecList);
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.OK)
            {
                this.ShowRecordings(RecList);
                form.Dispose();
            }
            else
            {
                form.Dispose();
            }
        }

        private void toolRemove_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView.SelectedItems;

            ListViewItem lvItem = items[0];
            int pos = lvItem.Index;

            RecList.Remove(pos);
            this.ShowRecordings(RecList);
        }

        //Download
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
