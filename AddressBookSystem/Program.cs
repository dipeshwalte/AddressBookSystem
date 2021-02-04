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
            person.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            person.zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            person.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            person.email = Console.ReadLine();
            addressBook.Add(person);
        }
        public void DisplayNamesInAddresBook() 
        {
            if (addressBook.Count==0)
            {
                Console.WriteLine("No Names to Display");
            }
            foreach (Person person in addressBook)
            {
                Console.WriteLine(person.firstName);
            }
        }

        public void EditContact(string firstName,string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
            {
                Console.WriteLine("Enter First name");
                addressBook[index].firstName = Console.ReadLine();
                Console.WriteLine("Enter Last name");
                addressBook[index].lastName = Console.ReadLine();
                Console.WriteLine("Enter Address");
                addressBook[index].address = Console.ReadLine();
                Console.WriteLine("Enter City");
                addressBook[index].city = Console.ReadLine();
                Console.WriteLine("Enter State");
                addressBook[index].state = Console.ReadLine();
                Console.WriteLine("Enter Zip");
                addressBook[index].zip = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber");
                addressBook[index].phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Email");
                addressBook[index].email = Console.ReadLine();
            }
            else
                Console.WriteLine("Entry Not found for the name");
        }

        public void DeleteContact(string firstName, string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
                addressBook.Remove(addressBook[index]);
            else
                Console.WriteLine("Entry Not found");
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
                Console.WriteLine("3) Edit Entry");
                Console.WriteLine("4) Delete Entry");
                Console.WriteLine("5) Exit");
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
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        addressBook.EditContact(firstName,lastName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBook.DeleteContact(firstName, lastName);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Enter Proper Choice!");
                        break;
                }
            } while (choice!=5);
            
           
        }
    }
}
