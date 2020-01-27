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
    public long TransactionId { get; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Transaction() 
    {
      TransactionId = long.Parse(DateTime.Now.Ticks.ToString());
    }
    public Transaction(string description, decimal amount, DateTime date)
    {
      Description = description;
      Amount = amount;
      Date = date;
      TransactionId = long.Parse(DateTime.Now.Ticks.ToString());
    }
    //public Transaction(Transaction t)
    //{
    //  Description = t.Description;
    //  Amount = t.Amount;
    //  Date = t.Date;
    //}
  }
}
