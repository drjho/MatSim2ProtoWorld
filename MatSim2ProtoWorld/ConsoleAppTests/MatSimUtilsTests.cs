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
    public class MatSimUtilsTests
    {
        [TestMethod()]
        public void LineToPointDistance2DTest()
        {
            double[] a = { 0d, 0d };
            double[] b = { 0d, 2d };
            double[] c = { 0d, 1d };

            double expected = 0d;

            double actual = MatSimUtils.LineToPointDistance2D(a, b, c);

            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void LineToPointDistance2DTest2()
        {
            double[] a = { 0d, 0d };
            double[] b = { 0d, 2d };
            double[] c = { 1d, 1d };

            double expected = 0d;

            double actual = MatSimUtils.LineToPointDistance2D(a, b, c);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void LineToPointDistance2DTest3()
        {
            double[] a = { 0d, 0d };
            double[] b = { 0d, 2d };
            double[] c = { 1d, 1d };
            double[] d = { 2d, 2d };

            var dist1 = MatSimUtils.LineToPointDistance2D(a, b, c);
            var dist2 = MatSimUtils.LineToPointDistance2D(a, b, d);

            Assert.IsTrue(dist1 < dist2);
        }

    }
}