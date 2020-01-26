using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditAccountForm : Form
  {
    public event EventHandler<NewAccountAddedEventArgs> NewAccountAdded;
    public EditAccountForm()
    {
      InitializeComponent();

      //todo: use reflection to get this?
      string[] AccountTypes = new string[] { "CheckingAccount", "CreditCard" };
      typeCb.Items.AddRange(AccountTypes);

      nameTb.Text = string.Empty;
      balanceTb.Text = 0.ToString();
      typeCb.SelectedItem = AccountTypes[0];
      startingDateDtp.Value = DateTime.Today;

    }
    private void saveBtn_Click(object sender, EventArgs e)
    {
      decimal startingAmount = 0;
      if (!decimal.TryParse(balanceTb.Text, out startingAmount))
      {
        balanceTb.Text = 0.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }

      DateTime startingDate = startingDateDtp.Value;

      string name = nameTb.Text;

      AccountBase account = null;
      string type = typeCb.SelectedItem.ToString();
      switch (type)
      {
        case "CheckingAccount":
          account = new CheckingAccount(name, startingAmount, startingDate);
          break;
        case "CreditCard":
          account = new CreditCard(name, startingAmount, startingDate);
          break;

      }
      NewAccountAddedEventArgs args = new NewAccountAddedEventArgs();
      args.NewAccount = account;
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
  }

  public class NewAccountAddedEventArgs : EventArgs
  {
    public AccountBase NewAccount { get; set; }
  }
}
