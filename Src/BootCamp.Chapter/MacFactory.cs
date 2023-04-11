using System;
using System.Collections.Generic;
using System.Text;
using BootCamp.Chapter.Computer;

namespace BootCamp.Chapter
{
    public class MacFactory
    {
        public DesktopComputer Assemble()
        {            
            DesktopComputer computer = new DesktopComputer();
            PrepareBody(computer);
            InstallCPU(computer);
            InstallRAM(computer);
            InstallGPU(computer);
            InstallCooler(computer);
            InstallMotherboard(computer);
            return computer;
        }
    }
}
