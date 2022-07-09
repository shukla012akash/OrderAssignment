using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OrderAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------WELCOME TO ORDER ASSIGNMENT SYSTEM---------------");
            Console.WriteLine("Please log in into any of the following account:");
            Console.WriteLine("Press 1 for CustomerMaster. CustomerMaster");
            Console.WriteLine("Press 2 for ItemMaster. ItemMaster");
            Console.WriteLine("");

            int choice = Convert.ToInt32(Console.ReadLine());
            ItemMaster itemMaster = new ItemMaster();
            CustomerMaster customerMaster = new CustomerMaster();


            switch (choice)
            {
                case 1:
                    Console.WriteLine("---------------WELCOME TO CUSTOMER MASTER---------------");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose one of the following action:");
                    Console.WriteLine("a. Add a Customer in the Order System.");
                    Console.WriteLine("b. Show the current available Customer in the Order System.");
                    Console.WriteLine("c. Show Update Customer.");
                    Console.WriteLine("d. Show The Delete Customer.");
                    Console.WriteLine("e. Exit.");
                    char choice1 = Convert.ToChar(Console.ReadLine());
                    switch (choice1)
                    {
                        case 'a':
                            Console.WriteLine("");
                            customerMaster.InsertCustomer();

                            break;
                        case 'b':
                            Console.WriteLine("");
                            customerMaster.UpdateCustomer();

                            break;
                        case 'c':
                            Console.WriteLine("");
                            customerMaster.Show();

                            break;
                        case 'd':
                            Console.WriteLine("");
                            customerMaster.DeleteCustomer();

                            break;


                    }
                    break;
                case 2:
                    Console.WriteLine("\t\t---------------WELCOME TO ITEM MASTER---------------\t\t");
                    Console.WriteLine("");
                    Console.WriteLine("Please choose one of the following action:");
                    Console.WriteLine("a. Add a Item In the Item Master.");
                    Console.WriteLine("b. Show the Available Item. ");
                    Console.WriteLine("c. Show the Update Item. ");
                    Console.WriteLine("d. Show the Delete Item. ");
                    Console.WriteLine("e. Exit. ");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    switch (choice2)
                    {
                        case 'a':
                            Console.WriteLine("");
                            itemMaster.InsertItem();


                            break;
                        case 'b':
                            Console.WriteLine("");
                            itemMaster.UpdateItem();

                            break;
                        case 'c':
                            Console.WriteLine("");
                            itemMaster.show();
                            break;
                        case 'd':
                            Console.WriteLine("");
                            itemMaster.DeleteItem();
                            break;
                    }
                    break;
            }
        }



















































    
    }
}
