using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditBudgetTop : Form
  {
    private YearTop _year;
    public EditBudgetTop(YearTop year)
    {
      InitializeComponent();

      if (year != null)
      {
        _year = year;
      }
      else
      {
        _year = new YearTop();
      }

      accountsLv.MouseUp += new MouseEventHandler(accountsLv_MouseUp);
      incomeLv.MouseUp += new MouseEventHandler(incomeLv_MouseUp);
      hardBillsLv.MouseUp += new MouseEventHandler(annualHbLv_MouseUp);
      annualSbLv.MouseUp += new MouseEventHandler(annualSbLv_MouseUp);
      monthlySbLv.MouseUp += new MouseEventHandler(monthlySbLv_MouseUp);

      RefreshPage();
    }

    #region Private Helpers
    private void RefreshPage_Handler(object sender, EventArgs e)
    {
      RefreshPage();
    }

    private void RefreshPage()
    {
      accountsLv.Items.Clear();
      var accounts = _year.GetAccounts();
      foreach (var account in accounts)
      {
        ListViewItem lvi = new ListViewItem(account.Name);
        lvi.SubItems.Add(account.GetType().Name);
        lvi.SubItems.Add(account.BalanceHistory[account.StartingDate].ToString());
        accountsLv.Items.Add(lvi);
      }

      incomeLv.Items.Clear();
      var incomes = _year.GetIncomeSources();
      foreach (var incomeSrc in incomes)
      {
        ListViewItem lvi = new ListViewItem(incomeSrc.Name);
        lvi.SubItems.Add(incomeSrc.PaydayAmount.ToString());
        lvi.SubItems.Add(incomeSrc.PaydayFrequency.ToString());
        lvi.SubItems.Add(incomeSrc.DepositAccount.Name);
        incomeLv.Items.Add(lvi);
      }

      var hardBills = _year.GetHardBills();
      hardBillsLv.Items.Clear();
      foreach (var hardBill in hardBills)
      {
        ListViewItem lvi = new ListViewItem(hardBill.Name);
        lvi.SubItems.Add(hardBill.Amount.ToString());
        lvi.SubItems.Add(hardBill.Frequency.ToString());
        lvi.SubItems.Add(hardBill.PaymentAccount.Name);
        lvi.SubItems.Add(hardBill.FirstBillDue.ToString("d"));
        hardBillsLv.Items.Add(lvi);
      }

      annualSbLv.Items.Clear();
      var softBillGroups = _year.GetSoftBillGroups();
      foreach (var softBill in softBillGroups[0].SoftBills)
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.ToString());
        annualSbLv.Items.Add(lvi);
      }

      monthlySbLv.Items.Clear();
      foreach (var softBill in softBillGroups[1].SoftBills)
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.ToString());
        monthlySbLv.Items.Add(lvi);
      }

      decimal totalSalary = _year.AnnualIncome;
      decimal totalHb = _year.AnnualHardBillAmount;
      decimal totalSb = _year.AnnualSoftBillAmount;
      decimal totalBills = totalHb + totalSb;
      decimal totalDiff = totalSalary - totalBills;

      totSalaryTb.Text = totalSalary.ToString();
      totHardBillsTb.Text = totalHb.ToString();
      totSoftBillsTb.Text = totalSb.ToString();
      totBillsTb.Text = totalBills.ToString();
      totDiffTb.Text = totalDiff.ToString();
    }

    #endregion

    #region Account Stuff
    private void accountsLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (accountsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = accountsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (index > -1)
        {
          deleteAccount.Enabled = true;
        }
        else
        {
          deleteAccount.Enabled = false;
        }
        accountCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void addAccount_Click(object sender, EventArgs e)
    {
      var createNewGroup = new EditAccountForm();
      createNewGroup.NewAccountAdded += NewAccount_Added;
      createNewGroup.Show();
    }

    private void deleteAccount_Click(object sender, EventArgs e)
    {
      string accountSelected = accountsLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveAccount(accountSelected);
      RefreshPage();
    }

    private void NewAccount_Added(object sender, NewAccountAddedEventArgs e)
    {
      if (e.NewAccount != null)
      {
        _year.RemoveAccount(e.NewAccount.Name);
        _year.AddAccount(e.NewAccount);
      }
      RefreshPage();
    }
    #endregion

    #region Income Stuff
    private void incomeLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (incomeLv.Items.Count > 0)
        {
          ListViewItem selectedItem = incomeLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.GetAccounts().Count > 0)
        {
          incomeAdd.Enabled = true;
        }
        else
        {
          incomeAdd.Enabled = false;
        }

        if (index > -1)
        {
          incomeDelete.Enabled = true;
          incomeEdit.Enabled = true;
        }
        else
        {
          incomeDelete.Enabled = false;
          incomeEdit.Enabled = false;
        }
        incomeCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void incomeAdd_Click_1(object sender, EventArgs e)
    {
      var createNewIncome = new EditIncomeForm(null, _year);
      createNewIncome.NewIncomeAdded += NewIncome_Added;
      createNewIncome.Show();
    }

    private void incomeDelete_Click_1(object sender, EventArgs e)
    {
      string incomeSelected = incomeLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveIncomeSource(incomeSelected);
      RefreshPage();
    }

    private void incomeEdit_Click_1(object sender, EventArgs e)
    {
      string incomeSelected = incomeLv.SelectedItems[0].SubItems[0].Text;

      var createNewIncome = new EditIncomeForm(_year.GetIncomeSource(incomeSelected), _year);
      createNewIncome.NewIncomeAdded += RefreshPage_Handler;
      createNewIncome.Show();
    }

    private void NewIncome_Added(object sender, NewIncomeAddedEventArgs e)
    {
      if (e.NewIncome != null)
      {
        _year.RemoveIncomeSource(e.NewIncome.Name);
        _year.AddIncomeSource(e.NewIncome);
      }
      RefreshPage();
    }
    #endregion

    #region Annual Stuff
    private void annualHbLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (hardBillsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = hardBillsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.GetAccounts().Count > 0)
        {
          annualHbAdd.Enabled = true;
        }
        else
        {
          annualHbAdd.Enabled = false;
        }

        if (index > -1)
        {
          annualHbDelete.Enabled = true;
          annualHbEdit.Enabled = true;
        }
        else
        {
          annualHbDelete.Enabled = false;
          annualHbEdit.Enabled = false;
        }
        annualHbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void annualHbAdd_Click_1(object sender, EventArgs e)
    {
      var editHardBill = new EditHardBillForm(null, _year);
      editHardBill.NewHardBillAdded += NewAnnualHardBill_Added;
      editHardBill.Show();
    }
    private void annualHbDelete_Click_1(object sender, EventArgs e)
    {
      string hardBill = hardBillsLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveHardBill(hardBill);
      RefreshPage();
    }
    private void annualHbEdit_Click_1(object sender, EventArgs e)
    {
      string hardBill = hardBillsLv.SelectedItems[0].SubItems[0].Text;

      var editHardBill = new EditHardBillForm(_year.GetHardBill(hardBill), _year);
      editHardBill.NewHardBillAdded += RefreshPage_Handler;
      editHardBill.ShowDialog();
    }
    private void NewAnnualHardBill_Added(object sender, NewHardBillAddedEventArgs e)
    {
      if (e.NewHardBill != null)
      {
        _year.AddHardBill(e.NewHardBill);

      }
      RefreshPage();
    }

    private void annualSbLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (annualSbLv.Items.Count > 0)
        {
          ListViewItem selectedItem = annualSbLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.GetAccounts().Count > 0)
        {
          annualSbAdd.Enabled = true;
        }
        else
        {
          annualSbAdd.Enabled = false;
        }

        if (index > -1)
        {
          annualSbDelete.Enabled = true;
          annualSbEdit.Enabled = true;
        }
        else
        {
          annualSbDelete.Enabled = false;
          annualSbEdit.Enabled = false;
        }
        annualSbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void annualSbAdd_Click(object sender, EventArgs e)
    {
      var editSoftBill = new EditSoftBillForm(string.Empty, 0);
      editSoftBill.NewSoftBillAdded += NewAnnualSoftBill_Added;
      editSoftBill.Show();
    }
    private void annualSbDelete_Click(object sender, EventArgs e)
    {
      string name = annualSbLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveSoftBill(name);
      RefreshPage();
    }
    private void annualSbEdit_Click(object sender, EventArgs e)
    {
      string name = annualSbLv.SelectedItems[0].SubItems[0].Text;
      decimal amount = decimal.Parse(annualSbLv.SelectedItems[0].SubItems[1].Text);

      var editSoftBill = new EditSoftBillForm(name, amount);
      editSoftBill.NewSoftBillAdded += NewAnnualSoftBill_Added;
      editSoftBill.ShowDialog();
      RefreshPage();
    }
    private void NewAnnualSoftBill_Added(object sender, NewSoftBillAddedEventArgs e)
    {
      _year.AddSoftBill(e.Name, e.Amount, true);
      RefreshPage();
    }
    #endregion

    #region Monthly Stuff
    private void monthlySbLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (monthlySbLv.Items.Count > 0)
        {
          ListViewItem selectedItem = monthlySbLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.GetAccounts().Count > 0)
        {
          monthlySbAdd.Enabled = true;
        }
        else
        {
          monthlySbAdd.Enabled = false;
        }

        if (index > -1)
        {
          monthlySbDelete.Enabled = true;
          monthlySbEdit.Enabled = true;
        }
        else
        {
          monthlySbDelete.Enabled = false;
          monthlySbEdit.Enabled = false;
        }
        monthlySbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void monthlySbAdd_Click_1(object sender, EventArgs e)
    {
      var editSoftBill = new EditSoftBillForm(string.Empty, 0);
      editSoftBill.NewSoftBillAdded += NewMonthlySoftBill_Added;
      editSoftBill.Show();
    }

    private void monthlySbDelete_Click_1(object sender, EventArgs e)
    {
      string name = annualSbLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveSoftBill(name);
      RefreshPage();
    }

    private void monthlySbEdit_Click_1(object sender, EventArgs e)
    {
      string name = monthlySbLv.SelectedItems[0].SubItems[0].Text;
      decimal amount = decimal.Parse(annualSbLv.SelectedItems[0].SubItems[1].Text);

      var editSoftBill = new EditSoftBillForm(name, amount);
      editSoftBill.NewSoftBillAdded += NewMonthlySoftBill_Added;
      editSoftBill.Show();
    }

    private void NewMonthlySoftBill_Added(object sender, NewSoftBillAddedEventArgs e)
    {
      _year.AddSoftBill(e.Name, e.Amount, false);
      RefreshPage();
    }
    #endregion

    #region Buttons

    private void loadYearBtn_Click_1(object sender, EventArgs e)
    {
      var fileContent = string.Empty;

      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = @"C:\Users\Batman\budgets";
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          Properties.Settings.Default["BudgetFile"] = openFileDialog.FileName;
          Properties.Settings.Default.Save();

          _year = YearTop.LoadFromFile(openFileDialog.FileName);
          RefreshPage();
        }
      }
    }

    private void saveYearBtn_Click_1(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();

      saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1.FilterIndex = 2;
      saveFileDialog1.RestoreDirectory = true;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        Properties.Settings.Default["BudgetFile"] = saveFileDialog1.FileName;
        Properties.Settings.Default.Save();

        _year.SaveToFile(saveFileDialog1.FileName);
      }
    }

    private void manageMonthsBtn_Click_1(object sender, EventArgs e)
    {
      var manageBudget = new ManageBudget(_year);
      this.Close();
      manageBudget.Show();
    }

    #endregion

  }
}
