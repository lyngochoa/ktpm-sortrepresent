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

            string xml = "<start><var>int32 i</var><assign>i=1</assign><var>int32 j</var><assign>j=0</assign><var>int32 temp</var><assign>temp=0</assign><var>int32 n</var><assign>n=length</assign><var>int32 m</var><assign>m=n-1</assign>";
	               xml += "<for><from>i</from><to>m</to><do>";
			       xml += "<assign>j=m+0</assign><var>int32 to</var><assign>to=i-1</assign>";
                   xml += "<for><from>j</from><to>to</to><do>";
				   xml += "<assign>temp=j-1</assign><if><condition><type>array</type><input>temp,j</input><compare>></compare></condition>";
				   xml += "<do><swap><type>array</type><input>temp,j</input></swap></do></if>";
                   xml += "<assign>j=j-1</assign></do></for><assign>i=i+1</assign></do></for></start>";

                   doc.LoadXml(xml);

            return doc;
        }
    }
}
