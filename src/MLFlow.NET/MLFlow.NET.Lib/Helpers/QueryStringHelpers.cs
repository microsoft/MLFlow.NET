using System.Linq;
using System.Web;

namespace MLFlow.NET.Lib.Helpers
{
    public static class QueryStringHelpers
    {
        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }

   
}
