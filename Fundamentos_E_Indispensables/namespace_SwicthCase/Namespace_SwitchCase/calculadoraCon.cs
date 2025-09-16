namespace example_LInqq;

public class calculadoraCon
{
    public static void esqueletoC()
    {
        Console.WriteLine("Introduzca un numero: ");
        double numero1 = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Introduzca el segundo numero: ");
        double numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Que operacion desea realizar?");
        Console.WriteLine("+");
        Console.WriteLine("-");
        Console.WriteLine("/");
        Console.WriteLine("*");
        string operation = Console.ReadLine().Trim();
        double resultado = 0;
        
        switch (operation)
        {
            case "+":
                resultado = numero1 + numero2;
                Console.WriteLine(resultado);
                break;
            case "-":
                resultado = numero1 - numero2;
                Console.WriteLine(resultado);
                break;
            case "/":
                resultado = numero1 / numero2;
                Console.WriteLine(resultado);
                break;
            case "*":
                resultado = numero1 * numero2;
                Console.WriteLine(resultado);
                break;
        }
    }
}