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
      NewDebitTransaction = subtractTransactionAmount;
      NewCreditTransaction = addTransactionAmount;
    }

    public CreditCard(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
      NewDebitTransaction = subtractTransactionAmount;
      NewCreditTransaction = addTransactionAmount;
    }

    public CreditCard(CreditCard cc) :  base(cc)
    {
      NewDebitTransaction = subtractTransactionAmount;
      NewCreditTransaction = addTransactionAmount;
    }

  }
}
