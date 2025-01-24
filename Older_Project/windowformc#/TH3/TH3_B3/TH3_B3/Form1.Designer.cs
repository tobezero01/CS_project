namespace TH3_B3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbODia = new System.Windows.Forms.ComboBox();
            this.cbThuMuc = new System.Windows.Forms.ComboBox();
            this.lblODia = new System.Windows.Forms.Label();
            this.lblThuMuc = new System.Windows.Forms.Label();
            this.lblTapTin = new System.Windows.Forms.Label();
            this.rtbLyrics = new System.Windows.Forms.RichTextBox();
            this.lbTapTin = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbODia
            // 
            this.cbODia.FormattingEnabled = true;
            this.cbODia.Location = new System.Drawing.Point(153, 15);
            this.cbODia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbODia.Name = "cbODia";
            this.cbODia.Size = new System.Drawing.Size(267, 28);
            this.cbODia.TabIndex = 0;
            this.cbODia.SelectedIndexChanged += new System.EventHandler(this.cbODia_SelectedIndexChanged);
            // 
            // cbThuMuc
            // 
            this.cbThuMuc.FormattingEnabled = true;
            this.cbThuMuc.Location = new System.Drawing.Point(153, 74);
            this.cbThuMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThuMuc.Name = "cbThuMuc";
            this.cbThuMuc.Size = new System.Drawing.Size(267, 28);
            this.cbThuMuc.TabIndex = 1;
            this.cbThuMuc.SelectedIndexChanged += new System.EventHandler(this.cbThuMuc_SelectedIndexChanged);
            // 
            // lblODia
            // 
            this.lblODia.AutoSize = true;
            this.lblODia.Location = new System.Drawing.Point(37, 18);
            this.lblODia.Name = "lblODia";
            this.lblODia.Size = new System.Drawing.Size(46, 20);
            this.lblODia.TabIndex = 2;
            this.lblODia.Text = "Ổ đĩa";
            // 
            // lblThuMuc
            // 
            this.lblThuMuc.AutoSize = true;
            this.lblThuMuc.Location = new System.Drawing.Point(37, 77);
            this.lblThuMuc.Name = "lblThuMuc";
            this.lblThuMuc.Size = new System.Drawing.Size(70, 20);
            this.lblThuMuc.TabIndex = 3;
            this.lblThuMuc.Text = "Thư mục";
            // 
            // lblTapTin
            // 
            this.lblTapTin.AutoSize = true;
            this.lblTapTin.Location = new System.Drawing.Point(37, 129);
            this.lblTapTin.Name = "lblTapTin";
            this.lblTapTin.Size = new System.Drawing.Size(57, 20);
            this.lblTapTin.TabIndex = 4;
            this.lblTapTin.Text = "Tập tin";
            // 
            // rtbLyrics
            // 
            this.rtbLyrics.Location = new System.Drawing.Point(450, 15);
            this.rtbLyrics.Name = "rtbLyrics";
            this.rtbLyrics.Size = new System.Drawing.Size(402, 630);
            this.rtbLyrics.TabIndex = 6;
            this.rtbLyrics.Text = "";
            // 
            // lbTapTin
            // 
            this.lbTapTin.FormattingEnabled = true;
            this.lbTapTin.ItemHeight = 20;
            this.lbTapTin.Location = new System.Drawing.Point(41, 167);
            this.lbTapTin.Name = "lbTapTin";
            this.lbTapTin.Size = new System.Drawing.Size(379, 184);
            this.lbTapTin.TabIndex = 7;
            this.lbTapTin.SelectedIndexChanged += new System.EventHandler(this.lbTapTin_SelectedIndexChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(41, 379);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(379, 266);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 657);
            this.Controls.Add(this.lbTapTin);
            this.Controls.Add(this.rtbLyrics);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lblTapTin);
            this.Controls.Add(this.lblThuMuc);
            this.Controls.Add(this.lblODia);
            this.Controls.Add(this.cbThuMuc);
            this.Controls.Add(this.cbODia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbODia;
        private System.Windows.Forms.ComboBox cbThuMuc;
        private System.Windows.Forms.Label lblODia;
        private System.Windows.Forms.Label lblThuMuc;
        private System.Windows.Forms.Label lblTapTin;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.RichTextBox rtbLyrics;
        private System.Windows.Forms.ListBox lbTapTin;
    }
}

