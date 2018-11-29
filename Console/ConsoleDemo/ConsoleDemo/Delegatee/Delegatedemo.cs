using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.Delegatee
{
    public class Delegatedemo
    {

        /// <summary>
        ///  to notify the user (Callback fucntion is getting notify by delegate delcallback that which current no is in process)
        /// </summary>
        /// <param name="i"></param>
        public delegate void delcallback(int i);
        public void LongRunningProcess(delcallback o)
        {
            for (int i = 0; i < 1000; i++)
            {
                o(i);
            }
        }
    }

    public  class Delegatefirst
    {
        public Delegatefirst()
        {
            Delegatedemo Delegatedemo = new Delegatedemo();
            Delegatedemo.LongRunningProcess(Callback);
        }
        public void Callback(int i)
        {
            Console.WriteLine("Current -{0}" , i);
        }
    }

}
