using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Commands
{
    public interface ICommand
    {
        ICanvas ExecuteCommand(string[] args);
    }
}
