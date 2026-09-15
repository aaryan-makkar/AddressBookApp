using AddressBookApp.Models;
using AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private List<Contact> contacts = new();
        public List<Contact> Contacts { get { return contacts; } }
        public void AddContact(Contact c)
        {
            ContactValidator.Validate(c);
            contacts.Add(c);
            Console.WriteLine("Contact added successfully");
        }
        
        public void PrintAll()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            foreach (Contact c in contacts)
            {
                Console.WriteLine(c);
            }
        }
    }
}
