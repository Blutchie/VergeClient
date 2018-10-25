using System;
using System.Collections.Generic;
using System.Text;

namespace VergeClient.Models
{
    public class AccountBalance
    {
        public string Account;
        public double Balance;

        public AccountBalance(string account, double balance)
        {
            Account = account;
            Balance = balance;
        }
    }
}
