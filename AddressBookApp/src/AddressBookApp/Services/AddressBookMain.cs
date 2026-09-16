using System;
using System.Collections.Generic;
using System.Text;
using AddressBookApp.Models;

namespace AddressBookApp.Services
{
    public class AddressBookMain
    {
        private readonly List<AddressBook> books = new();
        public List<AddressBook> Books { get { return books; } }

        public void AddAddressBook(AddressBook book)
        {
            Books.Add(book);
        }

        public void SearchByCity(string city)
        {
            
            var result = Books
                .SelectMany(b => b.Contacts)
                .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"Found {result.Count()} contact(s): ");
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void SearchByState(string state)
        {

            var result = Books
                .SelectMany(b => b.Contacts)
                .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                .ToList();
            Console.WriteLine($"Found {result.Count()} contact(s)");

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public int GetTotalContacts()
        {
            return Books.Sum(b => b.Contacts.Count);
        }
    }
}
