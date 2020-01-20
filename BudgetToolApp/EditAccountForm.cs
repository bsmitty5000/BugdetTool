using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditAccountForm : Form
  {
    private AccountBase _account;
    private decimal _startingAmount;
    private string _name;
    private string _type;
    private DateTime _startingDate;
    public event EventHandler<NewAccountAddedEventArgs> NewAccountAdded;
    public EditAccountForm()
    {
      InitializeComponent();

      //todo: use reflection to get this?
      string[] AccountTypes = new string[] { "CheckingAccount", "CreditCard" };
      typeCb.Items.AddRange(AccountTypes);

      _name = string.Empty;
      _startingAmount = 0;
      _type = AccountTypes[0];
      _startingDate = DateTime.Today;

      RefreshForm();
    }

    private void nameTb_TextChanged_1(object sender, EventArgs e)
    {
      _name = nameTb.Text;
    }

    private void balanceTb_TextChanged_1(object sender, EventArgs e)
    {
      _startingAmount = Decimal.Parse(balanceTb.Text);
    }
    private void typeCb_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      _type = typeCb.SelectedItem.ToString();
    }
    private void startingDateDtp_ValueChanged_1(object sender, EventArgs e)
    {
      _startingDate = startingDateDtp.Value;
    }
    private void saveBtn_Click(object sender, EventArgs e)
    {
      switch (_type)
      {
        case "CheckingAccount":
          _account = new CheckingAccount(_name, _startingAmount, _startingDate);
          break;
        case "CreditCard":
          _account = new CreditCard(_name, _startingAmount, _startingDate);
          break;

      }
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
      nameTb.Text = _name;
      balanceTb.Text = _startingAmount.ToString();
      typeCb.SelectedItem = _type;
      startingDateDtp.Value = _startingDate;
    }
  }

  public class NewAccountAddedEventArgs : EventArgs
  {
    public AccountBase NewAccount { get; set; }
  }
}
