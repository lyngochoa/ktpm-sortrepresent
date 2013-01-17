using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Plugin
{
    public class SelectionSort: SortAlgorithm.IPlugin
    {
        public string getName()
        {
            return "Sắp xếp chọn";
        }

        public System.Xml.XmlDocument SortAlgo()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\thuattoan.xml");

            return doc;
        }
    }
}
