
namespace GUI
{
    partial class FormHome
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnQLDiem = new System.Windows.Forms.Button();
            this.BtnQLMH = new System.Windows.Forms.Button();
            this.BtnQLSV = new System.Windows.Forms.Button();
            this.BtnQLLop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_body = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.BtnQLDiem);
            this.panel1.Controls.Add(this.BtnQLMH);
            this.panel1.Controls.Add(this.BtnQLSV);
            this.panel1.Controls.Add(this.BtnQLLop);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 834);
            this.panel1.TabIndex = 0;
            // 
            // BtnQLDiem
            // 
            this.BtnQLDiem.BackColor = System.Drawing.Color.Turquoise;
            this.BtnQLDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQLDiem.FlatAppearance.BorderSize = 0;
            this.BtnQLDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQLDiem.ForeColor = System.Drawing.Color.White;
            this.BtnQLDiem.Location = new System.Drawing.Point(0, 246);
            this.BtnQLDiem.Name = "BtnQLDiem";
            this.BtnQLDiem.Size = new System.Drawing.Size(186, 53);
            this.BtnQLDiem.TabIndex = 4;
            this.BtnQLDiem.Text = "Quản Lý Điểm";
            this.BtnQLDiem.UseVisualStyleBackColor = false;
            this.BtnQLDiem.Click += new System.EventHandler(this.BtnQLDiem_Click);
            // 
            // BtnQLMH
            // 
            this.BtnQLMH.BackColor = System.Drawing.Color.Orange;
            this.BtnQLMH.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQLMH.FlatAppearance.BorderSize = 0;
            this.BtnQLMH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQLMH.ForeColor = System.Drawing.Color.White;
            this.BtnQLMH.Location = new System.Drawing.Point(0, 193);
            this.BtnQLMH.Name = "BtnQLMH";
            this.BtnQLMH.Size = new System.Drawing.Size(186, 53);
            this.BtnQLMH.TabIndex = 3;
            this.BtnQLMH.Text = "Quản Lý Môn Học";
            this.BtnQLMH.UseVisualStyleBackColor = false;
            this.BtnQLMH.Click += new System.EventHandler(this.BtnQLMH_Click);
            // 
            // BtnQLSV
            // 
            this.BtnQLSV.BackColor = System.Drawing.Color.Red;
            this.BtnQLSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQLSV.FlatAppearance.BorderSize = 0;
            this.BtnQLSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQLSV.ForeColor = System.Drawing.Color.White;
            this.BtnQLSV.Location = new System.Drawing.Point(0, 140);
            this.BtnQLSV.Name = "BtnQLSV";
            this.BtnQLSV.Size = new System.Drawing.Size(186, 53);
            this.BtnQLSV.TabIndex = 2;
            this.BtnQLSV.Text = "Quản Lý Sinh Viên";
            this.BtnQLSV.UseVisualStyleBackColor = false;
            this.BtnQLSV.Click += new System.EventHandler(this.BtnQLSV_Click);
            // 
            // BtnQLLop
            // 
            this.BtnQLLop.BackColor = System.Drawing.Color.Pink;
            this.BtnQLLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQLLop.FlatAppearance.BorderSize = 0;
            this.BtnQLLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQLLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQLLop.ForeColor = System.Drawing.Color.White;
            this.BtnQLLop.Location = new System.Drawing.Point(0, 87);
            this.BtnQLLop.Name = "BtnQLLop";
            this.BtnQLLop.Size = new System.Drawing.Size(186, 53);
            this.BtnQLLop.TabIndex = 1;
            this.BtnQLLop.Text = "Quản Lý Lớp";
            this.BtnQLLop.UseVisualStyleBackColor = false;
            this.BtnQLLop.Click += new System.EventHandler(this.BtnQLLop_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(186, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1339, 87);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHƯƠNG TRÌNH QUẢN LÝ ĐIỂM SINH VIÊN";
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel_body.Controls.Add(this.pictureBox2);
            this.panel_body.Location = new System.Drawing.Point(184, 87);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(1341, 747);
            this.panel_body.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::GUI.Properties.Resources.home1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1341, 747);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::GUI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 834);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormHome";
            this.Text = "FormHome";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Button BtnQLDiem;
        private System.Windows.Forms.Button BtnQLMH;
        private System.Windows.Forms.Button BtnQLSV;
        private System.Windows.Forms.Button BtnQLLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}