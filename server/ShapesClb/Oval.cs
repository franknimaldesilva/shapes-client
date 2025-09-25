using IShapesClb;


namespace ShapesClb
{
  public class Oval : IShape
  {
    public static string ShapeName
    {
      get { return "Oval"; }
    }
    public Dictionary<string, object> GetShapeCoordinates(string command)
    {
      Dictionary<string, object> result = new Dictionary<string, object>();
      string[] parts = command.Split(' ');
      try
      {
        if (parts.Length == 15)
        {
          // The radius is limited to an int value as it is expected to be a pixel count
          long rx = System.Convert.ToInt32(parts[8]);
          long ry = System.Convert.ToInt32(parts[parts.Length - 1]);
          result.Add("valid", true);
          result.Add("rx", rx);
          result.Add("ry", ry);
          result.Add("Shape", "Oval");
          result.Add("ShapeName", Rectangle.ShapeName);
        }
      }
      catch (Exception e)
      {
        result.Add("valid", false);
        result.Add("error", e.Message);
        result.Add("Shape", "Oval");
        result.Add("ShapeName", Rectangle.ShapeName);
      }
      return result;
    }
  }
}
