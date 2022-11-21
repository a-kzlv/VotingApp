using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Caching;

namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string myString { get; set; }
        public Window2(string value)
        {
            InitializeComponent();
            this.myString = value;
        }

        private void btnr(object sender, RoutedEventArgs e)
        {

            if (rb_1.IsChecked == true)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    //prepare conectio string
                    conn.ConnectionString = "connectionstring";

                    
                    //Prepare SQL command that we want to query
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = String.Format("INSERT INTO [voting].[dbo].[Votes] (Vote, CandidateNr, loginname) VALUES (1, 'Option1', '{0}');",myString);
                    cmd.Connection = conn;
                    conn.Open(); 
                    SqlDataReader sdr = cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Sie haben sich für die 1ste Option entschieden");
                    System.Windows.Application.Current.Shutdown();
                }
                
            }
            else if (rb_2.IsChecked == true)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    //prepare conectio string
                    conn.ConnectionString = "connectionstring";

                    //Prepare SQL command that we want to query
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = String.Format("INSERT INTO [voting].[dbo].[Votes] (Vote, CandidateNr, loginname) VALUES (1, 'Option2', '{0}');", myString);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Sie haben sich für die 2te Option entschieden");
                    System.Windows.Application.Current.Shutdown();
                }
            }
            else if (rb_3.IsChecked == true)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    //prepare conectio string
                    conn.ConnectionString = "connectionstring";

                    //Prepare SQL command that we want to query
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = String.Format("INSERT INTO [voting].[dbo].[Votes] (Vote, CandidateNr, loginname) VALUES (1, 'Option3', '{0}');", myString);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Sie haben sich für die 3te Option entschieden");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }
    }
}
