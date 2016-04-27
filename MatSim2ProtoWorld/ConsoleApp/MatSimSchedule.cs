using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp
{
    [XmlRoot("transitSchedule")]
    public class MatSimSchedule
    {
        [XmlArray("transitStops")]
        [XmlArrayItem("stopFacility")]
        public List<MatSimStop> stops;

        [XmlElement("transitLine")]
        public List<MatSimLine> lines;

        public static MatSimSchedule Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(MatSimSchedule));
                return serializer.Deserialize(stream) as MatSimSchedule;
            }
        }

        public void Save(string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(MatSimSchedule));
                serializer.Serialize(stream, this);
            }
        }

        public float[] GetMinMaxXY()
        {
            return MatSimUtils.GetMinMaxXY(stops);
        }

        public string GetStopString(string id)
        {
            return stops.Find(s => s.id == id).ToString();
        }

        public string GetLineString(string id)
        {
            return lines.Find(line => line.id == id).ToString();
        }
    }

    public class MatSimStop : MatSimNode
    {
        [XmlAttribute]
        public string name;

        [XmlAttribute]
        public bool isBlocking;

        public override string ToString()
        {
            return $"{base.ToString()}, name: {name}, block?: {isBlocking}";
        }


    }

    public class MatSimLine
    {
        [XmlAttribute]
        public string id;

        [XmlElement("transitRoute")]
        public List<MatSimRoute> routes;

        public override string ToString()
        {
            return $"id: {id} {routes[0].stops[0]}";
        }
    }

    public class MatSimRoute
    {
        [XmlAttribute]
        public string id;

        [XmlElement("transportMode")]
        public string mode;

        [XmlArray("routeProfile")]
        [XmlArrayItem("stop")]
        public List<MatSimProfileStop> stops;

        public override string ToString()
        {
            return $"id: {id}, mode: {mode}";
        }
    }

    public class MatSimProfileStop
    {
        [XmlAttribute]
        public string refId;

        [XmlAttribute]
        public string departureOffset;

        [XmlAttribute]
        public string arrivalOffset;

        [XmlAttribute]
        public bool awaitDeparture;


        public override string ToString()
        {
            return $"refId: {refId}, dOff: {departureOffset}, aOff: {arrivalOffset}, await: {awaitDeparture}";
        }
    }


}
