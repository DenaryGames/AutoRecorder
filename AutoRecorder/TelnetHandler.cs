using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;
using System.Windows.Forms;
using System.Threading;

namespace AutoRecorder
{
    class TelnetHandler
    {

        Settings settings;

        public TelnetHandler(Settings settings)
        {
            this.settings = settings;
        }

        public void Connect(ToolStripStatusLabel toolStatus, ToolStripProgressBar toolProgress)
        {
            TelnetConnection tc = new TelnetConnection(settings.Address, 23);
            string s = tc.Login(settings.Username, settings.Password, 100);
            Console.Write(s);

            tc.WriteLine("/etc/enigma2/AutoRecorder/reconf /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.prof >/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py");

            ftp ftpClient = new ftp(@"ftp://" + settings.Address, settings.Username, settings.Password);

            toolProgress.Value = 65;
            toolStatus.Text = "Downloading...";
            ftpClient.download("/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py", @".\AutomaattiOut.py");

        }

        public void UploadConfig(ToolStripStatusLabel toolStatus, ToolStripProgressBar toolProgress)
        {
            TelnetConnection tc = new TelnetConnection(settings.Address, 23);
            string s = tc.Login(settings.Username, settings.Password, 100);
            Console.Write(s);

            tc.WriteLine("mv /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.py /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti-2.py");
            
            ftp ftpClient = new ftp(@"ftp://" + settings.Address, settings.Username, settings.Password);
            Thread.Sleep(1000);
            toolProgress.Value = 65;
            toolStatus.Text = "Uploading...";

            //ftpClient.upload(@".\AutomaattiIn.py", "/etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.py");
            ftpClient.upload("/etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.py", "AutomaattiIn.py");
            
            tc.WriteLine("cd /etc/enigma2/AutoRecorder/SearchProfiles");
            tc.WriteLine("chmod 777 Automaatti.py");
            tc.WriteLine("./Automaatti.py");

            toolProgress.Value = 0;
            toolStatus.Text = "Ready";
        }

    }
}
