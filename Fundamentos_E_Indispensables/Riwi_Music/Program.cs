using System;
using Riwi_Music.Models;

public class Music
{
    public static void Main(string[] args)
    {
        // Console.WriteLine("Ingresa el nombre: ");
        // string nombre = Console.ReadLine();
        // Person p1 = new Person(nombre, "alejandro", "teka", "23412", 12);
        // Console.WriteLine(p1.Name);
        //
        // Customer de = new Customer("sergio", "mateo", "t", "222", 12, 1);
        // Console.WriteLine(de.Email);

        // Person persona1 = new Person("david", "klauss", "davi@.com", 34, "3423423");

        Artists artista1 = new Artists("Jbalvin", "Rap", "Jose", "Rua", "jesus@", 23, "1234567");

        artista1.Pers();

        Console.WriteLine( artista1.Pers() );


    }
    
}
