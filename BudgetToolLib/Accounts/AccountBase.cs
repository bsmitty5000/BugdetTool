using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace BudgetToolLib
{
  public static class AccountBaseFactory
  {
    //public static AccountBase CopyAccountBase(IAccountBase ab)
    //{
    //  switch (ab.GetType().Name)
    //  {
    //    case "CheckingAccount":
    //      return new CheckingAccount(ab as CheckingAccount);
    //    case "CreditCard":
    //      return new CreditCard(ab as CreditCard);
    //    default:
    //      throw new ArgumentException("Unknown AccountBase type");
    //  }
    //}
  }

  [Serializable()]
  public abstract class AccountBase : IAccountBase
  {
    protected List<Transaction> _transactions;

    #region Constructors
    public AccountBase()
    { }
    //public AccountBase(AccountBase account)
    //{
    //  StartingAmount = account.StartingAmount;
    //  StartingDate = account.StartingDate;
    //  _transactions = new List<Transaction>();
    //  foreach (var t in account._transactions)
    //  {
    //    _transactions.Add(new Transaction(t));
    //  }
    //  Name = account.Name;
    //}

    public AccountBase(string name, decimal startingBalance, DateTime? startingDate = null)
    {
      StartingDate = startingDate ?? DateTime.MinValue;
      _transactions = new List<Transaction>();
      Name = name;
      StartingBalance = startingBalance;
    }
    #endregion

    #region Properties
    public string Name { get; set; }
    public DateTime StartingDate { get; private set; }
    public decimal CurrentBalance
    {
      get
      {
        return BalanceHistory.Last().Value;
      }
    }
    public Dictionary<DateTime, decimal> BalanceHistory
    {
      get
      {
        Dictionary<DateTime, decimal> balanceHistory = new Dictionary<DateTime, decimal>() { { StartingDate, StartingBalance } };
        decimal lastVal = StartingBalance;

        //greater than starting date so transactions on starting date do not affect startingBalance
        foreach (var t in _transactions.Where(p => p.Date > StartingDate).OrderBy(p => p.Date).ToList())
        {
          lastVal += t.Amount;
          balanceHistory[t.Date] = lastVal;
        }

        return balanceHistory;
      }
    }

    public decimal StartingBalance { get; private set; }
    #endregion

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);
    public IReadOnlyList<Transaction> GetTransactions()
    {
      return _transactions.AsReadOnly();
    }
    public bool RemoveTransaction(long transactionId)
    {
      Transaction transaction = null;
      foreach (var t in _transactions)
      {
        if(t.TransactionId == transactionId)
        {
          transaction = t;
          break;
        }
      }

      if(transaction != null)
      {
        return _transactions.Remove(transaction);
      }
      else
      {
        return false;
      }
    }
    public decimal GetBalance(DateTime date)
    {
      var balanceHistory = BalanceHistory;
      decimal latestEntry = balanceHistory.First().Value;
      foreach (var entry in balanceHistory)
      {
        if (entry.Key > date)
          break;
        latestEntry = entry.Value;
      }

      return latestEntry;
    }
  }
}
