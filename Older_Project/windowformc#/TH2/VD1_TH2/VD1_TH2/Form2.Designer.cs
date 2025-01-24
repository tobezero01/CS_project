namespace VD1_TH2
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.lbThongTinTimKiem = new System.Windows.Forms.Label();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbThongTinTimKiem
            // 
            this.lbThongTinTimKiem.AutoSize = true;
            this.lbThongTinTimKiem.Location = new System.Drawing.Point(162, 166);
            this.lbThongTinTimKiem.Name = "lbThongTinTimKiem";
            this.lbThongTinTimKiem.Size = new System.Drawing.Size(114, 16);
            this.lbThongTinTimKiem.TabIndex = 2;
            this.lbThongTinTimKiem.Text = "Thong tin tim kiem";
            this.lbThongTinTimKiem.Click += new System.EventHandler(this.lbThongTinTimKiem_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Location = new System.Drawing.Point(402, 177);
            this.tbTimKiem.Multiline = true;
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(169, 54);
            this.tbTimKiem.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbTimKiem);
            this.Controls.Add(this.lbThongTinTimKiem);
            this.Controls.Add(this.button2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbThongTinTimKiem;
        private System.Windows.Forms.TextBox tbTimKiem;
    }
}