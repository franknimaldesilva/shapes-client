using IShapesClb;
using System.Text;
namespace ShapesClb
{
    public class Rectangle : IShape
    {
        public static string ShapeName
        {
            get { return "Rectangle"; }
        }

        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string[] parts = command.Split(' ');
            try
            {
                if (parts.Length == 13)
                {
                    // The radius is limited to an int value as it is expected to be a pixel count
                    long width = System.Convert.ToInt32(parts[7]);
                    long height = System.Convert.ToInt32(parts[parts.Length - 1]);
                   
                    result.Add("valid", true);
                    result.Add("width", width);
                    result.Add("height", height);
                    result.Add("Shape", "Rectangle");
                    result.Add("ShapeName", Rectangle.ShapeName);
             
                }

            }
            catch (Exception e)
            {
                result.Add("valid", false);
                result.Add("error", e.Message);
                result.Add("Shape", "Rectangle");
                result.Add("ShapeName", Rectangle.ShapeName);
            }
            return result;
        }
    }
}
