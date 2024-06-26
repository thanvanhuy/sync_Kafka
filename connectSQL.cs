using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sync_Kafka
{
    public class connectSQL
    {
        public string strConn { get; set; }
        public string Server { get; set; }
        public string Catalog { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public SqlConnection connection;
        public Boolean testConnect()
        {
            try
            {
                strConn = String.Format("Data Source = {0}; Initial Catalog = {1}; User ID = {2}; PWD = {3}; Integrated Security =False; Connect Timeout = 6; MultipleActiveResultSets=True", Server, Catalog, Username, Password);
                connection = new SqlConnection(strConn);
                connection.Open();
                connection.Close();
                return true;
            }
            catch { }
            return false;

        }
        public DataTable GetDataTable(string strQuery)
        {
            DataTable dt = new DataTable("temp");
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand myCommand = new SqlCommand(strQuery, connection);
                myCommand.CommandTimeout = 1000;
                SqlDataAdapter MyReader = new SqlDataAdapter(myCommand);
                MyReader.Fill(dt);
            }
            catch (Exception ex) { }
            return dt;

        }

        public Boolean ExecuteNonQuery(string strQuery)
        {
            try
            {
                //using (SqlConnection connection = new SqlConnection(strConn))
                //{
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand myCommand = new SqlCommand(strQuery, connection);
                //myCommand.CommandTimeout = 1000;
                var i = myCommand.ExecuteNonQuery();
                if (i == 1)
                    return true;
                //}
            }
            catch (Exception ex) { }
            return false;

        }
    }
}
