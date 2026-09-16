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

        public void ViewByCity()
        {
            var groups = Books
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.City);

            Console.WriteLine($"---By City---");
            foreach(var group in groups)
            {
                Console.WriteLine($"{group.Key}:");
                foreach(var contact in group)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }
            }
        }

        public void ViewByState()
        {
            var groups = Books
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.State);

            Console.WriteLine("---By State---");
            foreach(var group in groups)
            {
                Console.WriteLine($"{group.Key}:");
                foreach(var contact in group)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }
            }
        }

        public void CountByCityOrState()
        {
            var cityCounts = Books
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.City)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                });


            Console.WriteLine("By City: ");
            foreach(var city in cityCounts)
            {
                Console.WriteLine($"{city.Name} = {city.Count}");
            }

            Console.WriteLine();

            var stateCounts = Books
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.State)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                });

            Console.WriteLine("By State: ");
            foreach (var state in stateCounts)
            {
                Console.WriteLine($"{state.Name} = {state.Count}");
            }
        }

        public int GetTotalContacts()
        {
            return Books.Sum(b => b.Contacts.Count);
        }
    }
}
