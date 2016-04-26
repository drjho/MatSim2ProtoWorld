using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp
{
    [XmlRoot("network")]
    public class MatSimNetwork
    {
        [XmlArrayItem("node")]
        public List<MatSimNode> nodes;

        [XmlArrayItem("link")]
        public List<MatSimLinks> links;

        public static MatSimNetwork Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(MatSimNetwork));
                return serializer.Deserialize(stream) as MatSimNetwork;
            }
        }

        public void Save(string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(MatSimNetwork));
                serializer.Serialize(stream, this);
            }
        }

        /// <summary>
        /// minx, miny, maxx, maxy.
        /// </summary>
        /// <returns></returns>
        public float[] GetMinMaxXY()
        {
            var minmax = new float[4] { float.MaxValue, float.MaxValue, float.MinValue, float.MinValue };
            foreach (var node in nodes)
            {
                minmax[0] = (node.x < minmax[0]) ? node.x : minmax[0];
                minmax[1] = (node.y < minmax[1]) ? node.y : minmax[1];
                minmax[2] = (node.x > minmax[2]) ? node.x : minmax[2];
                minmax[3] = (node.y > minmax[3]) ? node.y : minmax[3];
            }

            return minmax;
        }

        public string GetNodeString(string id)
        {
            return nodes.Find(node => node.id == id).ToString();
        }

        public string GetLinkString(string id)
        {
            return links.Find(link => link.id == id).ToString();

        }
    }

    public class MatSimLinks
    {
        [XmlAttribute]
        public string id;

        [XmlAttribute]
        public string from;

        [XmlAttribute]
        public string to;

        [XmlAttribute]
        public string modes;

        public override string ToString()
        {
            return $"{id}: {from}->{to}; {modes}";
        }
    }

    public class MatSimNode
    {
        [XmlAttribute]
        public string id;

        [XmlAttribute]
        public float x;

        [XmlAttribute]
        public float y;

        public override string ToString()
        {
            return $"{id}: {x}, {y}.";
        }
    }
}
