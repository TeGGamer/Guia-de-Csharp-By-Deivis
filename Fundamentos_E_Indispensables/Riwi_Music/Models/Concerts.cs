namespace Riwi_Music.Models;

public class Concerts
{
    private static int Id_Cont = 0;
    public int contador;
    public DateOnly Timeevent { get; set; }
    public string location { get; set; }
    public int capacity { get; set; }
    

    public Concerts(DateOnly timeevent)
    {
        Timeevent = timeevent;
        Id_Cont = contador++;
        
    }
    
}