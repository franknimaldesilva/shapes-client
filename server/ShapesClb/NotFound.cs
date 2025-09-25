using IShapesClb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesClb
{
  public class NotFound : IShape
  {
    public static string ShapeName
    {
      get { return "Not Found"; }

    }
    public Dictionary<string, object> GetShapeCoordinates(string command)
    {
      Dictionary<string, object> result = new Dictionary<string, object>();
      result.Add("valid", false);
      result.Add("error", "Invalid shape");
      result.Add("ShapeName", NotFound.ShapeName);
      return result;
    }
  }
}
