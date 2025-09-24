using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public class ScaleneTriangle : IShape
    {
        public static string ShapeName
        {
            get { return "Scalene Triangle"; }
        }

        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string[] parts = command.Split(' ');
            try
            {
                if (parts.Length == 23)
                {
                    // The radius is limited to an int value as it is expected to be a pixel count
                    long sideA = System.Convert.ToInt32(parts[8]);
                    long sideB = System.Convert.ToInt32(parts[14]);
                    long angleB = System.Convert.ToInt32(parts[19]);
                    double angleRadB = angleB * 2 * Math.PI / 360;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("0,0 " + sideA.ToString() + ",0 ");

                    sb.Append((sideB * Math.Cos(angleRadB)).ToString() + "," + (sideB * Math.Sin(angleRadB)).ToString());
                    result.Add("valid", true);
                    result.Add("radius", sideA);
                    result.Add("Shape", "Polygon");
                    result.Add("ShapeName", ScaleneTriangle.ShapeName);
                    result.Add("points", sb.ToString());
                }

            }
            catch (Exception e)
            {
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("Shape", "Polygon");
                result.Add("ShapeName", ScaleneTriangle.ShapeName);
            }
            return result;
        }
    }
}
