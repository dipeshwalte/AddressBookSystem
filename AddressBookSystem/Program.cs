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

        public void DisplayPerson()
        {
            Console.WriteLine($"First Name : {firstName}");
            Console.WriteLine($"Last Name : {lastName}");
            Console.WriteLine($"Address : {address}");
            Console.WriteLine($"City : {city}");
            Console.WriteLine($"State : {state}");
            Console.WriteLine($"Zip : {zip}");
            Console.WriteLine($"PhoneNumber : {phoneNumber}");
            Console.WriteLine($"Email : {email}");
        }
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
                Console.WriteLine("-------------------------------------------------");
                person.DisplayPerson();
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

    public class AddressBookCollection
    {
        public Dictionary<string, AddressBook> addressBookDictionary;
        public AddressBookCollection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
        }
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Address Book!");
            Console.WriteLine("Enter Default Address Book Name");
            string addressBookName = Console.ReadLine();
            AddressBookCollection addressBookCollection = new AddressBookCollection();
            AddressBook addressBook = new AddressBook();
            addressBookCollection.addressBookDictionary.Add(addressBookName, addressBook);
            int choice;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter Choice:");
                Console.WriteLine("1) Display All Entries");
                Console.WriteLine("2) Insert new Entry");
                Console.WriteLine("3) Edit Entry");
                Console.WriteLine("4) Delete Entry");
                Console.WriteLine("5) Add New Address Book");
                Console.WriteLine("6) Switch To Different Address Book");
                Console.WriteLine("7) Exit");
                Console.WriteLine("------------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookCollection.addressBookDictionary[addressBookName].DisplayNamesInAddresBook();
                        break;
                    case 2:
                        addressBookCollection.addressBookDictionary[addressBookName].AddAddressBookEntry();
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].EditContact(firstName,lastName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].DeleteContact(firstName, lastName);
                        break;
                    case 5:
                        Console.WriteLine("Enter New Address Book Name");
                        addressBookName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary.Add(addressBookName, new AddressBook());
                        Console.WriteLine($"Address Book {addressBookName} selected!");
                        break;
                    case 6:
                        Console.WriteLine("Listing all Address Books");
                        foreach (var addressBookEntry in addressBookCollection.addressBookDictionary)
                        {
                            Console.WriteLine(addressBookEntry.Key);
                        }
                        Console.WriteLine("Select an Address Book");
                        addressBookName = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Enter Proper Choice!");
                        break;
                }
            } while (choice!=7);
            
           
        }
    }
}
