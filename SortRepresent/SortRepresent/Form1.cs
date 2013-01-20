using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SortAlgorithm;
using SortRepresent.Plugin;
using System.Reflection;
using System.Xml;
using System.Threading;

namespace SortRepresent
{
    public partial class Form1 : Form
    {
        VirtualMachine machine = VirtualMachine.Instance;
        List<Button> lstButton = new List<Button>();
        List<IPlugin> plugin = new List<IPlugin>();
        List<Color> recColor = new List<Color>();
        List<Rectangle> recs = new List<Rectangle>();
        int idxColor = 0;

        string strPlugin = "";

        int moveDelay = 1;

        private Rectangle rect = new Rectangle();
        
        public Form1()
        {
            InitializeComponent();
            LoadPlugin();
            InitButton_LabelArrayNotSort();

            InitListRecColor(5);
        }

        private void InitListRecColor(int n)
        {
            recColor.Add(Color.Magenta);
            recColor.Add(Color.NavajoWhite);
            recColor.Add(Color.Navy);
            recColor.Add(Color.OldLace);
            recColor.Add(Color.Olive);
        }

        /*
         * Sự kiện click vào button "Tạo Mãng"
         */
        private void btnTaoMang_Click(object sender, EventArgs e)
        {
            InitButton_LabelArrayNotSort();

            //moveButtonToChange(0, 2);
        }

        private void InitButton_LabelArrayNotSort()
        {
            InitMethod initMethod = new InitMethod();
            initMethod.GetArrayRandom();

            //tao list danh sach cac button de gan gia tri
            InitLstButtons();

            //Init for Buttons
            for (int i = 0; i < 10; i++)
            {
                lstButton[i].Text = machine.getElement(i).ToString();
            }

            //Init for Label not sort
            lbMangBanDau.Text = GetValueAfterInitButtons();
        }

        /*
         * input: List<int> arrayRandom
         * Tạo chuỗi thể hiện thứ tự các phần tử trong mãng trước khi sort
         */
        private string GetValueAfterInitButtons()
        {
            

            string str = "";
            for(int i = 0; i < 10; i++ )
            {
                str += machine.getElement(i).ToString()+ "   ";
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

        private void LoadPlugin()
        { 
            //Load local plugin
            //IPlugin temp = new SelectionSort();
            //plugin.Add(temp);

            IPlugin temp = null;

            //External plugin
            string[] files = System.IO.Directory.GetFiles(
                Application.StartupPath + @"\Addons\", "*.iplugin");

            foreach (string f in files)
            {
                // Load assembly from each file
                Assembly asm = Assembly.LoadFile(f);
                string className = System.IO.Path.GetFileName(f)
                    .Replace(@".iplugin", "") + ".PluginClass";

                Type[] types = asm.GetTypes();
                foreach (Type t in types)
                {
                    if (t.FullName == className)
                    {
                        temp = Activator.CreateInstance(t) as IPlugin;
                        plugin.Add(temp);
                    }
                }
            }

            //Load list plugin
            int n = plugin.Count;
            for (int i = 0; i < n; i++)
            {
                RadioButton rbtn = new RadioButton();
                rbtn.AutoSize = true;
                rbtn.Name = "rbtn" + i.ToString();
                rbtn.Size = new System.Drawing.Size(91, 17);
                rbtn.TabIndex = 1000 + i;
                rbtn.TabStop = true;
                rbtn.Text = plugin[i].getName();
                rbtn.UseVisualStyleBackColor = true;

                rbtn.Click += new EventHandler(rbtnThuatToan_Click); 

                flowLayoutPanelThuatToan.Controls.Add(rbtn);
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (strPlugin == "")
            {
                MessageBox.Show("Vui lòng lựa chọn thuật toán");
            }

            btnTaoMang.Enabled = false;
            btnTamDung.Enabled = true;

            VirtualMachine machine = VirtualMachine.Instance;

            IPlugin temp = getPlugin(strPlugin);

            XmlDocument doc = temp.SortAlgo();

            XmlElement elemt = doc.DocumentElement;

            XmlNodeList node = elemt.ChildNodes;

            int n = node.Count;

            for (int z = 0; z < n; z++)
            {
                XmlNode child = node.Item(z);

                Syntaxs.Syntax syn = machine.getSyntax(child.Name);

                if (syn != null)
                {
                    syn.Do(child);
                }
            }

            lbMangDaSapXep.Text = GetValueAfterInitButtons();
        }

        private void rbtnThuatToan_Click(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;

            strPlugin = rbtn.Text;

            btnSapXep.Enabled = true;
        }

        private IPlugin getPlugin(string name)
        { 
            int n = plugin.Count;

            for (int i = 0; i < n; i++)
            {
                if (plugin[i].getName() == name)
                {
                    return plugin[i];
                }
            }

            return null;
        }

        //Lấy hình chữ nhật bao quanh 2 nút
        private Rectangle GetRectangle(Button startBtn, Button endBtn)
        {
            Rectangle rect = new Rectangle();
            int height = startBtn.Size.Height;
            int startBtnX = startBtn.Location.X;
            int startBtnY = startBtn.Location.Y;
            int endBtnX = endBtn.Location.X + endBtn.Size.Width;
            int endBtnY = endBtn.Location.Y;

            int startXRect = startBtnX;
            int startYRect = startBtnY - height;
            int widthRect = endBtnX - startBtnX;
            int heightRect = startBtn.Size.Height * 2;
            rect = new Rectangle(startXRect, startYRect, widthRect, heightRect);
            return rect;
        }

        /*
         *Form Paint để có thể vẽ được các hình chữ nhật 
         */
        private void gbSapXep_Paint(object sender, PaintEventArgs e)
        {
            int n = recs.Count;

            int temp = idxColor;

            for (int i = 0; i < n; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(recColor[temp]), recs[i]);

                temp++;

                if (temp >= 5)
                {
                    temp = 0;
                }
            }
        }

        public void drawRectangle(int i, int j)
        {
            rect = GetRectangle(this.lstButton[i], this.lstButton[j]);
            recs.Add(rect);
            this.Refresh();
        }

        public void removeRectangle(int i, int j)
        {
            rect = GetRectangle(this.lstButton[i], this.lstButton[j]);
            recs.Remove(rect);
            this.Refresh();
        }

        #region Đổi vị trí 2 button
        Button[] moveButton = new Button[2];    //2 button cần đổi vị trí
        Point[] oldPoint = new Point[2];         //Vị trí cũ của 2 button cần đổi

        public void moveButtonToChange(int i, int j)
        {
            moveButton[0] = lstButton[i];
            moveButton[1] = lstButton[j];

            oldPoint[0] = moveButton[0].Location;
            oldPoint[1] = moveButton[1].Location;

            lstButton[i] = moveButton[1];
            lstButton[j] = moveButton[0];

            Moving();
        }

        //private delegate void moveBd(Button btn, char p, int n);
        void moveBtn(Button btn, char p, int n)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;

            if (p == 'x')
            {
                btn.Location = new Point(x + n, y);
            }
            else
            {
                btn.Location = new Point(x, y + n);
            }
        }

        private void Moving()
        {
            while (moveButton[0].Location.Y > 35)
            {
                //Invoke(new moveBd(moveBtn), moveButton[0], 'y', -1);
                moveBtn(moveButton[0], 'y', -1);
                moveBtn(moveButton[1], 'y', -1);
                Thread.Sleep(moveDelay);
            }

            Refresh();

            while (moveButton[0].Location.X != oldPoint[1].X)
            {
                moveBtn(moveButton[0], 'x', 1);
                moveBtn(moveButton[1], 'x', -1);
                Thread.Sleep(moveDelay);
            }
            Refresh();

            while (moveButton[0].Location.Y != oldPoint[1].Y)
            {
                //Invoke(new moveBd(moveBtn), moveButton[0], 'y', 1);
                moveBtn(moveButton[0], 'y', 1);
                moveBtn(moveButton[1], 'y', 1);
                Thread.Sleep(moveDelay);
            }
            Refresh();

            moveButton[0].Location = oldPoint[1];
            moveButton[1].Location = oldPoint[0];
        }

        #endregion

        /*
         * Thuật toán của selectionSort, Lấy demo tạm
         */
        String needXML = "<start>"
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

        private void btnTuTaoThuatToan_Click(object sender, EventArgs e)
        {
            FormImportAlgorithm frmImport = new FormImportAlgorithm(this);
            frmImport.ShowDialog();
            try
            {
                if (checkExistencePluginWithClassName("SelectionSort"))
                {
                    InitMethod initMethod = new InitMethod();

                    //Gọi Phương thức tạo plugin với input là 3 parametters 
                    initMethod.BuildPluginAuto("SelectionSort", "Sắp xếp chọn", needXML);

                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("ClassName đã tồn tại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkExistencePluginWithClassName(string _className)
        {
            try
            {
                //External plugin
                string[] files = System.IO.Directory.GetFiles(
                    Application.StartupPath + @"\Addons\", "*.iplugin");

                foreach (string f in files)
                {
                    // Load assembly from each file
                    Assembly asm = Assembly.LoadFile(f);
                    string className = System.IO.Path.GetFileName(f)
                        .Replace(@".iplugin", "") + ".PluginClass";

                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.FullName == className && className.IndexOf(_className) != -1)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }




    }
}
