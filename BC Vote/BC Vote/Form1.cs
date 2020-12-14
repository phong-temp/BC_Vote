using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BC_Vote
{
    public partial class MainForm : Form
    {
        private string TIM_KIEM = "Tìm kiếm";
        private string KIEM_PHIEU = "Kiểm phiếu";
        private string DANG_KY_THAM_DU = "Đăng ký tham dự";
        private KiemPhieu mKiemPhieu;
        private string path = @"C:/CSC/test.xlsx";
        private ArrayList listKiemPhieu;
        private ArrayList listTimKiem;
        private ArrayList listDangKyThamDu;
        public MainForm()
        {
            InitializeComponent();
            panCheThanhChon.Size = new Size(1000, 49);
            //btnKiemPhieu.BackColor = Color.Red;
            btnKiemPhieu_Click(this, new EventArgs());
            mKiemPhieu = new KiemPhieu(path);
            listKiemPhieu = new ArrayList();
            listTimKiem = new ArrayList();
            listDangKyThamDu = new ArrayList();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = TIM_KIEM;
            tabControl1.SelectedIndex = 0;
            refreshListView(listTimKiem);
        }

        private void btnKiemPhieu_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = KIEM_PHIEU;
            tabControl1.SelectedIndex = 1;
        }

        private void btnDangKyThamDu_Click(object sender, EventArgs e)
        {
            lbTitleSelect.Text = DANG_KY_THAM_DU;
            tabControl1.SelectedIndex = 2;
            refreshListView(listDangKyThamDu);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbxInputKiemPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKiemTra_Click(this, new EventArgs());
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (tbxInputKiemPhieu.Text.Trim().Equals("")) return;
            listKiemPhieu.Add(mKiemPhieu.kiemTraPhieu(tbxInputKiemPhieu.Text.Trim()));
            refreshListView(listKiemPhieu);
            tbxInputKiemPhieu.Text = "";
        }

        private void writeExcelFile()
        {
            string sheet = "Sheet1";
            if (File.Exists(path)) File.Delete(path);

            FileInfo newFile = new FileInfo(path);
            OfficeOpenXml.ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets.Add(sheet);
            ws.View.ShowGridLines = true;
            ws.Cells["A1"].Value = "Test Write";
            pck.Save();
        }

        private void refreshListView(ArrayList list)
        {
            listView.Items.Clear();
            foreach (String a in list)
                listView.Items.Add(a);
        }
    }
}
