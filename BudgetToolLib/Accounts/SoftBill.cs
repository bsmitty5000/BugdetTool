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
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }

    public SoftBill(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }

    public SoftBill(SoftBill sb) : base(sb)
    {
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }

  }
}
