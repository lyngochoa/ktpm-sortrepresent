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
    public partial class ThemThuatToan : Form
    {
        Form1 f;

        public ThemThuatToan(Form1 f)
        {
            InitializeComponent();

            this.f = f;
        }

        private void ThemThuatToan_Load(object sender, EventArgs e)
        {

        }

        private void tbTenThuatToan_TextChanged(object sender, EventArgs e)
        {
            if (tbTenThuatToan.Text != "" && rtbXML.Text != "")
            {
                btnTaoThuatToan.Enabled = true;
            }
            else
            {
                btnTaoThuatToan.Enabled = false;
            }
        }

        private void rtbXML_TextChanged(object sender, EventArgs e)
        {
            if (tbTenThuatToan.Text != "" && rtbXML.Text != "")
            {
                btnTaoThuatToan.Enabled = true;
            }
            else
            {
                btnTaoThuatToan.Enabled = false;
            }
        }

        private void btnTaoThuatToan_Click(object sender, EventArgs e)
        {
            string name = tbTenThuatToan.Text;

            string xml = rtbXML.Text;

            bool b = f.ThemThuatToan(name, xml);

            if (b)
            {
                MessageBox.Show("Bạn đã tạo thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng kiếm tra lại thông tin!");
            }
        }
    }
}
