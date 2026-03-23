using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;

//Task :
//Add exception handling:
//1- system format exception , Done!
//2- string.IsNullOrEmpty(name) Done!

/*Notes:
    1- Add "no contact found" in DisplayContact() Method //Fixed
    2- Fix bug in SearchContact() and RemoveContact() UpdateContact() Methods, the name is not found if its not in uppercase //Fixed
    3- See what the fuck all this warnings is about...
    4-There is a bug in UpdateContact() method when entering a new name its in lower case //Fixed

*/

class Program
{
    static List<string> Names = new List<string>();
    static List<int> Numbers = new List<int>();
    static List<string> Emails=new List<string>();

    static string UserInput="";
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
                string? input = Console.ReadLine();
                if (input == null) { exit = true; break; }
                int choice = int.Parse(input);
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
                        UpdateContact(); //Done!
                        break;
                
                    case 5:
                        DisplayContacts(Names,Numbers,Emails); //Done!
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
            catch (System.FormatException ex)
            {
                Console.WriteLine("Error: you must enter a number.\nplease try again.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
                Console.Clear();
            }


        }

    }

    static void ContactsInfo(string Name ,int Number,string Email) //method to store the contacts in lists..
    {
        //List<string> Names = new List<string>();
        Names.Add(Name.ToUpper());

        //List<int> Numbers = new List<int>();
        Numbers.Add(Number);

        //List<string> Emails=new List<string>();
        Emails.Add(Email);

        //DisplayContacts(Names,Numbers,Emails);

    }
    static void AddContact() //done
    {
        string name;
        int number;
        string email;

        Console.WriteLine("Enter Name of the contact:");
        string? nameInput = Console.ReadLine();
        if (nameInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        name = nameInput;

        if(string.IsNullOrEmpty(name))
        {
            Console.WriteLine("The name must not be empty.");
            Console.WriteLine("please try again.");
            Console.ReadKey();
            Console.Clear();
            AddContact();
        }

        Console.WriteLine("Enter number of the contact:");
        string? numberInput = Console.ReadLine();
        if (numberInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        number = int.Parse(numberInput);

        Console.WriteLine("Enter email address:");
        string? emailInput = Console.ReadLine();
        if (emailInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        email = emailInput;

        ContactsInfo(name,number,email);

        Console.WriteLine("The Contact has been added.\npress any key to continue.");
        Console.ReadKey();
        Console.Clear();
        
    }

    static void RemoveContact() //done
    {
        string UserInput;

        //asking for user input...
        Console.WriteLine("Enter the contact name that you want to delete.");
        string? userInput = Console.ReadLine();
        if (userInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        UserInput = userInput;

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
        string? searchInput = Console.ReadLine();
        if (searchInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        UserInput = searchInput;

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

    static void DisplayContacts(List<string>Names , List<int> Numbers,List<string> Emails) //done!
    {
        if (Names.Count > 0)
        {
            for (int i=0;i<Names.Count;i++)
            {
                Console.WriteLine("Contact No["+(i+1) +"]: " + Names[i]);
                Console.WriteLine("Number of the contact: " + Numbers[i]);
                Console.WriteLine("Email: " + Emails[i]);
                Console.WriteLine(" ");
            }
        }
        else if (Names.Count == 0 )
        {
            Console.WriteLine("No Contacts Found. ");
        }

        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    static void UpdateContact() //done!
    {
        bool found =false;

        Console.WriteLine("Enter the name of the contact that you want to modify:");
        string? updateInput = Console.ReadLine();
        if (updateInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
        UserInput = updateInput;

        for (int i=0 ; i < Names.Count ; i++)
        {
            if (Names[i] == UserInput.ToUpper())
            {
                Console.WriteLine("Contact found.\n");
                Console.WriteLine("Enter new Name of the contact:");
                string? newName = Console.ReadLine();
                if (newName == null) { Console.WriteLine("Input interrupted. Contact not updated."); Console.ReadKey(); Console.Clear(); return; }
                Names[i] = newName.ToUpper();

                Console.WriteLine("Enter new Number of the contact:");
                string? newNumber = Console.ReadLine();
                if (newNumber == null) { Console.WriteLine("Input interrupted. Contact not updated."); Console.ReadKey(); Console.Clear(); return; }
                Numbers[i] = int.Parse(newNumber);

                Console.WriteLine("Enter new Email of the contact:");
                string? newEmail = Console.ReadLine();
                if (newEmail == null) { Console.WriteLine("Input interrupted. Contact not updated."); Console.ReadKey(); Console.Clear(); return; }
                Emails[i] = newEmail;

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
            string? choiceInput = Console.ReadLine();
            if (choiceInput == null) { Console.WriteLine("Input interrupted. Returning to menu."); Console.ReadKey(); Console.Clear(); return; }
            string choice = choiceInput;

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
