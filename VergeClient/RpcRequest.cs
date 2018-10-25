using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient
{
    public class RpcRequest
    {
        public string method;
        public List<object> @params;
        public object id;
        public RpcRequest(string method, List<object> @params = null, object id = null)
        {
            this.method = method;
            this.@params = @params ?? new List<object>();
            this.id = id;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
