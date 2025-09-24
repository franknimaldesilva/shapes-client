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
            get { return "Not Found";  }
                    
        }

        public Dictionary<string, object> GetShapeCoordinates(string command)
        {
            throw new NotImplementedException();
        }
    }
}
