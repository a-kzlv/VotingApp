using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Caching;



namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    
    public partial class MainWindow : Window
    {

        private String Logr = "";
        private String pwpw = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn(object sender, RoutedEventArgs e)
        {
            Logr = log.Text;
            pwpw = pw.Password;
            Window3 win3 = new Window3();
            win3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win3.ShowDialog();
        }
  
        private void btn2(object sender, RoutedEventArgs e)
        {

            Logr = log.Text;
            pwpw = pw.Password;
            using (SqlConnection conn = new SqlConnection())
            {
                //prepare conectio string
                conn.ConnectionString = "connectionstring";

                //Prepare SQL command that we want to query
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                // cmd.CommandText = "SELECT * FROM MYTABLE";
                cmd.CommandText = String.Format("select V.loginname, C.* from [voting].[dbo].[Customerdata] C left join [voting].[dbo].[Votes] V on C.Logn = V.loginname where C.Logn = '{0}'", Logr);
                cmd.Connection = conn;

                // open database connection.
                conn.Open();

                //Execute the query 
                SqlDataReader sdr = cmd.ExecuteReader();

                ////Retrieve data from table and Display result
                while (sdr.Read())
                {
                    string logcheck     =  sdr["Logn"].ToString();
                    string pwcheck      =  sdr["Pword"].ToString();
                    string votecheck    =  sdr["loginname"].ToString();

                    if ((Logr == logcheck) && (pwpw == pwcheck) && (votecheck == ""))
                    {
                        MessageBox.Show("Richtig");
                        Window2 win2 = new Window2(Logr);
                        win2.ShowDialog();
                    }
                    else if ((Logr == logcheck) && (pwpw == pwcheck) && (votecheck != ""))
                    {
                        MessageBox.Show("Sie haben bereits abgestimmt");
                    }
                    else if ((Logr == null) && (pwpw == null))
                    {
                        MessageBox.Show("Fehlende Eingaben");
                    }
                    else
                    {
                        MessageBox.Show("Login oder Passwort falsch");
                    }

                }
                
                //Close the connection
                conn.Close();


            }
            
        }
    }
}
