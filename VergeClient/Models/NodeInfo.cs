using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient.Models
{
    public class NodeInfo
    {
        public string version;
        public int protocolversion;
        public int walletversion;
        public double balance;
        public double newmint;
        public double stake;
        public int blocks;
        public double moneysupply;
        public int connections;
        public string proxy;
        public string ip;
        public int pow_algo_id;
        public string pow_algo;
        public double difficulty;
        public double difficulty_x17;
        public double difficulty_scrypt;
        public double difficulty_groestl;
        public double difficulty_lyra2re;
        public double difficulty_blake;
        public bool testnet;
        public int keypoololdest;
        public int keypoolsize;
        public double paytxfee;
        public string errors;
    }
}
