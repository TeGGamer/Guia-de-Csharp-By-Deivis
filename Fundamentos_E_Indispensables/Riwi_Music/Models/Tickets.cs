namespace Riwi_Music.Models;

public class Tickets : Concerts
{
    private static int Id = 0;
    private int contador;
    public double price { get; set; }
    public string localy { get; set; }
    

    public Tickets(double price, string localy, DateOnly timeevent) 
        : base( timeevent )
    {
        Id = contador++;
    }

}