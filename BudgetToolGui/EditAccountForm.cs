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
    private AccountBase _account;
    private decimal _startingAmount;
    private string _name;
    public event EventHandler<NewAccountAddedEventArgs> NewAccountAdded;
    public EditAccountForm()
    {
      InitializeComponent();

      //todo: use reflection to get this?
      string[] AccountTypes = new string[] { "CheckingAccount", "CreditCard" };
      typeCb.Items.AddRange(AccountTypes);

      _account = new CheckingAccount();

      RefreshForm();
    }

    private void NameTb_TextChanged(object sender, EventArgs e)
    {
      _name = nameTb.Text;
    }

    private void BalanceTb_TextChanged(object sender, EventArgs e)
    {
      _startingAmount = Decimal.Parse(balanceTb.Text);
    }
    private void TypeCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      AccountBase tempAccount = null;
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

        _account = tempAccount;
      }
    }
    private void SaveBtn_Click(object sender, EventArgs e)
    {
      _account.Name = _name;
      _account.BalanceHistory = new List<BalanceEntry>() { new BalanceEntry() { Date = DateTime.Today, Amount = _startingAmount } };
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
      balanceTb.Text = _startingAmount.ToString();
      typeCb.SelectedItem = _account.GetType().Name;
    }
  }

  public class NewAccountAddedEventArgs : EventArgs
  {
    public AccountBase NewAccount { get; set; }
  }
}
