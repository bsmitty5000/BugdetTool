using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class CreditCard : AccountBase
  {
    public CreditCard()
    {
      NewCreditTransaction = subtractTransactionAmount;
      NewDebitTransaction  = addTransactionAmount;
    }

    public CreditCard(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
      NewCreditTransaction = subtractTransactionAmount;
      NewDebitTransaction  = addTransactionAmount;
    }

    public CreditCard(CreditCard cc) :  base(cc)
    {
      NewCreditTransaction = subtractTransactionAmount;
      NewDebitTransaction  = addTransactionAmount;
    }

  }
}
