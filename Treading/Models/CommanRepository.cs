using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
namespace Treading.Models
{
    public class CommanRepository
    {
        private static string GetConnection = @"Data Source=DESKTOP-MQ1T80C;Initial Catalog=Treading;Persist Security Info=True;User ID=ravi;Password=12345";
        public static void WithoutReturn(string StoreProcureName, object Param)
        {
            using (SqlConnection con = new SqlConnection(GetConnection))
            {
                con.Open();
                con.Execute(StoreProcureName, Param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T singleReturn<T>(string StoreProcureName, object Param)
        {
            using (SqlConnection con = new SqlConnection(GetConnection))
            {
                con.Open();
                return con.Query<T>(StoreProcureName, Param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public static IEnumerable<T> listReturn<T>(string StoreProcureName, object Param)
        {
            using (SqlConnection con = new SqlConnection(GetConnection))
            {
                con.Open();
                return con.Query<T>(StoreProcureName, Param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}