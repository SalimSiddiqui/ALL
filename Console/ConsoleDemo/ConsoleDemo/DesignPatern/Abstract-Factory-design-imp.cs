using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.DesignPatern
{
    class Abstract_Factory_design_imp
    {
    }
    public interface Vehcile
    {
        Bike getBike(string name);
        Scooter getScooter(string name);
    }

    public interface Bike
    {
        void name();
    }
    public interface Scooter
    {
        void name();
    }

    public class HondaVehcle : Vehcile
    {
        public Bike getBike(string name)
        {
            return null;
        }

        public Scooter getScooter(string name)
        {
            return null;
        }

        
    }
}
