using System;
using System.Collections.Generic;
using System.Text;

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
}
