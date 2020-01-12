using System;
using System.Collections.Generic;
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
    private AccountBase checking;
    private AccountBase credit;

    private Income salary;
    private Income bonus;

    //annuals
    private HardBill carRegistration;
    private SoftBill vacation;

    //monthlys
    private HardBill electricity;
    private HardBill cable;
    private SoftBill food;
    private SoftBill gas;

    //top
    private YearTop yearTop;

    [SetUp]
    public void Init()
    {
      DateTime startingDate = new DateTime(2020, 1, 1);
      //create accounts
      checking = new CheckingAccount("checking", 5000, startingDate);
      credit = new CreditCard("credit", 0, startingDate);

      //create income
      salary = new Income("salary", 2500, IncomeFrequencyEnum.BiWeekly, checking, new DateTime(2020, 1, 10));
      bonus = new Income("bonus", 1500, IncomeFrequencyEnum.BiAnnualy, checking, new DateTime(2020, 1, 10));

      //annuals
      carRegistration = new HardBill("carRegistration", 1000, new DateTime(2020, 12, 31), HardBillFrequencyEnum.Annualy, credit);
      vacation = new SoftBill("vacation", 7500);

      //monthlys
      electricity = new HardBill("electricity", 150, new DateTime(2020, 1, 15), HardBillFrequencyEnum.Monthly, checking);
      cable = new HardBill("cable", 75, new DateTime(2020, 1, 20), HardBillFrequencyEnum.Monthly, credit);
      food = new SoftBill("food", 500);
      gas = new SoftBill("gas", 400);

      yearTop = new YearTop();
      yearTop.InitializeYear();

      //wire up top
      yearTop.Accounts.Add(checking.Name, checking);
      yearTop.Accounts.Add(credit.Name, credit);

      yearTop.IncomeSources.Add(salary.Name, salary);
      yearTop.IncomeSources.Add(bonus.Name, bonus);

      yearTop.HardBills.Add(carRegistration.Name, carRegistration);
      yearTop.AddSoftBill(vacation, true);

      yearTop.HardBills.Add(electricity.Name, electricity);
      yearTop.HardBills.Add(cable.Name, cable);
      yearTop.AddSoftBill(food, false);
      yearTop.AddSoftBill(gas, false);

    }

    [Test]
    public void SimplePurchaseTest()
    {
      decimal creditExpected = yearTop.Accounts["credit"].BalanceHistory.Last().Amount;
      decimal checkingExpected = yearTop.Accounts["checking"].BalanceHistory.Last().Amount;
      decimal total;
      Dictionary<string, decimal> sbSplit = new Dictionary<string, decimal>();
      Purchase purchase;

      /* Credit checks */ 
      total = 100;
      sbSplit = new Dictionary<string, decimal>() { { "food", total } };
      purchase = new Purchase("Grocery Store", credit, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.AddPurchase(purchase);

      creditExpected += total; 
      Assert.AreEqual(creditExpected, yearTop.Accounts["credit"].BalanceHistory.Last().Amount);

      total = 150;
      sbSplit = new Dictionary<string, decimal>() { { "food", total } };
      purchase = new Purchase("Grocery Store", credit, new DateTime(2020, 1, 16), total, sbSplit);
      yearTop.AddPurchase(purchase);

      creditExpected += total;
      Assert.AreEqual(creditExpected, yearTop.Accounts["credit"].BalanceHistory.Last().Amount);

      total = 150;
      sbSplit = new Dictionary<string, decimal>() { { "food", total } };
      purchase = new Purchase("Grocery Store", credit, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.AddPurchase(purchase);

      creditExpected += total;
      Assert.AreEqual(creditExpected, yearTop.Accounts["credit"].BalanceHistory.Last().Amount);

      /* Checking checks */
      total = 150;
      sbSplit = new Dictionary<string, decimal>() { { "gas", total } };
      purchase = new Purchase("Gas Station", checking, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.AddPurchase(purchase);

      checkingExpected -= total;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);

      total = 50;
      sbSplit = new Dictionary<string, decimal>() { { "gas", total } };
      purchase = new Purchase("Gas Station", checking, new DateTime(2020, 1, 20), total, sbSplit);
      yearTop.AddPurchase(purchase);

      checkingExpected -= total;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);

      total = 75;
      sbSplit = new Dictionary<string, decimal>() { { "gas", total } };
      purchase = new Purchase("Gas Station", checking, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.AddPurchase(purchase);

      checkingExpected -= total;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);
    }

    [Test]
    public void SimpleIncomeTest()
    {
      decimal checkingExpected = yearTop.Accounts["checking"].BalanceHistory.Last().Amount;
      salary.MakeDeposits(new DateTime(2020, 1, 10));

      checkingExpected += salary.PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);

      salary.MakeDeposits(new DateTime(2020, 1, 23));

      //checkingExpected += salary.PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);

      salary.MakeDeposits(new DateTime(2020, 1, 24));

      checkingExpected += salary.PaydayAmount;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);

      checkingExpected = yearTop.Accounts["checking"].BalanceHistory.First().Amount + salary.AnnualAmount;
      salary.MakeDeposits(new DateTime(2020, 12, 31));

      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);
    }
    [Test]
    public void SimpleHardBillTest()
    {
      decimal checkingExpected = yearTop.Accounts["checking"].BalanceHistory.Last().Amount;
      electricity.PayBill(new DateTime(2020, 2, 14));

      checkingExpected -= electricity.Amount;
      Assert.AreEqual(checkingExpected, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);
    }
    [Test]
    public void FastForwardYearTest()
    {
      yearTop.FastForward(new DateTime(2020, 12, 31));

      Console.WriteLine("Done");
    }
  }
}
