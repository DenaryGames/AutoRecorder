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
        public AddEditForm(Recording record, bool edit, List<String> channels)
        {
            InitializeComponent();

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

            }
        }
    }
}
