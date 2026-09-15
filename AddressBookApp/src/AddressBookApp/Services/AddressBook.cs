using AddressBookApp.Models;
using AddressBookApp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApp.Services
{
    public class AddressBook
    {
        private readonly List<Contact> contacts = new();
        public List<Contact> Contacts { get { return contacts; } }
        public void AddContact(Contact c)
        {
            ContactValidator.Validate(c);
            contacts.Add(c);
            Console.WriteLine("Contact added successfully");
        }

        public void EditContact(string fn, string ln)
        {
            Contact foundContact = Contacts.FirstOrDefault(c => c.FirstName == fn && c.LastName == ln);

            if(foundContact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }
           
                Console.WriteLine("Enter new first name(or press Enter to keep): ");
                string firstName = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(firstName))
                {
                    ContactValidator.ValidName(firstName);
                    foundContact.FirstName = firstName;
                }

                Console.WriteLine("Enter new last name(or press Enter to keep): ");
                string lastName = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(lastName))
                {
                    ContactValidator.ValidName(lastName);
                    foundContact.LastName = lastName;
                }


                Console.WriteLine("Enter new address (or press Enter to keep): ");
                string address = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(address))
                {
                    ContactValidator.ValidAddress(address);
                    foundContact.Address = address;
                }

                Console.WriteLine("Enter new city (or press Enter to keep): ");
                string city = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(city))
                {
                    ContactValidator.ValidAddress(city);
                    foundContact.City = city;
                }

                Console.WriteLine("Enter new state (or press Enter to keep): ");
                string state = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(state))
                {
                    ContactValidator.ValidAddress(state);
                    foundContact.State = state;
                }

                Console.Write("Enter new zip (or press Enter to keep): ");
                string zip = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(zip))
                {
                    ContactValidator.ValidZip(zip);
                    foundContact.Zip = zip;
                }

                Console.Write("Enter new phone (or press Enter to keep): ");
                string phone = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    ContactValidator.ValidPhone(phone);
                    foundContact.PhoneNumber = phone;
                }

                Console.Write("Enter new email (or press Enter to keep): ");
                string email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(email))
                {
                    ContactValidator.ValidEmail(email);
                    foundContact.Email = email;
                }
                Console.WriteLine("Contact updated.");
        }

        public void DeleteContact(string fn, string ln)
        {
            Contact foundContact = Contacts.FirstOrDefault(c => c.FirstName == fn && c.LastName == ln);
            
            if(foundContact == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }

            Contacts.Remove(foundContact);
            Console.WriteLine("Contact deleted");
        }
        
        public void PrintAll()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            foreach (Contact c in Contacts)
            {
                Console.WriteLine(c);
            }
        }
    }
}
