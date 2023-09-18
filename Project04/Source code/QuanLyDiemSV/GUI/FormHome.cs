using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild!=null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnQLLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyLop());
            label1.Text = BtnQLLop.Text;
        }

        private void BtnQLSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLySinhVien());
            label1.Text = BtnQLSV.Text;
        }

        private void BtnQLMH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyMonHoc());
            label1.Text = BtnQLMH.Text;
        }

        private void BtnQLDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyDiem());
            label1.Text = BtnQLDiem.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = "CHƯƠNG TRÌNH QUẢN LÝ ĐIỂM SINH VIÊN";
        }
    }
}
