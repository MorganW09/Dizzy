using System;
using System.Collections.Generic;
using System.Text;

namespace Dizzy
{
    public class Interpreter
    {
        public byte[] tape;
        public int pointer;
        public char[] input;

        public Interpreter(string input)
        {
            this.input = input.ToCharArray();
            tape = new byte[30000];
        }

        public void Run()
        {
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '>':
                        pointer++;
                        break;
                    case '<':
                        pointer--;
                        break;
                    case '+':
                        tape[pointer]++;
                        break;
                    case '-':
                        tape[pointer]--;
                        break;
                    case '.':
                        Console.Write(Convert.ToChar(tape[pointer]));
                        break;
                    case ',':
                        break;
                    case '[':
                        if (tape[pointer] == 0)
                        {
                            while (input[i] != ']')
                            {
                                i++;
                            }
                        }
                        else
                        {
                            pointer++;
                        }
                        break;
                    case ']':
                        if (tape[pointer] != 0)
                        {
                            while (input[i] != '[')
                            {
                                i--;
                            }
                        }
                        else
                        {
                            pointer++;
                        }
                        break;
                }
            }
        }
    }
}
