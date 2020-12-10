using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BC_Vote
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            panCheThanhChon.Size = new Size(1000, 49);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = "Tìm kiếm";
            tabControl1.SelectedIndex = 0;
        }

        private void btnKiemPhieu_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = "Kiểm phiếu";
            tabControl1.SelectedIndex = 1;
        }

        private void btnDangKyThamDu_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = "Đăng ký tham dự";
            tabControl1.SelectedIndex = 2;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
