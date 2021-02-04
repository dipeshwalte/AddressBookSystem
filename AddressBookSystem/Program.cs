using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Person
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string phoneNumber;
        public string email;
    }
    public class AddressBook
    {
        List<Person> addressBook;
        public AddressBook()
        {
            addressBook = new List<Person>();
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to Address Book!");
            int choice;
            do
            {
                Console.WriteLine("Enter Choice:");
                Console.WriteLine("1) Display All Entries");
                Console.WriteLine("2) Insert Entry");
                Console.WriteLine("3) Delete Entry");
                Console.WriteLine("4) Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Enter Proper Choice!");
                        break;
                }
            } while (choice!=4);
            
           
        }
    }
}
