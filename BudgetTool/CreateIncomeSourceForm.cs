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

namespace BudgetTool
{
  public partial class CreateIncomeSourceForm : Form
  {
    public CreateIncomeSourceForm()
    {
      InitializeComponent();

      Array Values = System.Enum.GetValues(typeof(IncomeFrequencyEnum));

      foreach (int Value in Values)
      {
        string Display = Enum.GetName(typeof(IncomeFrequencyEnum), Value);

        incomeFreqCb.Items.Add(Display);
      }
    }
    public CreateIncomeSourceForm(Income incomeSource)
    {
      InitializeComponent();

      Array Values = System.Enum.GetValues(typeof(IncomeFrequencyEnum));

      foreach (int Value in Values)
      {
        string Display = Enum.GetName(typeof(IncomeFrequencyEnum), Value);

        incomeFreqCb.Items.Add(Display);
      }

      incomeNameTb.Text = incomeSource.Name;
      unitAmtTb.Text = incomeSource.UnitAmount.ToString();
      incomeFreqCb.SelectedItem = incomeSource.IncomeFrequency.ToString();
    }

    protected virtual void OnNewIncomeAdded(NewIncomeAddedEventArgs e)
    {
      NewIncomeAdded?.Invoke(this, e);
    }

    public event EventHandler<NewIncomeAddedEventArgs> NewIncomeAdded;

    private void addIncomeSrcBtn_Click(object sender, EventArgs e)
    {
      Income newIncomeSource = new Income();

      newIncomeSource.Name = incomeNameTb.Text;

      decimal unitAmount;
      if (!Decimal.TryParse(unitAmtTb.Text, out unitAmount))
      {
        throw new ArgumentException("Invalid Amount Format");
      }
      newIncomeSource.UnitAmount = unitAmount;

      IncomeFrequencyEnum freq;
      if(!Enum.TryParse(incomeFreqCb.SelectedItem.ToString(), out freq))
      {
        throw new FormatException("Income frequency not found.");
      }
      newIncomeSource.IncomeFrequency = freq;

      NewIncomeAddedEventArgs args = new NewIncomeAddedEventArgs();
      args.NewIncomeSrc = newIncomeSource;
      OnNewIncomeAdded(args);

      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      NewIncomeAddedEventArgs args = new NewIncomeAddedEventArgs();
      args.NewIncomeSrc = null;
      OnNewIncomeAdded(args);

      this.Close();
    }
  }

  public class NewIncomeAddedEventArgs : EventArgs
  {
    public Income NewIncomeSrc { get; set; }
  }
}
