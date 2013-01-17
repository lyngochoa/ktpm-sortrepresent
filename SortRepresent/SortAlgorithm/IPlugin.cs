using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortAlgorithm
{
    public interface IPlugin
    {
        string getName();
        XmlDocument SortAlgo();
    }
}
