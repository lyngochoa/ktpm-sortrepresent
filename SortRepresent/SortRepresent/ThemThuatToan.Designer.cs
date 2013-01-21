namespace SortRepresent
{
    partial class ThemThuatToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnTaoThuatToan = new System.Windows.Forms.Button();
            this.tbTenThuatToan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbXML = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Hàm hỗ trợ";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listBox1.ForeColor = System.Drawing.Color.Aquamarine;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "var",
            "assign",
            "if",
            "condition",
            "swap",
            "for",
            "while"});
            this.listBox1.Location = new System.Drawing.Point(10, 58);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(127, 527);
            this.listBox1.TabIndex = 14;
            // 
            // btnTaoThuatToan
            // 
            this.btnTaoThuatToan.Enabled = false;
            this.btnTaoThuatToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoThuatToan.Location = new System.Drawing.Point(631, 4);
            this.btnTaoThuatToan.Name = "btnTaoThuatToan";
            this.btnTaoThuatToan.Size = new System.Drawing.Size(139, 23);
            this.btnTaoThuatToan.TabIndex = 13;
            this.btnTaoThuatToan.Text = "Tạo thuật toán";
            this.btnTaoThuatToan.UseVisualStyleBackColor = true;
            this.btnTaoThuatToan.Click += new System.EventHandler(this.btnTaoThuatToan_Click);
            // 
            // tbTenThuatToan
            // 
            this.tbTenThuatToan.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbTenThuatToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenThuatToan.Location = new System.Drawing.Point(143, 6);
            this.tbTenThuatToan.Name = "tbTenThuatToan";
            this.tbTenThuatToan.Size = new System.Drawing.Size(482, 20);
            this.tbTenThuatToan.TabIndex = 12;
            this.tbTenThuatToan.TextChanged += new System.EventHandler(this.tbTenThuatToan_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên thuật toán";
            // 
            // rtbXML
            // 
            this.rtbXML.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rtbXML.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbXML.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbXML.Location = new System.Drawing.Point(143, 33);
            this.rtbXML.Name = "rtbXML";
            this.rtbXML.Size = new System.Drawing.Size(627, 552);
            this.rtbXML.TabIndex = 9;
            this.rtbXML.Text = "";
            this.rtbXML.TextChanged += new System.EventHandler(this.rtbXML_TextChanged);
            // 
            // ThemThuatToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 588);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnTaoThuatToan);
            this.Controls.Add(this.tbTenThuatToan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbXML);
            this.Name = "ThemThuatToan";
            this.Text = "ThemThuatToan";
            this.Load += new System.EventHandler(this.ThemThuatToan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnTaoThuatToan;
        private System.Windows.Forms.TextBox tbTenThuatToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbXML;
    }
}