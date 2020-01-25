using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BudgetToolLib
{
  public enum HardBillFrequencyEnum
  {
    Weekly,
    Monthly,
    Annualy
  }

  [Serializable()]
  public class HardBill
  {
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime FirstBillDue { get; set; }
    public DateTime NextBillDue { get; set; }
    public HardBillFrequencyEnum Frequency { get; set; }
    public AccountBase PaymentAccount { get; set; }

    public decimal AnnualAmount
    {
      get
      {
        switch(Frequency)
        {
          case HardBillFrequencyEnum.Annualy:
            return Amount;
          case HardBillFrequencyEnum.Monthly:
            return Amount * 12;
          case HardBillFrequencyEnum.Weekly:
            return Amount * 52;
          default:
            return 0;
        }
      }
    }
    public HardBill()
    { }

    public HardBill(string name, decimal amount, DateTime firstBillDue, HardBillFrequencyEnum frequency, AccountBase paymentSource)
    {
      Name = name;
      Amount = amount;
      FirstBillDue = firstBillDue;
      Frequency = frequency;
      PaymentAccount = paymentSource;
    }

    public HardBill(HardBill hb)
    {
      this.Name = hb.Name;
      this.Amount = hb.Amount;
      this.FirstBillDue = hb.FirstBillDue;
      this.Frequency = hb.Frequency;
      this.PaymentAccount = AccountBaseFactory.CopyAccountBase(hb.PaymentAccount);
      this.NextBillDue = hb.NextBillDue;
    }

    public void PayBill(DateTime date)
    {
      while(NextBillDue <= date)
      {
        PaymentAccount.NewDebitTransaction(new Transaction() { Description = Name, Date = NextBillDue, Amount = this.Amount });
        switch (Frequency)
        {
          case HardBillFrequencyEnum.Monthly:
            NextBillDue = NextBillDue.AddMonths(1);
            break;
          case HardBillFrequencyEnum.Weekly:
            NextBillDue = NextBillDue.AddDays(7);
            break;
            // Nothing to do for now for annuals because i'm only concentrating on a single year at a time
          default:
            return;
        }
      }
    }
  }
}
