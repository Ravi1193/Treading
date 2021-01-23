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
        private static string GetConnection = @"Data Source=DESKTOP-1I002HL\RAVI;Initial Catalog=Treading;Persist Security Info=True;User ID=sa;Password=123";
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

                string mailBody;
                mailBody = @"<html>
	            <head><title></title></head>
	            <style>
		            body{margin:20px;font-family:Arial;font-size:11pt}
		            a{text-decoration:none;color:rgb(6,113,176)}
		            div.signature{font-size:9pt}
		            div.signature span.name{font-weight:bold}
		            div.signature span.blue{font-weight:bold;color:rgb(6,113,176)}
		            div.signature .address{font-size:8pt;color:rgb(6,113,176)}
		            div.signature span.website{text-decoration:underline;color:rgb(6,113,176);font-weight:bold}
		            div.signature span.print,span.print-p{color:rgb(0,128,0);font-weight:bold;font-size:8pt}
		            div.signature span.print-p{font-size:15pt}
		            div.disclaimer{font-size:8pt;text-align:justify}
		            div.disclaimer a{text-decoration:underline;font-weight:normal}
	            </style>
	            <body>
		            Dear {0},
		            <br>
		                <br> New user is registered , Below is the all details of user.Contact him/her as soon as possible.  
    		    <br>
	    	    <br><br>
                    <strong>Name:</strong> {1}
		            <br>
		            <strong>Username:</strong> {2}
		            <br>
		            <strong>Password:</strong> {3}
                    <br>
                    <strong>Email:</strong> {4}
		            <br>
                    <strong>Phone No:</strong> {5}
		            <br>
                    <br><br><br>Please send your feedback to<a href='kravi8365@gmail.com' > kravi8365@gmail.com</a> and contact us on this email address if you have any problems accessing the Portal.
		            <br><br><br><br>
                    Best regards,
		            <br><br><br><br>
		            <div class='signature'>
			            <span class='name'>Ravi Rana</span>
                         <br />
                        <span class='blue'>Developer</span>
                        <br/>
                        <img src='cid:IMAGE_ID'/>
			            <div class='address'>
				            <br>
				            Flat 16
				            <br>Baba Niwas 
                            <br>KOpari Goan Vashi Navi Mumbai
				            <br>Pin 400705, Mumbai, Maharstra ,India
				            <br><br>
				            <br>Tel: +918104021089         
				            <br><br>
			            </div>
		            </div>
		            <div class='disclaimer'>
			            <br>
			            <br>
                        This email is confidential and may include privileged and price sensitive information. It is for the exclusive use of the intended recipient(s). If you are not the intended recipient(s), disclosure, copying, distribution or other use of, or taking of any action in reliance upon, this communication or the information in it is prohibited and may be unlawful. If you received this communication in error please notify us immediately and delete the message from your system. Incoming and outgoing email communications may be monitored by Sahani Group (as permitted by law). If the contents of this email are personal to the sender, then it is not a communication from Sahani Group.
		                </div>
	                </body>
                </html>";
                string mailtext = mailBody.Replace("{0}", "Pawan" ).Replace("{1}", model.Name).Replace("{2}", model.Username).Replace("{3}", model.Password).Replace("{4}", model.Email).Replace("{5}", model.Mobile);
                mail.From =new MailAddress(ConfigurationManager.AppSettings["Username"]);
                mail.To.Add(ConfigurationManager.AppSettings["To"]);
                mail.Subject = "New User Registered";
                mail.Body = mailtext;
                mail.IsBodyHtml = true;
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