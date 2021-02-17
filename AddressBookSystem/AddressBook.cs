using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    /// <summary>
    /// Contains list of people and the respective methods
    /// </summary>
    public class AddressBook
    {
        public List<Person> addressBook;
        public AddressBook()
        {
            addressBook = new List<Person>();
        }
        /// <summary>
        /// Adds the person to dictionary.
        /// </summary>
        /// <param name="personDictionary">The person dictionary.</param>
        /// <param name="person">The person.</param>
        /// <param name="placeEntity">The place entity.</param>
        private void AddPersonToDictionary(Dictionary<string, List<Person>> personDictionary,Person person,string placeEntity)
        {
            if (personDictionary.ContainsKey(placeEntity))
            {
                personDictionary[placeEntity].Add(person);
            }
            else
            {
                List<Person> newList = new List<Person>();
                newList.Add(person);
                personDictionary.Add(placeEntity, newList);
            }
        }
        /// <summary>
        /// Adds the state of the person to city and.
        /// </summary>
        /// <param name="addressBookCollection">The address book collection.</param>
        /// <param name="person">The person.</param>
        private void AddPersonToCityAndState(AddressBookCollection addressBookCollection,Person person)
        {
            AddPersonToDictionary(addressBookCollection.cityDictionary, person,person.city);
            AddPersonToDictionary(addressBookCollection.stateDictionary, person,person.state);
        }
        /// <summary>
        /// Adds the address book entry.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="addressBookCollection">The address book collection.</param>
        /// <exception cref="AddressBookException">Person already Exists, enter new person!</exception>
        public void AddAddressBookEntry(Person person,AddressBookCollection addressBookCollection)
        {
                if (addressBook.Find(i => person.Equals(i)) != null)
                {
                    throw new AddressBookException("Person already Exists, enter new person!");
                    //Console.WriteLine("Person already Exists, enter new person!");
                    //return;
                }
                AddPersonToCityAndState(addressBookCollection, person);
                addressBook.Add(person);
                        
            
        }
        /// <summary>
        /// Adds the address book entry.
        /// </summary>
        /// <param name="addressBookCollection">The address book collection.</param>
        public void AddAddressBookEntry(AddressBookCollection addressBookCollection)
        {
            Person personEntered = new Person();
            Console.WriteLine("Enter First name");
            personEntered.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            personEntered.lastName = Console.ReadLine();
            if (addressBook.Find(i => personEntered.Equals(i))!=null)
            {
                Console.WriteLine("Person already Exists, enter new person!");
                return;
            }
            Console.WriteLine("Enter Address");
            personEntered.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            personEntered.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            personEntered.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            personEntered.zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            personEntered.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            personEntered.email = Console.ReadLine();
            addressBookCollection.cityDictionary[personEntered.city].Add(personEntered);
            addressBookCollection.stateDictionary[personEntered.state].Add(personEntered);
            addressBook.Add(personEntered);
        }
        /// <summary>
        /// Displays the names in addres book.
        /// </summary>
        public void DisplayNamesInAddresBook()
        {
            if (addressBook.Count == 0)
            {
                Console.WriteLine("No Names to Display");
            }
            foreach (Person person in addressBook)
            {
                Console.WriteLine("-------------------------------------------------");
                person.DisplayPerson();
            }
        }
        /// <summary>
        /// Sorts the first name of the by.
        /// </summary>
        public void SortByFirstName()
        {
            addressBook.Sort((x, y) => x.firstName.CompareTo(y.firstName));
        }
        /// <summary>
        /// Sorts the by zip.
        /// </summary>
        public void SortByZip()
        {
            addressBook.Sort((x, y) => x.zip.CompareTo(y.zip));
        }
        /// <summary>
        /// Sorts the by city.
        /// </summary>
        public void SortByCity()
        {
            addressBook.Sort((x, y) => x.city.CompareTo(y.city));
        }
        /// <summary>
        /// Sorts the state of the by.
        /// </summary>
        public void SortByState()
        {
            addressBook.Sort((x, y) => x.state.CompareTo(y.state));
        }

        /// <summary>
        /// Edits the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public void EditContact(string firstName, string lastName)
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
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
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

}
