using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsDevProject.DBHelper
{
    internal class DBHelper
    {
        public static string gen = "";
        public static OleDbConnection conn;
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        
        public static void fillDB(string q, DataGridView dgv)
        {
            try
            {
                Connection.ConnectionDB.DB();
                DataTable dt = new DataTable();
                OleDbDataAdapter data = null;
                OleDbCommand command = new OleDbCommand(q, Connection.ConnectionDB.conn);
                data = new OleDbDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;
                Connection.ConnectionDB.conn.Close();
            }
            catch(Exception ex)
            {
                Connection.ConnectionDB.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
