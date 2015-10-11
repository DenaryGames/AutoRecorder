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

        public MainForm()
        {
            InitializeComponent();
            listView.Columns.Add("Title", 200);
            listView.Columns.Add("Enabled", 60);
            listView.Columns.Add("Days", 200);
            listView.Columns.Add("Time", 150);
            listView.Columns.Add("Channel", 70);
            listView.Columns.Add("Directory", 200);
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void ShowRecordings(RecordingList list)
        {
            foreach(Recording record in list.Records)
            {
                String[] row = { Convert.ToString(record.Enabled), record.DaysString, record.TimeString, record.Channel, record.Directory };
                listView.Items.Add(record.Title).SubItems.AddRange(row);
                listView.Update();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ReadSettings();
            TelnetHandler telnet = new TelnetHandler(settings);

            telnet.Connect();

            RecordingList list = new RecordingList();
            RecordFileReader reader = new RecordFileReader(list);
            RecList = list;

            reader.ReadRecords(@".\Automaatti.py");

            this.ShowRecordings(list);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView.SelectedItems;

                ListViewItem lvItem = items[0];
                int pos = lvItem.Index;

                AddEditForm form = new AddEditForm(RecList.RecordingNumber(pos), true);
                form.ShowDialog(this);
            }
        }
    }
}
