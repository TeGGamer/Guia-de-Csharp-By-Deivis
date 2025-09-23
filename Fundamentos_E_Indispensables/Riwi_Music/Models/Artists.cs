namespace Riwi_Music.Models;

public class Artists : Person
{
    // Esto es lo nuevo
    public string ArtName { get; set; }
    private static int contador = 0;
    private int Id;  
    public string genre { get; set; }

    public Artists( string ArtName, string genre, string name, string lastname, string email, int age , string dni)     // Puede cambiar el orden pero los param. del padre deben llamarse exactamente igual
        : base (name,lastname, email, age, dni )        // si o si debe tener el mismo orden del MCPadre
    {
        // Solo se mete lo nuevo.
        Id = contador++;
        this.ArtName = ArtName;
    }

    public override string Pers()
    {
        int total = 1 + 1;
        return $"{total} este es el total";
    }
    
}