using InterfaceCustomer;
using Factory;
namespace Interface_Decoupling
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomer Icus;
            FactoryCustomer Factory = new FactoryCustomer();
            //Factory.Create(1);
            Icus = Factory.Create(0);
            Icus = Factory.Create(1);

            System.Console.WriteLine(Factory.Create(0));
            System.Console.WriteLine(Factory.Create(1));


            System.Console.ReadLine();
        }
    }
}
