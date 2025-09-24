using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
    public abstract class EqualSidePolygon 
    {
        
        public Dictionary<string, object> GetCoordinates(int n,string command)
        {

            Dictionary<string, object> result;
            string[] parts = command.Split(' ');
            try
            {
                // The side length is limited to an int value as it is expected to be a pixel count
                long side = System.Convert.ToInt32(parts[parts.Length - 1]);
                double midAngle = 2 * Math.PI / n;
                double radius = side/ Math.Sin(midAngle/2);
                StringBuilder sb = new StringBuilder();
                for(int i=0;i<n;++i)
                {
                    if(i > 0)
                    {
                        sb.Append(" ");
                    }
                    long x = (long)(radius*Math.Sin(i * midAngle));
                    long y = (long)(radius * Math.Cos(i * midAngle));
                    sb.Append(x.ToString() + "," + y.ToString());
                }
                result = new Dictionary<string, object>();
                result.Add("valid", true);
                result.Add("radius", radius);
                result.Add("Shape", "Polygon");
                result.Add("points", sb.ToString());

            }
            catch (Exception e)
            {
                result = new Dictionary<string, object>();
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("Shape", "Polygon");
              
            }
            return result;
            
        }
    }
}
