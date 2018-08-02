using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverterTest.Utils
{
    public static class JsonBase<T> where T : BaseData<T>
    {
        public static List<T> ReturnResultsList(string json)
        {
            var returnData = JsonConvert.DeserializeObject<BaseData<T>>(json);
            return returnData.data;
        }
        public static string ReturnMetaData(string json)
        {
            var returnData = JsonConvert.DeserializeObject<BaseData<T>>(json);
            return returnData.metadata;
        }
    }
    public class BaseData<T> where T : class
    {

        public string metadata { get; set; }
        public List<T> data { get; set; }
    }
    public class SomeObjectTHatUwant : BaseData<SomeObjectTHatUwant>
    {
        public string category { get; set; }/// property for my case
        public string quantity { get; set; }

    }
}
