using IShapesClb;


namespace ShapesClb
{
  public class Polygon : EqualSidePolygon, IShape
  {
    public static string ShapeName
    {
      get { return "Polygon"; }
    }

    public Dictionary<string, object> GetShapeCoordinates(string command)
    {
      Dictionary<string, object> result;
      try
      {
        string[] parts = command.Split(' ');
        int n = System.Convert.ToInt32(parts[4]);
        result = GetCoordinates(n, command);
        result.Add("ShapeName", Polygon.ShapeName);
      }
      catch (Exception e)
      {
        result = new Dictionary<string, object>();
        result.Add("valid", false);
        result.Add("error", e.Message);
        result.Add("ShapeName", Polygon.ShapeName);
      }
      return result;

    }

  }
}
