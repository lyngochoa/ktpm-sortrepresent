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
        private Rectangle rect = new Rectangle();
        
        public Form1()
        {
            InitializeComponent();            
        }

        private Rectangle GetRectangle(Button startBtn,Button endBtn)
        {
            Rectangle rect = new Rectangle();
            int height = startBtn.Size.Height;
            int startBtnX = startBtn.Location.X;
            int startBtnY = startBtn.Location.Y;
            int endBtnX = endBtn.Location.X + endBtn.Size.Width;
            int endBtnY = endBtn.Location.Y;

            int startXRect = startBtnX ;
            int startYRect = startBtnY - height;
            int widthRect = endBtnX - startBtnX;
            int heightRect = startBtn.Size.Height * 2;
            rect = new Rectangle(startXRect, startYRect, widthRect, heightRect);
            return rect;
        }

        private void testDraw(Graphics g,Rectangle rect)
        {
            g.DrawRectangle(new Pen(Color.Red, 6), rect);
        }

      
        /*
         * Sự kiện click vào button "Tạo Mãng"
         */
        private void btnTaoMang_Click(object sender, EventArgs e)
        {
            
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
         * Tạo chuỗi thể hiện thứ tự các phần tử trong mãng trước khi sort
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
         * Output: List<Button> được khai báo toàn cục
         * Khởi tạo danh sách các Button để     
         * gán giá trị random         
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

        /*
         *Form Paint để có thể vẽ được các hình chữ nhật 
         */
        private void gbSapXep_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Moccasin), rect);
        }

        /*
         *Tạo thử để test draw rectangle 
         *Nội dung thuật toán là thay đổi X,Y của hình chữ nhật dựa vào vị trí các button
         *Sau đó đưa các vị trí mới vào biến rect toàn cục và gọi this.refresh() để form có thể vẽ
         */
        private void btnTestDraw_Click(object sender, EventArgs e)
        {
            InitLstButtons();
            rect = GetRectangle(btn1, btn4);
            this.Refresh();

            for (int i = 0; i < lstButton.Count() - 2; i++)
            {
                for (int j = i + 2; j < lstButton.Count(); j++)
                {
                    rect = GetRectangle(lstButton[i], lstButton[j]);
                    this.Refresh();
                    System.Threading.Thread.Sleep(500);
                }
                rect = new Rectangle();
                this.Refresh();
                break;
            }
        }
    }
}
