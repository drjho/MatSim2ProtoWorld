using MightyLittleGeodesy.Positions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp
{
    public class MatSimContainer
    {
        public void Load(string path)
        {
            var networkPath = Path.Combine(path, "network-plain.xml");
            var schedulePath = Path.Combine(path, "transitSchedule.xml");
            var vehiclePath = Path.Combine(path, "vehicles.xml");

            var matSimNetwork = MatSimNetwork.Load(networkPath);
            var matSimSchedule = MatSimSchedule.Load(schedulePath);
            var vehicleDefinition = VehicleDefinitions.Load(vehiclePath);

            var minmax = matSimNetwork.GetMinMaxXY();

            SWEREF99Position minSwe = new SWEREF99Position(minmax[1], minmax[0]);
            SWEREF99Position maxSwe = new SWEREF99Position(minmax[3], minmax[2]);

            WGS84Position minWgs = minSwe.ToWGS84();
            WGS84Position maxWgs = maxSwe.ToWGS84();

            Console.WriteLine($"Min Lat: {minWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Min Lon: {minWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Max Lat: {maxWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Max Lon: {maxWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}");

            //Console.WriteLine(matSimSchedule.GetStopString("99999"));
            //Console.WriteLine(matSimSchedule.GetLineString("line1_r"));
            //Console.WriteLine(matSimSchedule.GetLineString("line10_r"));

            //Console.WriteLine(matSimNetwork.GetLinkString("100004_AB"));
            //Console.WriteLine(matSimNetwork.GetNodeString("tr_65905"));

            //Console.WriteLine(vehicleDefinition.GetVehicleTypeString("BUS"));
            //Console.WriteLine(vehicleDefinition.GetVehicleString("Veh144931"));
            //Console.WriteLine($"vehicle list count: {vehicleDefinition.vehicles.Count}");
        }



    }

}
