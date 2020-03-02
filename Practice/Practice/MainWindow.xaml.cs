using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtName.Text != String.Empty)
                {
                    string constr = ConfigurationManager.ConnectionStrings["CrudConnection"].ConnectionString;
                    con = new SqlConnection(constr);
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO WPFNames VALUES('" + TxtName.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                else
                {
                    MessageBox.Show("Please Enter a name", "Message#01", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                con.Close();
                TxtName.Clear();
            }

            
        }
    }
}
