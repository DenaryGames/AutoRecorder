using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace AutoRecorder
{
    class TelnetHandler
    {

        Settings settings;

        public TelnetHandler(Settings settings)
        {
            this.settings = settings;
        }

        public void Connect()
        {
            TelnetConnection tc = new TelnetConnection(settings.Address, 23);
            string s = tc.Login(settings.Username, settings.Password, 100);
            Console.Write(s);

            tc.WriteLine("/etc/enigma2/AutoRecorder/reconf /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.prof >/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py");

            ftp ftpClient = new ftp(@"ftp://" + settings.Address, settings.Username, settings.Password);

            ftpClient.download("/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py", @".\AutomaattiOut.py");

        }
        
    }
}
