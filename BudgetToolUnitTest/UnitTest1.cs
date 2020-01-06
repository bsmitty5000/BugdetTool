using NUnit.Framework;
using BudgetToolLib;

namespace BudgetToolUnitTest
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
      YearTop year = new YearTop();
      SpendingCategory japanTrip = new SpendingCategory("Japan Trip", 7500);
      year.AddSpendingGroup(true, japanTrip);

      SpendingCategory food = new SpendingCategory("Food", 500);
      year.AddSpendingGroup(false, food);

      CreditCardDebit ccDebit = new CreditCardDebit("Food", 50, new System.DateTime(2020, 1, 15));
      year.AddDebit(ccDebit);

      Assert.AreEqual(450, year.BudgetGroups[0].MonthlyGroups["Food"].Amount);

      year.BudgetGroups[0].MonthlyGroups["Food"].Debits[0].UpdateAmount(55);

      Assert.AreEqual(445, year.BudgetGroups[0].MonthlyGroups["Food"].Amount);

    }
  }
}