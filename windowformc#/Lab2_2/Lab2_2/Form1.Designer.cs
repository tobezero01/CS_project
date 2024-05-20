namespace Lab2_2
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.rdoHalfDay = new System.Windows.Forms.RadioButton();
            this.rdoFullDay = new System.Windows.Forms.RadioButton();
            this.txtAdd = new System.Windows.Forms.Button();
            this.cbAmount = new System.Windows.Forms.ComboBox();
            this.cbDrinks = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDrinksPrice = new System.Windows.Forms.TextBox();
            this.txtYachtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDrinksPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDrinks = new System.Windows.Forms.Label();
            this.lblYachtPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.lbCustomer = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpInfo.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnAddNew);
            this.grpInfo.Controls.Add(this.rdoHalfDay);
            this.grpInfo.Controls.Add(this.rdoFullDay);
            this.grpInfo.Controls.Add(this.txtAdd);
            this.grpInfo.Controls.Add(this.cbAmount);
            this.grpInfo.Controls.Add(this.cbDrinks);
            this.grpInfo.Controls.Add(this.label7);
            this.grpInfo.Controls.Add(this.txtDrinksPrice);
            this.grpInfo.Controls.Add(this.txtYachtPrice);
            this.grpInfo.Controls.Add(this.txtName);
            this.grpInfo.Controls.Add(this.label6);
            this.grpInfo.Controls.Add(this.lblDrinksPrice);
            this.grpInfo.Controls.Add(this.lblAmount);
            this.grpInfo.Controls.Add(this.lblDrinks);
            this.grpInfo.Controls.Add(this.lblYachtPrice);
            this.grpInfo.Controls.Add(this.lblName);
            this.grpInfo.Location = new System.Drawing.Point(14, 81);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInfo.Size = new System.Drawing.Size(507, 428);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Nhập thông tin khách hàng đặt Tour ";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(284, 356);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(128, 44);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "Thêm &mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // rdoHalfDay
            // 
            this.rdoHalfDay.AutoSize = true;
            this.rdoHalfDay.Location = new System.Drawing.Point(249, 112);
            this.rdoHalfDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoHalfDay.Name = "rdoHalfDay";
            this.rdoHalfDay.Size = new System.Drawing.Size(97, 24);
            this.rdoHalfDay.TabIndex = 14;
            this.rdoHalfDay.TabStop = true;
            this.rdoHalfDay.Text = "Nửa ngày";
            this.rdoHalfDay.UseVisualStyleBackColor = true;
            this.rdoHalfDay.CheckedChanged += new System.EventHandler(this.rdoHalfDay_CheckedChanged);
            // 
            // rdoFullDay
            // 
            this.rdoFullDay.AutoSize = true;
            this.rdoFullDay.Location = new System.Drawing.Point(37, 112);
            this.rdoFullDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoFullDay.Name = "rdoFullDay";
            this.rdoFullDay.Size = new System.Drawing.Size(88, 24);
            this.rdoFullDay.TabIndex = 13;
            this.rdoFullDay.TabStop = true;
            this.rdoFullDay.Text = "Cả ngày";
            this.rdoFullDay.UseVisualStyleBackColor = true;
            this.rdoFullDay.CheckedChanged += new System.EventHandler(this.rdoFullDay_CheckedChanged);
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(79, 356);
            this.txtAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(169, 44);
            this.txtAdd.TabIndex = 12;
            this.txtAdd.Text = "Thêm vào danh sách";
            this.txtAdd.UseVisualStyleBackColor = true;
            // 
            // cbAmount
            // 
            this.cbAmount.FormattingEnabled = true;
            this.cbAmount.Items.AddRange(new object[] {
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
            this.cbAmount.Location = new System.Drawing.Point(205, 285);
            this.cbAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAmount.Name = "cbAmount";
            this.cbAmount.Size = new System.Drawing.Size(88, 28);
            this.cbAmount.TabIndex = 11;
            this.cbAmount.SelectedIndexChanged += new System.EventHandler(this.cbAmount_SelectedIndexChanged);
            // 
            // cbDrinks
            // 
            this.cbDrinks.FormattingEnabled = true;
            this.cbDrinks.Items.AddRange(new object[] {
            "Coca cola",
            "Pepsi",
            "Seven up"});
            this.cbDrinks.Location = new System.Drawing.Point(37, 285);
            this.cbDrinks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDrinks.Name = "cbDrinks";
            this.cbDrinks.Size = new System.Drawing.Size(119, 28);
            this.cbDrinks.TabIndex = 10;
            this.cbDrinks.SelectedIndexChanged += new System.EventHandler(this.cbDrinks_SelectedIndexChanged);
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
            // txtDrinksPrice
            // 
            this.txtDrinksPrice.Enabled = false;
            this.txtDrinksPrice.Location = new System.Drawing.Point(354, 287);
            this.txtDrinksPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDrinksPrice.Name = "txtDrinksPrice";
            this.txtDrinksPrice.Size = new System.Drawing.Size(83, 26);
            this.txtDrinksPrice.TabIndex = 8;
            this.txtDrinksPrice.TextChanged += new System.EventHandler(this.txtDrinksPrice_TextChanged);
            // 
            // txtYachtPrice
            // 
            this.txtYachtPrice.Enabled = false;
            this.txtYachtPrice.Location = new System.Drawing.Point(144, 173);
            this.txtYachtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYachtPrice.Name = "txtYachtPrice";
            this.txtYachtPrice.ReadOnly = true;
            this.txtYachtPrice.Size = new System.Drawing.Size(149, 26);
            this.txtYachtPrice.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(223, 26);
            this.txtName.TabIndex = 6;
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
            // lblDrinksPrice
            // 
            this.lblDrinksPrice.AutoSize = true;
            this.lblDrinksPrice.Location = new System.Drawing.Point(351, 253);
            this.lblDrinksPrice.Name = "lblDrinksPrice";
            this.lblDrinksPrice.Size = new System.Drawing.Size(39, 20);
            this.lblDrinksPrice.TabIndex = 4;
            this.lblDrinksPrice.Text = "Tiền";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(201, 253);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(72, 20);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Số lượng";
            // 
            // lblDrinks
            // 
            this.lblDrinks.AutoSize = true;
            this.lblDrinks.Location = new System.Drawing.Point(34, 253);
            this.lblDrinks.Name = "lblDrinks";
            this.lblDrinks.Size = new System.Drawing.Size(70, 20);
            this.lblDrinks.TabIndex = 2;
            this.lblDrinks.Text = "Đồ uống";
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ tên";
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.lbCustomer);
            this.grpCustomer.Location = new System.Drawing.Point(528, 81);
            this.grpCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCustomer.Size = new System.Drawing.Size(518, 428);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Danh sách khách hàng đặt Tour";
            // 
            // lbCustomer
            // 
            this.lbCustomer.FormattingEnabled = true;
            this.lbCustomer.ItemHeight = 20;
            this.lbCustomer.Location = new System.Drawing.Point(27, 35);
            this.lbCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(466, 364);
            this.lbCustomer.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(904, 539);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 41);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "T&hoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1059, 631);
            this.Controls.Add(this.btnExit);
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
        private System.Windows.Forms.Label lblDrinksPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDrinks;
        private System.Windows.Forms.Label lblYachtPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.TextBox txtDrinksPrice;
        private System.Windows.Forms.TextBox txtYachtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.RadioButton rdoHalfDay;
        private System.Windows.Forms.RadioButton rdoFullDay;
        private System.Windows.Forms.Button txtAdd;
        private System.Windows.Forms.ComboBox cbAmount;
        private System.Windows.Forms.ComboBox cbDrinks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbCustomer;
        private System.Windows.Forms.Button btnExit;
    }
}

