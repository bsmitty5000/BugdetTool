﻿using System;
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
    }

    public CreditCard(string name, decimal startingAmount, DateTime? startingDate) : base(name, startingAmount, startingDate)
    {
    }

    public CreditCard(CreditCard cc) :  base(cc)
    {
    }
    public override void NewDebitTransaction(Transaction transaction)
    {
      if (transaction.Amount < 0)
      {
        throw new ArgumentException("Transaction amount should be positive. Use Debit vs Credit");
      }
      ProcessNewTransaction(transaction);
    }

    public override void NewCreditTransaction(Transaction transaction)
    {
      if (transaction.Amount < 0)
      {
        throw new ArgumentException("Transaction amount should be positive. Use Debit vs Credit");
      }
      transaction.Amount = -1 * transaction.Amount;
      ProcessNewTransaction(transaction);
    }
  }
}
