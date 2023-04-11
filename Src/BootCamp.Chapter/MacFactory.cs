using System;
using System.Collections.Generic;
using System.Text;
using BootCamp.Chapter.Computer;

namespace BootCamp.Chapter
{
    public class MacFactory : ComputerFactory
    {
        public override DesktopComputer Assemble()
        {            
            DesktopComputer computer = new DesktopComputer();
            Body body = new Body();
            computer.SetBody(body);
            return computer;
        }
    }
}
