using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolGui
{
  public partial class EditIncomeForm : Form
  {
    private Income _income;
    private YearTop _year;
    public event EventHandler<NewIncomeAddedEventArgs> NewIncomeAdded;
    public EditIncomeForm(Income income, YearTop year)
    {
      InitializeComponent();

      if(income != null)
      {
        _income = income;
      }
      else
      {
        _income = new Income();
      }

      if(year == null)
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

      RefreshForm();
    }

    private void RefreshForm()
    {
      nameTb.Text = _income.Name;
      amountTb.Text = _income.UnitAmount.ToString();
      frequencyCb.SelectedItem = _income.IncomeFrequency.ToString();
      accountCb.SelectedItem = _income.DepositAccount != null ? _income.DepositAccount.Name : string.Empty;
      firstDepositDtp.Value = _income.FirstDeposit;
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _income.Name = nameTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      _income.UnitAmount = Decimal.Parse(amountTb.Text);
    }

    private void frequencyCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      IncomeFrequencyEnum enumParse;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out enumParse);
      _income.IncomeFrequency = enumParse;
    }

    private void accountCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _income.DepositAccount = _year.Accounts[accountCb.Text];
    }

    private void firstDepositDtp_ValueChanged(object sender, EventArgs e)
    {
      _income.FirstDeposit = firstDepositDtp.Value;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewIncomeAddedEventArgs args = new NewIncomeAddedEventArgs();
      args.NewIncome = _income;
      OnNewIncomeAdded(args);

      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
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
