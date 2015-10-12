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

        public AddEditForm(Recording recordIn, bool editIn, List<String> channels)
        {
            InitializeComponent();
            this.record = recordIn;
            this.edit = editIn;

            if(edit)
            {
                txtTitle.Text = record.Title;
                txtDirectory.Text = record.Directory;

                foreach(String channel in channels)
                {
                    cbChannel.Items.Add(channel);
                }

                cbChannel.SelectedIndex = cbChannel.FindStringExact(record.Channel);

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
            this.record.Title = txtTitle.Text;
        }
    }
}
