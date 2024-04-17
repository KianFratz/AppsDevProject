using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace AppsDevProject.Connection
{
    internal class ConnectionDB
    {
        
        public static OleDbConnection conn;
        public static string dbConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "ProjectDB.accdb ";
        public static void DB()
        {
            try
            {
                conn = new OleDbConnection(dbConn);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
