using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecorder
{
    class RecordFileWriter
    {
        private List<String> lines = new List<String>();
        private string file;
        private RecordingList list;


        public RecordFileWriter(string fileName, RecordingList recordings)
        {
            this.file = fileName;
            this.list = recordings;
        }

        private void WriteHeader()
        {
            lines.Add(@"#!/usr/bin/python");
            lines.Add(@"# -*- coding: utf-8 -*-");
            lines.Add(@"import pickle");
            lines.Add(@"conf = (");
        }

        private void WriteRecordings()
        {
            foreach(Recording record in list.Records)
            {
                lines.Add(@"     {");

                string _line = "         \"title\": \"" + record.Title + "\" ,"; 
                lines.Add(_line);

                _line = "         \"auto\": " + Convert.ToInt32(record.Enabled) + " ,";
                lines.Add(_line);

                _line = "         \"manual\": " + Convert.ToInt32(record.Enabled) + " ,";
                lines.Add(_line);

                _line = "         \"weekdays\": [" + record.DaysString + "] ,";
                lines.Add(_line);

                if (!String.IsNullOrEmpty(record.Times))
                {
                    _line = "         \"hours\": [" + record.Times + "] ,";
                    lines.Add(_line);
                }

                if (!String.IsNullOrEmpty(record.Directory))
                {
                    _line = "         \"directory\": \"" + record.Directory + "\" ,";
                    lines.Add(_line);
                }

                _line = "         \"channel\": \"" + record.Channel + "\" ,";
                lines.Add(_line);
                lines.Add(@"     },");
            }
        }

        private void WriteFooter()
        {
            lines.Add(")");
            lines.Add("profDir = locals().get(\"SearchProfilesDir\", \"./\")");
            lines.Add("print \"profile for /etc/enigma2/AutoRecorder/SearchProfiles/Automaatti.prof goes to\", profDir") ;
            lines.Add("if profDir[-1] != \"/\": profDir += \"/\"");
            lines.Add("confFile = open(\"%sAutomaatti.prof\" %profDir, \"wb\")");
            lines.Add("pickle.dump(conf, confFile)");
            lines.Add("confFile.close()");
            lines.Add("");
            lines.Add("");
        }


        public void WriteToFile()
        {
            WriteHeader();
            WriteRecordings();
            WriteFooter();

            using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@".\AutomaattiIn.py"))
            {
                file.NewLine = "\n";
                foreach (string line in lines)
                {
                        file.WriteLine(line);
                }
            }
        }
    }
}
