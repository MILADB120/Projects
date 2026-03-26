using System.Diagnostics;

class Program
{
    static List<Contact> Contacts = new List<Contact>();

    static string userInput ="";
    static bool exit=false;

    static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to Contact Book!");
        Console.WriteLine("please select a number of your choice");

        while (exit != true)
        {
            try
            {
                Console.WriteLine("1- Add a contact.");
                Console.WriteLine("2- Remove a contact.");
                Console.WriteLine("3- Search a contact");
                Console.WriteLine("4- Update a contact.");
                Console.WriteLine("5- Display all Contacts.");
                Console.WriteLine("6- Exit.");
                int choice = int.Parse(Console.ReadLine()!);
                Console.Clear();
                
                switch (choice)
                {
                    case 1:
                        AddContact(); //Done!
                        break;
                    case 2:
                        RemoveContact(); //Done!
                        break;
                    case 3:
                        SearchContact(); //Done! 
                        break;
                    case 4:
                        UpdateContact(); //in progress..
                        break;
                
                    case 5:
                        DisplayContacts(); //Done!
                        break;
                    case 6:
                        exit = true;
                        break;
                        
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-6.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (System.FormatException )
            {
                Console.WriteLine("Error: wrong input.\nplease try again.");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    static void AddContact() //done
    {
        string inputName;
        int inputNumber;
        string inputEmail;
        
        Console.WriteLine("Enter Name of the contact:");
        inputName = Console.ReadLine()!;

        if(string.IsNullOrEmpty(inputName))
        {
            Console.WriteLine("Name cannot be empty.");
            Console.WriteLine("please try again.");
            Console.ReadKey();
            Console.Clear();
            AddContact();
        }

        Console.WriteLine("Enter Number: ");
        inputNumber=int.Parse(Console.ReadLine()!);
        if(inputNumber.ToString().Length == 0)
        {
            Console.WriteLine("Number cannot be empty.");
            Console.WriteLine("please try again.");
            Console.ReadKey();
            Console.Clear();
            AddContact();
        }

        Console.WriteLine("Enter email address:");
        inputEmail=Console.ReadLine()!;
        if(string.IsNullOrEmpty(inputEmail))
        {
            Console.WriteLine("Email cannot be empty.");
            Console.WriteLine("please try again.");
            Console.ReadKey();
            Console.Clear();
            AddContact();
        }
        else
        {
            if (!inputEmail.Contains("@"))
            {
                Console.WriteLine("Invalid email: missing '@'");
                Console.WriteLine("please try again.");
                Console.ReadKey();
                Console.Clear();
                AddContact();
            }

            else if (!inputEmail.Contains("."))
            {
                Console.WriteLine("Invalid email: missing '.'");
                Console.WriteLine("please try again.");
                Console.ReadKey();
                Console.Clear();
                AddContact();
            }
        }

        Contact newContact = new Contact(inputName,inputNumber,inputEmail);
        Contacts.Add(newContact);

        //ContactsInfo(inputName,number,email);

        Console.WriteLine("The Contact has been added.\npress any key to continue.");
        Console.ReadKey();
        Console.Clear();
        
    }

    static void RemoveContact() //Done!
    {
        string userInput;

        //asking for user input...
        Console.WriteLine("Enter the contact name that you want to delete.");
        userInput=Console.ReadLine()!.ToUpper();

        var contact = Contacts.Find(c => c.Name == userInput);

        //checking the list for the contact..
        bool found = false;
        if (contact != null)
        {
            Contacts.Remove(contact);
            Console.WriteLine("The contact has been deleted..\n press any key to continue...");
            Console.ReadKey();
            found = true;
        }

        if (!found || contact == null )
        {
            Console.WriteLine("No Contact found..");
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
    }
    
    static void SearchContact() //Done!
    {
        Console.WriteLine("Enter name to search:");
        string input = Console.ReadLine().ToUpper();

        bool found = false;

        foreach (var contact in Contacts)
        {
            if (contact.Name.Contains(input))
            {
                Console.WriteLine("Name: " + contact.Name);
                Console.WriteLine("Number:  " + contact.Number);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine();

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No contact found.");
        }
        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
        
    static void DisplayContacts( ) //Done!
    {
        if (Contacts.Count > 0)
        {
            for (int i=0;i<Contacts.Count;i++)
            {
                Console.WriteLine("Contact No["+(i+1) +"]: " + Contacts[i].Name);
                Console.WriteLine("Number:  " + Contacts[i].Number);
                Console.WriteLine("Email: " + Contacts[i].Email);
                Console.WriteLine(" ");
            }
        }

        else if (Contacts.Count == 0 )
        {
            Console.WriteLine("No Contacts Found. ");
        }

        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    static void UpdateContact() 
    {
        bool found =false;

        Console.WriteLine("Enter the name of the contact that you want to modify:");
        userInput = Console.ReadLine()!.ToUpper();
        if(!string.IsNullOrEmpty(userInput))
        {
            foreach (var contact in Contacts)
            {
                if (contact.Name.Contains(userInput))
                {
                    Console.WriteLine("Contact found.\n");
                    Console.WriteLine("Enter new Name of the contact:");
                    contact.Name = Console.ReadLine()!.ToUpper();

                    Console.WriteLine("Enter new Number: ");
                    contact.Number=int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Enter new Email of the contact:");
                    contact.Email=Console.ReadLine()!;

                    Console.WriteLine("Contact Updated.");
                    Console.WriteLine("press any key to continue..");
                    Console.ReadKey();
                    Console.Clear();

                    found=true;
                    break;
                }
            }
        }

        else if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Name cannot be empty.");
            Console.WriteLine("please try again.");
            Console.ReadKey();
            Console.Clear();
            UpdateContact();
        }

        else if (!found)
        {
            Console.WriteLine("No such Contact, please try again or press 6 to Exit program.");
            string choice=Console.ReadLine()!;

            if(choice == "6" )
            {
                exit=true;
            }

            else
            {
            Console.Clear();
            UpdateContact();
            }
        }
    }
}
