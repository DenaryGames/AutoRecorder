using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecorder
{
    public class Recording
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

        public Recording()
        {

        }

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

        public int StartHour
        {
            set
            {
                startHour = value;
            }
        }

        public int StartMinute
        {
            set
            {
                StartMinute = value;
            }
        }

        public int EndHour
        {
            set
            {
                endHour = value;
            }
        }

        public int EndMinute
        {
            set
            {
                endMinute = value;
            }
        }

        public String[] Days
        {
            get
            {
                return weekdays;
            }
            set
            {
                weekdays = value;
            }
        }

        public String DaysString
        {
            get
            {
                string _tmp = String.Join(", ", weekdays);
                _tmp = _tmp.Trim();
                return _tmp.Remove(_tmp.Length - 1);
            }
        }

        public String DayNames
        {
            get
            {
                string dayString = "";
                foreach(string day in weekdays)
                {
                    if (!String.IsNullOrEmpty(day))
                    {
                        if (Convert.ToInt32(day) == 0)
                        {
                            dayString += "Mon ";
                        }
                        if (Convert.ToInt32(day) == 1)
                        {
                            dayString += "Tue ";
                        }
                        if (Convert.ToInt32(day) == 2)
                        {
                            dayString += "Wed ";
                        }
                        if (Convert.ToInt32(day) == 3)
                        {
                            dayString += "Thu ";
                        }
                        if (Convert.ToInt32(day) == 4)
                        {
                            dayString += "Fri ";
                        }
                        if (Convert.ToInt32(day) == 5)
                        {
                            dayString += "Sat ";
                        }
                        if (Convert.ToInt32(day) == 6)
                        {
                            dayString += "Sun";
                        }
                    }
                }

                return dayString;
            }
        }

        public String Times
        {
            get
            {
                if(startHour == -1)
                {
                    return "";
                }
                else
                {
                    return startHour.ToString() + "," + startMinute.ToString() + "," + endHour.ToString() + "," + endMinute + ",";
                }
            }
        }

        public String TimeString
        {
            get
            {
                if(startHour == -1)
                {
                    return "";
                }
                string fmt = "00";
                return startHour.ToString(fmt) + ":" + startMinute.ToString(fmt) + " - " + endHour.ToString(fmt) + ":" + endMinute.ToString(fmt);
            }
        }

        public String StartTimeString
        {
            get
            {
                if (startHour == -1)
                {
                    return "";
                }
                string fmt = "00";
                return startHour.ToString(fmt) + ":" + startMinute.ToString(fmt);
            }
        }

        public String EndTimeString
        {
            get
            {
                if (endHour == -1)
                {
                    return "";
                }
                string fmt = "00";
                return endHour.ToString(fmt) + ":" + endMinute.ToString(fmt);
            }
        }


    }
}
