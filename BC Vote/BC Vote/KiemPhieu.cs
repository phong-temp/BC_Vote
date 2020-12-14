using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BC_Vote
{
    /// <summary>
    /// Class này dùng để kiểm tra phiếu
    /// </summary>
    class KiemPhieu
    {
        public ArrayList data { get; set; }
        public KiemPhieu(String path)
        {
            data = new ArrayList();
            if (File.Exists(path))
            {
                ExcelPackage package = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int rows = worksheet.Dimension.Rows;

                for (int i = 2; i <= rows; i++)// i=2 bỏ rows đầu
                {
                    string barcode = worksheet.Cells[i, 1].Value.ToString();
                    string type = worksheet.Cells[i, 2].Value.ToString();
                    data.Add(new Data(barcode, type));
                }
            }
        }

        /// <summary>
        /// Kiểm tra phiếu có trong list hay không
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public string kiemTraPhieu(string barcode)
        {
            if (barcode == null || barcode.Trim().Equals("")) return "Không hợp lệ";

            foreach (Data a in data)
            {
                if (barcode.Equals(a.barcode))
                {
                    return "Kiểm phiếu: " + a.type;
                }
            }
            return "Không hợp lệ";
        }

        class Data
        {
            public string barcode { get; set; }
            public string type { get; set; }
            public Data(string barcode, string type)
            {
                this.barcode = barcode;
                this.type = type;
            }
        }
    }
}
