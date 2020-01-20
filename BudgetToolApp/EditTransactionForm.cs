using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditTransactionForm : Form
  {
    private SoftBillTransaction _sbt;
    private YearTop _year;
    private AccountBase _selectedAccount;
    private DateTime _selectedDate;
    private bool _eventsOn;
    private bool _annualGroup;
    public event EventHandler<NewTransactionEventArgs> NewTransactionAdded;

    public EditTransactionForm(SoftBillTransaction sbt, AccountBase account, YearTop year)
    {
      InitializeComponent();

      if(year == null)
      {
        throw new ArgumentException("Year must be initialized.");
      }

      _year = year;

      if(sbt == null)
      {
        _sbt = _year.GetSoftBillTransaction(string.Empty, 0, DateTime.Today.Month);
      }
      else
      {
        _sbt = sbt;
      }

      UpdateTpl();
    }

    private void UpdateTpl()
    {
      int i = 0;
      _eventsOn = false;
      foreach (var kvp in _sbt.SoftGroupSplit)
      {
        softBillSplitTpl.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        Label lblTitle = new Label();
        lblTitle.Text = string.Format("{0}:", kvp.Key);
        lblTitle.TabIndex = (i * 2);
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        softBillSplitTpl.Controls.Add(lblTitle, 0, i);

        TextBox txtValue = new TextBox();
        txtValue.TabIndex = (i * 2) + 1;
        txtValue.Margin = new Padding(0);
        txtValue.Dock = DockStyle.Fill;
        txtValue.TextChanged += new EventHandler(SoftGroupSplit_TextChanged);
        txtValue.Name = kvp.Key + "_tb";
        txtValue.Text = kvp.Value.ToString();
        softBillSplitTpl.Controls.Add(txtValue, 1, i);

        Button remainder = new Button();
        remainder.Text = "Use Remainder";
        remainder.TabIndex = (i * 2) + 2;
        remainder.Margin = new Padding(0);
        remainder.Dock = DockStyle.Fill;
        remainder.Click += new EventHandler(remainder_Click);
        remainder.Name = kvp.Key + "_btn";
        remainder.AutoSize = true;
        softBillSplitTpl.Controls.Add(remainder, 2, i);

        i++;
      }
      _eventsOn = true;
    }

    private void remainder_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
      string sbKey = tbpKey.Split('_')[0];
      foreach (var sub in _sbt.SoftGroupSplit.Values)
      {
        currentTotal += sub;
      }

      decimal remainderTotal = _sbt.Amount - currentTotal;
      softBillSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
      _sbt.SoftGroupSplit[sbKey] = remainderTotal;
    }

    private void SoftGroupSplit_TextChanged(object sender, EventArgs e)
    {
      if (!_eventsOn)
        return;

      TextBox textBox = (TextBox)sender;
      string sbKey = textBox.Name.Split('_')[0];

      if (_sbt.SoftGroupSplit.ContainsKey(sbKey))
      {
        _sbt.SoftGroupSplit[sbKey] = Decimal.Parse(textBox.Text);
      }

    }
  }
  public class NewTransactionEventArgs : EventArgs
  {
    public Transaction NewTransaction { get; set; }
  }
}
