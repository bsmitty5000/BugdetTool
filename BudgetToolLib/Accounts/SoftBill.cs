using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class SoftBill : AccountBase
  {
    public SoftBill()
    {
    }

    public SoftBill(string name, decimal startingAmount, DateTime? startingDate = null) : base(name, startingAmount, startingDate)
    {
    }

    public SoftBill(SoftBill sb) : base(sb)
    {
    }

    public override void NewDebitTransaction(Transaction transaction)
    {
      if (transaction.Amount < 0)
      {
        throw new ArgumentException("Transaction amount should be positive. Use Debit vs Credit");
      }
      transaction.Amount = -1 * transaction.Amount;
      ProcessNewTransaction(transaction);
    }

    public override void NewCreditTransaction(Transaction transaction)
    {
      if (transaction.Amount < 0)
      {
        throw new ArgumentException("Transaction amount should be positive. Use Debit vs Credit");
      }
      ProcessNewTransaction(transaction);
    }
  }
}
