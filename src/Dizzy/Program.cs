using System;

namespace Dizzy
{
    class Program
    {
        static void Main(string[] args)
        {

            var i = new Interpreter(args[0]);

            i.Run();

        }
    }


}
