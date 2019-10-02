using System;

namespace Dizzy
{
    class Program
    {
        static void Main(string[] args)
        {

            var i = new Interpreter("++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.");

            i.Run();

            Console.ReadKey();
        }
    }


}
