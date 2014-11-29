using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class DataAccess
    {
        private static SqlConnection connection;
        public static void OpenConnection()
        {
            connection = new SqlConnection(@"Data Source=(LocalDb)\v11.0;Integrated Security=True");
            connection.Open();
        }
        public static void CloseConnexion()
        {
            connection.Close();
        }
        public static void InsertValues(string table, string [] columnName, string [] param)
        {
            string insertString = "INSERT INTO " + table + "(";

            for (int i = 0; i < columnName.Length; i++)
            {
                insertString += String.Format("{0}", columnName[i]);
                if (i == (columnName.Length - 1))
                    insertString += ") VALUES (";
                else
                    insertString += ", ";
            }

            for (int i = 0; i < columnName.Length; i++)
            {
                insertString += String.Format("@{0}", columnName[i]);
                if (i == (columnName.Length - 1))
                    insertString += ");";
                else
                    insertString += ", ";
            }

            SqlCommand insert = new SqlCommand(insertString, connection);
            for (int i = 0; i < columnName.Length; i++)
            {
                insert.Parameters.AddWithValue(String.Format("@{0}", columnName[i]), param[i]);
            }
            insert.ExecuteNonQuery();
        }
        public static string SelectContent(string table, string [] columnName)
        {
            string returnString = "";
            
            string selectString = "SELECT ";
            for (int i = 0; i < columnName.Length; i++)
            {
                selectString += String.Format("{0}", columnName[i]); 
                if (i == (columnName.Length - 1))
                    selectString += " ";
                else
                    selectString += ", ";
            }       

            selectString += "FROM " + table;
            SqlCommand select = new SqlCommand(selectString, connection);
            SqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < columnName.Length; i++)
                {
                    returnString += String.Format("{0} ", reader[i]);
                }
                returnString += "\n";
            }
            reader.Close();
            return returnString;
        }
    }
}
