using System;
using Xunit;

namespace Dizzy.Test
{
    public class InterpreterTests
    {
        [Fact]
        public void Test_InitializeCorrectly()
        {
            var input = "[->+<]";

            var interpreter = new Interpreter(input);

            Assert.Equal(0, interpreter.pointer);
            Assert.Equal(30000, interpreter.tape.Length);
            Assert.Equal(6, interpreter.input.Length);
        }

        [Fact]
        public void Test_PointerIncrement()
        {
            var input = ">>>>>";

            var interpreter = new Interpreter(input);

            interpreter.Run();

            Assert.Equal(5, interpreter.pointer);
        }

        [Fact]
        public void Test_PointerIncrementAndDecrement()
        {
            var input = ">>>>><<<<";

            var interpreter = new Interpreter(input);

            interpreter.Run();

            Assert.Equal(1, interpreter.pointer);
        }

        [Fact]
        public void Test_TapeIncrement()
        {
            var input = "+++++";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(5, i.tape[0]);
        }

        [Fact]
        public void Test_TapeIncrementAndDecrement()
        {
            var input = "+++++----";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(1, i.tape[0]);
        }

        [Fact]
        public void Test_ComplexIncrement()
        {
            var input = "+++>++>+";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(2, i.pointer);
            Assert.Equal(3, i.tape[0]);
            Assert.Equal(2, i.tape[1]);
            Assert.Equal(1, i.tape[2]);
            Assert.Equal(0, i.tape[3]);
        }

        [Fact]
        public void Test_ComplexIncrementAndDecrement()
        {
            var input = "++++>+++>++-<--<---";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(0, i.pointer);
            Assert.Equal(1, i.tape[0]);
            Assert.Equal(1, i.tape[1]);
            Assert.Equal(1, i.tape[2]);
            Assert.Equal(0, i.tape[3]);
        }

        [Fact]
        public void Test_JumpForward()
        {
            var input = "[++++++]>+";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(1, i.pointer);
            Assert.Equal(0, i.tape[0]);
            Assert.Equal(1, i.tape[1]);
            Assert.Equal(0, i.tape[2]);
        }

        [Fact]
        public void Test_JumpBackward()
        {
            var input = "++[-]";

            var i = new Interpreter(input);

            i.Run();

            Assert.Equal(0, i.pointer);
            Assert.Equal(0, i.tape[0]);
        }
        
    }
}
