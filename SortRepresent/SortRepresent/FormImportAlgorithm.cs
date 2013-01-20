using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortRepresent
{
    public partial class FormImportAlgorithm : Form
    {
        private Form1 form1;

        //public FormImportAlgorithm()
        //{
            
        //}

        public FormImportAlgorithm(Form1 form1)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
