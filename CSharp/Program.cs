using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static List<string> Names = new List<string>();
    static List<int> Numbers = new List<int>();
    static List<string> Emails=new List<string>();


    static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to Contact Book!");
        Console.WriteLine("please select a number of your choice");

        bool exit = false;
        while (exit != true)
        {
            Console.WriteLine("1- Add a contact.");
            Console.WriteLine("2- Remove a contact.");
            Console.WriteLine("3- Search a contact");
            Console.WriteLine("4- Update a contact.");
            Console.WriteLine("5- Display all Contacts.");
            Console.WriteLine("6- Exit.");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    RemoveContact();
                    break;
                case 3:
                    SearchContact();
                    break;
                case 4:
                    UpdateContact();
                    break;
                
                case 5:
                    DisplayContacts(Names,Numbers,Emails);
                    break;
                case 6:
                    exit = true;
                    break;
            }

        }
    }

    static void ContactsInfo(string Name ,int Number,string Email)
    {
        //List<string> Names = new List<string>();
        Names.Add(Name);

        //List<int> Numbers = new List<int>();
        Numbers.Add(Number);

        //List<string> Emails=new List<string>();
        Emails.Add(Email);

        //DisplayContacts(Names,Numbers,Emails);

    }
    static void AddContact()
    {
        string name;
        int number;
        string email;
        Console.WriteLine("Enter Name of the contact:");
        name = Console.ReadLine();
        Console.WriteLine("Enter number of the contact:");
        number=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter email address:");
        email=Console.ReadLine();

        ContactsInfo(name,number,email);

        Console.WriteLine("The Contact has been added.\npress any key to continue.");
        Console.ReadKey();
        Console.Clear();
        
    }

    // TODO: Implement other methods
    static void RemoveContact()
    {

    }
    static void SearchContact() { }

    static void DisplayContacts(List<string>Names , List<int> Numbers,List<string> Emails) 
    {
        for (int i=0;i<Names.Count;i++)
        {
            Console.WriteLine("Contact No["+(i+1) +"]: " + Names[i]);
            Console.WriteLine("Number of the contact: " + Numbers[i]);
            Console.WriteLine("Email: " + Emails[i]);
            Console.WriteLine(" ");
        }

        Console.WriteLine("press any key to continue...");
        Console.ReadKey();
        Console.Clear();


    }
    static void UpdateContact() { }
}
