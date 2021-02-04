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

        public void AddAddressBookEntry()
        {
            Person person = new Person();
            Console.WriteLine("Enter First name");
            person.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            person.lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            person.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            person.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            person.city = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            person.city = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            person.city = Console.ReadLine();
            Console.WriteLine("Enter Email");
            person.city = Console.ReadLine();
            addressBook.Add(person);
        }
        public void DisplayNamesInAddresBook() 
        {
            foreach (Person person in addressBook)
            {
                Console.WriteLine(person.firstName);
            }
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
                Console.WriteLine("2) Insert new Entry");
                Console.WriteLine("3) Delete Entry");
                Console.WriteLine("4) Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.DisplayNamesInAddresBook();
                        break;
                    case 2:
                        addressBook.AddAddressBookEntry();
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
