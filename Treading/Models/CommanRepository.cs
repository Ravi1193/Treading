using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Dapper;
using Treading.ViewModel;

namespace Treading.Models
{
    public class CommanRepository
    {
        private static string GetConnection = @"Data Source=DESKTOP-MQ1T80C;Initial Catalog=Treading;Persist Security Info=True;User ID=ravi;Password=12345";
        public static int WithoutReturn(string StoreProcureName, object Param)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnection))
                {
                    con.Open();
                    con.Execute(StoreProcureName, Param, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }catch(Exception ex)
            {
                return 0;
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


        public static bool SendMail(AuthenticationViewModel model)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From =new MailAddress(ConfigurationManager.AppSettings["Username"]);
                mail.To.Add(ConfigurationManager.AppSettings["To"]);
                mail.Subject = "New User Registered";
                mail.Body =
                    "Name" + model.Name +
                    "<br />" + "Email" + model.Email +
                    "<br />" + "Mobile" + model.Mobile +
                    "<br />" + "Username" + model.Username +
                    "<br />" + "Password" + model.Password +
                    "<br />" +
                    "<br />" +
                    "<br />" +
                    "<br />" +
                    "Disclaimer :" + "<br/>" +

"This email communication may contain privileged and confidential information and is intended for the use of the addressee only.If you are not an intended recipient you are requested not to reproduce, copy disseminate or in any manner distribute this email communication as the same is strictly prohibited. If you have received this email in error, Please notify the sender immediately by return e - mail and delete the communication sent in error.Email communications cannot be guaranteed to be secure &error free and BullsTreadingAcademy is not liable for any errors in the email communication or for the proper, timely and complete transmission thereof.";

                  SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"],ConfigurationManager.AppSettings["Password"] );
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}