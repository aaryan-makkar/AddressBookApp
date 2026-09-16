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
            AddressBookMain manager = new AddressBookMain();
            manager.AddAddressBook(addressBook);

            while(true)
            {
                Console.WriteLine("===== Address Book Menu =====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show All Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Total Contact Count");
                Console.WriteLine("6. Searh by City");
                Console.WriteLine("7. Search by State");
                Console.WriteLine("8. View by City/State");
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

                    case "3":
                        try
                        {
                            Console.WriteLine("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name: ");
                            string lastName = Console.ReadLine();
                            addressBook.EditContact(firstName, lastName);
                        }
                        catch(InvalidContactException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "4":
                        {
                            Console.WriteLine("Enter first name: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string lastName = Console.ReadLine();
                            addressBook.DeleteContact(firstName, lastName);
                        }
                         break;

                    case "5":
                        {
                            Console.WriteLine($"Total contacts in all address books: {manager.GetTotalContacts()}");
                        }
                        break;

                    case "6":
                        {
                            Console.WriteLine("Enter city name: ");
                            string city = Console.ReadLine();
                            manager.SearchByCity(city);
                        }
                        break;
                    case "7":
                        {
                            Console.WriteLine("Enter state name: ");
                            string state = Console.ReadLine();
                            manager.SearchByState(state);
                        }
                        break;

                    case "8":
                        {
                            Console.WriteLine("1. View By City");
                            Console.WriteLine("2. View By State");

                            string selected = Console.ReadLine();

                            if(selected == "1")
                            {
                                manager.ViewByCity();
                            }
                            else if(selected == "2")
                            {
                                manager.ViewByState();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice");
                            }
                        }
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