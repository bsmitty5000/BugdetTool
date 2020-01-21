using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BudgetToolLib
{
  public enum IncomeFrequencyEnum
  {
    BiWeekly = 2,
    BiAnnualy = 26,
    Annualy = 52
  }

  public class Income
  {
    private DateTime _firstDeposit;
    public string Name { get; set; }
    public decimal PaydayAmount { get; set; }
    public IncomeFrequencyEnum PaydayFrequency { get; set; }
    public AccountBase DepositAccount { get; set; }
    public DateTime FirstDeposit
    {
      get
      {
        return _firstDeposit;
      }
      set
      {
        _firstDeposit = value;
        NextDeposit = value;
      }
    }
    public DateTime NextDeposit { get; set; }
    public int NumPaydaysPaidThisYear { get; set; }
    public decimal AnnualAmount
    {
      get
      {
        decimal annualAmount;
        switch (PaydayFrequency)
        {
          case IncomeFrequencyEnum.BiAnnualy:
            annualAmount = PaydayAmount * 2;
            break;
          case IncomeFrequencyEnum.BiWeekly:
            annualAmount = PaydayAmount * 26;
            break;
          case IncomeFrequencyEnum.Annualy:
            annualAmount = PaydayAmount * 1;
            break;
          default:
            throw new ArgumentException("Invalid Income Frequency");
        }

        return annualAmount;
      }
    }

    public Income()
    {
      Name = string.Empty;
      PaydayAmount = 0;
      PaydayFrequency = IncomeFrequencyEnum.Annualy;
      DepositAccount = null;
      FirstDeposit = DateTime.Today;
    }

    public Income(string name, decimal paydayAmount, IncomeFrequencyEnum incomeFrequency, AccountBase depositAccount, DateTime firstDeposit)
    {
      Name = name;
      PaydayAmount = paydayAmount;
      PaydayFrequency = incomeFrequency;
      DepositAccount = depositAccount;
      FirstDeposit = firstDeposit;
      NextDeposit = FirstDeposit;
      NumPaydaysPaidThisYear = 0;
    }

    public Income(Income i)
    {
      Name = i.Name;
      PaydayAmount = i.PaydayAmount;
      PaydayFrequency = i.PaydayFrequency;
      DepositAccount = AccountBaseFactory.CopyAccountBase(i.DepositAccount);
      FirstDeposit = i.FirstDeposit;
      NextDeposit = i.NextDeposit;
      NumPaydaysPaidThisYear = i.NumPaydaysPaidThisYear;
    }

    public void MakeDeposits(DateTime date)
    {
      var cal = new GregorianCalendar();

      if(date < NextDeposit)
      {
        return;
      }

      //todo: maybe make the deposit only happen if it's during the week
      while(NextDeposit <= date)
      {
        DepositAccount.NewCreditTransaction(new Transaction() { Description = Name, Date = NextDeposit, Amount = PaydayAmount, AccountUsed = DepositAccount });
        NextDeposit = NextDeposit.AddDays((double)PaydayFrequency * 7);
        NumPaydaysPaidThisYear++;

        if (cal.GetYear(NextDeposit) > cal.GetYear(FirstDeposit))
        {
          break; //passing into next year. for now keep this confined to a single year
        }
      }
    }
  }
}
