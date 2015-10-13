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
    public partial class AddEditForm : Form
    {

        bool edit;
        Recording record;
        RecordingList list;

        public AddEditForm(bool editIn, List<String> channels, RecordingList list)
        {
            InitializeComponent();
            PopulateBasics(channels);
            this.list = list;
        }

        public AddEditForm(Recording recordIn, bool editIn, List<String> channels)
        {
            InitializeComponent();
            this.record = recordIn;
            this.edit = editIn;

            if(edit)
            {
                txtTitle.Text = record.Title;
                txtDirectory.Text = record.Directory;

                PopulateBasics(channels);

                cbChannel.SelectedIndex = cbChannel.FindStringExact(record.Channel);

                cbStartTime.SelectedIndex = cbStartTime.FindStringExact(record.StartTimeString);
                cbEndTime.SelectedIndex = cbEndTime.FindStringExact(record.EndTimeString);

                chcEnabled.Checked = record.Enabled;

                chcMon.Checked = false;
                chcTue.Checked = false;
                chcWed.Checked = false;
                chcThu.Checked = false;
                chcFri.Checked = false;
                chcSat.Checked = false;
                chcSun.Checked = false;

                foreach (String day in record.Days)
                {

                    if (day.Contains("0"))
                    {
                        chcMon.Checked = true;
                    }
                    if (day.Contains("1"))
                    {
                        chcTue.Checked = true;
                    }
                    if (day.Contains("2"))
                    {
                        chcWed.Checked = true;
                    }
                    if (day.Contains("3"))
                    {
                        chcThu.Checked = true;
                    }
                    if (day.Contains("4"))
                    {
                        chcFri.Checked = true;
                    }
                    if (day.Contains("5"))
                    {
                        chcSat.Checked = true;
                    }
                    if (day.Contains("6"))
                    {
                        chcSun.Checked = true;
                    }                 
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(!edit)
            {
                this.record = new Recording();
                list.AddRecording(record);
            }
            this.record.Title = txtTitle.Text;
            this.record.Channel = cbChannel.Text;

            if (!cbStartTime.Text.Equals(""))
            {
                string[] _time = cbStartTime.Text.Split(':');
                this.record.StartHour = Convert.ToInt32(_time[0]);
                this.record.StartMinute = Convert.ToInt32(_time[1]);
                _time = cbEndTime.Text.Split(':');
                this.record.EndHour = Convert.ToInt32(_time[0]);
                this.record.EndMinute = Convert.ToInt32(_time[1]);
            }
            else
            {
                this.record.StartHour = -1;
                this.record.StartMinute = -1;
                this.record.EndHour = -1;
                this.record.EndMinute = -1;
            }

            this.record.Directory = txtDirectory.Text;

            List<String> days = new List<String>();
            if(chcMon.Checked)
            {
                days.Add("0");
            }
            if (chcTue.Checked)
            {
                days.Add("1");
            }
            if (chcWed.Checked)
            {
                days.Add("2");
            }
            if (chcThu.Checked)
            {
                days.Add("3");
            }
            if (chcFri.Checked)
            {
                days.Add("4");
            }
            if (chcSat.Checked)
            {
                days.Add("5");
            }
            if (chcSun.Checked)
            {
                days.Add("6");
            }

            string[] dayNumbers = days.ToArray();

            this.record.Days = dayNumbers;

            this.record.Enabled = chcEnabled.Enabled;

        }

        private void PopulateBasics(List<String> channels)
        {
            foreach (String channel in channels)
            {
                cbChannel.Items.Add(channel);
            }

            int hour = 0;
            int min = 0;
            string fmt = "00";
            cbStartTime.Items.Add("");
            cbEndTime.Items.Add("");
            for (int i = 0; i < 48; i++)
            {
                cbStartTime.Items.Add(hour.ToString(fmt) + ":" + min.ToString(fmt));
                cbEndTime.Items.Add(hour.ToString(fmt) + ":" + min.ToString(fmt));
                if (min == 0)
                {
                    min = 30;
                }
                else
                {
                    min = 0;
                    hour++;
                }

            }
        }
    }
}
