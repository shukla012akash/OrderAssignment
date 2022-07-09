using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace OrderAssignment
{
    public class CustomerMaster
    {
        public static string sqlConnectionstr = @"Data Source=DESKTOP-0LKSRK2;Initial Catalog=OrderAssignment;Integrated Security=True";


        public void InsertCustomer()
        {
            CustomerMaster customerMaster = new CustomerMaster();

        #region
        FirstName:
            Console.WriteLine("Enter the FirstName:");
            string name = Console.ReadLine();

            if (name.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto FirstName;
            }

        LastName:
            Console.WriteLine("Enter the LastName:");
            string lname = Console.ReadLine();

            if (lname.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto LastName;
            }


        Phone:
            Console.WriteLine("Enter the Phone:");
            int phone = Convert.ToInt32(Console.ReadLine());

            if (phone.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto Phone;
            }

        Email:
            Console.WriteLine("Enter the Email:");
            string email = Console.ReadLine();

            if (email.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto Email;
            }
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into CustomerMaster values('" + name + "','" + lname + "'," + phone + ",'"+ email + "')", sqlConnection); 
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            customerMaster.SendMailMethod(name,email);




        }
        public  void SendMailMethod(string CustomerName, string recieverMail)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(" Orders ", "as0285303@gmail.com"));
            message.To.Add(MailboxAddress.Parse(recieverMail));

            message.Subject = "!!!Welcome!!!";
            message.Body = new TextPart("plain")
            {
                Text = $"Dear {CustomerName}, Thanks for registering with us."
            };

            #region private data
            string email = "as0285303@gmail.com";
            string password = "lmtfdfzyxhrggfkk";
            #endregion

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(email, password);
                smtpClient.Send(message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }

        }





        #endregion


        #region--Show Customer
        public DataTable Show()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select* from CustomerMaster", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = cmd.ExecuteReader();

            DataTable obj = new DataTable();
            obj.Load(DataReader);

            sqlConnection.Close();
            return obj;
        }
        #endregion

        public string UpdateCustomer()
        {
            #region--Update the customer
            Console.WriteLine("Enter First Name to Update   : ");
            string name = Console.ReadLine();

            Console.WriteLine(" Enter the Last Name to Update  : ");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter the Phone to Update  : ");
            int phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Email to Update  : ");
            string email = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update Customer set FirstName='" + name + "',LastName='" + lname + "',Phone=" + phone + " where Email='" + email + "'", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

        }
        #endregion



        public string DeleteCustomer()
        {
            #region--Delete the Customer
            string name = Console.ReadLine();
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);//connection establishment

            SqlCommand cmd = new SqlCommand("Delete from CustomerMaster where FirstName='" + name + "'", sqlConnection);
    

            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
            {
                return "notDeleted";
            }
            return "Deleted";
        }
        #endregion

    }
}
