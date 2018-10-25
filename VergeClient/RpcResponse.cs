using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient
{
    public class RpcResponse
    {
        public string result;
        public RpcError error;
        public string id;
        
        public RpcResponse(string json)
        {
            JObject raw = JObject.Parse(json);
            result = raw["result"].ToString();
            error = raw["error"].ToObject<RpcError>();
            id = raw["id"].ToObject<string>();
        }
        public RpcResponse(string result, RpcError error = null, string id = null)
        {
            this.result = result;
            this.error = error;
            this.id = id;
        }
    }
}
