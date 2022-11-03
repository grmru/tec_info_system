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
            LoadData();
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
    }
}
