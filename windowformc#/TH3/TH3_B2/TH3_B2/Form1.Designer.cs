namespace TH3_B2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dienTuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baiDienTu1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baiDienTu2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bienDoiCauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracNgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datCauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dienTuToolStripMenuItem,
            this.bienDoiCauToolStripMenuItem,
            this.tracNgToolStripMenuItem,
            this.datCauToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dienTuToolStripMenuItem
            // 
            this.dienTuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baiDienTu1ToolStripMenuItem,
            this.baiDienTu2ToolStripMenuItem});
            this.dienTuToolStripMenuItem.Name = "dienTuToolStripMenuItem";
            this.dienTuToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.dienTuToolStripMenuItem.Text = "Dien Tu";
            // 
            // baiDienTu1ToolStripMenuItem
            // 
            this.baiDienTu1ToolStripMenuItem.Name = "baiDienTu1ToolStripMenuItem";
            this.baiDienTu1ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.baiDienTu1ToolStripMenuItem.Text = "Bai Dien Tu 1";
            this.baiDienTu1ToolStripMenuItem.Click += new System.EventHandler(this.baiDienTu1ToolStripMenuItem_Click);
            // 
            // baiDienTu2ToolStripMenuItem
            // 
            this.baiDienTu2ToolStripMenuItem.Name = "baiDienTu2ToolStripMenuItem";
            this.baiDienTu2ToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.baiDienTu2ToolStripMenuItem.Text = "bai Dien Tu 2";
            this.baiDienTu2ToolStripMenuItem.Click += new System.EventHandler(this.baiDienTu2ToolStripMenuItem_Click);
            // 
            // bienDoiCauToolStripMenuItem
            // 
            this.bienDoiCauToolStripMenuItem.Name = "bienDoiCauToolStripMenuItem";
            this.bienDoiCauToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.bienDoiCauToolStripMenuItem.Text = "Bien Doi Cau";
            // 
            // tracNgToolStripMenuItem
            // 
            this.tracNgToolStripMenuItem.Name = "tracNgToolStripMenuItem";
            this.tracNgToolStripMenuItem.Size = new System.Drawing.Size(165, 25);
            this.tracNgToolStripMenuItem.Text = "Trac Nghiem Gioi Tu";
            // 
            // datCauToolStripMenuItem
            // 
            this.datCauToolStripMenuItem.Name = "datCauToolStripMenuItem";
            this.datCauToolStripMenuItem.Size = new System.Drawing.Size(79, 25);
            this.datCauToolStripMenuItem.Text = "Dat Cau";
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(63, 25);
            this.thoatToolStripMenuItem.Text = "Thoat";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Bai Tap Tieng Anh";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dienTuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baiDienTu1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baiDienTu2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bienDoiCauToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tracNgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datCauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
    }
}

