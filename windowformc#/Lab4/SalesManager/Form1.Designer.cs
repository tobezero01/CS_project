namespace SalesManager
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
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBoxDetailProduct = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.dtpProduceDate = new System.Windows.Forms.DateTimePicker();
            this.txtProductNote = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductUnit = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductNote = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblProduceDate = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearchProductName = new System.Windows.Forms.TextBox();
            this.txtSearchProductID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.errDetail = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.groupBoxDetailProduct.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1161, 73);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1161, 73);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.btnExit);
            this.panelFooter.Controls.Add(this.btnDelete);
            this.panelFooter.Controls.Add(this.btnUpdate);
            this.panelFooter.Controls.Add(this.btnAdd);
            this.panelFooter.Controls.Add(this.btnSearch);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 577);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1161, 73);
            this.panelFooter.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(553, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Th&oát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(430, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(303, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 35);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(176, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "T&hêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(52, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBoxDetailProduct
            // 
            this.groupBoxDetailProduct.Controls.Add(this.btnCancel);
            this.groupBoxDetailProduct.Controls.Add(this.btnSave);
            this.groupBoxDetailProduct.Controls.Add(this.dtpExpirationDate);
            this.groupBoxDetailProduct.Controls.Add(this.dtpProduceDate);
            this.groupBoxDetailProduct.Controls.Add(this.txtProductNote);
            this.groupBoxDetailProduct.Controls.Add(this.txtProductPrice);
            this.groupBoxDetailProduct.Controls.Add(this.txtProductUnit);
            this.groupBoxDetailProduct.Controls.Add(this.txtProductName);
            this.groupBoxDetailProduct.Controls.Add(this.txtProductID);
            this.groupBoxDetailProduct.Controls.Add(this.lblProductNote);
            this.groupBoxDetailProduct.Controls.Add(this.lblProductPrice);
            this.groupBoxDetailProduct.Controls.Add(this.lblProductUnit);
            this.groupBoxDetailProduct.Controls.Add(this.lblExpirationDate);
            this.groupBoxDetailProduct.Controls.Add(this.lblProduceDate);
            this.groupBoxDetailProduct.Controls.Add(this.lblProductName);
            this.groupBoxDetailProduct.Controls.Add(this.lblProductID);
            this.groupBoxDetailProduct.Controls.Add(this.splitter1);
            this.groupBoxDetailProduct.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxDetailProduct.Location = new System.Drawing.Point(779, 73);
            this.groupBoxDetailProduct.Name = "groupBoxDetailProduct";
            this.groupBoxDetailProduct.Size = new System.Drawing.Size(382, 504);
            this.groupBoxDetailProduct.TabIndex = 2;
            this.groupBoxDetailProduct.TabStop = false;
            this.groupBoxDetailProduct.Text = "Chi tiết";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 38);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(54, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 38);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpirationDate.CustomFormat = "yyyy-MM-dd";
            this.dtpExpirationDate.Location = new System.Drawing.Point(117, 144);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(243, 27);
            this.dtpExpirationDate.TabIndex = 13;
            this.dtpExpirationDate.Value = new System.DateTime(2020, 10, 26, 0, 0, 0, 0);
            // 
            // dtpProduceDate
            // 
            this.dtpProduceDate.CustomFormat = "yyyy-MM-dd";
            this.dtpProduceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProduceDate.Location = new System.Drawing.Point(117, 104);
            this.dtpProduceDate.Name = "dtpProduceDate";
            this.dtpProduceDate.Size = new System.Drawing.Size(243, 27);
            this.dtpProduceDate.TabIndex = 12;
            this.dtpProduceDate.Value = new System.DateTime(2020, 10, 26, 0, 0, 0, 0);
            // 
            // txtProductNote
            // 
            this.txtProductNote.Location = new System.Drawing.Point(117, 261);
            this.txtProductNote.Name = "txtProductNote";
            this.txtProductNote.Size = new System.Drawing.Size(243, 27);
            this.txtProductNote.TabIndex = 16;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(117, 220);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(243, 27);
            this.txtProductPrice.TabIndex = 15;
            // 
            // txtProductUnit
            // 
            this.txtProductUnit.Location = new System.Drawing.Point(117, 180);
            this.txtProductUnit.Name = "txtProductUnit";
            this.txtProductUnit.Size = new System.Drawing.Size(243, 27);
            this.txtProductUnit.TabIndex = 14;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(117, 70);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(243, 27);
            this.txtProductName.TabIndex = 9;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(117, 31);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(243, 27);
            this.txtProductID.TabIndex = 8;
            // 
            // lblProductNote
            // 
            this.lblProductNote.Location = new System.Drawing.Point(26, 267);
            this.lblProductNote.Name = "lblProductNote";
            this.lblProductNote.Size = new System.Drawing.Size(85, 21);
            this.lblProductNote.TabIndex = 7;
            this.lblProductNote.Text = "Ghi chú:";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Location = new System.Drawing.Point(26, 226);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(85, 21);
            this.lblProductPrice.TabIndex = 6;
            this.lblProductPrice.Text = "Giá:";
            // 
            // lblProductUnit
            // 
            this.lblProductUnit.Location = new System.Drawing.Point(26, 186);
            this.lblProductUnit.Name = "lblProductUnit";
            this.lblProductUnit.Size = new System.Drawing.Size(85, 21);
            this.lblProductUnit.TabIndex = 5;
            this.lblProductUnit.Text = "Đơn vị:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Location = new System.Drawing.Point(26, 147);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(85, 21);
            this.lblExpirationDate.TabIndex = 4;
            this.lblExpirationDate.Text = "Ngày HH:";
            // 
            // lblProduceDate
            // 
            this.lblProduceDate.Location = new System.Drawing.Point(26, 109);
            this.lblProduceDate.Name = "lblProduceDate";
            this.lblProduceDate.Size = new System.Drawing.Size(85, 21);
            this.lblProduceDate.TabIndex = 3;
            this.lblProduceDate.Text = "Ngày SX:";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(26, 73);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(85, 21);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên SP:";
            // 
            // lblProductID
            // 
            this.lblProductID.Location = new System.Drawing.Point(26, 34);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(85, 21);
            this.lblProductID.TabIndex = 1;
            this.lblProductID.Text = "Mã SP:";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitter1.Location = new System.Drawing.Point(3, 23);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 478);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.txtSearchProductName);
            this.groupBoxSearch.Controls.Add(this.txtSearchProductID);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.splitter2);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch.Location = new System.Drawing.Point(0, 73);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(779, 94);
            this.groupBoxSearch.TabIndex = 3;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Tìm kiếm";
            // 
            // txtSearchProductName
            // 
            this.txtSearchProductName.Location = new System.Drawing.Point(553, 31);
            this.txtSearchProductName.Name = "txtSearchProductName";
            this.txtSearchProductName.Size = new System.Drawing.Size(194, 27);
            this.txtSearchProductName.TabIndex = 1;
            // 
            // txtSearchProductID
            // 
            this.txtSearchProductID.Location = new System.Drawing.Point(135, 31);
            this.txtSearchProductID.Name = "txtSearchProductID";
            this.txtSearchProductID.Size = new System.Drawing.Size(194, 27);
            this.txtSearchProductID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(455, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên SP:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã SP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(3, 81);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(773, 10);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.dgvProducts);
            this.groupBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Location = new System.Drawing.Point(0, 167);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(779, 410);
            this.groupBoxResult.TabIndex = 4;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Kết quả";
            // 
            // dgvProducts
            // 
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.GridColor = System.Drawing.SystemColors.Control;
            this.dgvProducts.Location = new System.Drawing.Point(3, 23);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(773, 384);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // errDetail
            // 
            this.errDetail.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 650);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.groupBoxDetailProduct);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.groupBoxDetailProduct.ResumeLayout(false);
            this.groupBoxDetailProduct.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDetail)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Panel panelFooter;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.GroupBox groupBoxDetailProduct;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.GroupBox groupBoxSearch;
		private System.Windows.Forms.GroupBox groupBoxResult;
		private System.Windows.Forms.Label lblExpirationDate;
		private System.Windows.Forms.Label lblProduceDate;
		private System.Windows.Forms.Label lblProductName;
		private System.Windows.Forms.Label lblProductPrice;
		private System.Windows.Forms.Label lblProductUnit;
		private System.Windows.Forms.Label lblProductNote;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.DateTimePicker dtpExpirationDate;
		private System.Windows.Forms.DateTimePicker dtpProduceDate;
		private System.Windows.Forms.TextBox txtProductNote;
		private System.Windows.Forms.TextBox txtProductPrice;
		private System.Windows.Forms.TextBox txtProductUnit;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.TextBox txtProductID;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtSearchProductName;
		private System.Windows.Forms.TextBox txtSearchProductID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvProducts;
		private System.Windows.Forms.ErrorProvider errDetail;
	}
}

