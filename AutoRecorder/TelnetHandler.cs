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
        public TelnetHandler()
        {
            
        }

        public void Connect()
        {
            TelnetConnection tc = new TelnetConnection("vuultimo", 23);
            string s = tc.Login("root", "dreambox", 100);
            Console.Write(s);

            tc.WriteLine("/etc/enigma2/AutoRecorder/reconf /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.prof >/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py");

            ftp ftpClient = new ftp(@"ftp://vuultimo", "root", "dreambox");

            ftpClient.download("/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py", @".\AutomaattiOut.py");

            string fileDateTime = ftpClient.getFileCreatedDateTime("/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py");
            string fileSize = ftpClient.getFileSize("/etc/enigma2/AutoRecorder/SearchProfiles/AutomaattiOut.py");

        }
        
    }
}
