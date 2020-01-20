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
    public SortedList<DateTime, decimal> BalanceHistory { get; set; }
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
      BalanceHistory = new SortedList<DateTime, decimal>();
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
      BalanceHistory = new SortedList<DateTime, decimal>() { { StartingDate, startingAmount } };
      Transactions = new List<Transaction>();
      Name = name;
    }

    public abstract void NewDebitTransaction(Transaction transaction);
    public abstract void NewCreditTransaction(Transaction transaction);
    public abstract void UpdateInitialBalance(decimal amount);

    public decimal GetBalance(DateTime date)
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
      Transactions.Add(transaction);

      updateBalanceHistory(transaction.Amount, transaction.Date);
    }

    //Use to 'edit' transactions
    public void ReplaceTransaction(Transaction tToReplace, Transaction tToReplaceWith)
    {
      if(tToReplace.Date != tToReplaceWith.Date)
      {
        throw new ArgumentException("This function only works if Dates are the same.");
      }

      decimal balanceDiff = tToReplaceWith.Amount - tToReplace.Amount;
      DateTime date = tToReplaceWith.Date;

      Transactions.Remove(tToReplace);
      Transactions.Add(tToReplaceWith);

      updateBalanceHistory(balanceDiff, date);
    }

    public void RemoveTransaction(Transaction tToRemove)
    {

      Transactions.Remove(tToRemove);

      updateBalanceHistory(-1 * tToRemove.Amount, tToRemove.Date);
    }

    private void updateBalanceHistory(decimal amount, DateTime date)
    {

      if (date <= StartingDate)
      {
        // going to assume this means logging old transactions that are already reflected in the BalanceHistory
        // including transactions that happened on the startingdate
        return;
      }

      if (BalanceHistory.ContainsKey(date))
      {
        BalanceHistory[date] += amount;
      }
      else
      {
        BalanceHistory.Add(date, amount);
        //carry over previous date's balance
        BalanceHistory[date] += BalanceHistory.Values[BalanceHistory.IndexOfKey(date) - 1];
      }

      var dates = BalanceHistory.Keys.Where(d => d > date).ToList();

      //this seems like it's not the accepted way of doing things since i was forced to
      //add ToList above, otherwise if this foreach loop ever does anything, ie if there's
      //an old transaction added, an exception is thrown because the iterator was modified after
      //creation
      foreach (var key in dates)
      {
        BalanceHistory[key] += amount;
      }
    }
  }
}
