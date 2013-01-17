using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BubbleSort
{
    public class PluginClass : SortAlgorithm.IPlugin
    {
        public string getName()
        {
            return "Sắp xếp nổi bọt";
        }

        public System.Xml.XmlDocument SortAlgo()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\thuattoan.xml");

            return doc;
        }
    }
}
