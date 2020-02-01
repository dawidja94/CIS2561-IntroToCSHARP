using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary3
{
    public class MySQLDB
    {
        public static void RunQuery(string connStr, string query, Func<string[], int> handleRecord)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

                //loop over each record in result set
                while (reader.Read())
                {
                    //roll up fields into a string array
                    string[] fields = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        fields[i] = reader.GetString(i);
                    }
                    //we now have a record
                    handleRecord(fields);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Query failed: ", e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}
