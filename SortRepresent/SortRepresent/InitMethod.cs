using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Xml;

namespace SortRepresent
{
    class InitMethod
    {
        public void GetArrayRandom()
        {
            VirtualMachine machine = VirtualMachine.Instance;

            machine.cleanElement();

            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                machine.addElement(rd.Next(-100,100));
            }
        }

        public bool BuildPluginAuto(String nameClass, String nameReturn, String strXml)
        {
            string sourcecode =
               TEMPLATE_CODE.Replace("{0}", nameClass)
               .Replace("{1}",nameReturn)
               .Replace("{2}", strXml);

            CSharpCodeProvider csprovider = new CSharpCodeProvider();
            ICodeCompiler icc = csprovider.CreateCompiler();

            CompilerParameters ps = new CompilerParameters();

            // Add an assembly reference.
            ps.ReferencedAssemblies.Add("System.Xml.dll");

            // Be terminated dll or exe file extension
            ps.GenerateExecutable = false;
            ps.OutputAssembly = Application.StartupPath +
                @"\Addons\" + nameClass + ".iplugin";
            ps.ReferencedAssemblies.Add(Application.StartupPath +
                @"\SortAlgorithm.dll");

            CompilerResults rs =
                icc.CompileAssemblyFromSource(ps, sourcecode);

            if (rs.Errors.Count > 0)
            {
                //MessageBox.Show(rs.Errors[rs.Errors.Count - 1].ErrorText);

                return false;
            }

            return true;
        }

        public static string TEMPLATE_CODE = @"
        using System.Xml;
        namespace {0}
        {
            public class PluginClass : SortAlgorithm.IPlugin
            {

                #region IPlugin Members
                public XmlDocument SortAlgo()
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(""{2}"");
                    return doc;
                }

                public string getName()
                {
                    return ""{1}"";
                }


                #endregion
            }
        }";
    }
}
