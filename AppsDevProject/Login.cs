using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsDevProject
{
    public partial class Login : Form
    {
        public string sendText = " "; 
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //retrieving username and password from the database
            try
            {
                Connection.ConnectionDB.DB();
                DBHelper.DBHelper.gen = "Select * from users where [username] = '" + txtusername.Text + "' and [password] = '" + txtpassword.Text + "'";
                DBHelper.DBHelper.command = new OleDbCommand(DBHelper.DBHelper.gen, Connection.ConnectionDB.conn);
                DBHelper.DBHelper.reader = DBHelper.DBHelper.command.ExecuteReader();

                if (DBHelper.DBHelper.reader.HasRows)
                {
                    DBHelper.DBHelper.reader.Read();
                    //database  
                    txtusername.Text = (DBHelper.DBHelper.reader["username"].ToString());
                    txtpassword.Text = (DBHelper.DBHelper.reader["password"].ToString());
                    // open a next form  
                    //  Stocks s = new Stocks ();
                    //  s.Show();
                    //   this.Visible =false;//cosing the form
                    //   sale.Show();l

                    
                    timer1.Enabled = true;
                    timer1.Start();
                    timer1.Interval = 1;
                    progressBar1.Maximum = 200;
                    timer1.Tick += new EventHandler(timer1_Tick);
                    

                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");

                }
                Connection.ConnectionDB.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.ConnectionDB.conn.Close();
                MessageBox.Show(ex.Message);

            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 200)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                this.Hide();

                progressBar1.Value = 0;
                sendText = txtusername.Text;
                Stocks s = new Stocks();
                s.Show();
            }
        }
    }
}
