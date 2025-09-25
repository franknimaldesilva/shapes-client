using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
  public class IsoscelesTriangle : IShape
  {
    public static string ShapeName
    {
      get { return "Isosceles Triangle"; }
    }
    public Dictionary<string, object> GetShapeCoordinates(string command)
    {
      Dictionary<string, object> result = new Dictionary<string, object>();
      string[] parts = command.Split(' ');
      try
      {
        if (parts.Length == 14)
        {
          // The radius is limited to an int value as it is expected to be a pixel count
          long width = System.Convert.ToInt32(parts[parts.Length - 1]);
          long height = System.Convert.ToInt32(parts[8]);
          StringBuilder sb = new StringBuilder();
          sb.Append("0,0 " + width.ToString() + ",0 ");
          sb.Append((width / 2).ToString() + "," + height);
          result.Add("valid", true);
          result.Add("radius", height);
          result.Add("Shape", "Polygon");
          result.Add("ShapeName", IsoscelesTriangle.ShapeName);
          result.Add("points", sb.ToString());
        }
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
