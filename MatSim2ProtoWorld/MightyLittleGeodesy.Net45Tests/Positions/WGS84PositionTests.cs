using Microsoft.VisualStudio.TestTools.UnitTesting;
using MightyLittleGeodesy.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyLittleGeodesy.Positions.Tests
{
    [TestClass()]
    public class WGS84PositionTests
    {
        [TestMethod()]
        public void LatitudeToStringTest1()
        {
            SWEREF99Position swePos = new SWEREF99Position(6652797.165, 658185.201);
            WGS84Position wgsPos = swePos.ToWGS84();

            // String values from Lantmateriet.se, they convert DMS only.
            // Reference: http://www.lantmateriet.se/templates/LMV_Enkelkoordinattransformation.aspx?id=11500
            string latDmsStringFromLM = "N 59º 58' 55.23001\"";
            string lonDmsStringFromLM = "E 17º 50' 6.11997\"";

            Assert.AreEqual(latDmsStringFromLM, wgsPos.LatitudeToString(WGS84Position.WGS84Format.DegreesMinutesSeconds));
            Assert.AreEqual(lonDmsStringFromLM, wgsPos.LongitudeToString(WGS84Position.WGS84Format.DegreesMinutesSeconds));
        }

        [TestMethod()]
        public void LatitudeToStringTest2()
        {
            SWEREF99Position swePos = new SWEREF99Position(6652797.165, 658185.201);
            WGS84Position wgsPos = swePos.ToWGS84();

            string latDegStringFromLM = "59.982008334868";
            string lonDegStringFromLM = "17.8350333249246";

            Assert.AreEqual(latDegStringFromLM, wgsPos.LatitudeToString(WGS84Position.WGS84Format.Degrees));
            Assert.AreEqual(lonDegStringFromLM, wgsPos.LongitudeToString(WGS84Position.WGS84Format.Degrees));

        }
    }
}