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

            String xml = "<start>"
                            + "<var>int32 i</var>"
                                + "<assign>i=0</assign>"
                                + "<var>int32 n</var>"
                                    + "<assign>n=length</assign>	"
                                        + "<for>"
                                        + "<from>i</from>"
                                            + "<to>n</to>"
                                                + "<do>"
                                                    + "<var>int32 j</var><assign>j=i+1</assign><for><from>j</from><to>n</to><do>"
                    + "<if><condition><type>array</type><input>i,j</input><compare>></compare></condition><do>"
                            + "<swap><type>array</type><input>i,j</input></swap></do></if>"
                    + "<assign>j=j+1</assign></do></for><assign>i=i+1</assign></do></for></start>";

            doc.LoadXml(xml);

            return doc;
        }
    }
}
