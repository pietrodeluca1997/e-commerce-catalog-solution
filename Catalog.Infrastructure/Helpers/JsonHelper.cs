using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Helpers
{
    public class JsonHelper
    {
        public static string ToJson<TObject>(TObject obj) => JsonSerializer.Serialize(obj);
        public static TObject FromJson<TObject>(string json) => JsonSerializer.Deserialize<TObject>(json);
        public static TTarget SerializeAndDeserialize<TOrigin, TTarget>(TOrigin obj)
        {
            return FromJson<TTarget>(ToJson(obj));
        }
    }
}
