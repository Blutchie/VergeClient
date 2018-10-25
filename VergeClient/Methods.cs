using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient
{
    public static class Methods
    {
        public static readonly string GetInfo = "getinfo";
        public static readonly string GetAccount = "getaccount";
        public static readonly string GetAccountAddress = "getaccountaddress";
        public static readonly string CheckWallet = "checkwallet";
        public static readonly string EncryptWallet = "encryptwallet";
        public static readonly string WalletLock = "walletlock";
        public static readonly string WalletPassphrase = "walletpassphrase";
        public static readonly string WalletPassphraseChange = "walletpassphrasechange";
        public static readonly string SendFrom = "sendfrom";
        public static readonly string GetBalance = "getbalance";
        public static readonly string ListAccounts = "listaccounts";
        public static readonly string GetNewStealthAddress = "getnewstealthaddress";
        public static readonly string GetNewAddress = "getnewaddress";
    }
}

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