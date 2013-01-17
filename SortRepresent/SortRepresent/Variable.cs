using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent
{
    public class Variable
    {
        string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Variable(string _type, string _name, string _value)
        {
            this._type = _type;

            this._name = _name;

            this._value = _value;
        }

        public Object getObj()
        {
            string strType = "System." + _type;

            if (_type == "int")
            {
                strType += "32";
            }

            var varType = typeof(ValueType).Assembly.GetType(strType, true);
            var control = (ValueType)Activator.CreateInstance(varType);

            return control;
        }
    }
}
