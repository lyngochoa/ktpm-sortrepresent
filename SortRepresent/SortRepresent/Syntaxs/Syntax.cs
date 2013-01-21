using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SortRepresent.Message;
using System.Threading;

namespace SortRepresent.Syntaxs
{
    public abstract class Syntax
    {
        protected String _name;

        public String Name
        {
            get { return _name; }
        //    set { _name = value; }
        }

        public Syntax()
        { 
        
        }

        public Syntax(String name)
        {
            _name = name;
        }

        virtual public void Do(XmlNode node)
        {
        }

        virtual public bool DoCondition(XmlNode node)
        {
            return false;
        }

        virtual public Syntax Clone()
        {
            return null;
        }

        public void PostMessage(string name, int x, int y)
        {
            ControlCenter.PostMessage(name, x, y);
            Thread.Sleep(100);
        }
    }
}
