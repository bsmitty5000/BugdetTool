using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public interface IHardBill
  {
    string Name { get; }
    decimal Amount { get; set; }
    DateTime FirstBillDue { get; }
    DateTime NextBillDue { get; }
    HardBillFrequencyEnum Frequency { get; set; }
    IAccountBase PaymentAccount { get; set; }
    bool AutoPay { get; set; }
    decimal AnnualAmount { get; }
    void PayBill(DateTime date, decimal amount = 0);
    void PerformAutoPay(DateTime date);
  }
}
