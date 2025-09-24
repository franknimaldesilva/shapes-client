using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShapesClb
{
    public interface IComputeShape
    {
        //return JSON string
        string GetShapeCoordinates(string command);
    }
}
