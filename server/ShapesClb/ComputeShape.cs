using IShapesClb;
using System.Reflection;
using System.Reflection.Metadata;
namespace ShapesClb
{
    public class ComputeShape : IComputeShape
    {
        
        private bool ConatainsValue(string command, string shape)
        {
            return command.Trim().ToLower().Contains(shape.ToLower());
        }
        private Type GetShape(string command)
        {         
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type[] allTypes = currentAssembly.GetTypes();
            foreach (Type type in allTypes)
            {
                if (type.IsClass && type.IsPublic && type.GetInterfaces().Contains(typeof(IShape)))
                {
                    PropertyInfo publicPropertyInfo = type.GetProperty("ShapeName", BindingFlags.Public | BindingFlags.Static);
                    if (publicPropertyInfo != null)
                    {
                        string shapename = (string)publicPropertyInfo.GetValue(null);
                        if (!string.IsNullOrEmpty(shapename) && ConatainsValue(command, shapename))
                            return type;
                    }
                }
            }
            return typeof(NotFound);
        }
        public string GetShapeCoordinates(string command)
        {
           return  Helpers.GetJson(((IShape)Activator.CreateInstance(GetShape(command))).GetShapeCoordinates(command));          
        }
    }
}
