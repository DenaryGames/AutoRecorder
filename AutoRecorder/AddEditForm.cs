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
        public AddEditForm(Recording record, bool edit)
        {
            InitializeComponent();

            if(edit)
            {
                txtTitle.Text = record.Title;
            }
        }
    }
}
