using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditIncomeForm : Form
  {
    private IIncome _income;
    private YearTop _year;
    public event EventHandler<NewIncomeAddedEventArgs> NewIncomeAdded;
    public EditIncomeForm(IIncome income, YearTop year)
    {
      InitializeComponent();

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      frequencyCb.Items.AddRange(Enum.GetNames(typeof(IncomeFrequencyEnum)));

      var accountList = _year.GetAccountsNames();
      foreach (var account in accountList)
      {
        accountCb.Items.Add(account);
      }

      if (income != null)
      {
        _income = income;
        nameTb.Text = _income.Name;
        nameTb.ReadOnly = true;

        firstDepositDtp.Value = _income.FirstDeposit;
        firstDepositDtp.Enabled = false;

        //editable fields
        amountTb.Text = _income.PaydayAmount.ToString();
        frequencyCb.SelectedItem = _income.PaydayFrequency.ToString();
        accountCb.SelectedItem = _income.DepositAccount.Name;
      }
      else
      {
        _income = null;
        firstDepositDtp.Value = DateTime.Today;
      }
    }
    private void saveBtn_Click_1(object sender, EventArgs e)
    {
      NewIncomeAddedEventArgs args = new NewIncomeAddedEventArgs();

      decimal amount;
      if (!decimal.TryParse(amountTb.Text, out amount))
      {
        amountTb.Text = 0.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }

      string name = nameTb.Text;
      DateTime firstDeposit = firstDepositDtp.Value.Date;

      IncomeFrequencyEnum frequency;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out frequency);

      string accountName = accountCb.Text;

      if (_income == null)
      {
        _income = new Income(name, amount, frequency, _year.GetAccount(accountName), firstDeposit);
        args.NewIncome = _income;
      }
      else
      {
        _income.DepositAccount = _year.GetAccount(accountName);
        _income.PaydayAmount = amount;
        _income.PaydayFrequency = frequency;

        args.NewIncome = null;
      }

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
    public IIncome NewIncome { get; set; }
  }
}
