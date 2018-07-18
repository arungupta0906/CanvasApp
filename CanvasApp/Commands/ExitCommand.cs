using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Commands
{
    public class ExitCommand : ICommand
    {
        public ICanvas ExecuteCommand(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
