namespace BAI1_TH2
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTenMonHoc = new System.Windows.Forms.Label();
            this.lblSoTin = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblTongTin = new System.Windows.Forms.Label();
            this.lblTongDiem = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.tbTongSoTin = new System.Windows.Forms.TextBox();
            this.tbDiemTB = new System.Windows.Forms.TextBox();
            this.tbTongSoDiem = new System.Windows.Forms.TextBox();
            this.tbDiem = new System.Windows.Forms.TextBox();
            this.tbSoTin = new System.Windows.Forms.TextBox();
            this.cbTenMonHoc = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.listMonHoc = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cbTenMonHoc);
            this.groupBox1.Controls.Add(this.tbSoTin);
            this.groupBox1.Controls.Add(this.tbDiem);
            this.groupBox1.Controls.Add(this.lblDiem);
            this.groupBox1.Controls.Add(this.lblSoTin);
            this.groupBox1.Controls.Add(this.lblTenMonHoc);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(369, 532);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin điểm sinh viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listMonHoc);
            this.groupBox2.Location = new System.Drawing.Point(389, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(497, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các môn học";
            // 
            // lblTenMonHoc
            // 
            this.lblTenMonHoc.AutoSize = true;
            this.lblTenMonHoc.Location = new System.Drawing.Point(61, 76);
            this.lblTenMonHoc.Name = "lblTenMonHoc";
            this.lblTenMonHoc.Size = new System.Drawing.Size(101, 20);
            this.lblTenMonHoc.TabIndex = 0;
            this.lblTenMonHoc.Text = "Tên môn học";
            // 
            // lblSoTin
            // 
            this.lblSoTin.AutoSize = true;
            this.lblSoTin.Location = new System.Drawing.Point(61, 188);
            this.lblSoTin.Name = "lblSoTin";
            this.lblSoTin.Size = new System.Drawing.Size(74, 20);
            this.lblSoTin.TabIndex = 1;
            this.lblSoTin.Text = "Số tín chỉ";
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(61, 264);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(46, 20);
            this.lblDiem.TabIndex = 2;
            this.lblDiem.Text = "Điểm";
            // 
            // lblTongTin
            // 
            this.lblTongTin.AutoSize = true;
            this.lblTongTin.Location = new System.Drawing.Point(389, 299);
            this.lblTongTin.Name = "lblTongTin";
            this.lblTongTin.Size = new System.Drawing.Size(111, 20);
            this.lblTongTin.TabIndex = 2;
            this.lblTongTin.Text = "Tổng số tín chỉ";
            // 
            // lblTongDiem
            // 
            this.lblTongDiem.AutoSize = true;
            this.lblTongDiem.Location = new System.Drawing.Point(666, 299);
            this.lblTongDiem.Name = "lblTongDiem";
            this.lblTongDiem.Size = new System.Drawing.Size(104, 20);
            this.lblTongDiem.TabIndex = 3;
            this.lblTongDiem.Text = "Tổng số điểm";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Location = new System.Drawing.Point(389, 376);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(121, 20);
            this.lblDiemTB.TabIndex = 4;
            this.lblDiemTB.Text = "Điểm trung bình";
            // 
            // tbTongSoTin
            // 
            this.tbTongSoTin.Location = new System.Drawing.Point(524, 296);
            this.tbTongSoTin.Name = "tbTongSoTin";
            this.tbTongSoTin.Size = new System.Drawing.Size(100, 26);
            this.tbTongSoTin.TabIndex = 5;
            // 
            // tbDiemTB
            // 
            this.tbDiemTB.Location = new System.Drawing.Point(524, 373);
            this.tbDiemTB.Name = "tbDiemTB";
            this.tbDiemTB.Size = new System.Drawing.Size(206, 26);
            this.tbDiemTB.TabIndex = 6;
            // 
            // tbTongSoDiem
            // 
            this.tbTongSoDiem.Location = new System.Drawing.Point(776, 296);
            this.tbTongSoDiem.Name = "tbTongSoDiem";
            this.tbTongSoDiem.Size = new System.Drawing.Size(100, 26);
            this.tbTongSoDiem.TabIndex = 7;
            // 
            // tbDiem
            // 
            this.tbDiem.Location = new System.Drawing.Point(159, 261);
            this.tbDiem.Name = "tbDiem";
            this.tbDiem.Size = new System.Drawing.Size(86, 26);
            this.tbDiem.TabIndex = 6;
            // 
            // tbSoTin
            // 
            this.tbSoTin.Enabled = false;
            this.tbSoTin.Location = new System.Drawing.Point(159, 185);
            this.tbSoTin.Name = "tbSoTin";
            this.tbSoTin.Size = new System.Drawing.Size(178, 26);
            this.tbSoTin.TabIndex = 7;
            // 
            // cbTenMonHoc
            // 
            this.cbTenMonHoc.FormattingEnabled = true;
            this.cbTenMonHoc.Location = new System.Drawing.Point(65, 115);
            this.cbTenMonHoc.Name = "cbTenMonHoc";
            this.cbTenMonHoc.Size = new System.Drawing.Size(272, 28);
            this.cbTenMonHoc.TabIndex = 0;
            this.cbTenMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbTenMonHoc_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(87, 360);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(183, 50);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm vào &danh sách";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(418, 448);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(183, 50);
            this.btnTinh.TabIndex = 8;
            this.btnTinh.Text = "&Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(703, 448);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(183, 50);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // listMonHoc
            // 
            this.listMonHoc.FormattingEnabled = true;
            this.listMonHoc.ItemHeight = 20;
            this.listMonHoc.Location = new System.Drawing.Point(17, 26);
            this.listMonHoc.Name = "listMonHoc";
            this.listMonHoc.Size = new System.Drawing.Size(470, 184);
            this.listMonHoc.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.tbTongSoDiem);
            this.Controls.Add(this.tbDiemTB);
            this.Controls.Add(this.tbTongSoTin);
            this.Controls.Add(this.lblDiemTB);
            this.Controls.Add(this.lblTongDiem);
            this.Controls.Add(this.lblTongTin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblSoTin;
        private System.Windows.Forms.Label lblTenMonHoc;
        private System.Windows.Forms.Label lblTongTin;
        private System.Windows.Forms.Label lblTongDiem;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbTenMonHoc;
        private System.Windows.Forms.TextBox tbSoTin;
        private System.Windows.Forms.TextBox tbDiem;
        private System.Windows.Forms.TextBox tbTongSoTin;
        private System.Windows.Forms.TextBox tbDiemTB;
        private System.Windows.Forms.TextBox tbTongSoDiem;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ListBox listMonHoc;
    }
}

