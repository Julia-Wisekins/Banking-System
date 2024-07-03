using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    /// <summary>
    /// Options from the menu on what the user can do
    /// </summary>
    public enum Event
    {
        AddAccount,
        DepositMoney,
        WithdrawMoney,
        DisplayAccountDetails,
        DisplayAccountTransactions,
        Exit,
    }
}
