using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public interface IAccountBase
  {
    string Name { get; }
    DateTime StartingDate { get; }
    decimal CurrentBalance { get; }
    decimal StartingBalance { get; }
    Dictionary<DateTime, decimal> BalanceHistory { get; }
    void NewDebitTransaction(Transaction transaction);
    void NewCreditTransaction(Transaction transaction);
    IReadOnlyList<Transaction> GetTransactions();
    bool RemoveTransaction(long transactionId);
    decimal GetBalance(DateTime date);
  }
}
