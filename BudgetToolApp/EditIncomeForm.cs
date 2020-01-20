using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditIncomeForm : Form
  {
    private Income _income;
    private YearTop _year;
    public event EventHandler<NewIncomeAddedEventArgs> NewIncomeAdded;
    public EditIncomeForm(Income income, YearTop year)
    {
      InitializeComponent();

      if (income != null)
      {
        _income = income;
      }
      else
      {
        _income = new Income();
      }

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      frequencyCb.Items.AddRange(Enum.GetNames(typeof(IncomeFrequencyEnum)));

      foreach (var account in _year.Accounts)
      {
        accountCb.Items.Add(account.Value.Name);
      }

      nameTb.Text = _income.Name;
      amountTb.Text = _income.PaydayAmount.ToString();
      frequencyCb.SelectedItem = _income.PaydayFrequency.ToString();
      accountCb.SelectedItem = _income.DepositAccount != null ? _income.DepositAccount.Name : string.Empty;
      firstDepositDtp.Value = _income.FirstDeposit;
    }
    private void saveBtn_Click_1(object sender, EventArgs e)
    {
      NewIncomeAddedEventArgs args = new NewIncomeAddedEventArgs();

      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _income.PaydayAmount = amount;
      }
      else
      {
        amountTb.Text = _income.PaydayAmount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
      _income.Name = nameTb.Text;

      IncomeFrequencyEnum enumParse;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out enumParse);
      _income.PaydayFrequency = enumParse;

      _income.DepositAccount = _year.Accounts[accountCb.Text];

      _income.FirstDeposit = firstDepositDtp.Value;

      args.NewIncome = _income;
      OnNewIncomeAdded(args);

      this.Close();
    }
    private void cancelBtn_Click_1(object sender, EventArgs e)
    {
      this.Close();
    }
    protected virtual void OnNewIncomeAdded(NewIncomeAddedEventArgs e)
    {
      NewIncomeAdded?.Invoke(this, e);
    }
  }
  public class NewIncomeAddedEventArgs : EventArgs
  {
    public Income NewIncome { get; set; }
  }
}
