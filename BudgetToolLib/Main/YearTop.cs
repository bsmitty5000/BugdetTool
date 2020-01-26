using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BudgetToolLib
{
  [Serializable()]
  public class YearTop
  {
    public DateTime TimeLastLoaded { get; set; }
    /* Add to dictionary directly */
    public Dictionary<string, AccountBase> Accounts { get; set; }

    /* Add to dictionary directly */
    public Dictionary<string, Income> IncomeSources { get; set; }
    public Dictionary<string, HardBill> HardBills { get; set; }
    public List<SoftBillGroup> MonthlySoftBills { get; set; }
    public decimal AnnualHardBillAmount
    {
      get
      {
        decimal totalHb = 0;
        foreach (var hb in HardBills)
        {
          totalHb += hb.Value.AnnualAmount;
        }
        return totalHb;
      }
    }
    public decimal AnnualIncome
    {
      get
      {
        decimal totalSalary = 0;
        foreach (var income in IncomeSources)
        {
          totalSalary += income.Value.AnnualAmount;
        }
        return totalSalary;
      }
    }
    public decimal AnnualSoftBillAmount
    {
      get
      {
        decimal annualSb = 0;
        foreach (var group in MonthlySoftBills)
        {
          annualSb += group.TotalSoftBillAmountBudgeted;
        }
        return annualSb;
      }
    }

    public YearTop()
    {
    }

    public YearTop(YearTop y)
    {
      Accounts = new Dictionary<string, AccountBase>();
      foreach (var a in y.Accounts)
      {
        Accounts.Add(a.Key, AccountBaseFactory.CopyAccountBase(a.Value));
      }

      IncomeSources = new Dictionary<string, Income>();
      foreach (var i in y.IncomeSources)
      {
        IncomeSources.Add(i.Key, new Income(i.Value));
        //this is ugly. probably should find a better way
        IncomeSources[i.Key].DepositAccount = Accounts[i.Value.DepositAccount.Name];
      }

      MonthlySoftBills = new List<SoftBillGroup>();
      foreach (var m in y.MonthlySoftBills)
      {
        MonthlySoftBills.Add(new SoftBillGroup(m));
      }

      HardBills = new Dictionary<string, HardBill>();
      foreach (var hb in y.HardBills)
      {
        HardBills.Add(hb.Key, new HardBill(hb.Value));
        //this is ugly. probably should find a better way
        HardBills[hb.Key].PaymentAccount = Accounts[hb.Value.PaymentAccount.Name];
      }
    }
    public void InitializeYear()
    {
      MonthlySoftBills = new List<SoftBillGroup>();
      /* BudgetGroup[0] = Year
       * BudgetGroup[1:12] = Months
       */
      for (int i = 0; i < 13; i++)
      {
        MonthlySoftBills.Add(new SoftBillGroup());
      }
      IncomeSources = new Dictionary<string, Income>();
      Accounts = new Dictionary<string, AccountBase>();
      HardBills = new Dictionary<string, HardBill>();
    }
    static public YearTop LoadFromFile(string filepath)
    {
      YearTop jsonYear = null;

      if (File.Exists(filepath))
      {
        Console.WriteLine("Reading saved file");
        Stream openFileStream = File.OpenRead(filepath);
        BinaryFormatter deserializer = new BinaryFormatter();
        jsonYear = (YearTop)deserializer.Deserialize(openFileStream);
        jsonYear.TimeLastLoaded = DateTime.Now;
        openFileStream.Close();
      }
      return jsonYear;
    }
    public void SaveToFile(string filepath)
    {
      Stream SaveFileStream = File.Create(filepath);
      BinaryFormatter serializer = new BinaryFormatter();
      serializer.Serialize(SaveFileStream, this);
      SaveFileStream.Close();
    }
    public void RemoveSoftBill(string name)
    {
      foreach (var group in MonthlySoftBills)
      {
        group.SoftBills.Remove(name);
      }
    }
    public void AddSoftBill(string name, decimal startingAmount, Boolean annualGroup)
    {
      if (annualGroup)
      {
        MonthlySoftBills[0].SoftBills[name] = startingAmount;
      }
      else
      {
        /* important to start at 1 here */
        for (int i = 1; i < MonthlySoftBills.Count; i++)
        {
          MonthlySoftBills[i].SoftBills[name] = startingAmount;
        }
      }
    }
    public SoftBillTransaction GetSoftBillTransaction(string description, decimal amount, int month)
    {
      SoftBillTransaction sbt = MonthlySoftBills[month].CreateSoftBillTransaction();
      //sbt.Date = new DateTime(DateTime.Today.Year, month, DateTime.Today.Day);
      sbt.Description = description;
      sbt.Amount = amount;
      return sbt;
    }
    public List<string> GetSoftBillKeys(int month)
    {
      return MonthlySoftBills[month].GetSoftBillKeys();
    }
    public Dictionary<string, decimal> GetSoftBillUsed(int month)
    {
      Dictionary<string, decimal> softBillTotals = new Dictionary<string, decimal>();
      List<string> softBillNames = GetSoftBillKeys(month);
      foreach (var name in softBillNames)
      {
        softBillTotals.Add(name, 0);
      }

      foreach (var kvpAcc in Accounts)
      {
        foreach (var trans in kvpAcc.Value.GetTransactions())
        {
          if((trans.Date.Month == month) && (trans.GetType().Name.Contains("SoftBill")))
          {
            SoftBillTransaction sbTrans = trans as SoftBillTransaction;
            foreach (var kvpSb in sbTrans.SoftGroupSplit)
            {
              if(softBillTotals.ContainsKey(kvpSb.Key))
              {
                softBillTotals[kvpSb.Key] += kvpSb.Value;
              }
            }
          }
        }
      }

      return softBillTotals;
    }
    public void FastForward(DateTime date)
    {
      foreach (var income in IncomeSources)
      {
        income.Value.MakeDeposits(date);
      }

      foreach (var hb in HardBills)
      {
        if(hb.Value.AutoPay)
        {
          hb.Value.PerformAutoPay(date);
        }
      }
    }
  }
}
