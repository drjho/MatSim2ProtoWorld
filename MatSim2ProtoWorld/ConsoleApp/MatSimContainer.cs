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

            var networkMinMax = matSimNetwork.GetMinMaxXY();

            SWEREF99Position minSwe = new SWEREF99Position(networkMinMax[1], networkMinMax[0]);
            SWEREF99Position maxSwe = new SWEREF99Position(networkMinMax[3], networkMinMax[2]);

            WGS84Position netMinWgs = minSwe.ToWGS84();
            WGS84Position netMaxWgs = maxSwe.ToWGS84();

            Console.WriteLine($"Min Lat: {netMinWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Min Lon: {netMinWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Max Lat: {netMaxWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}");
            Console.WriteLine($"Max Lon: {netMaxWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}");

            var scheduleMinMax = matSimSchedule.GetMinMaxXY();

            minSwe = new SWEREF99Position(scheduleMinMax[1], scheduleMinMax[0]);
            maxSwe = new SWEREF99Position(scheduleMinMax[3], scheduleMinMax[2]);

            WGS84Position schMinWgs = minSwe.ToWGS84();
            WGS84Position schMaxWgs = maxSwe.ToWGS84();

            Console.WriteLine($"Min Lat: {schMinWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}, {scheduleMinMax[1]}");
            Console.WriteLine($"Min Lat: {schMinWgs.Latitude}");

            Console.WriteLine($"Min Lon: {schMinWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}, {scheduleMinMax[0]}");
            Console.WriteLine($"Max Lat: {schMaxWgs.LatitudeToString(WGS84Position.WGS84Format.Degrees)}, {scheduleMinMax[3]}");
            Console.WriteLine($"Max Lon: {schMaxWgs.LongitudeToString(WGS84Position.WGS84Format.Degrees)}, {scheduleMinMax[2]}");


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
