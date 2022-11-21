using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik für Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            {
                string log = t1.Text;
                string ps1 = r1.Password;
                string ps2 = r2.Password;

                if (ps1 == ps2)
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        //prepare conectio string
                        conn.ConnectionString = "connectionstring";

                        //Prepare SQL command that we want to query
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        // cmd.CommandText = "SELECT * FROM MYTABLE";
                        cmd.CommandText = String.Format("insert into [voting].[dbo].[Customerdata] (Logn, Pword) values ('{0}','{1}')", log, ps1);
                        cmd.Connection = conn;

                        // open database connection.
                        conn.Open();
                        try
                        {
                            if ((log.Length > 6) && (Regex.IsMatch(log, "[A-Z]")) && (ps1.Length > 6) && (Regex.IsMatch(ps1, "[A-Z]")))
                            {
                                SqlDataReader sdr = cmd.ExecuteReader();
                                MessageBox.Show("Registrierung erfogreich. Melden Sie sich bitte an.");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Login oder Passwort entspricht nicht den Anforderungen.");
                                Window3 win3 = new Window3();
                                win3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                win3.ShowDialog();
                            }
                       
                        }
                        catch
                        {
                            MessageBox.Show("Name schon vorhanden");
                        }
                        conn.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Passwörter ungleich");
                }

            }
        }
    }
}
