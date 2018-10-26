using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VergeClient.Models;

namespace VergeClient
{
    public class RpcClient : IRpcClient
    {
        private HttpClient _http;
        public RpcClient(string url, int port, string username, string password)
        {
            _http = new HttpClient();

            _http.BaseAddress = new Uri($"{url}:{port}");

            string credentials = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RpcResponse> SendRequestAsync(RpcRequest req, bool throw_on_error = true)
        {
            HttpResponseMessage response = await _http.PostAsync(_http.BaseAddress, new StringContent(req.ToJson()));
            string result = await response.Content.ReadAsStringAsync();

            RpcResponse res = new RpcResponse(result);
            if(throw_on_error && res.error != null)
            {
                throw new RpcException(res.error);
            }

            return res;
        }

        public async Task<NodeInfo> GetInfo(bool include_unconfirmed = false)
        {
            RpcRequest req = new RpcRequest(Methods.GetInfo, new List<object>() { include_unconfirmed });
            RpcResponse res = await SendRequestAsync(req);

            return JsonConvert.DeserializeObject<NodeInfo>(res.result);
        }

        public async Task<string> GetAccount(string address)
        {
            RpcRequest req = new RpcRequest(Methods.GetAccount, new List<object>() { address });
            RpcResponse res = await SendRequestAsync(req);

            return res.result;
        }

        public async Task<string> GetAccountAddress(string account)
        {
            RpcRequest req = new RpcRequest(Methods.GetAccountAddress, new List<object>() { account });
            RpcResponse res = await SendRequestAsync(req);

            return res.result;
        }

        public async Task<bool> CheckWallet()
        {
            RpcRequest req = new RpcRequest(Methods.CheckWallet);
            RpcResponse res = await SendRequestAsync(req);
            JObject result = JObject.Parse(res.result);
            return  result["wallet check passed"]?.Value<bool>() ?? false;
        }

        public async Task<string> EncryptWallet(string passphrase)
        {
            RpcRequest req = new RpcRequest(Methods.EncryptWallet, new List<object>() { passphrase });
            RpcResponse res = await SendRequestAsync(req);
            
            return res.result;
        }

        public async void WalletLock()
        {
            RpcRequest req = new RpcRequest(Methods.WalletLock, new List<object>());
            RpcResponse res = await SendRequestAsync(req);
        }

        public async void WalletPassphrase(string passphrase, int timeout = 30, bool mintonly = false)
        {
            RpcRequest req = new RpcRequest(Methods.WalletPassphrase, new List<object>() { passphrase, timeout, mintonly });
            RpcResponse res = await SendRequestAsync(req);
        }

        public async void WalletPassphraseChange(string oldpassphrase, string newpassphrase)
        {
            RpcRequest req = new RpcRequest(Methods.WalletPassphraseChange, new List<object>() { oldpassphrase, newpassphrase });
            RpcResponse res = await SendRequestAsync(req);
        }

        public async Task<string> SendFrom(string account, string address, double amount, int minconf = 1, string comment = null, string comment_to = null)
        {
            List<object> @params = new List<object>() { account, address, amount, minconf };
            if (comment != null) @params.Add(comment);
            if (comment_to != null) @params.Add(comment_to);

            RpcRequest req = new RpcRequest(Methods.SendFrom, @params);
            RpcResponse res = await SendRequestAsync(req);
            if (res.error != null) throw new RpcException(res.error);
            return res.result;
         }

        public async Task<double> GetBalance(string account = null, int minconf = 1)
        {
            List<object> @params = new List<object>();
            if (account != null)
            {
                @params.Add(account);
                @params.Add(minconf);
            }

            RpcRequest req = new RpcRequest(Methods.GetBalance, @params);
            RpcResponse res = await SendRequestAsync(req);

            return double.Parse(res.result);
        }

        public async Task<List<AccountBalance>> ListAccounts(int minconf = 1)
        {
            RpcRequest req = new RpcRequest(Methods.ListAccounts, new List<object>() { minconf });
            RpcResponse res = await SendRequestAsync(req);

            JObject result = JObject.Parse(res.result);
            List<AccountBalance> accounts = new List<AccountBalance>();
            foreach(var prop in result)
            {
                accounts.Add(new AccountBalance(prop.Key, prop.Value.ToObject<double>()));
            }
            return accounts;
        }

        public async Task<string> GetNewStealthAddress(string label = null)
        {
            List<object> @params = new List<object>();
            if (label != null) @params.Add(label);

            RpcRequest req = new RpcRequest(Methods.GetNewStealthAddress, @params);
            RpcResponse res = await SendRequestAsync(req);

            return res.result;
        }

        public async Task<string> GetNewAddress(string account = null)
        {
            List<object> @params = new List<object>();
            if (account != null) @params.Add(account);

            RpcRequest req = new RpcRequest(Methods.GetNewAddress, @params);
            RpcResponse res = await SendRequestAsync(req);

            return res.result;
        }
    }
}
