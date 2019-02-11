using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.DesignPatern
{
    class FactoryMethodDesignPattern_arch
    {
        public void Call()
        {

            // An array of creators

            Creater[] creators = new Creater[2];

            creators[0] = new ConcreateCreator();
            creators[1] = new ConcreateCreator();

            // Iterate over creators and create products

            foreach (Creater creator in creators)
            {
                IProduct product = creator.FactoryCreator("A");
                Console.WriteLine("Created {0}",
                  product.GetType().Name);


                 product = creator.FactoryCreator("B");
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user

            Console.ReadKey();
        }

    }
}
public interface IProduct { }

public class ConcreateClassA : IProduct { }
public class ConcreateClassB : IProduct { }

public abstract class Creater
{
    public abstract IProduct FactoryCreator(string Type);
}
public class ConcreateCreator : Creater
{
    public override IProduct FactoryCreator(string Type)
    {
        switch (Type)
        {
            case "A": return new ConcreateClassA();
            case "B": return new ConcreateClassB();
            default: throw new ArgumentException("Invalid Type");

        }
    }
}



