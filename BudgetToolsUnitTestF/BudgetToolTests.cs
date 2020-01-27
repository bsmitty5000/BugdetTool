using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetToolLib;
using NUnit.Framework;


namespace BudgetToolsUnitTestF
{
  [TestFixture]
  public class BudgetToolTests
  {
    //top
    private YearTop yearTop;

    [SetUp]
    public void Init()
    {
      IAccountBase checking;
      IAccountBase credit;

      IIncome salary;
      IIncome bonus;

      //annuals
      IHardBill carRegistration;

      //monthlys
      IHardBill electricity;
      IHardBill cable;

      DateTime startingDate = new DateTime(2020, 1, 1);
      //create accounts
      checking = new CheckingAccount("checking", 5000, startingDate);
      credit = new CreditCard("credit", 0, startingDate);

      //create income
      salary = new Income("salary", 2500, IncomeFrequencyEnum.BiWeekly, checking, new DateTime(2020, 1, 10));
      bonus = new Income("bonus", 1500, IncomeFrequencyEnum.BiAnnualy, checking, new DateTime(2020, 1, 10));

      //annuals
      carRegistration = new HardBill("carRegistration", 1000, new DateTime(2020, 12, 31), HardBillFrequencyEnum.Annualy, credit, false);

      //monthlys
      electricity = new HardBill("electricity", 150, new DateTime(2020, 1, 15), HardBillFrequencyEnum.Monthly, checking, true);
      cable = new HardBill("cable", 75, new DateTime(2020, 1, 20), HardBillFrequencyEnum.Monthly, credit, true);

      yearTop = new YearTop();
      yearTop.InitializeYear();

      //wire up top
      yearTop.AddAccount(checking);
      yearTop.AddAccount(credit);

      yearTop.AddIncomeSource(salary);
      yearTop.AddIncomeSource(bonus);

      yearTop.AddHardBill(carRegistration);
      yearTop.AddSoftBill("vacation", 7500, true);

      yearTop.AddHardBill(electricity);
      yearTop.AddHardBill(cable);
      yearTop.AddSoftBill("food", 500, false);
      yearTop.AddSoftBill("gas", 100, false);

    }

    [Test]
    public void SimplePurchaseTest()
    {
      decimal creditExpected = yearTop.GetAccount("credit").CurrentBalance;
      decimal checkingExpected = yearTop.GetAccount("checking").CurrentBalance;

      //transaction details
      decimal amount;
      string description;
      DateTime date;
      SoftBillTransaction sbt;

      /* Credit checks */
      amount = 100;
      description = "grocery store";
      date = new DateTime(2020, 1, 15);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.Date = date;
      sbt.SoftGroupSplit["food"] = amount;
      yearTop.GetAccount("credit").NewDebitTransaction(sbt);

      creditExpected += amount; 
      Assert.AreEqual(creditExpected, yearTop.GetAccount("credit").CurrentBalance);

      /* Credit checks */
      amount = 150;
      description = "grocery store";
      date = new DateTime(2020, 1, 16);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.Date = date;
      sbt.SoftGroupSplit["food"] = amount;
      yearTop.GetAccount("credit").NewDebitTransaction(sbt);

      creditExpected += amount;
      Assert.AreEqual(creditExpected, yearTop.GetAccount("credit").CurrentBalance);

      /* Checking checks */
      amount = 150;
      description = "gas station";
      date = new DateTime(2020, 1, 16);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.Date = date;
      sbt.SoftGroupSplit["gas"] = amount;
      yearTop.GetAccount("checking").NewDebitTransaction(sbt);

      checkingExpected -= amount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);

      amount = 50;
      description = "gas station";
      date = new DateTime(2020, 1, 20);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.Date = date;
      sbt.SoftGroupSplit["gas"] = amount;
      yearTop.GetAccount("checking").NewDebitTransaction(sbt);

      checkingExpected -= amount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);
    }

    [Test]
    public void SimpleIncomeTest()
    {
      decimal checkingExpected = yearTop.GetAccount("checking").CurrentBalance;
      yearTop.GetIncomeSource("salary").MakeDeposits(new DateTime(2020, 1, 10));

      checkingExpected += yearTop.GetIncomeSource("salary").PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);

      yearTop.GetIncomeSource("salary").MakeDeposits(new DateTime(2020, 1, 23));

      //checkingExpected += yearTop.GetIncomeSource("salary").PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);

      yearTop.GetIncomeSource("salary").MakeDeposits(new DateTime(2020, 1, 24));

      checkingExpected += yearTop.GetIncomeSource("salary").PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);

      checkingExpected = yearTop.GetAccount("checking").StartingBalance + yearTop.GetIncomeSource("salary").AnnualAmount;
      yearTop.GetIncomeSource("salary").MakeDeposits(new DateTime(2020, 12, 31));

      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);
    }
    [Test]
    public void SimpleHardBillTest()
    {
      decimal checkingExpected = yearTop.GetAccount("checking").CurrentBalance;
      yearTop.GetHardBill("electricity").PerformAutoPay(new DateTime(2020, 2, 14));

      checkingExpected -= yearTop.GetHardBill("electricity").Amount;
      Assert.AreEqual(checkingExpected, yearTop.GetAccount("checking").CurrentBalance);
    }
    [Test]
    public void FastForwardYearTest()
    {
      yearTop.FastForward(new DateTime(2020, 12, 31));

      Console.WriteLine("Done");
    }

    [Test]
    public void SerializeTest()
    {
      string filepath = @"C:\Users\Batman\budgets\BudgetTest.bin";
      yearTop.FastForward(new DateTime(2020, 12, 31));

      //transaction details
      decimal amount;
      string description;
      DateTime date;
      SoftBillTransaction sbt;

      /* Credit checks */
      amount = 100;
      description = "grocery store";
      date = new DateTime(2020, 1, 15);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.SoftGroupSplit["food"] = amount;
      yearTop.GetAccount("credit").NewDebitTransaction(sbt);

      /* Checking checks */
      amount = 150;
      description = "gas station";
      date = new DateTime(2020, 1, 16);
      sbt = yearTop.GetSoftBillTransaction(description, amount, date.Month);
      sbt.SoftGroupSplit["gas"] = amount;
      yearTop.GetAccount("checking").NewDebitTransaction(sbt);

      yearTop.SaveToFile(filepath);

      YearTop desYearTop = YearTop.LoadFromFile(filepath);

      var accountNames = yearTop.GetAccountsNames();
      foreach (var name in accountNames)
      {
        IAccountBase origAccount = yearTop.GetAccount(name);
        IAccountBase copyAccount = desYearTop.GetAccount(name);

        Assert.AreEqual(origAccount.CurrentBalance, copyAccount.CurrentBalance);
        IReadOnlyList<Transaction> origTs = origAccount.GetTransactions();
        IReadOnlyList<Transaction> copyTs = copyAccount.GetTransactions();
        for (int i = 0; i < origTs.Count; i++)
        {
          Transaction origT = origTs[i];
          Transaction copyT = copyTs[i];

          Assert.AreEqual(origT.Amount, copyT.Amount);
          Assert.AreEqual(origT.Date, copyT.Date);
          Assert.AreEqual(origT.Description, copyT.Description);

          if(origT.GetType().Name.Contains("SoftBill"))
          {
            SoftBillTransaction origSbt = origT as SoftBillTransaction;
            SoftBillTransaction copySbt = copyT as SoftBillTransaction;

            foreach (var item in origSbt.SoftGroupSplit)
            {
              Assert.AreEqual(item.Value, copySbt.SoftGroupSplit[item.Key]);
            }
          }
        }
      }
    }
  }
}
