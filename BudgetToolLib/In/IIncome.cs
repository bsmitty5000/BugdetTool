using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public interface IIncome
  {
    string Name { get; }
    decimal PaydayAmount { get; set; }
    IncomeFrequencyEnum PaydayFrequency { get; set; }
    IAccountBase DepositAccount { get; set; }
    DateTime FirstDeposit { get; }
    DateTime NextDeposit { get; }
    int NumPaydaysPaidThisYear { get; }
    decimal AnnualAmount { get; }
    void MakeDeposits(DateTime date);
  }
}
