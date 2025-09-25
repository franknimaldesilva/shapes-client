using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
  public class Circle : IShape
  {
    public static string ShapeName
    {
      get { return "Circle"; }
    }
    public Dictionary<string, object> GetShapeCoordinates(string command)
    {
      Dictionary<string, object> result = new Dictionary<string, object>();
      string[] parts = command.Split(' ');
      try
      {
        // The radius is limited to an int value as it is expected to be a pixel count
        long radius = System.Convert.ToInt32(parts[parts.Length - 1]);
        result.Add("valid", true);
        result.Add("radius", radius);
        result.Add("Shape", GetType().Name);
        result.Add("ShapeName", Circle.ShapeName);

      }
      catch (Exception e)
      {
        result.Add("valid", false);
        result.Add("error", e.Message);
        result.Add("Shape", GetType().Name);
        result.Add("ShapeName", Circle.ShapeName);
      }
      return result;
    }
  }
}
