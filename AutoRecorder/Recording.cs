using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecorder
{
    class Recording
    {
        private String title;
        private bool enabled;
        private String channel;
        private String directory;
        private int[] weekdays;

        public Recording(String title, bool enabled, String channel, String directory, int[] weekdays)
        {
            this.title = title;
            this.enabled = enabled;
            this.channel = channel;
            this.directory = directory;
            this.weekdays = weekdays;
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        public String Channel
        {
            get
            {
                return channel;
            }
            set
            {
                channel = value;
            }
        }

        public String Directory
        {
            get
            {
                return directory;
            }
            set
            {
                directory = value;
            }
        }


    }
}
