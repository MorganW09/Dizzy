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
            var unmatchedBracketCounter = 0;
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
                        var key = Console.ReadKey();
                        tape[pointer] = (byte)key.KeyChar;
                        break;
                    case '[':
                        if (tape[pointer] == 0)
                        {
                            unmatchedBracketCounter++;
                            while (input[i] != ']' || unmatchedBracketCounter != 0)
                            {
                                i++;

                                if (input[i] == '[')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (input[i] == ']')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                    case ']':
                        if (tape[pointer] != 0)
                        {
                            unmatchedBracketCounter++;
                            while (input[i] != '[' || unmatchedBracketCounter != 0)
                            {
                                i--;

                                if (input[i] == ']')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (input[i] == '[')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
