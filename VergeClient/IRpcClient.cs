using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VergeClient.Models;

namespace VergeClient
{
    public interface IRpcClient
    {
        Task<RpcResponse> SendRequestAsync(RpcRequest req, bool throw_on_error = true);
        Task<NodeInfo> GetInfo(bool include_unconfirmed = false);
        Task<string> GetAccount(string address);
        Task<string> GetAccountAddress(string account);
        Task<bool> CheckWallet();
        Task<string> EncryptWallet(string passphrase);
        void WalletLock();
        void WalletPassphrase(string passphrase, int timeout = 30, bool mintonly = false);
        void WalletPassphraseChange(string oldpassphrase, string newpassphrase);
        Task<string> SendFrom(string account, string address, double amount, int minconf = 1, string comment = null, string comment_to = null);
        Task<double> GetBalance(string account = null, int minconf = 1);
        Task<List<AccountBalance>> ListAccounts(int minconf = 1);
        Task<string> GetNewStealthAddress(string label = null);
        Task<string> GetNewAddress(string account = null);



        // Below the output of the help command (after implementing, the method will be removed from the comments)



        //addmultisigaddress<nrequired> <'["key","key"]'> [account]
        //backupwallet<destination>
        //createrawtransaction[{"txid":txid,"vout":n},...] {address:amount,...}
        //decoderawtransaction<hex string>
        //dumpprivkey<VERGEaddress>
        //getblock <hash> [txinfo]
        //getblockbynumber <number> [txinfo]
        //getblockcount
        //getblockhash <index>
        //getblocktemplate[params]
        //getcheckpoint
        //getconnectioncount
        //getdifficulty
        //getgenerate
        //gethashespersec
        //getmininginfo
        //getnewpubkey [account]
        //getpeerinfo
        //getrawblockbynumber<number>
        //getrawmempool
        //getrawtransaction<txid>[verbose = 0]
        //getreceivedbyaccount <account> [minconf=1]
        //getreceivedbyaddress <VERGEaddress> [minconf=1]
        //gettransaction <txid>
        //getwork[data]
        //getworkex [data, coinbase]
        //help [command]
        //importprivkey <VERGEprivkey> [label]
        //importstealthaddress <scan_secret> <spend_secret> [label]
        //keypoolrefill
        //listaddressgroupings
        //listreceivedbyaccount [minconf=1] [includeempty=false]
        //listreceivedbyaddress [minconf=1] [includeempty=false]
        //listsinceblock [blockhash] [target-confirmations]
        //liststealthaddresses [show_secrets=0]
        //listtransactions [account] [count=10] [from=0]
        //listunspent [minconf=1] [maxconf=9999999]  ["address",...]
        //makekeypair [prefix]
        //move <fromaccount> <toaccount> <amount> [minconf=1] [comment]
        //repairwallet
        //resendtx
        //reservebalance[< reserve > [amount]]
        //scanforalltxns [fromHeight]
        //scanforstealthtxns [fromHeight]
        //sendalert <message> <privatekey> <minver> <maxver> <priority> <id> [cancelupto]
        //sendmany <fromaccount> { address: amount,...}[minconf=1][comment]
        //sendrawtransaction<hex string>
        //sendtoaddress<VERGEaddress> <amount> [narration] [comment] [comment-to]
        //sendtostealthaddress <stealth_address> <amount> [narration] [comment] [comment-to]
        //setaccount <VERGEaddress> <account>
        //setgenerate<generate>[genproclimit]
        //settxfee <amount>
        //signmessage<VERGEaddress> <message>
        //signrawtransaction<hex string>[{ "txid":txid,"vout":n,"scriptPubKey":hex},...] [<privatekey1>,...][sighashtype="ALL"]
        //smsgaddkey<address> <pubkey>
        //smsgbuckets[stats | dump]
        //smsgdisable
        //smsgenable
        //smsggetpubkey<address>
        //smsginbox[all | unread | clear]
        //smsglocalkeys [whitelist|all|wallet|recv <+/-> <address>|anon <+/-> <address>]
        //smsgoptions [list|set <optname> <value>]
        //smsgoutbox [all|clear]
        //smsgscanbuckets
        //smsgscanchain
        //smsgsend<addrFrom> <addrTo> <message>
        //smsgsendanon<addrTo> <message>
        //stop<detach>
        //submitblock <hex data> [optional-params-obj]
        //validateaddress <VERGEaddress>
        //validatepubkey <VERGEpubkey>
        //verifymessage<VERGEaddress> <signature> <message>

    }
}
