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
  public partial class EditSoftBillForm : Form
  {
    private string _name;
    private decimal _startingAmount;
    public event EventHandler<NewSoftBillAddedEventArgs> NewSoftBillAdded;

    public EditSoftBillForm(string name, decimal startingAmount)
    {
      InitializeComponent();

      _name = name;
      _startingAmount = startingAmount;
      RefreshForm();
    }
    private void RefreshForm()
    {
      nameTb.Text = _name;
      amountTb.Text = _startingAmount.ToString();
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _name = nameTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      if (amountTb.Text.Equals(string.Empty))
      {
        _startingAmount = 0;
      }
      else
      {
        _startingAmount = Decimal.Parse(amountTb.Text);
      }
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewSoftBillAddedEventArgs args = new NewSoftBillAddedEventArgs();
      args.Name = _name;
      args.Amount = _startingAmount;
      OnNewSoftBillAdded(args);

      this.Close();
    }
    protected virtual void OnNewSoftBillAdded(NewSoftBillAddedEventArgs e)
    {
      NewSoftBillAdded?.Invoke(this, e);
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
  public class NewSoftBillAddedEventArgs : EventArgs
  {
    public string Name { get; set; }
    public decimal Amount { get; set; }
  }
}
