using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    [TestClass()]
    public class MatSimNetworkTests
    {
        [TestMethod()]
        public void GetMinMaxXYTest()
        {
            MatSimNetwork msn = new MatSimNetwork();
            msn.nodes = new List<MatSimNode>();
            msn.nodes.Add(new MatSimNode() { id = "0", x = -1, y = 100 });
            msn.nodes.Add(new MatSimNode() { id = "1", x = 100, y = 1 });
            msn.nodes.Add(new MatSimNode() { id = "2", x = -100, y = 1 });
            msn.nodes.Add(new MatSimNode() { id = "3", x = 1, y = -100 });

            float[] expected = { -100f, -100f, 100f, 100f };

            var actual = msn.GetMinMaxXY();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}