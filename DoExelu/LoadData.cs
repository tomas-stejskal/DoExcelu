using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DoExelu
{
    class LoadData
    {
        MySqlConnection conn;

        public LoadData()
        {
            string con_str = "SERVER=localhost;DATABASE=world;UID=root;PASSWORD=1234;";
            conn = new MySqlConnection(con_str);
        }

        private bool openConn()
        {
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
        private bool closeConn()
        {
            try
            {
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public List<Data> getData()
        {
            List<Data> dat = new List<Data>();
            if (openConn())
            {
                string query = "select * from city";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query,conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data d = new Data();
                        d.ID = reader["ID"].ToString();
                        d.name = reader["Name"].ToString();
                        d.countryCode = reader["CountryCode"].ToString();
                        d.district = reader["District"].ToString();
                        d.population = reader["Population"].ToString();

                        dat.Add(d);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }


                closeConn();
            }



            return dat;
        }
    }
}
