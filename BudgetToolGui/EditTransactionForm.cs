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
  public partial class EditTransactionForm : Form
  {
    private AccountBase _account;
    private decimal _amount;
    private DateTime _date;

    public event EventHandler<NewTransactionAddedEventArgs> NewTransactionAdded;
    public EditTransactionForm(AccountBase account, DateTime? date = null)
    {
      InitializeComponent();

      if(account == null)
      {
        throw new ArgumentException("Invalid account");
      }
      else
      {
        _account = account;
      }

      if(date == null)
      {
        _date = DateTime.Today;
      }
      else
      {
        _date = date.Value;
      }

      accountTb.Text = account.Name;

      RefreshPage();
    }

    private void RefreshPage()
    {
      amountTb.Text = _amount.ToString();
      dateDtp.Value = _date;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      if (amountTb.Text.Equals(string.Empty))
      {
        _amount = 0;
      }
      else
      {
        _amount = Decimal.Parse(amountTb.Text);
      }
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _date = dateDtp.Value;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewTransactionAddedEventArgs args = new NewTransactionAddedEventArgs();
      Transaction transaction = new Transaction();
      transaction.Amount = _amount;
      transaction.Date = _date;
      args.NewTransaction = transaction;
      OnNewTransactionAdded(args);

      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    protected virtual void OnNewTransactionAdded(NewTransactionAddedEventArgs e)
    {
      NewTransactionAdded?.Invoke(this, e);
    }
  }
  public class NewTransactionAddedEventArgs : EventArgs
  {
    public Transaction NewTransaction { get; set; }
  }
}
