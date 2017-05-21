using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Configer.Configer.Init("conn");



            Configer.Configer.Set("main","0");
            Configer.Configer.Set("main_1","10","main");
            Configer.Configer.Set("main_2","11","main");

            var c1 = Configer.Configer.Get("main");
            var c2 = Configer.Configer.Get("main_2");
            var c3 = Configer.Configer.Gets("main");

        }
    }
}
