using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditSoftBillForm : Form
  {
    public event EventHandler<NewSoftBillAddedEventArgs> NewSoftBillAdded;
    private string _name;
    private decimal _amount;
    public EditSoftBillForm(string name, decimal amount)
    {
      InitializeComponent();
      nameTb.Text = name;
      amountTb.Text = amount.ToString();
    }
    private void saveBtn_Click_1(object sender, EventArgs e)
    {
      NewSoftBillAddedEventArgs args = new NewSoftBillAddedEventArgs();

      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _amount = amount;
      }
      else
      {
        amountTb.Text = _amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
      _name = nameTb.Text;

      args.Name = _name;
      args.Amount = _amount;
      OnNewSoftBillAdded(args);

      this.Close();
    }
    private void cancelBtn_Click_1(object sender, EventArgs e)
    {
      this.Close();
    }

    protected virtual void OnNewSoftBillAdded(NewSoftBillAddedEventArgs e)
    {
      NewSoftBillAdded?.Invoke(this, e);
    }
  }
  public class NewSoftBillAddedEventArgs : EventArgs
  {
    public string Name{ get; set; }
    public decimal Amount { get; set; }
  }
}
