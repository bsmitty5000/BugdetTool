﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolCore
{
  public class CheckingAccount : AccountBase
  {
    public CheckingAccount()
    {
    }

    public CheckingAccount(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
    }

    public CheckingAccount(CheckingAccount ca) : base(ca)
    {
    }

    public override void NewDebitTransaction(Transaction transaction)
    {
      if(transaction.Amount < 0)
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

    public override void UpdateInitialBalance(decimal amount)
    {
      throw new NotImplementedException();
    }
  }
}
