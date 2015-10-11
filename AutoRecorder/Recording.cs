﻿using System;
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
        private String[] weekdays;
        private int startHour;
        private int startMinute;
        private int endHour;
        private int endMinute;

        public Recording(String title, bool enabled, String channel, String directory, String[] weekdays, int startHour, int startMinute, int endHour, int endMinute)
        {
            this.title = title;
            this.enabled = enabled;
            this.channel = channel;
            this.directory = directory;
            this.weekdays = weekdays;
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.endHour = endHour;
            this.endMinute = endMinute;
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
