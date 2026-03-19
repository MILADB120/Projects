using system;
class Program
{
    static void Main(string[]args)
    {
        console.WriteLine("Welcome to Contact Book!");
        console.WriteLine("please select a number of your choice");

        exit=false ;
        while(exit!=true)
        {
            console.WriteLine("1- Add a contact.");
            console.WriteLine("2- Remove a contact.");
            console.WriteLine("3- Search a contact");
            console.WriteLine("4- Update a contact.");
            console.WriteLine("5- Exit.");
            choice=int.parse(console.ReadLine());
            console.clear();
            switch(choice)
            {
                case 1 :
                    AddContact();
                
                case 2:
                    RemoveContact();
                
                case 3:
                    SearchContact();
                
                case 4:
                    UpdateContact();

                case 5:
                    exit=true;
            }

        }
    }

    AddContact()
    {
        string [] name;
        
        console.WriteLine("Enter name of the contact:");
        name+=console.ReadLine();
        console.WriteLine("Enter number of the contact:");
    }
}