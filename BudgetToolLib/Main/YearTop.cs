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
    public DateTime TimeLastLoaded { get; private set; }
    /* Add to dictionary directly */
    private Dictionary<string, IAccountBase> _accounts;

    /* Add to dictionary directly */
    private Dictionary<string, IIncome> _income;
    private Dictionary<string, IHardBill> _hardBills;
    private List<SoftBillGroup> _monthlySoftBills;

    public YearTop()
    {
      InitializeYear();
    }

    public YearTop Copy()
    {
      YearTop retYear = null;
      BinaryFormatter serializer = new BinaryFormatter();
      BinaryFormatter deserializer = new BinaryFormatter();
      using (MemoryStream stream = new MemoryStream())
      {
        serializer.Serialize(stream, this);
        stream.Position = 0;
        retYear = (YearTop)deserializer.Deserialize(stream);
      }

      return retYear;
    }


    #region Public Properties
    public decimal AnnualHardBillAmount
    {
      get
      {
        decimal totalHb = 0;
        foreach (var hb in _hardBills)
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
        foreach (var income in _income)
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
        foreach (var group in _monthlySoftBills)
        {
          annualSb += group.TotalSoftBillAmountBudgeted;
        }
        return annualSb;
      }
    }
    #endregion

    #region Constructor Helpers
    public void InitializeYear()
    {
      _monthlySoftBills = new List<SoftBillGroup>();
      /* BudgetGroup[0] = Year
       * BudgetGroup[1:12] = Months
       */
      for (int i = 0; i < 13; i++)
      {
        _monthlySoftBills.Add(new SoftBillGroup());
      }
      _income = new Dictionary<string, IIncome>();
      _accounts = new Dictionary<string, IAccountBase>();
      _hardBills = new Dictionary<string, IHardBill>();
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
    #endregion

    #region SoftBill Access
    public void RemoveSoftBill(string name)
    {
      foreach (var group in _monthlySoftBills)
      {
        group.SoftBills.Remove(name);
      }
    }
    public void RemoveSoftBill(string name, int month)
    {
      _monthlySoftBills[month].SoftBills.Remove(name);
    }
    public void AddSoftBill(string name, decimal startingAmount, int month)
    {
      _monthlySoftBills[month].SoftBills[name] = startingAmount;
    }
    public void AddSoftBill(string name, decimal startingAmount, Boolean annualGroup)
    {
      if (annualGroup)
      {
        _monthlySoftBills[0].SoftBills[name] = startingAmount;
      }
      else
      {
        /* important to start at 1 here */
        for (int i = 1; i < _monthlySoftBills.Count; i++)
        {
          _monthlySoftBills[i].SoftBills[name] = startingAmount;
        }
      }
    }
    public IReadOnlyList<string> GetSoftBillKeys(int month)
    {
      return _monthlySoftBills[month].GetSoftBillKeys();
    }
    public Dictionary<string, decimal> GetSoftBillUsed(int month)
    {
      Dictionary<string, decimal> softBillTotals = new Dictionary<string, decimal>();
      IReadOnlyList<string> softBillNames = GetSoftBillKeys(month);
      foreach (var name in softBillNames)
      {
        softBillTotals.Add(name, 0);
      }

      foreach (var kvpAcc in _accounts)
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
    public IReadOnlyDictionary<string,decimal> GetSoftBillGroup(int month)
    {
      return _monthlySoftBills[month].SoftBills;
    }
    #endregion

    #region Account access
    public void AddAccount(IAccountBase account)
    {
      //error checking
      if(_accounts.ContainsKey(account.Name))
      {
        throw new ArgumentException("That account already exists!");
      }
      _accounts.Add(account.Name, account);
    }
    public void RemoveAccount(string name)
    {
      _accounts.Remove(name);
    }
    public IAccountBase GetAccount(string name)
    {
      if(_accounts.ContainsKey(name))
      {
        return _accounts[name];
      }
      else
      {
        throw new ArgumentException("Cannot find that account!");
      }
    }
    public IReadOnlyList<string> GetAccountsNames()
    {
      return _accounts.Keys.ToList();
    }
    public List<IAccountBase> GetAccounts()
    {
      return _accounts.Values.ToList();
    }
    #endregion

    #region Income access
    public void AddIncomeSource(IIncome income)
    {
      //error checking
      if(_income.ContainsKey(income.Name))
      {
        throw new ArgumentException("That income source already exists!");
      }
      _income.Add(income.Name, income);
    }
    public void RemoveIncomeSource(string name)
    {
      _income.Remove(name);
    }
    public IIncome GetIncomeSource(string name)
    {
      if (_income.ContainsKey(name))
      {
        return _income[name];
      }
      else
      {
        throw new ArgumentException("Cannot find that income source!");
      }
    }
    public List<IIncome> GetIncomeSources()
    {
      return _income.Values.ToList();
    }
    #endregion

    #region HardBill access
    public void AddHardBill(IHardBill hb)
    {
      //error checking
      _hardBills.Add(hb.Name, hb);
    }
    public void RemoveHardBill(string name)
    {
      _hardBills.Remove(name);
    }
    public IHardBill GetHardBill(string name)
    {
      if (_hardBills.ContainsKey(name))
      {
        return _hardBills[name];
      }
      else
      {
        throw new ArgumentException("Cannot find that HardBill!");
      }
    }
    public List<IHardBill> GetHardBills()
    {
      return _hardBills.Values.ToList();
    }
    #endregion

    public void FastForward(DateTime date)
    {
      foreach (var income in _income)
      {
        income.Value.MakeDeposits(date);
      }

      foreach (var hb in _hardBills)
      {
        if(hb.Value.AutoPay)
        {
          hb.Value.PerformAutoPay(date);
        }
      }
    }
  }
}
