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
    BiAnnualy = 13,
    Annualy = 25
  }
  public class Income
  {
    public string Name { get; set; }
    public decimal PaydayAmount { get; set; }
    public IncomeFrequencyEnum PaydayFrequency { get; set; }
    public AccountBase DepositAccount { get; set; }
    public DateTime FirstDeposit { get; set; }
    public DateTime NextDeposit { get; private set; }
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
    }

    public void MakeDeposits(DateTime date)
    {
      var cal = new GregorianCalendar();
      int currentDayNumber = cal.GetDayOfYear(date);

      if(date < NextDeposit)
      {
        return;
      }

      while(cal.GetDayOfYear(NextDeposit) <= currentDayNumber)
      {
        DepositAccount.NewCreditTransaction(new Transaction() { Description = Name, Date = NextDeposit, Amount = PaydayAmount });
        NextDeposit = NextDeposit.AddDays((double)PaydayFrequency * 7);
      }
    }
  }
}
