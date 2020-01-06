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
  public enum Months
  {
    January     = 0x1,
    February    = 0x2,
    March       = 0x4,
    April       = 0x8,
    May         = 0x10,
    June        = 0x20,
    July        = 0x40,
    August      = 0x80,
    September   = 0x100,
    October     = 0x200,
    November    = 0x400,
    December    = 0x800,
    All         = 0xFFF,
    Annual      = 0x1000
  }

  public partial class EditSoftBillForm : Form
  {
    private YearTop _year;
    private SoftBill _softBill;
    public event EventHandler<NewSoftBillAddedEventArgs> NewSoftBillAdded;
    private int _monthMask;

    public EditSoftBillForm(SoftBill softBill, YearTop year)
    {
      InitializeComponent();

      if (softBill != null)
      {
        _softBill = softBill;
      }
      else
      {
        _softBill = new SoftBill();
      }

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      Array Values = System.Enum.GetValues(typeof(Months));

      foreach (int Value in Values)
      {
        string Display = Enum.GetName(typeof(Months), Value);

        monthsClb.Items.Add(Display);
      }
      monthsClb.SetItemChecked(12, true);

      RefreshForm();
    }
    private void RefreshForm()
    {
      nameTb.Text = _softBill.Name;
      amountTb.Text = _softBill.Amount.ToString();
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _softBill.Name = nameTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      _softBill.Amount = Decimal.Parse(amountTb.Text);
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewSoftBillAddedEventArgs args = new NewSoftBillAddedEventArgs();
      args.NewSoftBill = _softBill;
      args.MonthMask = _monthMask;
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

    private void monthsClb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _monthMask = 0;
      Months months;
      foreach (var item in monthsClb.CheckedItems)
      {
        Enum.TryParse(item.ToString(), out months);
        _monthMask |= (int)months;
      }
    }
  }
  public class NewSoftBillAddedEventArgs : EventArgs
  {
    public SoftBill NewSoftBill { get; set; }
    public int MonthMask { get; set; }
  }
}
