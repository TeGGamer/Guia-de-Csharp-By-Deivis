namespace Riwi_Music.Models;

public abstract class Person
{
    public string Name;
    public string Lastname;
    public string Email;
    public string DNI;
    public int Age;

    public Person(string name, string lastname, string email,  int age, string dni)
    {
        Name = name;
        Lastname = lastname;
        Email = email;
        DNI = dni;
        Age = age;
    }

    public virtual string Pers()
    {
        return $"Hola salchichas{Name}";
    }
    
}