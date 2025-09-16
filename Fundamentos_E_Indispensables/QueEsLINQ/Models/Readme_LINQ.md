## 🔹 ¿Qué es LINQ?

LINQ significa Language Integrated Query (Consulta Integrada al Lenguaje).
Es una forma de consultar, filtrar, ordenar y transformar datos en C# usando una sintaxis muy parecida a las consultas SQL, pero directamente sobre colecciones, listas, arrays, bases de datos, XML, etc.

En pocas palabras:
👉 LINQ te permite trabajar con datos de una forma más clara, corta y legible que si usaras for, foreach o métodos tradicionales.

### 
🔹 ¿Qué puede reemplazar?

LINQ puede reemplazar:

✅ Bucles for o foreach cuando solo quieres filtrar, buscar o transformar datos.

✅ Condiciones if anidadas para seleccionar elementos que cumplen ciertos criterios.

✅ Métodos manuales de ordenamiento o búsqueda, como cuando escribes tu propio código para encontrar el máximo, mínimo, promedio, etc.

✅ Código repetitivo para manipular colecciones.

🔹 ¿En qué casos ayuda?

LINQ ayuda cuando trabajas con:

Listas o Arrays → Ejemplo: filtrar productos con precio mayor a 100.

Bases de datos (Entity Framework, Dapper, etc.) → LINQ genera consultas SQL de manera sencilla.

XML / JSON → Para consultar nodos o propiedades.

Colecciones en memoria → Para buscar, agrupar, ordenar y transformar datos rápido.

Sin LINQ (con foreach):

```C#
List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
List<int> pares = new List<int>();

foreach (int n in numeros)
{
    if (n % 2 == 0)
    {
        pares.Add(n);
    }
}
``` 
Con LINQ:
```C#
List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
var pares = numeros.Where(n => n % 2 == 0).ToList();
```

Explicación paso a paso

using System.Linq;

Importa las extensiones LINQ (métodos como Where, Select, OrderBy, etc.). Sin esto los métodos no están disponibles.

List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };

Crea una lista de enteros.

List<int> es una colección en memoria que implementa IEnumerable<int>.

numeros.Where(...)

Where es un método de extensión definido en System.Linq.Enumerable.

Toma una colección (numeros) y una condición (predicado) y devuelve una secuencia (IEnumerable<int>) con los elementos que cumplen la condición.

Importante: Where no ejecuta la consulta inmediatamente; devuelve una secuencia que se evaluará cuando la recorras (esto se llama deferred execution o ejecución diferida).

n => n % 2 == 0 (la parte dentro de Where)

Es una expresión lambda.

Equivale a una función que recibe un int n y devuelve true si n es par.

Tipo: Func<int, bool>.

Forma completa equivalente:
```C#
numeros.Where(n => { return n % 2 == 0; });
```
.ToList()

Convierte la secuencia IEnumerable<int> resultante en un List<int> materializando (forzando) la ejecución de la consulta en ese momento.

Es decir: ToList() recorre la secuencia y crea una lista con los resultados (snapshot).

var pares = ...

var infiere el tipo en tiempo de compilación. Como usamos ToList(), el tipo concreto será List<int>.

Si hubieras escrito var pares = numeros.Where(...); sin ToList(), pares sería IEnumerable<int> (y la consulta seguiría siendo diferida).

Ejemplo que muestra la diferencia (deferred vs materializado)
```C#
var query = numeros.Where(n => n % 2 == 0); // no ejecuta aún
numeros.Add(8);
foreach (var x in query) Console.WriteLine(x); // imprimirá 2,4,6,8 -> refleja el cambio

var lista = numeros.Where(n => n % 2 == 0).ToList(); // ejecuta ahora y guarda snapshot
numeros.Add(10);
foreach (var x in lista) Console.WriteLine(x); // imprimirá 2,4,6,8 -> NO incluye 10
```

## Variantes: sintaxis de consulta (parecida a SQL)
```C#
var paresQuery = (from n in numeros
                  where n % 2 == 0
                  select n).ToList();
```
-> Es lo mismo que la sintaxis de métodos; algunos la prefieren para consultas complejas.

Otros operadores útiles (una línea cada uno)

Select(x => x * 2) — transforma (map).

OrderBy(x => x) / OrderByDescending — ordena.

GroupBy(x => key) — agrupa por llave.

First() / FirstOrDefault() — toma el primer elemento (o null/default).

Any(pred) / All(pred) — comprobaciones booleanas.

Count() / Sum() / Average() / Min() / Max() — agregados.

Consejos prácticos

Usa Where + Select encadenados para filtrar y transformar sin crear listas intermedias (bueno para memoria).

Llama a ToList() o ToArray() cuando necesites materializar los resultados (por ejemplo para pasarlos a otra API o evitar re-ejecuciones).

Evita llamar ToList() innecesariamente (gasta memoria y CPU si la colección es grande).

LINQ es muy legible y reduce errores comparado con bucles manuales para operaciones comunes.

//////////////////////////////////////////////////////////////////////////////////////////
```C#
using System;
using System.Collections.Generic;
using System.Linq; // 🔑 Necesario para usar LINQ

public class Producto
{
public string Nombre { get; set; }
public decimal Precio { get; set; }
}

public class Program
{
public static void Main()
{
List<Producto> productos = new List<Producto>
{
new Producto { Nombre = "Laptop", Precio = 3000 },
new Producto { Nombre = "Mouse", Precio = 50 },
new Producto { Nombre = "Teclado", Precio = 120 },
new Producto { Nombre = "Monitor", Precio = 800 },
};

        // 🔹 Ejemplo LINQ: filtrar productos caros
        var caros = productos
            .Where(p => p.Precio > 500) // condición
            .OrderBy(p => p.Precio)     // ordenar por precio ascendente
            .Select(p => p.Nombre)      // proyectar solo los nombres
            .ToList();                  // convertir en lista

        foreach (var nombre in caros)
        {
            Console.WriteLine(nombre);
        }
    }
}
```
Explicación parte por parte

using System.Linq;

Habilita los métodos de LINQ como Where, OrderBy, Select.

List<Producto> productos = new List<Producto> {...};

Creamos una colección de objetos Producto en memoria.

.Where(p => p.Precio > 500)

Método Where: filtra los elementos según una condición (predicado).

p → cada elemento de la lista.

p.Precio > 500 → condición (booleano).

Resultado: solo Laptop (3000) y Monitor (800).

.OrderBy(p => p.Precio)

Ordena la secuencia resultante de menor a mayor precio.

Ahora: Monitor (800), Laptop (3000).

.Select(p => p.Nombre)

Select transforma cada elemento.

De un Producto (con Nombre y Precio) solo devuelve el Nombre.

Resultado: ["Monitor", "Laptop"].

.ToList()

Convierte la secuencia en un List<string>.

Forza la ejecución en ese momento.

foreach (var nombre in caros)

Recorre la lista final y la imprime.

## Versión con sintaxis de consulta (tipo SQL)
```C#
var caros = (from p in productos
where p.Precio > 500
orderby p.Precio
select p.Nombre).ToList();
```
Hace exactamente lo mismo pero con otra sintaxis.