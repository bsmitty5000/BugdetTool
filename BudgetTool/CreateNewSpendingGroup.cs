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
  public partial class CreateNewSpendingGroup : Form
  {
    public CreateNewSpendingGroup()
    {
      InitializeComponent();
    }

    public CreateNewSpendingGroup(SpendingCategory spendingGroup)
    {
      InitializeComponent();

      groupNameTb.Text = spendingGroup.Name;
      startingAmtTb.Text = spendingGroup.Amount.ToString();
      annualGroupRbtn.Checked = spendingGroup.Annual;
    }

    private void addGroupBtn_Click(object sender, EventArgs e)
    {
      string groupName = groupNameTb.Text;

      if(!checkGroupName(groupName))
      {
        throw new ArgumentException("Group Name Invalid");
      }

      decimal amount;
      if(!Decimal.TryParse(startingAmtTb.Text, out amount))
      {
        throw new ArgumentException("Invalid Amount Format");
      }

      SpendingCategory newGroup = new SpendingCategory(groupName, amount, annualGroupRbtn.Checked);
      NewGroupAddedEventArgs args = new NewGroupAddedEventArgs();
      args.NewGroup = newGroup;
      OnNewGroupAdded(args);

      this.Close();
    }

    protected virtual void OnNewGroupAdded(NewGroupAddedEventArgs e)
    {
      NewGroupAdded?.Invoke(this, e);
    }

    private bool checkGroupName(string groupName)
    {
      if(groupName.Equals(string.Empty) || groupName.Length > 25)
      {
        return false;
      }

      return true;
    }

    public event EventHandler<NewGroupAddedEventArgs> NewGroupAdded;

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      NewGroupAddedEventArgs args = new NewGroupAddedEventArgs();
      args.NewGroup = null;
      OnNewGroupAdded(args);
      this.Close();
    }
  }

  public class NewGroupAddedEventArgs : EventArgs
  {
    public SpendingCategory NewGroup { get; set; }
  }
}
