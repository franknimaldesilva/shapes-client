using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public class Square : EqualSidePolygon, IShape
    {
        public static string ShapeName
        {
            get { return "Square"; }
        }
        /*
        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string[] parts = command.Split(' ');
            try
            {
                long length = System.Convert.ToInt32(parts[parts.Length - 1]);
                result.Add("valid", true);
                result.Add("length", length);
                result.Add("Shape", GetType().Name);
                result.Add("ShapeName", Square.ShapeName);

            }
            catch (Exception e)
            {
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("Shape", GetType().Name);
                result.Add("ShapeName", Square.ShapeName);
            }
            return result;
        }
        */
        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result;
            try
            {
                result = GetCoordinates(4, command);
                result.Add("ShapeName", Square.ShapeName);
            }
            catch (Exception e)
            {
                result = new Dictionary<string, object>();
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("ShapeName", Square.ShapeName);
            }
            return result;

        }
    }
}
