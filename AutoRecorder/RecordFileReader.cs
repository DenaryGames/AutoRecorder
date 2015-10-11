using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecorder
{
    class RecordFileReader
    {

        private RecordingList list;
        private char[] charsToRemove = { '"', '[', ']'};


        public RecordFileReader(RecordingList recordList)
        {
            this.list = recordList;
        }

        public void ReadRecords(String fileName)
        {
            String[] lines = System.IO.File.ReadAllLines(@".\AutomaattiOut.py");
            bool titleReady = false;

            String title = "";
            bool enabled = false;
            String channel = "";
            String directory = "";
            String[] weekdays;
            weekdays = new String[7];
            int startHour = -1;
            int startMinute = -1;
            int endHour = -1;
            int endMinute = -1;

            foreach (String line in lines)
            {
                if(line.Contains("\"title\":"))
                {
                    String[] _title = line.Split(':');

                    title = this.TrimResult(_title[1]);
                }

                if(line.Contains("\"auto\":"))
                {
                    if(line.Contains("1"))
                    {
                        enabled = true;
                    }
                    else
                    {
                        enabled = false;
                    }
                }

                if (line.Contains("\"weekdays\":"))
                {
                    String[] _days = line.Split(':');
                    String _daysString = this.TrimResult(_days[1]);

                    weekdays = new String[7];
                    weekdays = _daysString.Split(',');
                }

                if (line.Contains("\"hours\":"))
                {
                    String[] _hoursTemp = line.Split(':');
                    String _hours = this.TrimResult(_hoursTemp[1]);

                    _hoursTemp = _hours.Split(',');

                    startHour = Convert.ToInt32(_hoursTemp[0]);
                    startMinute = Convert.ToInt32(_hoursTemp[1]);
                    endHour = Convert.ToInt32(_hoursTemp[2]);
                    endMinute = Convert.ToInt32(_hoursTemp[3]);
                }

                if (line.Contains("\"directory\":"))
                {
                    String[] _dir = line.Split(':');

                    directory = this.TrimResult(_dir[1]);
                }

                if (line.Contains("\"channel\":"))
                {
                    String[] _chan = line.Split(':');

                    channel = this.TrimResult(_chan[1]);

                    titleReady = true;
                }

                if (titleReady && !String.IsNullOrEmpty(title))
                {
                    list.AddRecording(new Recording(title, enabled, channel, directory, weekdays, startHour, startMinute, endHour, endMinute));
                    titleReady = false;

                    title = "";
                    enabled = false;
                    channel = "";
                    directory = "";
                    weekdays = new String[7];
                    startHour = -1;
                    startMinute = -1;
                    endHour = -1;
                    endMinute = -1;
                }
                
            }
        }

        private String TrimResult(String trim)
        {
            trim = trim.Remove(trim.Length - 1);
            trim = trim.Trim();
            trim = trim.Trim(charsToRemove);

            return trim;
        }
    }
}
