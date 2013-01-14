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
    public partial class Form1 : Form
    {
        List<Button> lstButton = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            InitButton_LabelArrayNotSort();
        }

        private void InitButton_LabelArrayNotSort()
        {
            InitMethod initMethod = new InitMethod();
            List<int> arrayRandom = initMethod.GetArrayRandom();

            //tao list danh sach cac button de gan gia tri
            InitLstButtons();

            //Init for Buttons
            for (int i = 0; i < 10; i++)
            {
                lstButton[i].Text = arrayRandom[i].ToString();
            }
            
            //Init for Label not sort
            lbMangBanDau.Text = GetValueAfterInitButtons(arrayRandom);
        }


        /*
         * input: List<int> arrayRandom
         * Tao chuoi text tuong ung cac gia tri cua mang vua duoc random
         */
        private string GetValueAfterInitButtons(List<int> arrayRandom)
        {
            string str = "";
            foreach (int i in arrayRandom)
            {
                str += "   " + i.ToString();
            }
            return str;
        }

        /*
         * Input: List<Button> duoc khai bao toan cuc
         * Khoi tao danh sach chua cac Button co tren Form         
         * de gan gia tri random         
         */
        private void InitLstButtons()
        {
            lstButton.Add(btn1);
            lstButton.Add(btn2);
            lstButton.Add(btn3);
            lstButton.Add(btn4);
            lstButton.Add(btn5);
            lstButton.Add(btn6);
            lstButton.Add(btn7);
            lstButton.Add(btn8);
            lstButton.Add(btn9);
            lstButton.Add(btn10);
        }

    }
}
