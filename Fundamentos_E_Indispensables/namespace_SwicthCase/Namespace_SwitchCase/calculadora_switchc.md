## Como importar un namespace.

Para importar un namespace se usa el **"using (nombre del namespace);"**, y aunque no es obligatorio 
si se podria decir que es casi indispensable para las buenas practicas y para evitar en un futuro confusiones
ya que si se declaran dos clases sin un namespace el programa no sabria diferenciar cual clase es la que deberia usar.

A su vez varios namespaces no pueden estar dentro de una misma clase esto arrojaria un error

### Ejemplo de como *SI* deberian de verse varios namespace en un mismo .cs

```C#
namespace Tienda
{
    public class Producto
    {
        public string Nombre { get; set; }
    }
}

namespace Finanzas
{
    public class Factura
    {
        public double Total { get; set; }
    }
}
```
### Ejemplo de como *NO* Deberian de verse 
```C#
namespace Tienda
{
    public class Producto
    {
        public string Nombre { get; set; }
    }
}

namespace Finanzas
{
    public class Producto   // ❌ Aquí intentamos duplicar la clase con el mismo nombre.
    {
        public double Total { get; set; }
    }
}
```

### Ejemplo (esto compila, pero puede confundir):

```C#
namespace Tienda
{
    public class Producto
    {
        public string Nombre { get; set; }
    }
}

namespace Finanzas
{
    public class Producto
    {
        public double Total { get; set; }
    }
}
```
Conclusión

En el mismo namespace → no puedes repetir nombres de clases.

En namespaces distintos → sí puedes, pero puede causar ambigüedad y deberás usar el nombre completo para diferenciarlas.
Tienes que aclarar con el nombre completo:

Tienda.Producto p = new Tienda.Producto();

Finanzas.Producto f = new Finanzas.Producto();



### Swicth Case:
Un switch es una estructura condicional que se usa cuando quieres comparar una misma variable contra varios posibles valores.
Es una alternativa más ordenada que usar muchos if - else if.
```C#
switch (expresion)
{
case valor1:
// Código a ejecutar si expresion == valor1
break;

    case valor2:
        // Código a ejecutar si expresion == valor2
        break;

    default:
        // Código a ejecutar si no coincide con ningún case
        break;
}
```
¿Qué es el default?

El default es un bloque opcional dentro de un switch.
Se ejecuta cuando la expresión no coincide con ninguno de los case definidos.
 Piensa en el default como un "plan B" o un "else" dentro del switch.