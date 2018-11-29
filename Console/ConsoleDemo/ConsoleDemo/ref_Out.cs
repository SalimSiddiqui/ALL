using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    class ref_Out
    {

    }
    public class Ref_Key
    {
        public void call()
        {
            int num = 10;
            MyMethodRef(ref num);
            Console.WriteLine("Value Outer Method : {0}", num);

        }

        private static void MyMethodRef(ref int number)
        {
            number += 20;
            Console.WriteLine("Value Inner Method : {0}", number);
        }
    }
    public class Out_Ket
    {
        public void call()
        {
            int num = 0;

            MyMethodOut(out num);
            Console.WriteLine("Value Outer Method : {0}", num);

        }

        private static void MyMethodOut(out int number)
        {
            number = 20;
            Console.WriteLine("Value Inner Method : {0}", number);
        }
    }


    class Ref_Key2

    {

        public int sum(ref int a, ref int b)

        {

            a = a + 10;

            b = b + 20;

            return (a + b);

        }

        public void call()
        {
            int a = 10, b = 20;
            Ref_Key2 obj = new Ref_Key2();
            Console.WriteLine("sum of a and b  is : " + obj.sum(ref a, ref b));

            Console.WriteLine("Value of a is : " + a);

            Console.WriteLine("Value of b is : " + b);

        }

    }


    class Out_Key2

    {

        public int sum(int a, int b, out int c, out int d)

        {

            c = a + b;

            d = c + 100;

            return (a + b);

        }
        public void call()
        {
            // local data members have to initialized as they are not initiated with class constructor

            int a = 10, b = 20;

            // the out data members doesn't need to assign initial value as they are processed and brought back

            int c, d;

            Out_Key2 obj = new Out_Key2();



            Console.WriteLine("sum of a and b  is : " + obj.sum(a, b, out c, out d));

            Console.WriteLine("Value of a is : " + a);

            Console.WriteLine("Value of b is : " + b);

            Console.WriteLine("Value of c is : " + c);

            Console.WriteLine("Value of d is : " + d);



           

        }

    }

}
