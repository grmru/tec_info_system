using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AllProductsView.xaml
    /// </summary>
    public partial class AllProductsView : Window
    {
        BindingList<ProductRecord> _data = new BindingList<ProductRecord>();

        public AllProductsView()
        {
            InitializeComponent();
            this.dGrid.ItemsSource = _data;

            try
            {
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class ProductRecord
        {
            public int Id { get; set; } = -1;
            public string Name { get; set; } = string.Empty;
            public string Code { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
        }

        public void LoadData()
        {
            this._data.Clear();

            string connStr = "Server=localhost;Database=tec_data;Uid=root;Pwd=tec;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            
            conn.Open();

            string sql = "select id, name, code, type from products";
            MySql.Data.MySqlClient.MySqlCommand cmd = 
                new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

            var r = cmd.ExecuteReader();
            while(r.Read())
            {
                ProductRecord record = new ProductRecord();
                record.Id = r.GetInt32(0);
                record.Name = r.GetString(1);
                record.Code = r.GetString(2);
                record.Type = r.GetString(3);
                this._data.Add(record);
            }
            r.Close();
            conn.Close();
        }

        private void butNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void butEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void butExportExcel_Click(object sender, RoutedEventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Продукция");

            IRow row = sheet.CreateRow(0);

            ICell cell = row.CreateCell(0);
            cell.SetCellValue("ID");

            cell = row.CreateCell(1);
            cell.SetCellValue("Наименование");

            cell = row.CreateCell(2);
            cell.SetCellValue("Код");

            cell = row.CreateCell(3);
            cell.SetCellValue("Тип");

            for (int i = 0; i < _data.Count; i++)
            {
                IRow current_row = sheet.CreateRow(i+1);

                ICell current_cell = current_row.CreateCell(0);
                current_cell.SetCellValue(_data[i].Id);

                current_cell = current_row.CreateCell(1);
                current_cell.SetCellValue(_data[i].Name);

                current_cell = current_row.CreateCell(2);
                current_cell.SetCellValue(_data[i].Code);

                current_cell = current_row.CreateCell(3);
                current_cell.SetCellValue(_data[i].Type);
            }

            using (FileStream stream = new FileStream("outfile.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }

        private void butExportWord_Click(object sender, RoutedEventArgs e)
        {
            NPOI.XWPF.UserModel.XWPFDocument doc = new NPOI.XWPF.UserModel.XWPFDocument();

            NPOI.XWPF.UserModel.XWPFParagraph par = doc.CreateParagraph();
            par.CreateRun().AppendText("Экспорт данных по продукции на " + DateTime.Now);

            NPOI.XWPF.UserModel.XWPFTable table = doc.CreateTable(_data.Count + 1, 4);

            table.GetRow(0).GetCell(0).SetText("ID");
            table.GetRow(0).GetCell(1).SetText("Наименование");
            table.GetRow(0).GetCell(2).SetText("Код");
            table.GetRow(0).GetCell(3).SetText("Тип");

            table.Width = 5000;

            table.SetColumnWidth(0, 1000);
            table.SetColumnWidth(1, 1500);
            table.SetColumnWidth(2, 1000);
            table.SetColumnWidth(3, 1500);

            for (int i = 0; i < _data.Count; i++)
            {
                table.GetRow(i + 1).GetCell(0).SetText(_data[i].Id.ToString());
                table.GetRow(i + 1).GetCell(1).SetText(_data[i].Name);
                table.GetRow(i + 1).GetCell(2).SetText(_data[i].Code);
                table.GetRow(i + 1).GetCell(3).SetText(_data[i].Type);
            }

            FileStream out1 = new FileStream("table.docx", FileMode.Create);
            doc.Write(out1);
            out1.Close();
        }

        private void butSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
