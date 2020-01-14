using System;
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

  public class BalanceEntry
  {
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    public BalanceEntry() { }
    public BalanceEntry(BalanceEntry be)
    {
      Date = be.Date;
      Amount = be.Amount;
    }
  }

  public class Transaction
  {
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction() { }
    public Transaction(Transaction t)
    {
      Description = string.Copy(t.Description);
      Amount = t.Amount;
      Date = t.Date;
    }
  }

  public abstract class AccountBase
  {
    public List<BalanceEntry> BalanceHistory { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string Name { get; set; }
    public decimal CurrentBalance
    {
      get
      {
        return BalanceHistory.Last().Amount;
      }
    }
    
    public AccountBase()
    { }

    public AccountBase(AccountBase account)
    {
      BalanceHistory = new List<BalanceEntry>();
      foreach (var be in account.BalanceHistory)
      {
        BalanceHistory.Add(new BalanceEntry(be));
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
      DateTime _startingDate = startingDate ?? DateTime.MinValue;

      //Make sure starting entry is the very first
      BalanceEntry startingEntry = new BalanceEntry() { Date = _startingDate, Amount = startingAmount };
      BalanceHistory = new List<BalanceEntry>() { startingEntry };
      Transactions = new List<Transaction>();
      Name = name;
    }

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);

    public decimal GetCurrentBalance(DateTime date)
    {
      BalanceEntry latestEntry = BalanceHistory[0];
      foreach (var entry in BalanceHistory)
      {
        if (entry.Date > date)
          break;
        latestEntry = entry;
      }

      return latestEntry.Amount;
    }

    protected void ProcessNewTransaction(Transaction transaction)
    {
      //insert the transaction. Transactions is ordered by date
      int insertIndex = Transactions.BinarySearchForMatch<Transaction>((x) => x.Date.CompareTo(transaction.Date));
      if (insertIndex < 0) insertIndex = ~insertIndex;
      Transactions.Insert(insertIndex, transaction);

      if(transaction.Date < BalanceHistory[0].Date)
      {
        // going to assume this means logging old transactions that are already reflected in the BalanceHistory
        return;
      }

      insertIndex = BalanceHistory.BinarySearchForMatch<BalanceEntry>((x) => x.Date.CompareTo(transaction.Date));
      if (insertIndex < 0)
      {
        insertIndex = ~insertIndex;
        // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
        BalanceHistory.Insert(insertIndex, new BalanceEntry() { Date = transaction.Date, Amount = (BalanceHistory[insertIndex - 1].Amount + transaction.Amount) });

        // after the new entry update all remaining entries
        unravelAndAdjust(insertIndex + 1, transaction.Amount);
      }
      else
      {
        unravelAndAdjust(insertIndex, transaction.Amount);
      }

      return;
    }

    private void unravelAndAdjust(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount += amount;
      }
    }

  }
}
