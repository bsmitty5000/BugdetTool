using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace BudgetToolLib
{
  public static class ListExtensions
  {
    public static int BinarySearchForMatch<T>(this IList<T> list,
     Func<T, int> comparer)
    {
      int min = 0;
      int max = list.Count - 1;

      while (min <= max)
      {
        int mid = (min + max) / 2;
        int comparison = comparer(list[mid]);
        if (comparison == 0)
        {
          return mid;
        }
        if (comparison < 0)
        {
          min = mid + 1;
        }
        else
        {
          max = mid - 1;
        }
      }
      return ~min;
    }
  }

  public static class AccountBaseFactory
  {
    public static AccountBase CopyAccountBase(AccountBase ab)
    {
      switch (ab.GetType().Name)
      {
        case "CheckingAccount":
          return new CheckingAccount(ab as CheckingAccount);
        case "CreditCard":
          return new CreditCard(ab as CreditCard);
        default:
          throw new ArgumentException("Unknown AccountBase type");
      }
    }
  }

  [Serializable()]
  public abstract class AccountBase
  {
    private decimal _startingAmount;
    protected List<Transaction> _transactions { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; private set; }
    public decimal CurrentBalance
    {
      get
      {
        return BalanceHistory.Last().Value;
      }
    }
    
    public AccountBase()
    { }

    public AccountBase(AccountBase account)
    {
      _startingAmount = account._startingAmount;
      StartingDate = account.StartingDate;
      _transactions = new List<Transaction>();
      foreach (var t in account._transactions)
      {
        _transactions.Add(new Transaction(t));
      }
      Name = account.Name;
    }

    public AccountBase(string name, decimal startingAmount, DateTime? startingDate = null)
    {
      StartingDate = startingDate ?? DateTime.MinValue;
      _transactions = new List<Transaction>();
      Name = name;
      _startingAmount = startingAmount;
    }
    public Dictionary<DateTime, decimal> BalanceHistory
    {
      get
      {
        Dictionary<DateTime, decimal> balanceHistory = new Dictionary<DateTime, decimal>() { { StartingDate, _startingAmount } };
        decimal lastVal = _startingAmount;

        //greater than starting date so transactions on starting date do not affect startingBalance
        foreach (var t in _transactions.Where(p => p.Date > StartingDate).OrderBy(p => p.Date).ToList())
        {
          lastVal += t.Amount;
          balanceHistory[t.Date] = lastVal;
        }

        return balanceHistory;
      }
    }

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);
    public IReadOnlyList<Transaction> GetTransactions()
    {
      return _transactions.AsReadOnly();
    }
    public bool Remove(Transaction t)
    {
      return _transactions.Remove(t);
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
