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

  public abstract class AccountBase
  {
    public DateTime StartingDate { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string Name { get; set; }
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
      StartingDate = account.StartingDate;
      foreach (var be in account.BalanceHistory)
      {
        BalanceHistory.Add(be.Key, be.Value);
      }
      Transactions = new List<Transaction>();
      foreach (var t in account.Transactions)
      {
        Transactions.Add(new Transaction(t));
      }
      Name = account.Name;
    }

    public AccountBase(string name, decimal startingAmount, DateTime? startingDate = null)
    {
      StartingDate = startingDate ?? DateTime.MinValue;
      Transactions = new List<Transaction>();
      Name = name;
    }
    public Dictionary<DateTime, decimal> BalanceHistory
    {
      get
      {
        Dictionary<DateTime, decimal> balanceHistory = new Dictionary<DateTime, decimal>();
        foreach (var t in Transactions.OrderBy(p => p.Date).ToList())
        {
          if(balanceHistory.ContainsKey(t.Date))
          {
            balanceHistory[t.Date] += t.Amount;
          }
          else
          {
            balanceHistory.Add(t.Date, t.Amount);
          }
        }

        return balanceHistory;
      }
    }

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);
    public abstract void UpdateInitialBalance(decimal amount);

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
