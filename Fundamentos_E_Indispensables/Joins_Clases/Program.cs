using System;
using TrabajoClases;
 
public class exe
{
    static void Main(string[] args)
    {
        var estudiantes = new List<student>
        {
            new student { id = 1, name = "david", lastName = "santamaria", age = 31 },
            new student { id = 2, name = "andres", lastName = "arteaga",age = 20 },
            new student { id = 3, name = "diego", lastName = "wills",age = 19 },
            new student { id = 4, name = "carolina", lastName = "cortez",age = 25 }
        };

        var course = new List<course>
        {
            new course { id = 1, title = "Ingles", credits = 6000 },
            new course { id = 2, title = "Matema", credits = 9000 },
            new course { id = 3, title = "Logica", credits = 10000 },
            new course { id = 4, title = "Fisica", credits = 8000 }
        };
        var enrollment = new List<enrollment>
        {
            new enrollment { id = 1, studentId = 1, courseId = 1, Grade = 2 },
            new enrollment { id = 2, studentId = 2, courseId = 3, Grade = 8 },
            new enrollment { id = 3, studentId = 3, courseId = 2, Grade = 5 },
            new enrollment { id = 1, studentId = 3, courseId = 4, Grade = 1 }
        };

        var estudiantes20 = estudiantes.Where(i => i.age == 20);
        foreach (var x in estudiantes20)
        {
            Console.WriteLine($"{x.age} {x.name}");
        }


        //ordenar cursos por creditos
        var creditosB = (from i in course orderby i.credits ascending select i).ToList();
        foreach (var i in creditosB)
        {
            Console.WriteLine(i.credits);
        }

        //buscar curso especifico 
        var nombret = (from i in course where i.title == "Logica" select i);
        foreach (var i in nombret)
        {
            Console.WriteLine(i.id);
        }

        //contar matriculas
        var matriculasE = enrollment.Count();
        Console.WriteLine(matriculasE);
        Console.WriteLine("----------------------------------------");

        //join entre matriculas y estudiantes
        var consulta = from e in enrollment     // ponemos el alias de 'e' a enrollment
                     join s in estudiantes
                         on e.studentId equals s.id         // Campo en común
                     join c in course
                         on e.courseId equals c.id
                     where s.age == 19 || s.age == 31      // fintro o condicion de la busqueda
                     orderby e.Grade descending             // ordenar de forma descendente.
                     select new             // Solo muestrame estos campos:
                     {  
                         e.studentId,
                         e.courseId, 
                         fullname = s.name + " " + s.lastName,      
                         c.title,
                         e.Grade
                     };
        Console.WriteLine("Notas de estudiantes por materia de aquellos con edad de 19 o 31, en forma descendente:");
        Console.WriteLine("IdEst  Nombre              IdCurso          TituloMateria             Nota");
        foreach (var order in consulta)
        {
            Console.WriteLine($"{order.studentId,-6} {order.fullname,-21} {order.courseId,-15} {order.title} {order.Grade, 20}");
        }
            
    }
} 

