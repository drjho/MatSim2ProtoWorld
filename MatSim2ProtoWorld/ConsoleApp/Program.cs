using MightyLittleGeodesy.Positions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\admgaming\Desktop\Jay\input";

            var matsim = new MatSimContainer();
            matsim.Load(path);

        }
    }
}
