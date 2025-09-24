using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public class Hexagon : EqualSidePolygon, IShape
    {
        public static string ShapeName
        {
            get { return "Hexagon"; }
        }

        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result;
            try
            {
                result = GetCoordinates(6, command);
                result.Add("ShapeName", Hexagon.ShapeName);
            }
            catch (Exception e)
            {
                result = new Dictionary<string, object>();
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("ShapeName", Hexagon.ShapeName);
            }
            return result;

        }
    }
}
