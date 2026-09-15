using System;
using System.Collections.Generic;
using System.Text;

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

        public int GetTotalContacts()
        {
            return Books.Sum(b => b.Contacts.Count);
        }
    }
}
