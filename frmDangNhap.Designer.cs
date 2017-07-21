namespace QLHOTEL
{
    partial class frmDangNhap
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
            this.lbThoat = new DevComponents.DotNetBar.LabelX();
            this.lbDangNhap = new DevComponents.DotNetBar.LabelX();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTk = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbThoat
            // 
            this.lbThoat.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbThoat.BackgroundStyle.Class = "";
            this.lbThoat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbThoat.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoat.ForeColor = System.Drawing.Color.Black;
            this.lbThoat.Location = new System.Drawing.Point(344, 319);
            this.lbThoat.Name = "lbThoat";
            this.lbThoat.Size = new System.Drawing.Size(144, 39);
            this.lbThoat.TabIndex = 1;
            this.lbThoat.Text = "Thoát";
            this.lbThoat.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbThoat.Click += new System.EventHandler(this.lbThoat_Click);
            this.lbThoat.MouseLeave += new System.EventHandler(this.lbThoat_MouseLeave);
            this.lbThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbThoat_MouseMove);
            // 
            // lbDangNhap
            // 
            this.lbDangNhap.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbDangNhap.BackgroundStyle.Class = "";
            this.lbDangNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDangNhap.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangNhap.ForeColor = System.Drawing.Color.Black;
            this.lbDangNhap.Location = new System.Drawing.Point(177, 319);
            this.lbDangNhap.Name = "lbDangNhap";
            this.lbDangNhap.Size = new System.Drawing.Size(144, 39);
            this.lbDangNhap.TabIndex = 2;
            this.lbDangNhap.Text = "Đăng Nhập";
            this.lbDangNhap.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbDangNhap.Click += new System.EventHandler(this.lbDangNhap_Click);
            this.lbDangNhap.MouseLeave += new System.EventHandler(this.lbDangNhap_MouseLeave);
            this.lbDangNhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbDangNhap_MouseMove);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Khaki;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(266, 240);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(0, 29);
            this.textBox2.TabIndex = 3;
            // 
            // txtMK
            // 
            this.txtMK.BackColor = System.Drawing.Color.Khaki;
            this.txtMK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.Location = new System.Drawing.Point(266, 242);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(272, 29);
            this.txtMK.TabIndex = 3;
            // 
            // txtTk
            // 
            this.txtTk.BackColor = System.Drawing.Color.Khaki;
            this.txtTk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk.Location = new System.Drawing.Point(266, 201);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(272, 29);
            this.txtTk.TabIndex = 3;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::QLHOTEL.Properties.Resources.DangNhap2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(651, 396);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbDangNhap);
            this.Controls.Add(this.lbThoat);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbThoat;
        private DevComponents.DotNetBar.LabelX lbDangNhap;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTk;
    }
}