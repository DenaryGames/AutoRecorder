using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRecorder
{
    class Settings
    {
        private XMLUtils XMLUtil;
        private List<String> channels;
        private String address;
        private String password;
        private String username;

        public Settings()
        {
            XMLUtil = new XMLUtils("settings.xml");
            channels = new List<string>();
        }

        public void ReadSettings()
        {
            this.username = XMLUtil.ReadKey("Settings", "Username");
            this.address = XMLUtil.ReadKey("Settings", "Address");
            this.password = XMLUtil.ReadKey("Settings", "Password");

            this.PopulateChannels(XMLUtil.ReadKey("Settings", "Channels"));
        }

        private void PopulateChannels(String channelList)
        {
            foreach(String channel in channelList.Split(';'))
            {
                channels.Add(channel);
            }
        }

        public String Address
        {
            get
            {
                return address;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
        }

        public String Username
        {
            get
            {
                return username;
            }
        }

        public List<String> Channels
        {
            get
            {
                return channels;
            }
        }
    }
}
