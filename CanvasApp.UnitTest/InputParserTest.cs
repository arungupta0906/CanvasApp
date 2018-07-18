using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest
{
    public class InputParserTest
    {
        [Theory]
        [InlineData("C 20 4","C",new string[] { "20", "4" })]
        [InlineData("L 1 2 6 2", "L", new string[] { "1", "2", "6", "2" })]
        [InlineData("L 6 3 6 4", "L", new string[] { "6", "3", "6", "4" })]
        [InlineData("R 14 1 18 3", "R", new string[] { "14", "1", "18", "3" })]
        [InlineData("B 10 3 o", "B", new string[] { "10", "3", "o" })]
        [InlineData("Q", "Q", new string[] {  })]
        public void ParseInput_Command(string rawInput, string CommandName, string[] CommandArgs)
        {
            Input input = InputParser.ParseInput(rawInput);
            Assert.Equal(CommandName, input.Command);
            Assert.Equal(CommandArgs.Length, input.Args.Length);
            if(CommandArgs.Length > 0)
                foreach(string arg in CommandArgs)
                    Assert.Contains(arg, input.Args.ToHashSet());
        }
    }
}
