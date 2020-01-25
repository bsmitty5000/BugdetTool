using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  [Serializable()]
  public class Transaction
  {
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction() { }
    public Transaction(string description, decimal amount, DateTime date, AccountBase account)
    {
      Description = description;
      Amount = amount;
      Date = date;
    }
    public Transaction(Transaction t)
    {
      Description = t.Description;
      Amount = t.Amount;
      Date = t.Date;
    }
  }
}
