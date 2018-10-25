using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient
{
    public class RpcException : Exception
    {
        public RpcError RpcError { get; private set; }
        public RpcException(RpcError rpcerror) : base($"RpcError: code [{rpcerror.code}], message [{rpcerror.message}]")
        {
            RpcError = rpcerror;
        }
    }
}
