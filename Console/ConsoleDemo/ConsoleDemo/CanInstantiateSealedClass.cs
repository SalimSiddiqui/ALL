using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    /// <summary>
    /// 
    /// </summary>
    sealed class CanInstantiateSealedClass
    {
        public void Print()
        {
            Console.WriteLine("asdfsadfs");
            
        }
    }
    //public class CanNotInstantiateSealedClass : System.Data.SqlClient.SqlConnection
    //{

    //}

    // Can not inherit sealed calss but can be instantiated 
    //public class abc: CanInstantiateSealedClass
    //{

    //}

    /// <summary>
    /// Sealed Methods and Properties 

    //You can also use the sealed modifier on a method or a property that overrides 
    //a virtual method or property in a base class. This enables you to allow classes
    //to derive from your class and prevent other developers that are using your classes 
    //from overriding specific virtual methods and properties.
    /// </summary>
    class X
    {
        protected virtual void F() { Console.WriteLine("X.F"); }
        protected virtual void F2() { Console.WriteLine("X.F2"); }
    }

    class Y : X
    {
        sealed protected override void F() { Console.WriteLine("Y.F"); }
        protected override void F2() { Console.WriteLine("X.F3");}
        
    }

    class Z : Y
    {
        // Attempting to override F causes compiler error CS0239. 

        //Error CS0239	'Z.F()': cannot override inherited member 'Y.F()' because it is sealed ConsoleDemo C:\projects\Git\ConsoleDemo\ConsoleDemo\CanInstantiateSealedClass.cs	49	Active

        //        protected override void F() { Console.WriteLine("C.F"); }
        // Overriding F2 is allowed. 
        protected override void F2() { Console.WriteLine("Z.F2"); }
    }



    //https://www.c-sharpcorner.com/forums/difference-between-static-and-sealed-classes-in-c-sharp

    //A static field identifies exactly one storage location to be shared by all instances of a given closed class type (The C# Programming Language).
    /*ifference between static and sealed classes in C#
Jun 28 2011 12:15 PM
Static class:
1) A static class can not be instantiated. Means you can't create instance of          any static class.
2) A static class can have only static member (e.g static method, property, and         variables).
3) A static class restrict the user to call default constructor of the class.
4) Static classes can only have static constructor to initialize static members.
5) Static classes are sealed so they can not be inherited.

Sealed Class:
1) When a class defined as sealed its not possible to inherit.
2)  A Sealed class is last class of Inheritance feature.
3)  Use the sealed modifier in a class declaration to prevent inheritance of the         class.
4) It is not permitted to use the abstract modifier with a sealed class.
5) Structs are implicitly sealed; therefore, they cannot be inherited.
Example:
// cs_sealed_keyword.cs // Sealed classes using System; sealed class MyClass  {    public int x;     public int y; }  class MainClass  {    public static void Main()     {       MyClass mC = new MyClass();        mC.x = 110;       mC.y = 150;       Console.WriteLine("x = {0}, y = {1}", mC.x, mC.y);     } }
Output:
x = 110, y = 150
In the preceding example, if you attempt to inherit from the sealed class by using a statement like this:
class MyDerivedC: MyClass {}   // Error
you will get the error message:
'MyDerivedC' cannot inherit from sealed class 'MyBaseC'.
*/


}
