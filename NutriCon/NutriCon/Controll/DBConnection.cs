using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriCon.Controll
{
    class DBConnection
    {
        public static string connectionString = "datasource=127.0.0.1;port=3308;username=root;password=;database=projekt_tr_nutricon;";
        public static MySqlConnection conn = new MySqlConnection(connectionString);

        public void Otvori()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\nProvjerite vezu s internetom! \n\n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Zatvori()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\nProvjerite vezu s internetom! \n\n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
