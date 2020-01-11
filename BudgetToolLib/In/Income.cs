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
    public decimal UnitAmount { get; set; }
    public IncomeFrequencyEnum IncomeFrequency { get; set; }
    public AccountBase DepositAccount { get; set; }
    public DateTime FirstDeposit { get; set; }
    public DateTime LastDeposit { get; private set; }
    public int LastDepositWeekNumber { get; private set; }
    public decimal AnnualAmount
    {
      get
      {
        decimal annualAmount;
        switch (IncomeFrequency)
        {
          case IncomeFrequencyEnum.BiAnnualy:
            annualAmount = UnitAmount * 2;
            break;
          case IncomeFrequencyEnum.BiWeekly:
            annualAmount = UnitAmount * 26;
            break;
          case IncomeFrequencyEnum.Annualy:
            annualAmount = UnitAmount * 1;
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
      UnitAmount = 0;
      IncomeFrequency = IncomeFrequencyEnum.Annualy;
      DepositAccount = null;
      FirstDeposit = DateTime.Today;
    }

    public Income(string name, decimal unitAmount, IncomeFrequencyEnum incomeFrequency, DateTime firstDeposit)
    {
      Name = name;
      UnitAmount = unitAmount;
      IncomeFrequency = incomeFrequency;
      FirstDeposit = firstDeposit;
      LastDeposit = FirstDeposit;
    }

    public void MakeDeposits(DateTime date)
    {
      var cal = new GregorianCalendar();
      DayOfWeek firstDay = DayOfWeek.Sunday;
      int currentWeekNumber = cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, firstDay);
      int numOfPaydaysToProcess = (currentWeekNumber - LastDepositWeekNumber) / (int)IncomeFrequency;

      for(int i = 0; i < numOfPaydaysToProcess; i++)
      {
        LastDeposit = LastDeposit.AddDays((double)IncomeFrequency * 7);
        DepositAccount.NewCreditTransaction(new Transaction() { Description = Name, Date = LastDeposit, Amount = UnitAmount });
        LastDepositWeekNumber += (int)IncomeFrequency;
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(Name + ",");
      sb.Append(UnitAmount + ",");
      sb.Append(IncomeFrequency + ",");
      sb.Append(DepositAccount.Name + ",");
      sb.Append(FirstDeposit + ",");
      sb.Append(LastDeposit + ",");
      sb.Append(LastDepositWeekNumber);

      return sb.ToString();

    }
  }
}
