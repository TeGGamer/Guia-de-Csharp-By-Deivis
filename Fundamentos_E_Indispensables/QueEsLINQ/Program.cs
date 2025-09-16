using System;
using orders;
using product;
using customers;


public class Program
{
    static void Main(string[] args)
    {
        var productos = new List<Product>
        {
            new Product { id = 1, name = "Shampoo", price = 500 },
            new Product { id = 2, name = "agua", price = 2000 },
            new Product { id = 3, name = "cepillo", price = 2500 }
        };

        var producto1 = new Product { id = 1, name = "Coco", price = 25000 };
        producto1.name = "David";
        producto1.id = 5;
        Console.WriteLine(producto1.price);
        
        var customers = new List<Customers>
        {
            new Customers { id = 1, name = "Andres", email = "andres.david @riwi.io" },
            new Customers { id = 2, name = "luis", email = "luis.carlos @correo.io" }
        };
        
        var orders = new List<Orders>
        {
            new Orders {id = 1, CustomerId = 1,ProductId = 2,Quantity = 3},
            new Orders {id = 2, CustomerId = 2,ProductId = 3,Quantity = 4}
        };
        
        //LINQ
        //precio menor a 1000
        var query = from p in productos where p.price < 1000 select p;

        
        //lamda var queryLambda = productos.Where(p => p.price <1000)
        
        foreach (var order in query) //para remplazar segun el caso queryLambda
        {
            Console.WriteLine(order.id);
        }
        
        //Seleccionar nombre de los productos
        
        //Quary 
        var nameProducts = from p in productos select p.name;
        
        //Lmabda
        var queLambda = productos.Select(p => p.name);

        foreach (var name in queLambda )
        {
            Console.WriteLine(name);
        }

        //mostrar dos datos del objeto
        var clientesP = customers.Select(p => p );
        foreach (var i in clientesP)
        {
            Console.WriteLine($"su nombre {i.name} su correo {i.email}");
        }


        // mostrar un dato de la lista
        var clientesT = customers.Select(p => p.name);
        foreach (var i in clientesT)
        {
            Console.WriteLine(i);
        }

    
        //Mostrar ordenes con nombre de cliente y productos Joins 
        var ordenesNc = from o in orders
            join c in customers on o.CustomerId equals c.id
            join p in productos on o.ProductId equals p.id
            select new { o.id, o.ProductId };

        foreach (var iterar in ordenesNc)
        {
            Console.WriteLine(iterar);
        }

        //Mostrar ordenes con nombre de cliente y productos Lambda
      
            










    }
}