using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoRecorder
{
    class XMLUtils
    {
        private String Filename;

        public XMLUtils(String filename)
        {
            this.Filename = filename;
        }

        public String ReadKey(String descendant, String key)
        {
            XDocument xmlDoc = XDocument.Load(this.Filename);

            var oneAtrribute = (from i in xmlDoc.Descendants(descendant)
                                select i.Element(key).Value).FirstOrDefault();

            return oneAtrribute.ToString();
        }


    }
}
