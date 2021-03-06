﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace AddressBookSystem
{
    /// <summary>
    /// Collection of Address Books
    /// </summary>
    public class AddressBookCollection
    {
        public Dictionary<string, AddressBook> addressBookDictionary;
        public Dictionary<string, List<Person>> cityDictionary;
        public Dictionary<string, List<Person>> stateDictionary;
        public AddressBookCollection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
            cityDictionary = new Dictionary<string, List<Person>>();
            stateDictionary = new Dictionary<string, List<Person>>();
        }
        /// <summary>
        /// Prints all address book names.
        /// </summary>
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
        /// <summary>
        /// Searches the state of the person in city or.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ArrayList SearchPersonInCityOrState(string firstName,string lastName)
        {
            ArrayList outputLines = new ArrayList();
            foreach (var addressBookEntry in addressBookDictionary)
            {
               List<Person> PersonInCitiesOrStates =  addressBookEntry.Value.addressBook.FindAll(i => (i.firstName==firstName)&&(i.lastName==lastName));
               foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                    outputLines.Add($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                }
            }
            return outputLines;
        }
        /// <summary>
        /// Views the state of the persons by city or.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public ArrayList ViewPersonsByCityOrState(string city,string state)
        {
            ArrayList outputLines = new ArrayList();
            Console.WriteLine($"People in {city} city:");
            outputLines.Add($"People in {city} city:");
            foreach (Person person in cityDictionary[city])
            {
                Console.WriteLine(person.firstName+" "+person.lastName);
                outputLines.Add(person.firstName + " " + person.lastName);
            }

            Console.WriteLine($"People in {state} state:");
            outputLines.Add($"People in {state} state:");
            foreach (Person person in stateDictionary[state])
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
                outputLines.Add(person.firstName + " " + person.lastName);
            }
            return outputLines;
        }
        /// <summary>
        /// Views the state of the count by city or.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public ArrayList ViewCountByCityOrState(string city, string state)
        {
            ArrayList outputLines = new ArrayList();
            outputLines.Add($"Count of {city} is {cityDictionary[city].Count}");
            outputLines.Add($"Count of {state} is {stateDictionary[state].Count}");
            Console.WriteLine($"Count of {city} is {cityDictionary[city].Count}");
            Console.WriteLine($"Count of {state} is {stateDictionary[state].Count}");
            return outputLines;
        }
        /// <summary>
        /// Writes the address book collection to files text.
        /// </summary>
        public void WriteAddressBookCollectionToFilesTXT()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\txtFiles\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Person person in AddressBookItem.Value.addressBook)
                    {
                        writer.WriteLine($"First Name : {person.firstName}");
                        writer.WriteLine($"Last Name : {person.lastName}");
                        writer.WriteLine($"Address : {person.address}");
                        writer.WriteLine($"City : {person.city}");
                        writer.WriteLine($"State : {person.state}");
                        writer.WriteLine($"Zip : {person.zip}");
                        writer.WriteLine($"PhoneNumber : {person.phoneNumber}");
                        writer.WriteLine($"Email : {person.email}");
                    }
                }

                
            }
        }

        /// <summary>
        /// Writes the address book collection to files CSV.
        /// </summary>
        public void WriteAddressBookCollectionToFilesCSV()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\csvFiles\";
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IncludePrivateMembers = true,
            };
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".csv";
                using (StreamWriter writer = new StreamWriter(filePath))
                using (var csvExport = new CsvWriter(writer,configuration))
                {
                    csvExport.WriteRecords(AddressBookItem.Value.addressBook);
                   
                }
                //writer.Close();
            }
        }

        /// <summary>
        /// Writes the address book collection to files json.
        /// </summary>
        public void WriteAddressBookCollectionToFilesJSON()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\jsonFiles\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".json";
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter writer = new StreamWriter(filePath))
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(writer, AddressBookItem.Value.addressBook);
                }
                //writer.Close();
            }
        }
        /// <summary>
        /// Gets the people from file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private List<Person> GetPeopleFromFile(string filepath)
        {
            List<Person> people = new List<Person>();
            string[] lines = File.ReadAllLines(filepath);
            int noOfRecords = lines.Length/8;
            for (int i = 1; i <= noOfRecords; i++)
            {
                Person person = new Person();
                person.firstName = lines[0 * i].Split(':')[1];
                person.lastName = lines[1 * i].Split(':')[1];
                person.address = lines[2 * i].Split(':')[1];
                person.city = lines[3 * i].Split(':')[1];
                person.state = lines[4 * i].Split(':')[1];
                person.zip = lines[5 * i].Split(':')[1];
                person.phoneNumber = lines[6 * i].Split(':')[1];
                person.email = lines[7 * i].Split(':')[1];
                people.Add(person);
            }
            return people;
        }
        /// <summary>
        /// Reads the files to address book collection text.
        /// </summary>
        public void ReadFilesToAddressBookCollectionTXT()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\txtFiles\";
            DirectoryInfo d = new DirectoryInfo(folderPath);
            foreach (var file in d.GetFiles("*.txt"))
            {
                string addressBookName = file.Name.Replace(".txt", "");
                if (!this.addressBookDictionary.ContainsKey(addressBookName))
                {
                    this.addressBookDictionary.Add(addressBookName, new AddressBook());
                    List<Person> people = GetPeopleFromFile(folderPath + file.Name);
                    this.addressBookDictionary[addressBookName].addressBook = people;
                }       
            }
        }
        /// <summary>
        /// Reads the files to address book collection CSV.
        /// </summary>
        public void ReadFilesToAddressBookCollectionCSV()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\csvFiles\";
            DirectoryInfo d = new DirectoryInfo(folderPath);
            foreach (var file in d.GetFiles("*.csv"))
            {
                string addressBookName = file.Name.Replace(".csv", "");
                if (!this.addressBookDictionary.ContainsKey(addressBookName))
                {
                    this.addressBookDictionary.Add(addressBookName, new AddressBook());
                    using (var reader = new StreamReader(folderPath + file.Name))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        List<Person> people = csv.GetRecords<Person>().ToList();
                        this.addressBookDictionary[addressBookName].addressBook = people;
                        reader.Close();
                        Console.WriteLine("Successfully read records from the file "+file.Name);
                    }                    
                }   
            }
        }
        /// <summary>
        /// Reads the files to address book collection json.
        /// </summary>
        public void ReadFilesToAddressBookCollectionJSON()
        {
            string folderPath = @"C:\Users\pc\source\repos\AddressBookSystem\AddressBookSystem\jsonFiles\";
            DirectoryInfo d = new DirectoryInfo(folderPath);
            foreach (var file in d.GetFiles("*.json"))
            {
                string addressBookName = file.Name.Replace(".json", "");
                if (!this.addressBookDictionary.ContainsKey(addressBookName))
                {
                    this.addressBookDictionary.Add(addressBookName, new AddressBook());
                    List<Person> people = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(folderPath + file.Name));
                    this.addressBookDictionary[addressBookName].addressBook = people;
                    Console.WriteLine("Successfully read records from the file " + file.Name);
                }    
            }
        }

    }

}
