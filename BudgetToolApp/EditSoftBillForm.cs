using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditSoftBillForm : Form
  {
    private SoftBill _sb;
    public event EventHandler<NewSoftBillAddedEventArgs> NewSoftBillAdded;

    public EditSoftBillForm(SoftBill sb)
    {
      InitializeComponent();

      if(sb == null)
      {
        _sb = new SoftBill();
      }
      else
      {
        _sb = sb;
      }
      nameTb.Text = _sb.Name;
      amountTb.Text = _sb.AmountBudgeted.ToString();
    }
    private void saveBtn_Click_1(object sender, EventArgs e)
    {
      NewSoftBillAddedEventArgs args = new NewSoftBillAddedEventArgs();

      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _sb.AmountBudgeted = amount;
      }
      else
      {
        amountTb.Text = _sb.AmountBudgeted.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
      _sb.Name = nameTb.Text;

      args.NewSoftBill = _sb;
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
    public SoftBill NewSoftBill { get; set; }
  }
}
