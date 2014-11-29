using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBD1
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new masterEntities())
            {
                foreach(var t in context.Tables)
                    Console.WriteLine(t.LastName+ "  " + t.Id);
                    
            }

            DAL.DataAccess.OpenConnection();

            string[] columnTest = { "Id", "Libelle", "Country" };

            string[] param = {"213","Kikoulol","France"};
            DAL.DataAccess.InsertValues("Test", columnTest, param);
            
            Console.WriteLine(DAL.DataAccess.SelectContent("Test", columnTest));

            DAL.DataAccess.CloseConnexion();
            AttendreAvantFermetureConsole();
        }

        private static void AttendreAvantFermetureConsole()
        {
            Console.ReadKey();
        }
       
    }
}
