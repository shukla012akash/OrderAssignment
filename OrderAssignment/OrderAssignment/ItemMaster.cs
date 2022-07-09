using System;
using System.Data;
using System.Data.SqlClient;

namespace OrderAssignment
{
    public class ItemMaster
    {
        public static string sqlConnectionstr = @"Data Source=DESKTOP-0LKSRK2;Initial Catalog=OrderAssignment;Integrated Security=True";

        public DataTable IsItemNameInItems(string name)
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string queryString = "SELECT CASE WHEN EXISTS (SELECT * FROM ItemMaster WHERE ItemName = '" + name + "') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
            SqlCommand cmd = new SqlCommand(queryString, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            sqlConnection.Close();
            return dataTable;

            #endregion
        }
        public string InsertItem()
        {
            ItemMaster itemMaster = new ItemMaster();
            

            #region
        ItemName:
            Console.WriteLine("Enter the ItemName:");
            string name = Console.ReadLine();
            if (name.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto ItemName;
            }
            if (itemMaster.IsItemNameInItems(name).Rows[0][0].ToString().Equals("True"))
            {
                Console.WriteLine($"{name} is already in the Items Table.Please Insert different item!");
                goto ItemName;
            }
        ItemRate:
            Console.WriteLine("Enter the ItemRate:");
            int rate = Convert.ToInt32(Console.ReadLine());

            if (rate.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto ItemRate;
            }
            
         ItemQuantity:
            Console.WriteLine("Enter the ItemQuantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity.Equals(""))
            {
                Console.WriteLine("name Should not be empty!");
                goto ItemQuantity;
            }
            
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("Insert into ItemMaster values('" + name + "'," + rate + "," + quantity + ")", sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return "Inserted";

            #endregion
        }
        #region--Show Data Item
        public DataTable show()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            string a = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select* from ItemMaster", sqlConnection);
            sqlConnection.Open();
            SqlDataReader DataReader = cmd.ExecuteReader();

            DataTable obj = new DataTable();
            obj.Load(DataReader);

            sqlConnection.Close();
            return obj;

            #endregion
        }
        public string UpdateItem()
        {
            #region--Update the Item
          

            Console.WriteLine("Update Item Name  : ");
            string name = Console.ReadLine();

            Console.WriteLine("update Item Rate  : ");
            int rate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Update Item Quantity   : ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);
            SqlCommand cmd = new SqlCommand("update items set ItemRate=" + rate + ",ItemQuantity=" + quantity + " where ItemName= '" + name + "'", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result == 0)
                return "Not Updated";
            return "Updated";

            #endregion
        }

        public string DeleteItem()
        {
            #region--Delete
            string quantity = Console.ReadLine();
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionstr);//connection establishment
            SqlCommand cmd = new SqlCommand("Delete from ItemMaster where ItemQuantity=" + quantity + "", sqlConnection);
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
