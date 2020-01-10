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
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }

    public CheckingAccount(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }

    public CheckingAccount(CheckingAccount ca) : base(ca)
    {
      NewDebitTransaction = addTransactionAmount;
      NewCreditTransaction = subtractTransactionAmount;
    }
  }
}
