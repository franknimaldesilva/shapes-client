using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public class EquilateralTriangle : EqualSidePolygon, IShape
    {
        public static string ShapeName
        {
            get { return "Equilateral Triangle"; }
        }

        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result;
            try
            {
                result = GetCoordinates(3, command);
                result.Add("ShapeName", EquilateralTriangle.ShapeName);
            }
            catch (Exception e)
            {
                result = new Dictionary<string, object>();
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("ShapeName", EquilateralTriangle.ShapeName);
            }
            return result;

        }
    }
}
