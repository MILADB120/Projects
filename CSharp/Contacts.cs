using System.Dynamic;

class Contact
{
    public string Name  {get; set;}
    public int Number {get; set;}
    public string Email {get; set;}

    public Contact (string name , int number , string email)
    {
        Name = name.ToUpper();
        Number = number;
        Email = email;
    }
    
}