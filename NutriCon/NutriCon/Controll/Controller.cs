using MySql.Data.MySqlClient;
using NutriCon.Model;
using NutriCon.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriCon.Controll
{
    public class Controller
    {
        DBConnection connection = new DBConnection();

        public void InsertUser(string name, string surname, string oib, string birthday, string email, string gender)
        {
            try{
                string insertUserQuerry = "INSERT INTO `Korisnik` (`ime`, `prezime`, `birthday`, `oib`, `e_mail`, `spol`) VALUES ('" + name + "', '" + surname + "', '" + birthday + "', '" + oib + "', '" + email + "', '" + gender + "')";
                MySqlCommand MyCommand2 = new MySqlCommand(insertUserQuerry, DBConnection.conn);
                MySqlDataReader MyReader2;
                connection.Otvori();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                connection.Zatvori();

                MessageBox.Show("Korisnik je uspjesno unesen!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\nProvjerite vezu s internetom! \n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        internal List<UserModel> GetAllUsers()
        {
            List<UserModel> listaUsera = new List<UserModel>();
            string selectUserQuery = "SELECT * FROM `korisnik`";

            MySqlCommand commandDatabase = new MySqlCommand(selectUserQuery, DBConnection.conn);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                connection.Otvori();

                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserModel korisnik = new UserModel();
                        korisnik.UserId = reader.GetInt16(0);
                        korisnik.Name = reader.GetString(1);
                        korisnik.Surname = reader.GetString(2);
                        korisnik.Birthday = DateTime.Parse(reader.GetDateTime(3).ToShortDateString());
                        korisnik.Oib = reader.GetString(4);
                        korisnik.Email = reader.GetString(5);
                        korisnik.Gender = reader.GetString(6);
                       
                        listaUsera.Add(korisnik);
                    }
                }
                else
                {
                    Console.WriteLine("Nema podataka.");
                }
                connection.Zatvori();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\n Provjerite vezu s internetom! \n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaUsera;
        }

        internal void InsertUserMesurment(List<MesurmentModel> listaUserMesurment, string dateMesurment)
        {
            try
            {
                string insertMesurmentQuerry = "INSERT INTO `mjerenja` " +
                   "(`UserId`, `visina`, `tezina`, `dnevnaAktivnost`, `opsegStruka`, `opsegBokova`, `datumMjerenja`)" +
                   " VALUES (@UserId, @visina, @tezina, @dnevnaAktivnost, @opsegStruka, @opsegBokova, @datumMjerenja) ";

                MySqlCommand mysqlConn = new MySqlCommand(insertMesurmentQuerry, DBConnection.conn);
                connection.Otvori();
                mysqlConn.Prepare();

                foreach (var msr in listaUserMesurment)
                {
                    mysqlConn.Parameters.AddWithValue("@UserId", msr.UserId);
                    mysqlConn.Parameters.AddWithValue("@visina", msr.visina);
                    mysqlConn.Parameters.AddWithValue("@tezina",  msr.tezina);
                    mysqlConn.Parameters.AddWithValue("@dnevnaAktivnost", msr.dnevnaAktivnost);
                    mysqlConn.Parameters.AddWithValue("@opsegStruka", msr.opsegStruka);
                    mysqlConn.Parameters.AddWithValue("@opsegBokova", msr.opsegBokova);
                    mysqlConn.Parameters.AddWithValue("@datumMjerenja", dateMesurment);
                }

                mysqlConn.ExecuteNonQuery();
                connection.Zatvori();

                MessageBox.Show("Mjerenje korisnika je uspjesno uneseno!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\nProvjerite vezu s internetom! \n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        internal List<MesurmentModel> GetUserMesurment(int idUsera)
        {
            List<MesurmentModel> listaMjerenja = new List<MesurmentModel>();
            string selectMesurmentQuerry = "SELECT`visina`,`tezina`,`dnevnaAktivnost`,`opsegStruka`,`opsegBokova`,`datumMjerenja`,`MesurmentId` FROM `mjerenja` WHERE `UserId`=" + idUsera;
            MySqlCommand commandDatabase = new MySqlCommand(selectMesurmentQuerry, DBConnection.conn);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {

                /*
                 * string insertMesurmentQuerry = "SELECT`visina`,`tezina`,`dnevnaAktivnost`,`opsegStruka`,`opsegBokova`,`datumMjerenja` FROM `mjerenja` WHERE `UserId`=@userID";
                MySqlCommand cmd = new MySqlCommand(insertMesurmentQuerry, DBConnection.conn);
                connection.Otvori();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@UserId", idUsera);



                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows) 
                { 
                    MessageBox.Show("Error! ");
                    reader.Close();
                    connection.Zatvori();
                }
                else
                {
                    MesurmentModel mesMod = new MesurmentModel();
                    mesMod.visina = reader.GetInt32(0);
                    mesMod.tezina = reader.GetInt32(1);
                    mesMod.dnevnaAktivnost = reader.GetInt16(2);
                    mesMod.opsegStruka = reader.GetInt32(3);
                    Console.WriteLine(mesMod.opsegStruka);
                    mesMod.opsegBokova = reader.GetInt32(4);
                    Console.WriteLine(mesMod.opsegBokova);
                    mesMod.datumMjerenja = DateTime.Parse(reader.GetDateTime(5).ToShortDateString());
                    Console.WriteLine(mesMod.datumMjerenja);
                    listaMjerenja.Add(mesMod);
                }
                connection.Zatvori();
                */

                connection.Otvori();

                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MesurmentModel mesMod = new MesurmentModel();
                        mesMod.visina = reader.GetInt32(0);
                        mesMod.tezina = reader.GetInt32(1);
                        mesMod.dnevnaAktivnost = reader.GetInt16(2);
                        mesMod.opsegStruka = reader.GetInt32(3);
                        mesMod.opsegBokova = reader.GetInt32(4);
                        mesMod.datumMjerenja = DateTime.Parse(reader.GetDateTime(5).ToShortDateString());
                        mesMod.MesurmentId = reader.GetInt16(6);

                        listaMjerenja.Add(mesMod);
                    }
                }
                else
                {
                    Console.WriteLine("Nema podataka.");
                }
                connection.Zatvori();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\n Provjerite vezu s internetom! \n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listaMjerenja;
        }

        internal void deleteSelectedMesurment(int mesureID)
        {
            string deleteMesureQuerry = "DELETE FROM `mjerenja` WHERE `mjerenja`.`MesurmentId` ="+mesureID;
            try
            {
                MySqlCommand MyCommand2 = new MySqlCommand(deleteMesureQuerry, DBConnection.conn);
                MySqlDataReader MyReader2;
                connection.Otvori();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Obrisat ce se svi podatci!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                while (MyReader2.Read())
                {
                }
                connection.Zatvori();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške u vezi!.\n Provjerite vezu s internetom! \n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
