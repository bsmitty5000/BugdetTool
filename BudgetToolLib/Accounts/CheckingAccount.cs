using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class CheckingAccount : AccountBase
  {
    public CheckingAccount()
    {
      NewCreditTransaction = addTransactionAmount;
      NewDebitTransaction  = subtractTransactionAmount;
    }

    public CheckingAccount(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
      NewCreditTransaction = addTransactionAmount;
      NewDebitTransaction  = subtractTransactionAmount;
    }

    public CheckingAccount(CheckingAccount ca) : base(ca)
    {
      NewCreditTransaction = addTransactionAmount;
      NewDebitTransaction  = subtractTransactionAmount;
    }
  }
}
