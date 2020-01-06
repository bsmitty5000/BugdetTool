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
  public partial class EditAccountForm : Form
  {
    private Account _account;
    public event EventHandler<NewAccountAddedEventArgs> NewAccountAdded;
    public EditAccountForm(Account account)
    {
      InitializeComponent();

      //todo: use reflection to get this?
      string[] AccountTypes = new string[] { "CheckingAccount", "CreditCard" };
      typeCb.Items.AddRange(AccountTypes);

      if (account != null)
      {
        _account = account;
      }
      else
      {
        _account = new CheckingAccount();
      }

      RefreshForm();
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _account.Name = nameTb.Text;
    }

    private void balanceTb_TextChanged(object sender, EventArgs e)
    {
      _account.Balance = Decimal.Parse(balanceTb.Text);
    }
    private void typeCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      Account tempAccount = null;
      if(!_account.GetType().Name.Equals(typeCb.SelectedItem))
      {
        switch(typeCb.SelectedItem.ToString())
        {
          case "CheckingAccount":
            tempAccount = new CheckingAccount();
            break;
          case "CreditCard":
            tempAccount = new CreditCard();
            break;
        }

        tempAccount.Balance = _account.Balance;
        tempAccount.Name = _account.Name;
        _account = tempAccount;
      }
    }
    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewAccountAddedEventArgs args = new NewAccountAddedEventArgs();
      args.NewAccount = _account;
      OnNewAccountAdded(args);

      this.Close();
    }
    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected virtual void OnNewAccountAdded(NewAccountAddedEventArgs e)
    {
      NewAccountAdded?.Invoke(this, e);
    }

    private void RefreshForm()
    {
      nameTb.Text = _account.Name;
      balanceTb.Text = _account.Balance.ToString();
      typeCb.SelectedItem = _account.GetType().Name;
    }
  }

  public class NewAccountAddedEventArgs : EventArgs
  {
    public Account NewAccount { get; set; }
  }
}
