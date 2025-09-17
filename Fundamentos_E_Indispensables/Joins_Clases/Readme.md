## ¿Qué es un join en C# (LINQ)?

Un join sirve para combinar elementos de dos colecciones diferentes basándose en una clave común.
👉 Muy parecido a lo que se hace en SQL (INNER JOIN, LEFT JOIN, etc.), pero aplicado a objetos en C#.

En C# se pueden escribir en dos formas:

Sintaxis de consulta (parecida a SQL).

Sintaxis de métodos (con lambdas).

🔹 Tipos principales de join en C#

INNER JOIN (por defecto) → devuelve solo los elementos que tienen coincidencia en ambas colecciones.

LEFT JOIN → devuelve todos los de la colección de la izquierda, aunque no tengan coincidencia.

GROUP JOIN → agrupa coincidencias de la derecha en una colección.

## 1️ ⃣ INNER JOIN

👉 Solo devuelve coincidencias en ambas colecciones.

### Ejemplo
var students = new List<Student>
{
new Student { Id = 1, Name = "Ana" },
new Student { Id = 2, Name = "Luis" },
new Student { Id = 3, Name = "Marta" }
};

var enrollments = new List<Enrollment>
{
new Enrollment { StudentId = 1, Course = "Math" },
new Enrollment { StudentId = 1, Course = "History" },
new Enrollment { StudentId = 2, Course = "Programming" }
};

// 🔹 Sintaxis consulta
var innerJoin = from s in students
join e in enrollments
on s.Id equals e.StudentId
select new { s.Name, e.Course };

// 🔹 Sintaxis método
var innerJoin2 = students.Join(enrollments,
s => s.Id,
e => e.StudentId,
(s, e) => new { s.Name, e.Course });

foreach (var item in innerJoin)
Console.WriteLine($"{item.Name} está en {item.Course}");


###  Resultado:

Ana está en Math
Ana está en History
Luis está en Programming

## LEFT JOIN

👉 Incluye todos los elementos de la izquierda, aunque no tengan coincidencia (los sin match aparecen como null).

Ejemplo
var leftJoin = from s in students
join e in enrollments
on s.Id equals e.StudentId into se
from e in se.DefaultIfEmpty()
select new { s.Name, Course = e?.Course ?? "Sin curso" };

foreach (var item in leftJoin)
Console.WriteLine($"{item.Name} -> {item.Course}");


👉 Resultado:

Ana -> Math
Ana -> History
Luis -> Programming
Marta -> Sin curso

3️⃣GROUP JOIN

👉 Une y agrupa las coincidencias de la derecha en una lista.
```C
Ejemplo
var groupJoin = from s in students
join e in enrollments
on s.Id equals e.StudentId into se
select new { s.Name, Courses = se };

foreach (var item in groupJoin)
{
Console.WriteLine($"{item.Name}:");
foreach (var c in item.Courses)
{
Console.WriteLine($"   - {c.Course}");
}
}
```

👉 Resultado:

Ana:
- Math
- History
  Luis:
- Programming
  Marta:
  // vacío porque no tiene cursos

🔹 Resumen rápido

INNER JOIN → solo coincidencias.

LEFT JOIN → todos los de la izquierda (con null si no hay match).

GROUP JOIN → agrupa las coincidencias de la derecha.

//////////////////////////////////////////////////////////////////////////////
## ¿Qué es una clase en C#?

Una clase en C# es como un molde o plano para crear objetos.

Define las propiedades (datos, atributos).

Define los métodos (acciones, comportamientos).

No ocupa memoria por sí sola; la memoria se usa cuando creas un objeto a partir de esa clase (instancia).

👉 Piensa que una clase es como el plano de una casa. El plano no es una casa real, pero te permite construir muchas casas (objetos) con esas mismas características.

```C🔹 Sintaxis básica
public class Persona
{
// Propiedades (atributos)
public string Nombre { get; set; }
public int Edad { get; set; }

    // Método (acción)
    public void Saludar()
    {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }
}

🔹 Crear un objeto (instancia de la clase)
Persona p1 = new Persona();  // crear objeto
p1.Nombre = "David";
p1.Edad = 25;
p1.Saludar();


👉 Salida:

Hola, soy David y tengo 25 años.
```
## 🔹 Cosas importantes de las clases

Atributos/Propiedades → almacenan datos (ej. Nombre, Edad).

Métodos → acciones o funciones que puede hacer el objeto.

Constructores → métodos especiales que se ejecutan al crear el objeto.

public Persona(string nombre, int edad)
{
Nombre = nombre;
Edad = edad;
}


Ejemplo de uso:

Persona p2 = new Persona("Ana", 20);
p2.Saludar();


Encapsulación → puedes ocultar datos internos con private y exponer solo lo necesario con public.

Herencia → una clase puede heredar de otra.

public class Estudiante : Persona
{
public string Carrera { get; set; }
}

### 🔹 Resumen

Una clase = plano/molde.

Un objeto = instancia real de la clase.

Te permiten organizar y reutilizar código con datos + comportamientos juntos.

## Clases privadas en C#

En C#, una clase privada es una clase que solo puede usarse dentro de otra clase.
👉 Es decir, no es accesible desde fuera, su visibilidad está restringida.

### 🔹 ¿Dónde se usan?

Dentro de otra clase (clase anidada).

Se usan cuando quieres ocultar detalles internos que no deben ser visibles ni reutilizados fuera.
```C
🔹 Ejemplo
public class Banco
{
private class CuentaInterna
{
public string Numero { get; set; }
public decimal Saldo { get; set; }
}

    public void CrearCuenta()
    {
        var cuenta = new CuentaInterna
        {
            Numero = "12345",
            Saldo = 1000
        };
        Console.WriteLine($"Cuenta {cuenta.Numero} creada con saldo {cuenta.Saldo}");
    }
}

🔹 Uso
Banco banco = new Banco();
banco.CrearCuenta();  // ✅ Funciona
// var c = new Banco.CuentaInterna(); ❌ ERROR: es privada
```
### 🔹 Resumen rápido

Una clase privada solo existe para la clase contenedora.

Sirve para encapsular lógica auxiliar y evitar que otros la usen directamente.

Es parte de la idea de encapsulación en POO: exponer solo lo necesario.