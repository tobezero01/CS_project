namespace BAI2_TH2
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.rdoNuaNgay = new System.Windows.Forms.RadioButton();
            this.rdoCaNgay = new System.Windows.Forms.RadioButton();
            this.txtThemDS = new System.Windows.Forms.Button();
            this.cbSoLuong = new System.Windows.Forms.ComboBox();
            this.cbDoUong = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTienDU = new System.Windows.Forms.TextBox();
            this.txtGiaDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTien = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblDoUong = new System.Windows.Forms.Label();
            this.lblYachtPrice = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.lbKhachHang = new System.Windows.Forms.ListBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grpInfo.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnThemMoi);
            this.grpInfo.Controls.Add(this.rdoNuaNgay);
            this.grpInfo.Controls.Add(this.rdoCaNgay);
            this.grpInfo.Controls.Add(this.txtThemDS);
            this.grpInfo.Controls.Add(this.cbSoLuong);
            this.grpInfo.Controls.Add(this.cbDoUong);
            this.grpInfo.Controls.Add(this.label7);
            this.grpInfo.Controls.Add(this.txtTienDU);
            this.grpInfo.Controls.Add(this.txtGiaDT);
            this.grpInfo.Controls.Add(this.txtHoTen);
            this.grpInfo.Controls.Add(this.label6);
            this.grpInfo.Controls.Add(this.lblTien);
            this.grpInfo.Controls.Add(this.lblSoLuong);
            this.grpInfo.Controls.Add(this.lblDoUong);
            this.grpInfo.Controls.Add(this.lblYachtPrice);
            this.grpInfo.Controls.Add(this.lblHoTen);
            this.grpInfo.Location = new System.Drawing.Point(14, 81);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInfo.Size = new System.Drawing.Size(507, 428);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Nhập thông tin khách hàng đặt Tour ";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(262, 355);
            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(128, 44);
            this.btnThemMoi.TabIndex = 15;
            this.btnThemMoi.Text = "Thêm &mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // rdoNuaNgay
            // 
            this.rdoNuaNgay.AutoSize = true;
            this.rdoNuaNgay.Location = new System.Drawing.Point(249, 112);
            this.rdoNuaNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoNuaNgay.Name = "rdoNuaNgay";
            this.rdoNuaNgay.Size = new System.Drawing.Size(97, 24);
            this.rdoNuaNgay.TabIndex = 14;
            this.rdoNuaNgay.TabStop = true;
            this.rdoNuaNgay.Text = "Nửa ngày";
            this.rdoNuaNgay.UseVisualStyleBackColor = true;
            this.rdoNuaNgay.CheckedChanged += new System.EventHandler(this.rdoNuaNgay_CheckedChanged);
            // 
            // rdoCaNgay
            // 
            this.rdoCaNgay.AutoSize = true;
            this.rdoCaNgay.Location = new System.Drawing.Point(37, 112);
            this.rdoCaNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoCaNgay.Name = "rdoCaNgay";
            this.rdoCaNgay.Size = new System.Drawing.Size(88, 24);
            this.rdoCaNgay.TabIndex = 13;
            this.rdoCaNgay.TabStop = true;
            this.rdoCaNgay.Text = "Cả ngày";
            this.rdoCaNgay.UseVisualStyleBackColor = true;
            this.rdoCaNgay.CheckedChanged += new System.EventHandler(this.rdoCaNgay_CheckedChanged);
            // 
            // txtThemDS
            // 
            this.txtThemDS.Location = new System.Drawing.Point(37, 355);
            this.txtThemDS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtThemDS.Name = "txtThemDS";
            this.txtThemDS.Size = new System.Drawing.Size(169, 44);
            this.txtThemDS.TabIndex = 12;
            this.txtThemDS.Text = "Thêm vào danh sách";
            this.txtThemDS.UseVisualStyleBackColor = true;
            this.txtThemDS.Click += new System.EventHandler(this.txtThemDS_Click);
            // 
            // cbSoLuong
            // 
            this.cbSoLuong.FormattingEnabled = true;
            this.cbSoLuong.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbSoLuong.Location = new System.Drawing.Point(205, 285);
            this.cbSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSoLuong.Name = "cbSoLuong";
            this.cbSoLuong.Size = new System.Drawing.Size(88, 28);
            this.cbSoLuong.TabIndex = 11;
            this.cbSoLuong.SelectedIndexChanged += new System.EventHandler(this.cbSoLuong_SelectedIndexChanged);
            // 
            // cbDoUong
            // 
            this.cbDoUong.FormattingEnabled = true;
            this.cbDoUong.Items.AddRange(new object[] {
            "Coca cola",
            "Pepsi",
            "Seven up"});
            this.cbDoUong.Location = new System.Drawing.Point(37, 285);
            this.cbDoUong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDoUong.Name = "cbDoUong";
            this.cbDoUong.Size = new System.Drawing.Size(119, 28);
            this.cbDoUong.TabIndex = 10;
            this.cbDoUong.SelectedIndexChanged += new System.EventHandler(this.cbDoUong_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "$";
            // 
            // txtTienDU
            // 
            this.txtTienDU.Enabled = false;
            this.txtTienDU.Location = new System.Drawing.Point(354, 287);
            this.txtTienDU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTienDU.Name = "txtTienDU";
            this.txtTienDU.Size = new System.Drawing.Size(83, 26);
            this.txtTienDU.TabIndex = 8;
            // 
            // txtGiaDT
            // 
            this.txtGiaDT.Enabled = false;
            this.txtGiaDT.Location = new System.Drawing.Point(144, 173);
            this.txtGiaDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGiaDT.Name = "txtGiaDT";
            this.txtGiaDT.ReadOnly = true;
            this.txtGiaDT.Size = new System.Drawing.Size(149, 26);
            this.txtGiaDT.TabIndex = 7;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(122, 49);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(223, 26);
            this.txtHoTen.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "$";
            // 
            // lblTien
            // 
            this.lblTien.AutoSize = true;
            this.lblTien.Location = new System.Drawing.Point(351, 253);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(39, 20);
            this.lblTien.TabIndex = 4;
            this.lblTien.Text = "Tiền";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(201, 253);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(72, 20);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblDoUong
            // 
            this.lblDoUong.AutoSize = true;
            this.lblDoUong.Location = new System.Drawing.Point(34, 253);
            this.lblDoUong.Name = "lblDoUong";
            this.lblDoUong.Size = new System.Drawing.Size(70, 20);
            this.lblDoUong.TabIndex = 2;
            this.lblDoUong.Text = "Đồ uống";
            // 
            // lblYachtPrice
            // 
            this.lblYachtPrice.AutoSize = true;
            this.lblYachtPrice.Location = new System.Drawing.Point(34, 176);
            this.lblYachtPrice.Name = "lblYachtPrice";
            this.lblYachtPrice.Size = new System.Drawing.Size(108, 20);
            this.lblYachtPrice.TabIndex = 1;
            this.lblYachtPrice.Text = "Giá du thuyền";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(34, 54);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(57, 20);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên";
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.lbKhachHang);
            this.grpCustomer.Location = new System.Drawing.Point(528, 81);
            this.grpCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCustomer.Size = new System.Drawing.Size(518, 428);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Danh sách khách hàng đặt Tour";
            // 
            // lbKhachHang
            // 
            this.lbKhachHang.FormattingEnabled = true;
            this.lbKhachHang.ItemHeight = 20;
            this.lbKhachHang.Location = new System.Drawing.Point(27, 35);
            this.lbKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbKhachHang.Name = "lbKhachHang";
            this.lbKhachHang.Size = new System.Drawing.Size(466, 364);
            this.lbKhachHang.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(904, 539);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 41);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "T&hoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1059, 631);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.grpInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Công Ty Du Thuyền Hồ Tây";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblDoUong;
        private System.Windows.Forms.Label lblYachtPrice;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.TextBox txtTienDU;
        private System.Windows.Forms.TextBox txtGiaDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.RadioButton rdoNuaNgay;
        private System.Windows.Forms.RadioButton rdoCaNgay;
        private System.Windows.Forms.Button txtThemDS;
        private System.Windows.Forms.ComboBox cbSoLuong;
        private System.Windows.Forms.ComboBox cbDoUong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbKhachHang;
        private System.Windows.Forms.Button btnThoat;
    }
}


