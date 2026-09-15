using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
namespace AddressBookApp.src.AddressBookApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Contact contact1 = new Contact("John", "Doe", "12 MG Road", "Pune", "Maharashtra", "411001", "9876543210", "john.doe@mail.com");
            //Console.WriteLine(contact1);

            AddressBook addressBook = new AddressBook();

            while(true)
            {
                Console.WriteLine("--Address Book App");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show All COntacts.");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1": 
                        try
                        {
                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Address: ");
                            string address = Console.ReadLine();

                            Console.Write("City: ");
                            string city = Console.ReadLine();

                            Console.Write("State: ");
                            string state = Console.ReadLine();

                            Console.Write("Zip: ");
                            string zip = Console.ReadLine();

                            Console.Write("Phone Number: ");
                            string phone = Console.ReadLine();

                            Console.Write("Email: ");
                            string email = Console.ReadLine();

                            Contact contact = new Contact(
                                firstName,
                                lastName,
                                address,
                                city,
                                state,
                                zip,
                                phone,
                                email
                            );

                            addressBook.AddContact(contact);
                        }
                        catch (InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        addressBook.PrintAll();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}