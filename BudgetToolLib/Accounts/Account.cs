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
        case "SoftBill":
          return new SoftBill(ab as SoftBill);
        case "CheckingAccount":
          return new CheckingAccount(ab as CheckingAccount);
        case "CreditCard":
          return new CreditCard(ab as CreditCard);
        default:
          throw new ArgumentException("Unknown AccountBase type");
      }
    }
  }

  public class Transaction
  {
    public string Description { get; set; }
    public Dictionary<string, decimal> SoftGroupSplit { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction() { }
    public Transaction(Transaction t)
    {
      Description = string.Copy(t.Description);
      Amount = t.Amount;
      Date = t.Date;
      SoftGroupSplit = new Dictionary<string, decimal>();
      foreach (var kvp in t.SoftGroupSplit)
      {
        SoftGroupSplit.Add(kvp.Key, kvp.Value);
      }
    }
  }

  public abstract class AccountBase
  {
    public SortedList<DateTime, decimal> BalanceHistory { get; set; }
    public SortedList<DateTime, Transaction> Transactions { get; set; }
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
      BalanceHistory = new SortedList<DateTime, decimal>();
      foreach (var be in account.BalanceHistory)
      {
        BalanceHistory.Add(be.Key, be.Value);
      }
      Transactions = new SortedList<DateTime, Transaction>();
      foreach (var t in account.Transactions)
      {
        Transactions.Add(t.Key, new Transaction(t.Value));
      }
      Name = account.Name;
    }

    public AccountBase(string name, decimal startingAmount, DateTime? startingDate = null)
    {
      DateTime _startingDate = startingDate ?? DateTime.MinValue;

      BalanceHistory = new SortedList<DateTime, decimal>() { { _startingDate, startingAmount } };
      Transactions = new SortedList<DateTime, Transaction>();
      Name = name;
    }

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);

    public decimal GetCurrentBalance(DateTime date)
    {
      decimal latestEntry = BalanceHistory.First().Value;
      foreach (var entry in BalanceHistory)
      {
        if (entry.Key > date)
          break;
        latestEntry = entry.Value;
      }

      return latestEntry;
    }

    protected void ProcessNewTransaction(Transaction transaction)
    {
      //insert the transaction. Transactions is ordered by date
      Transactions.Add(transaction.Date, transaction);

      if(transaction.Date < BalanceHistory.First().Key)
      {
        // going to assume this means logging old transactions that are already reflected in the BalanceHistory
        return;
      }

      int index;
      if (BalanceHistory.ContainsKey(transaction.Date))
      {
        BalanceHistory[transaction.Date] += transaction.Amount;
        index = BalanceHistory.IndexOfKey(transaction.Date);
      }
      else
      {
        BalanceHistory.Add(transaction.Date, transaction.Amount);
        index = BalanceHistory.IndexOfKey(transaction.Date);
        BalanceHistory.Values[index] += BalanceHistory.Values[index - 1];
      }
      unravelAndAdjust(index + 1, transaction.Amount);

      return;
    }

    private void unravelAndAdjust(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory.Values[j] += amount;
      }
    }

  }
}
