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
        List<ElementProperties> lstElement = new List<ElementProperties>();
        List<IPlugin> plugin = new List<IPlugin>();
        List<Color> recColor = new List<Color>();
        List<Color> btnColor = new List<Color>();
        List<PointInLoop> recs = new List<PointInLoop>();
        public int nValue = 10;

        int idxRecColor = 0;
        int idxBtnColor = 0;

        string strPlugin = "";

        int moveDelay = 20;

        int startX;
        int startY;
        int width;
        int length;

        bool isInvoke = false;
        
        public Form1()
        {
            InitializeComponent();

            //Vẽ panel
            DoubleBufferPanel panel = new DoubleBufferPanel();
            panel.Location = new System.Drawing.Point(13, 68);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(907, 122);
            panel.TabIndex = 0;
            panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);

            this.Controls.Add(panel);

            LoadPlugin();
            InitButton_LabelArrayNotSort();

            InitListRecColor(5);
            InitListBtnColor(5);
        }

        private void InitListRecColor(int n)
        {
            recColor.Add(Color.Magenta);
            recColor.Add(Color.NavajoWhite);
            recColor.Add(Color.Navy);
            recColor.Add(Color.OldLace);
            recColor.Add(Color.Olive);
        }

        private void InitListBtnColor(int n)
        {
            btnColor.Add(Color.LightBlue);
            btnColor.Add(Color.Red);
            btnColor.Add(Color.RoyalBlue);
            btnColor.Add(Color.Yellow);
            btnColor.Add(Color.Violet);
        }


        /*
         * Sự kiện click vào button "Tạo Mãng"
         */
        private void btnTaoMang_Click(object sender, EventArgs e)
        {
            InitButton_LabelArrayNotSort();

            lbMangDaSapXep.Text = "";
        }


        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            //base.OnBackgroundImageChanged(e);
        }

        private void InitButton_LabelArrayNotSort()
        {
            if (strPlugin != "")
            {
                btnSapXep.Enabled = true;
            }

            InitMethod initMethod = new InitMethod();
            initMethod.GetArrayRandom();

            //tao list danh sach cac button de gan gia tri
            InitLstButtons();

            startX = lstElement[0].X - 1;
            startY = lstElement[0].Y - 1 - 50;
            width = 100;
            length = lstElement[0].Height + 50;

            //Init for Buttons
            for (int i = 0; i < nValue; i++)
            {
                lstElement[i].Value = machine.getElement(i).ToString();
                this.Controls["panel"].Refresh();
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
            for(int i = 0; i < nValue; i++ )
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
            lstElement.Clear();

            for (int i = 0; i < nValue; i++)
            {
                lstElement.Add(new ElementProperties(10 + i * 90, 70, 75, 40));
            }
        }

        private void LoadPlugin()
        {
            plugin.Clear();
            flowLayoutPanelThuatToan.Controls.Clear();
            //Load local plugin
            plugin.Add(new SelectionSort());

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

        Thread thread;

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (strPlugin == "")
            {
                MessageBox.Show("Vui lòng lựa chọn thuật toán");
            }
            else
            {
                btnTaoMang.Enabled = false;
                btnTamDung.Enabled = true;
                btnSapXep.Enabled = false;
                gbThuatToan.Enabled = false;

                thread = new Thread(Sorting);
                thread.Start();
            }
        }

        private void Sorting()
        {
            

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

            Invoke(new viewResult(UpdateEndArray));

            Invoke(new resetControl(ResetControl));
        }

        private delegate void viewResult();
        private void UpdateEndArray()
        {
            lbMangDaSapXep.Text = GetValueAfterInitButtons();
        }

        private delegate void resetControl();
        private void ResetControl()
        {
            this.btnTaoMang.Enabled = true;
            this.btnTamDung.Enabled = false;
            this.gbThuatToan.Enabled = true;
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

        #region Vẽ chữ nhật minh họa vòng for
        //Lấy hình chữ nhật bao quanh 2 nút
        private Rectangle GetRectangle(int i, int j)
        {
            Rectangle rect = new Rectangle();

            rect = new Rectangle(startX + length * i, startY, (j - i + 1) * length, width);
            return rect;
        }

        /*
         *Form Paint để có thể vẽ được các hình chữ nhật 
         */
        private Bitmap _backBuffer;
        public void recDrawing(int iStartIdx, int iEndIdx)
        {
            //Invoke(new RecDraw(drawRectangle), new object[] { iStartIdx, iEndIdx });
            drawRectangle(iStartIdx, iEndIdx);
        }

        //public delegate void RecDraw(int i, int j);
        public void drawRectangle(int i, int j)
        {
            recs.Add(new PointInLoop(i, j));
            Invoke(new refresh(r));
            isInvoke = false;
            //this.gbSapXep.Refresh();
        }

        public void remove(int iStartIdx, int iEndIdx)
        {
            //Invoke(new RecRemove(removeRectangle), new object[] { iStartIdx, iEndIdx });
            removeRectangle(iStartIdx, iEndIdx);
        }

        //public delegate void RecRemove(int i, int j);
        public void removeRectangle(int i, int j)
        {
            PointInLoop p = new PointInLoop(i, j);
            for (int idx = 0; idx < recs.Count; idx++)
            {
                if (recs[idx].I == i && recs[idx].J == j)
                {
                    recs.RemoveAt(idx);
                }
            }
            Invoke(new refresh(r));
            isInvoke = false;
            //this.gbSapXep.Refresh();
        }
        #endregion

        #region Đổi vị trí 2 button
        ElementProperties[] moveElement = new ElementProperties[2];    //2 button cần đổi vị trí
        Point[] oldPoint = new Point[2];         //Vị trí cũ của 2 button cần đổi

        public void moveButtonToChange(int i, int j)
        {
            moveElement[0] = lstElement[i];
            moveElement[1] = lstElement[j];

            oldPoint[0] = moveElement[0].Location;
            oldPoint[1] = moveElement[1].Location;

            lstElement[i] = moveElement[1];
            lstElement[j] = moveElement[0];

            Moving();

            lstElement[i].IdxColor = lstElement[j].IdxColor;
        }

        
        void moveBtn(ElementProperties btn, char p, int n, int kq)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;

            if (p == 'x')
            {
                int temp;

                if ((n > 0 && (x + n) > kq) || (n < 0 && (x + n) < kq))
                {
                    temp = kq;
                }
                else
                {
                    temp = x + n;
                }

                btn.X = temp;
            }
            else
            {
                int temp;

                if (n > 0 && (y + n) < kq)
                {
                    temp = kq;
                }
                else
                {
                    temp = y + n;
                }

                btn.Y = temp;
            }
        }

        //private delegate void move();
        private void Moving()
        {
            while (moveElement[0].Y > 20)
            {
                moveBtn(moveElement[0], 'y', -5, 20);
                moveBtn(moveElement[1], 'y', -5, 20);
                Invoke(new refresh(r));
                isInvoke = false;
                Thread.Sleep(moveDelay);
            }


            while (moveElement[0].X < oldPoint[1].X)
            {
                moveBtn(moveElement[0], 'x', 5, oldPoint[1].X);
                moveBtn(moveElement[1], 'x', -5, oldPoint[0].X);
                Invoke(new refresh(r));
                isInvoke = false;
                Thread.Sleep(moveDelay);
            }


            while (moveElement[0].Y < oldPoint[1].Y)
            {
                moveBtn(moveElement[0], 'y', 5, oldPoint[1].Y);
                moveBtn(moveElement[1], 'y', 5, oldPoint[0].Y);
                Invoke(new refresh(r));
                isInvoke = false;
                Thread.Sleep(moveDelay);
            }
        }

        protected delegate void refresh();
        private void r()
        {
            isInvoke = true;
            this.Controls["panel"].Refresh();
        }

        #endregion

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (_backBuffer == null)
            {
                _backBuffer = new Bitmap(this.Controls["panel"].Width, this.Controls["panel"].Height);
            }

            Graphics g = Graphics.FromImage(_backBuffer);

            //Paint your graphics on g here
            int n = recs.Count;

            int temp = idxRecColor;

            g.Clear(this.Controls["panel"].BackColor);

            for (int i = 0; i < n; i++)
            {
                g.FillRectangle(new SolidBrush(recColor[temp]), GetRectangle(recs[i].I, recs[i].J));

                temp++;

                if (temp >= 5)
                {
                    temp = 0;
                }
            }

            n = lstElement.Count;

            for (int i = 0; i < n; i++)
            {
                g.FillRectangle(new SolidBrush(btnColor[lstElement[i].IdxColor]), new Rectangle(lstElement[i].X, lstElement[i].Y, lstElement[i].Width, lstElement[i].Height));
                g.DrawString(lstElement[i].Value, this.Controls["panel"].Font, new SolidBrush(Color.Black), new Point(lstElement[i].X + lstElement[i].Height / 2 + 5, lstElement[i].Y + 13));
            }

            g.Dispose();

            //Copy the back buffer to the screen
            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
        }

        #region Đổi màu button
        public void ChangeColorButton(int idxBtn)
        {
            idxBtnColor++;

            if (idxBtnColor >= 5)
            {
                idxBtnColor = 0;
            }

            lstElement[idxBtn].IdxColor = idxBtnColor;
            Invoke(new refresh(r));
            isInvoke = false;
        }

        public void ResetColorButton(int idxBtn)
        {
            idxBtnColor--;

            if (idxBtnColor < 0)
            {
                idxBtnColor = 4;
            }

            lstElement[idxBtn].IdxColor = 0;//idxBtnColor;
            Invoke(new refresh(r));
            isInvoke = false;
        }
        #endregion

        private void btnTuTaoThuatToan_Click(object sender, EventArgs e)
        {
            ThemThuatToan formThemThuatToan = new ThemThuatToan(this);
            formThemThuatToan.ShowDialog();
        }

        public bool ThemThuatToan(string tenThuatToan, string xml)
        {
            xml = xml.Replace("\n", String.Empty);
            xml = xml.Replace("\r", String.Empty);
            xml = xml.Replace("\t", String.Empty);

            try
            {
                if (checkExistencePluginWithClassName(tenThuatToan))
                {
                    InitMethod initMethod = new InitMethod();

                    //Gọi Phương thức tạo plugin với input là 3 parametters 
                    bool b = initMethod.BuildPluginAuto(tenThuatToan, tenThuatToan, xml);

                    if (b)
                    {
                        LoadPlugin();
                        //this.Refresh();
                        return true;
                    }

                    
                }
                else
                {
                    MessageBox.Show("ClassName đã tồn tại !");

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Controls["panel"].Dispose();
            if(thread != null)
            {
                try
                {
                    thread.Abort();
                }
                catch (ThreadStateException)
                {
                    thread.Resume();
                }
            }

            this.Close();
        }

        private void trackBarTocDo_Scroll(object sender, EventArgs e)
        {
            int x = trackBarTocDo.Value;

            if (x == 0)
            {
                moveDelay = 40;
            }
            else {
                if (x == 1)
                {
                    moveDelay = 20;
                }
                else
                {
                    moveDelay = 5;
                }
            }
        }

        private void btnTamDung_Click(object sender, EventArgs e)
        {
            if (btnTamDung.Text == "Tạm dừng")
            {
                thread.Suspend();
                btnTamDung.Text = "Tiếp tục";
            }
            else
            {
                thread.Resume();
                btnTamDung.Text = "Tạm dừng";
            }
        }

    }
}
