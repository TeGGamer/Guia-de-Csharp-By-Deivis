namespace Riwi_Music.Models;

public class Customer : Person
{
    private static int contador = 0;
    private int Id;
    
    public Customer (string name, string lastname, string dni, int age, int id, string email="sin correo")
    : base(name, lastname, email, age, dni)
    {
        Id = contador++;
    }
}