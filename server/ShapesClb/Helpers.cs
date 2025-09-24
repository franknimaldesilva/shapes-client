using Newtonsoft.Json;

namespace ShapesClb
{
    public class Helpers
    {
        public static Cls GetObject<Cls>(string list) where Cls : new()
        {
            if (list != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<Cls>(list);
                }
                catch (Exception exp)
                {
                    string msg = exp.Message;
                }
            }
            return new Cls();
        }
        public static string GetJson(object obj)
        {
            if (obj != null)
            {
                try
                {
                    return JsonConvert.SerializeObject(obj);
                }
                catch (Exception exp)
                {
                    string msg = exp.Message;
                }
            }
            return "";
        }
    }
}
