using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BudgetToolLib;

namespace BudgetToolGui
{
  public partial class ManageYearFrom : Form
  {
    private YearTop _year;
    public ManageYearFrom(YearTop year)
    {
      InitializeComponent();

      if(year != null)
      {
        _year = year;
      }
      else
      {
        _year = new YearTop();
        _year.InitializeYear();
      }

      accountsLv.MouseUp += new MouseEventHandler(accountsLv_MouseUp);
      incomeLv.MouseUp += new MouseEventHandler(incomeLv_MouseUp);
      annualHbLv.MouseUp += new MouseEventHandler(annualHbLv_MouseUp);
      annualSbLv.MouseUp += new MouseEventHandler(annualSbLv_MouseUp);
      monthlyHbLv.MouseUp += new MouseEventHandler(monthlyHbLv_MouseUp);
      monthlySbLv.MouseUp += new MouseEventHandler(monthlySbLv_MouseUp);
    }

    #region Private Helpers

    private void RefreshPage()
    {
      accountsLv.Items.Clear();
      foreach (var account in _year.Accounts)
      {
        BalanceEntry lastEntry = account.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(account.Key);
        lvi.SubItems.Add(account.Value.GetType().Name);
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = account.Value;
        accountsLv.Items.Add(lvi);
      }

      incomeLv.Items.Clear();
      foreach (var incomeSrc in _year.IncomeSources)
      {
        ListViewItem lvi = new ListViewItem(incomeSrc.Key);
        lvi.SubItems.Add(incomeSrc.Value.PaydayAmount.ToString());
        lvi.SubItems.Add(incomeSrc.Value.PaydayFrequency.ToString());
        lvi.SubItems.Add(incomeSrc.Value.DepositAccount.Name);
        lvi.Tag = incomeSrc.Value;
        incomeLv.Items.Add(lvi);
      }

      annualHbLv.Items.Clear();
      foreach (var hardBill in _year.BudgetGroups[0].HardBills)
      {
        ListViewItem lvi = new ListViewItem(hardBill.Key);
        lvi.SubItems.Add(hardBill.Value.Amount.ToString());
        lvi.SubItems.Add(hardBill.Value.DayOfMonthPaid.ToString());
        lvi.SubItems.Add(hardBill.Value.PaymentAccount.Name);
        lvi.Tag = hardBill.Value;
        annualHbLv.Items.Add(lvi);
      }

      annualSbLv.Items.Clear();
      foreach (var softBill in _year.BudgetGroups[0].SoftBills)
      {
        BalanceEntry lastEntry = softBill.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = softBill.Value;
        annualSbLv.Items.Add(lvi);
      }

      monthlyHbLv.Items.Clear();
      /* for now just use first month group since forcing all months
       * to be the same
       * todo: if in the future months can have different bills this
       * logic needs to be udpated
       */
      foreach (var hardBill in _year.BudgetGroups[1].HardBills)
      {
        ListViewItem lvi = new ListViewItem(hardBill.Key);
        lvi.SubItems.Add(hardBill.Value.Amount.ToString());
        lvi.SubItems.Add(hardBill.Value.DayOfMonthPaid.ToString());
        lvi.SubItems.Add(hardBill.Value.PaymentAccount.Name);
        lvi.Tag = hardBill.Value;
        monthlyHbLv.Items.Add(lvi);
      }

      monthlySbLv.Items.Clear();
      foreach (var softBill in _year.BudgetGroups[1].SoftBills)
      {
        BalanceEntry lastEntry = softBill.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = softBill.Value;
        monthlySbLv.Items.Add(lvi);
      }
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
    private void deleteAccount_Click(object sender, EventArgs e)
    {
      AccountBase accountSelected = accountsLv.SelectedItems[0].Tag as AccountBase;
      _year.Accounts.Remove(accountSelected.Name);
      RefreshPage();
    }

    private void addAccount_Click(object sender, EventArgs e)
    {
      var createNewGroup = new EditAccountForm();
      createNewGroup.NewAccountAdded += NewAccount_Added;
      createNewGroup.Show();
    }
    private void NewAccount_Added(object sender, NewAccountAddedEventArgs e)
    {
      if (e.NewAccount != null)
      {
        _year.Accounts.Remove(e.NewAccount.Name);
        _year.Accounts.Add(e.NewAccount.Name, e.NewAccount);
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

        if(_year.Accounts.Count > 0)
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
    private void incomeAdd_Click(object sender, EventArgs e)
    {
      Income newIncome = new Income();

      var createNewIncome = new EditIncomeForm(newIncome, _year);
      createNewIncome.NewIncomeAdded += NewIncome_Added;
      createNewIncome.Show();
    }
    private void incomeDelete_Click(object sender, EventArgs e)
    {
      Income incomeSelected = incomeLv.SelectedItems[0].Tag as Income;
      _year.IncomeSources.Remove(incomeSelected.Name);
      RefreshPage();
    }
    private void incomeEdit_Click(object sender, EventArgs e)
    {
      Income incomeSelected = incomeLv.SelectedItems[0].Tag as Income;


      var createNewIncome = new EditIncomeForm(incomeSelected, _year);
      //createNewIncome.NewIncomeAdded += NewIncome_Added;
      createNewIncome.Show();
      RefreshPage();
    }
    private void NewIncome_Added(object sender, NewIncomeAddedEventArgs e)
    {
      if (e.NewIncome != null)
      {
        _year.IncomeSources.Remove(e.NewIncome.Name);
        _year.IncomeSources.Add(e.NewIncome.Name, e.NewIncome);
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
        if (annualHbLv.Items.Count > 0)
        {
          ListViewItem selectedItem = annualHbLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.Accounts.Count > 0)
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
    private void annualHbAdd_Click(object sender, EventArgs e)
    {
      HardBill hardBill = new HardBill();

      var editHardBill = new EditHardBillForm(hardBill, _year);
      editHardBill.NewHardBillAdded += NewAnnualHardBill_Added;
      editHardBill.Show();
    }
    private void annualHbDelete_Click(object sender, EventArgs e)
    {
      HardBill hardBill = annualHbLv.SelectedItems[0].Tag as HardBill;
      _year.RemoveHardBill(hardBill.Name, true);
      RefreshPage();
    }
    private void annualHbEdit_Click(object sender, EventArgs e)
    {
      HardBill hardBill = annualHbLv.SelectedItems[0].Tag as HardBill;

      var editHardBill = new EditHardBillForm(hardBill, _year);
      //editHardBill.NewHardBillAdded += NewAnnualHardBill_Added;
      editHardBill.ShowDialog();
      RefreshPage();
    }
    private void NewAnnualHardBill_Added(object sender, NewHardBillAddedEventArgs e)
    {
      if (e.NewHardBill != null)
      {
        _year.AddHardBill(e.NewHardBill, true);
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

        if (_year.Accounts.Count > 0)
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
    private void annualSbAdd_Click_1(object sender, EventArgs e)
    {
      var editSoftBill = new EditSoftBillForm(string.Empty, 0);
      editSoftBill.NewSoftBillAdded += NewAnnualSoftBill_Added;
      editSoftBill.Show();
    }
    private void annualSbDelete_Click_1(object sender, EventArgs e)
    {
      SoftBill softBill = annualSbLv.SelectedItems[0].Tag as SoftBill;
      _year.RemoveSoftBill(softBill.Name, true);
      RefreshPage();
    }
    private void annualSbEdit_Click_1(object sender, EventArgs e)
    {
      SoftBill softBill = annualSbLv.SelectedItems[0].Tag as SoftBill;

      var editSoftBill = new EditSoftBillForm(softBill.Name, softBill.BalanceHistory[0].Amount);
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
    private void monthlyHbLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (monthlyHbLv.Items.Count > 0)
        {
          ListViewItem selectedItem = monthlyHbLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.Accounts.Count > 0)
        {
          monthlyHbAdd.Enabled = true;
        }
        else
        {
          monthlyHbAdd.Enabled = false;
        }

        if (index > -1)
        {
          monthlyHbDelete.Enabled = true;
          monthlyHbEdit.Enabled = true;
        }
        else
        {
          monthlyHbDelete.Enabled = false;
          monthlyHbEdit.Enabled = false;
        }
        monthlyHbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void monthlyHbAdd_Click(object sender, EventArgs e)
    {
      HardBill hardBill = new HardBill();

      var editHardBill = new EditHardBillForm(hardBill, _year);
      editHardBill.NewHardBillAdded += NewMonthlyHardBill_Added;
      editHardBill.Show();
    }
    private void monthlyHbDelete_Click(object sender, EventArgs e)
    {
      HardBill hardBill = monthlyHbLv.SelectedItems[0].Tag as HardBill;
      _year.RemoveHardBill(hardBill.Name, true);
      RefreshPage();
    }
    private void monthlyHbEdit_Click(object sender, EventArgs e)
    {
      HardBill hardBill = monthlyHbLv.SelectedItems[0].Tag as HardBill;

      var editHardBill = new EditHardBillForm(hardBill, _year);
      //editHardBill.NewHardBillAdded += NewMonthlyHardBill_Added;
      editHardBill.ShowDialog();
      RefreshPage();
    }
    private void NewMonthlyHardBill_Added(object sender, NewHardBillAddedEventArgs e)
    {
      if (e.NewHardBill != null)
      {
        _year.AddHardBill(e.NewHardBill, false);
      }
      RefreshPage();
    }

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

        if (_year.Accounts.Count > 0)
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
    private void monthlySbAdd_Click(object sender, EventArgs e)
    {
      var editSoftBill = new EditSoftBillForm(string.Empty, 0);
      editSoftBill.NewSoftBillAdded += NewMonthlySoftBill_Added;
      editSoftBill.Show();
    }
    private void monthlySbDelete_Click(object sender, EventArgs e)
    {
      SoftBill softBill = monthlySbLv.SelectedItems[0].Tag as SoftBill;
      _year.RemoveSoftBill(softBill.Name, true);
      RefreshPage();
    }
    private void monthlySbEdit_Click(object sender, EventArgs e)
    {
      SoftBill softBill = monthlySbLv.SelectedItems[0].Tag as SoftBill;

      var editSoftBill = new EditSoftBillForm(softBill.Name, softBill.BalanceHistory[0].Amount);
      editSoftBill.NewSoftBillAdded += NewMonthlySoftBill_Added;
      editSoftBill.ShowDialog();
      RefreshPage();
    }
    private void NewMonthlySoftBill_Added(object sender, NewSoftBillAddedEventArgs e)
    {
      _year.AddSoftBill(e.Name, e.Amount, false);
      RefreshPage();
    }
    #endregion

    #region Buttons
    private void saveYearBtn_Click(object sender, EventArgs e)
    {
      Stream myStream;
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();

      saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1.FilterIndex = 2;
      saveFileDialog1.RestoreDirectory = true;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        if ((myStream = saveFileDialog1.OpenFile()) != null)
        {
          _year.SaveToFile(myStream);
          myStream.Close();
        }
      }
    }
    private void loadYearBtn_Click(object sender, EventArgs e)
    {
      var fileContent = string.Empty;
      var filePath = string.Empty;

      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = @"C:\Users\Batman\budgets";
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          //Get the path of specified file
          filePath = openFileDialog.FileName;

          //Read the contents of the file into a stream
          var fileStream = openFileDialog.OpenFile();

          _year = YearTop.LoadFromFile(fileStream);
          RefreshPage();
        }
      }
    }
    #endregion

    private void manageMonthsBtn_Click(object sender, EventArgs e)
    {
      var manageMonthsForm = new ManageMonthsForm(_year);
      manageMonthsForm.ShowDialog();
      RefreshPage();
    }
  }
}
