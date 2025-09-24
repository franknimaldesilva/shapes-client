using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public class Pentagon : EqualSidePolygon, IShape
    {
        public static string ShapeName
        {
            get { return "Pentagon"; }
        }

        public  Dictionary<string, object> GetShapeCoordinates(string command)
        { 
            Dictionary<string, object> result;           
            try
            {
                result = GetCoordinates(5, command);
                result.Add("ShapeName", Pentagon.ShapeName);
            }
            catch (Exception e)
            {
                result = new Dictionary<string, object>();
                result.Add("valid", false);
                result.Add("error", e.Message);              
                result.Add("ShapeName", Pentagon.ShapeName);
            }
            return result;
            
        }
    }
}
