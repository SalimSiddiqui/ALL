using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
   public class Constant_ReadOnly
    {
        public const float PI = 3.14f;

        public readonly float Readonly = 3.14f;
        public Constant_ReadOnly()
        {
           
            Console.WriteLine("readonly={0}", Readonly);
            Readonly = 10.0f;
            Console.WriteLine("PI={0}", PI);
            Readonly = 12.0f;

        }
        private void setReadOnlyAgain()
        {
           
        }

    }
}
