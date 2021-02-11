using NUnit.Framework;
using AddressBookSystem;
using System.Collections;

namespace AddressBookTesting
{
    public class Tests
    {
        AddressBookCollection addressBookCollection;
        public void AddDefaultEntries()
        {
            addressBookCollection.addressBookDictionary.Add("Default", new AddressBook());
            Person person1 = new Person();
            person1.firstName = "Dipesh";
            person1.lastName = "Walte";
            person1.address = "Flat no 30-B";
            person1.city = "Pune";
            person1.state = "Maharashtra";
            person1.zip = "411033";
            person1.phoneNumber = "942241411";
            person1.email = "dipeshrwalte@gmail.com";
            Person person2 = new Person();
            person2.firstName = "Dhanesh";
            person2.lastName = "Walte";
            person2.address = "Flat no 30-B";
            person2.city = "Mumbai";
            person2.state = "Maharashtra";
            person2.zip = "411033";
            person2.phoneNumber = "942241411";
            person2.email = "dhaneshrwalte@gmail.com";
            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person2, addressBookCollection);
            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person1, addressBookCollection);
        }
        [SetUp]
        public void Setup()
        {
            addressBookCollection = new AddressBookCollection();
            AddDefaultEntries();
        }
        //UC 7
        [Test]
        public void WhileAddingDuplicateEntry_ThrowException()
        {
            Person person = new Person();
            person.firstName = "Dipesh";
            person.lastName = "Walte";
            Assert.Throws<AddressBookException>(()=> addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person, addressBookCollection));
        }
        //UC8
        [Test]
        [TestCase("Dipesh","Walte")]
        public void GivenAddressBookSearchPersonInCityOrState(string firstName,string lastName)
        {
            ArrayList expectedOutputLines = new ArrayList();
            expectedOutputLines.Add($" {firstName} {lastName} is in Pune Maharashtra");
            ArrayList outputLines = addressBookCollection.SearchPersonInCityOrState(firstName,lastName);
            Assert.AreEqual(expectedOutputLines, outputLines);
        }

        [Test]
        [TestCase("Salil", "Jamdhar")]
        public void GivenAddressBookSearchPersonInCityOrState_EntryNotPresent(string firstName, string lastName)
        {
            ArrayList expectedOutputLines = new ArrayList();
            ArrayList outputLines = addressBookCollection.SearchPersonInCityOrState(firstName, lastName);
            Assert.AreEqual(expectedOutputLines, outputLines);
        }
        //UC9
        [Test]
        [TestCase("Pune","Maharashtra")]
        public void ViewPersonsByCityOrState(string cityName,string stateName)
        {
            ArrayList expectedOutputLines = new ArrayList();
            expectedOutputLines.Add("People in Pune city:");
            expectedOutputLines.Add("Dipesh Walte");
            expectedOutputLines.Add("People in Maharashtra state:");
            expectedOutputLines.Add("Dhanesh Walte");
            expectedOutputLines.Add("Dipesh Walte");
            ArrayList outputLines = addressBookCollection.ViewPersonsByCityOrState(cityName, stateName);
            Assert.AreEqual(expectedOutputLines, outputLines);
        }
        //UC10
        [Test]
        [TestCase("Pune", "Maharashtra")]
        public void GetNoOfContactPersonsByCityOrState(string cityName, string stateName)
        {
            ArrayList expectedOutputLines = new ArrayList();
            expectedOutputLines.Add("Count of Pune is 1");
            expectedOutputLines.Add("Count of Maharashtra is 2");
            ArrayList outputLines = addressBookCollection.ViewCountByCityOrState(cityName, stateName);
            Assert.AreEqual(expectedOutputLines, outputLines);
        }

    }
}