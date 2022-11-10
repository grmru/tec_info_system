using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static WpfClient.AllProductsView;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for ItemDetailsProductionView.xaml
    /// </summary>
    public partial class ItemDetailsProductionView : Window
    {
        private int _id = -1;

        public ItemDetailsProductionView(int id)
        {
            this._id = id;

            InitializeComponent();

            this.btnCreate.Visibility = Visibility.Collapsed;
            this.btnSave.Visibility = Visibility.Collapsed;

            if (this._id >= 0)
            {
                LoadData(this._id);
                this.btnSave.Visibility = Visibility.Visible;
            }
            else
            {
                this.btnCreate.Visibility = Visibility.Visible;
            }
        }

        private void LoadData(int id)
        {
            string connStr = "Server=localhost;Database=tec_data;Uid=root;Pwd=tec;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            conn.Open();

            string sql = "select id, name, code, type from products where id = @id";
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            var r = cmd.ExecuteReader();            
            while (r.Read())
            {
                this.txtID.Text = r.GetInt32(0).ToString();
                this.txtName.Text = r.GetString(1);
                this.txtCode.Text = r.GetString(2);
                this.txtType.Text = r.GetString(3);
            }
            r.Close();
            conn.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
