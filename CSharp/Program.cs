
using System.Diagnostics;

class Program
{
    //static List<string> Names = new List<string>();
    //static List<int> Numbers = new List<int>();
    //static List<string> Emails=new List<string>();

    static List<Contact> Contacts = new List<Contact>();

    static string UserInput ="";
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
                        //RemoveContact(); //Done!
                        break;
                    case 3:
                        //SearchContact(); //Done!
                        break;
                    case 4:
                        //UpdateContact(); //Done!
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

    static void ContactsInfo(string Name ,int Number,string Email) //method to store the contacts in lists..
    {
        //List<string> Names = new List<string>();
        //Names.Add(Name.ToUpper());

        //List<int> Numbers = new List<int>();
        //Numbers.Add(Number);

        //List<string> Emails=new List<string>();
        //Emails.Add(Email);

        //DisplayContacts(Names,Numbers,Emails);

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

        Console.WriteLine("Enter number of the contact:");
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

    /*static void RemoveContact() //done
    {
        string UserInput;

        //asking for user input...
        Console.WriteLine("Enter the contact name that you want to delete.");
        UserInput=Console.ReadLine()!;

        //checking the list for the contact..
        bool found = false;
        for (int i= Names.Count -1 ;i >= 0 ;i--)
        {
            if (Names[i] == UserInput.ToUpper())
            {
                Names.RemoveAt(i);
                Numbers.RemoveAt(i);
                Emails.RemoveAt(i);

                Console.WriteLine("The contact has been deleted..\n press any key to continue...");
                Console.ReadKey();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("No Contact found..");
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
    }
    static void SearchContact() //Done!
    {
        bool found = false;

        Console.WriteLine("Enter name of the contact:");
        UserInput =Console.ReadLine()!;

        for (int i=0 ; i < Names.Count ; i++)
        {
            if (Names[i] == UserInput.ToUpper())
            {
                Console.WriteLine("The contact has been found.");
                Console.WriteLine("Contact No["+(i+1) +"]: " + Names[i]);
                Console.WriteLine("Number of the contact: " + Numbers[i]);
                Console.WriteLine("Email: " + Emails[i]);
                Console.WriteLine(" ");

                found=true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Contact not found..");
        }

        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
*/
    static void DisplayContacts( ) //done!
    {
        if (Contacts.Count > 0)
        {
            /*
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Number: {contact.Number}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
            */
            
            for (int i=0;i<Contacts.Count;i++)
            {
                Console.WriteLine("Contact No["+(i+1) +"]: " + Contacts[i].Name);
                Console.WriteLine("Number of the contact: " + Contacts[i].Number);
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

    /*
    static void UpdateContact() //done!
    {
        bool found =false;

        Console.WriteLine("Enter the name of the contact that you want to modify:");
        UserInput = Console.ReadLine()!;

        for (int i=0 ; i < Names.Count ; i++)
        {
            if (Names[i] == UserInput.ToUpper())
            {
                Console.WriteLine("Contact found.\n");
                Console.WriteLine("Enter new Name of the contact:");
                Names[i] = Console.ReadLine()!.ToUpper();

                Console.WriteLine("Enter new Number of the contact:");
                Numbers[i]=int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter new Email of the contact:");
                Emails[i]=Console.ReadLine()!;

                Console.WriteLine("Contact Updated.");
                Console.WriteLine("press any key to continue..");
                Console.ReadKey();
                Console.Clear();

                found=true;

            }
        }

        if (!found)
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
*/

}
