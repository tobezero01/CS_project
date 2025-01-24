using System.Collections.Generic;
using System;

namespace VD1_TH2
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
            this.dtpNgayGui = new System.Windows.Forms.DateTimePicker();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSoTienGui = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.cbThoiGianGui = new System.Windows.Forms.ComboBox();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnThemVaoDS = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoPhatLoc = new System.Windows.Forms.RadioButton();
            this.rdoThuong = new System.Windows.Forms.RadioButton();
            this.lblTGGui = new System.Windows.Forms.Label();
            this.lblNgayGui = new System.Windows.Forms.Label();
            this.lblTienGui = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDanhSach = new System.Windows.Forms.ListBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayGui);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtSoTienGui);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.cbThoiGianGui);
            this.groupBox1.Controls.Add(this.btnMoi);
            this.groupBox1.Controls.Add(this.btnThemVaoDS);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblTGGui);
            this.groupBox1.Controls.Add(this.lblNgayGui);
            this.groupBox1.Controls.Add(this.lblTienGui);
            this.groupBox1.Controls.Add(this.lblDiaChi);
            this.groupBox1.Controls.Add(this.lblTen);
            this.groupBox1.Controls.Add(this.lblMa);
            this.groupBox1.Location = new System.Drawing.Point(25, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(393, 506);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin khách hàng gửi tiết  kiệm";
            // 
            // dtpNgayGui
            // 
            this.dtpNgayGui.Location = new System.Drawing.Point(165, 245);
            this.dtpNgayGui.Name = "dtpNgayGui";
            this.dtpNgayGui.Size = new System.Drawing.Size(104, 21);
            this.dtpNgayGui.TabIndex = 13;
            this.dtpNgayGui.Value = new System.DateTime(2023, 9, 20, 8, 6, 58, 0);
            this.dtpNgayGui.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(169, 99);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(100, 21);
            this.txtTenKH.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(169, 148);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(196, 21);
            this.txtDiaChi.TabIndex = 11;
            // 
            // txtSoTienGui
            // 
            this.txtSoTienGui.Location = new System.Drawing.Point(169, 198);
            this.txtSoTienGui.Name = "txtSoTienGui";
            this.txtSoTienGui.Size = new System.Drawing.Size(100, 21);
            this.txtSoTienGui.TabIndex = 10;
            this.txtSoTienGui.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTienGui_KeyPress);
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(169, 53);
            this.txtMaKH.Multiline = true;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(100, 26);
            this.txtMaKH.TabIndex = 9;
            this.txtMaKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaKH_KeyPress);
            // 
            // cbThoiGianGui
            // 
            this.cbThoiGianGui.FormattingEnabled = true;
            this.cbThoiGianGui.Location = new System.Drawing.Point(169, 289);
            this.cbThoiGianGui.Name = "cbThoiGianGui";
            this.cbThoiGianGui.Size = new System.Drawing.Size(68, 23);
            this.cbThoiGianGui.TabIndex = 0;
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(213, 445);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(109, 42);
            this.btnMoi.TabIndex = 8;
            this.btnMoi.Text = "Thêm &mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnThemVaoDS
            // 
            this.btnThemVaoDS.Location = new System.Drawing.Point(45, 445);
            this.btnThemVaoDS.Name = "btnThemVaoDS";
            this.btnThemVaoDS.Size = new System.Drawing.Size(113, 42);
            this.btnThemVaoDS.TabIndex = 7;
            this.btnThemVaoDS.Text = "Thêm vào";
            this.btnThemVaoDS.UseVisualStyleBackColor = true;
            this.btnThemVaoDS.Click += new System.EventHandler(this.btnThemVaoDS_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoPhatLoc);
            this.groupBox3.Controls.Add(this.rdoThuong);
            this.groupBox3.Location = new System.Drawing.Point(26, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 80);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại tiết kiệm";
            // 
            // rdoPhatLoc
            // 
            this.rdoPhatLoc.AutoSize = true;
            this.rdoPhatLoc.Location = new System.Drawing.Point(189, 34);
            this.rdoPhatLoc.Name = "rdoPhatLoc";
            this.rdoPhatLoc.Size = new System.Drawing.Size(73, 20);
            this.rdoPhatLoc.TabIndex = 1;
            this.rdoPhatLoc.TabStop = true;
            this.rdoPhatLoc.Text = "Phát lộc";
            this.rdoPhatLoc.UseVisualStyleBackColor = true;
            // 
            // rdoThuong
            // 
            this.rdoThuong.AutoSize = true;
            this.rdoThuong.Location = new System.Drawing.Point(24, 34);
            this.rdoThuong.Name = "rdoThuong";
            this.rdoThuong.Size = new System.Drawing.Size(71, 20);
            this.rdoThuong.TabIndex = 0;
            this.rdoThuong.TabStop = true;
            this.rdoThuong.Text = "Thường";
            this.rdoThuong.UseVisualStyleBackColor = true;
            // 
            // lblTGGui
            // 
            this.lblTGGui.AutoSize = true;
            this.lblTGGui.Location = new System.Drawing.Point(22, 292);
            this.lblTGGui.Name = "lblTGGui";
            this.lblTGGui.Size = new System.Drawing.Size(84, 16);
            this.lblTGGui.TabIndex = 5;
            this.lblTGGui.Text = "Thời gian gửi";
            // 
            // lblNgayGui
            // 
            this.lblNgayGui.AutoSize = true;
            this.lblNgayGui.Location = new System.Drawing.Point(22, 245);
            this.lblNgayGui.Name = "lblNgayGui";
            this.lblNgayGui.Size = new System.Drawing.Size(61, 16);
            this.lblNgayGui.TabIndex = 4;
            this.lblNgayGui.Text = "Ngày gửi";
            // 
            // lblTienGui
            // 
            this.lblTienGui.AutoSize = true;
            this.lblTienGui.Location = new System.Drawing.Point(21, 198);
            this.lblTienGui.Name = "lblTienGui";
            this.lblTienGui.Size = new System.Drawing.Size(69, 16);
            this.lblTienGui.TabIndex = 3;
            this.lblTienGui.Text = "Số tiền gửi";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(22, 151);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(47, 16);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(22, 102);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(67, 16);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Họ tên KH";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(22, 56);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(47, 16);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã KH";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDanhSach);
            this.groupBox2.Location = new System.Drawing.Point(424, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(504, 412);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách khách hàng";
            // 
            // lstDanhSach
            // 
            this.lstDanhSach.FormattingEnabled = true;
            this.lstDanhSach.ItemHeight = 15;
            this.lstDanhSach.Location = new System.Drawing.Point(19, 38);
            this.lstDanhSach.Name = "lstDanhSach";
            this.lstDanhSach.ScrollAlwaysVisible = true;
            this.lstDanhSach.Size = new System.Drawing.Size(467, 364);
            this.lstDanhSach.Sorted = true;
            this.lstDanhSach.TabIndex = 0;
            this.lstDanhSach.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(618, 475);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(113, 42);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(776, 475);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 42);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "T&hoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 562);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTGGui;
        private System.Windows.Forms.Label lblNgayGui;
        private System.Windows.Forms.Label lblTienGui;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoPhatLoc;
        private System.Windows.Forms.RadioButton rdoThuong;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnThemVaoDS;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbThoiGianGui;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoTienGui;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.ListBox lstDanhSach;
        private System.Windows.Forms.DateTimePicker dtpNgayGui;
       

    }
}

