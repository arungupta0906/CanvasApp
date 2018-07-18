using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanvasApp
{
    public class InputParser
    {
        public static Input ParseInput(string rawInput)
        {
            var command = rawInput.Split(' ');
            var commandName = command[0];
            var commandArgs = command.Skip(1).ToArray();

            return new Input(commandName, commandArgs);
        }
    }
    public class Input
    {
        public string Command { get; private set; }
        public string[] Args { get; private set; }

        public Input(string commandName, string[] commandArgs)
        {
            Command = commandName;
            Args = commandArgs;
        }
    }
}
