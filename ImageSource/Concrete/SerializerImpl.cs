using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ImageSource.Concrete
{
    public class SerializerImp : ISerializer
    {
        public string ToJson<T>(T source)
        {
            //TODO: Implement a Serialize method from Object to JSON string.
            string jsonString = JsonSerializer.Serialize(source);     
            return jsonString;
        }

        public T ToObject<T>(string source)
        {
            //TODO: Implement a Deserialize method from JSON string to Object.
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(source);
                //JsonSerializer.Deserialize<T>(source);
            return model;
        }
    }
}
