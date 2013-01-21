using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Syntaxs
{
    class AssignSyntax : Syntax
    {
        public AssignSyntax()
        {
            this._name = "assign";
        }

        int iOperator = -1;

        public override void Do(XmlNode node)
        {
            //base.Do();
            VirtualMachine machine = VirtualMachine.Instance;

            string strVar = node.InnerText;

            string name = strVar.Substring(0, strVar.IndexOf('='));

            string type = machine.getVar(name).Type;

            string value = strVar.Substring(strVar.IndexOf('=') + 1);

            int idxOperator = -1;
            
            idxOperator = OperatorIdx(value);


            if (idxOperator == -1)
            {
                if (value == "length")
                {
                    value = "10";
                }

                machine.setValue(name, value);
            }
            else
            {
                string input1 = value.Substring(0, idxOperator);

                int x1, x2;

                x1 = getIntFromString(input1);

                string input2 = value.Substring(idxOperator + 1);

                x2 = getIntFromString(input2);


                int result = getResult(x1, x2);

                machine.setValue(name, result.ToString());
            }
        }

        private int getResult(int x1, int x2)
        {
            if (iOperator == 1)
            {
                return x1 + x2;
            }

            if (iOperator == 2)
            {
                return x1 - x2;
            }

            if (iOperator == 3)
            {
                return x1 * x2;
            }

            if (iOperator == 4)
            {
                return x1 / x2;
            }

            return 0;
        }

        private static int getIntFromString(string input)
        {
            VirtualMachine machine = VirtualMachine.Instance;

            int x1;
            Variable v1 = machine.getVar(input);
            if (v1 == null)
            {
                x1 = Int32.Parse(input);
            }
            else
            {
                x1 = Int32.Parse(v1.Value);
            }

            return x1;
        }

        private int OperatorIdx(string value)
        {
            int idxOperator = -1;

            idxOperator = value.IndexOf('+');
            if (idxOperator == -1)
            {
                idxOperator = value.IndexOf('-');

                if (idxOperator == -1)
                {
                    idxOperator = value.IndexOf('*');

                    if (idxOperator == -1)
                    {
                        idxOperator = value.IndexOf('/');

                        if (idxOperator == -1)
                        {
                            return -1;
                        }
                        else
                        {
                            iOperator = 4;
                        }
                    }
                    else
                    {
                        iOperator = 3;
                    }
                }
                else
                {
                    iOperator = 2;
                }
            }
            else
            {
                iOperator = 1;
            }

            return idxOperator;
        }
    }
}
