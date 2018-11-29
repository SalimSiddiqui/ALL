using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.DesignPatern
{
    class Abstract_Factory_design_arch
    {
    }
    public interface AbstractProductA { }
    public class ProductA1 : AbstractProductA { }
    public class ProductA2 : AbstractProductA { }
    public interface AbstractProductB { }
    public class ProductB1 : AbstractProductB { }
    public class ProductB2 : AbstractProductB { }

    public interface abstarctFactory
    {
        AbstractProductA CreateProductA();
        AbstractProductB CreateProductB();

    }

    public class ConcreatefactoryA : abstarctFactory
    {
        public AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreatefactoryB : abstarctFactory
    {
        public AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }

        public class Client
        {
            // salam 29-10---gg
            private AbstractProductA _productA;
            private AbstractProductB _productB;
            public Client(abstarctFactory factory)
            {
                _productA = factory.CreateProductA();
                _productB = factory.CreateProductB();

            }

        }
    }
}
