namespace BudgetToolGui
{
  partial class ManageYearFrom
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.incomeLv = new System.Windows.Forms.ListView();
      this.IncomeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.IncomeAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.IncomeFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.IncomeDepositAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.accountsLv = new System.Windows.Forms.ListView();
      this.AccountsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AccountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AccountBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.accountCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.addAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.incomeCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.incomeAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.incomeDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.incomeEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.loadYearBtn = new System.Windows.Forms.Button();
      this.saveYearBtn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.annualHbLv = new System.Windows.Forms.ListView();
      this.AnnualHbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AnnualHbAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AnnualHbDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AnnualHbPaymentAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label5 = new System.Windows.Forms.Label();
      this.annualSbLv = new System.Windows.Forms.ListView();
      this.AnnualSbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AnnualSbAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.annualHbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.annualHbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.annualHbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.annualHbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.annualSbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.annualSbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.annualSbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.annualSbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbLv = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label6 = new System.Windows.Forms.Label();
      this.monthlyHbLv = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.monthlyHbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.monthlyHbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlyHbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlyHbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.monthlySbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.manageMonthsBtn = new System.Windows.Forms.Button();
      this.accountCms.SuspendLayout();
      this.incomeCms.SuspendLayout();
      this.annualHbCms.SuspendLayout();
      this.annualSbCms.SuspendLayout();
      this.monthlyHbCms.SuspendLayout();
      this.monthlySbCms.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Accounts";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 147);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Income";
      // 
      // incomeLv
      // 
      this.incomeLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IncomeName,
            this.IncomeAmount,
            this.IncomeFreq,
            this.IncomeDepositAccount});
      this.incomeLv.HideSelection = false;
      this.incomeLv.Location = new System.Drawing.Point(16, 164);
      this.incomeLv.Name = "incomeLv";
      this.incomeLv.Size = new System.Drawing.Size(294, 97);
      this.incomeLv.TabIndex = 4;
      this.incomeLv.UseCompatibleStateImageBehavior = false;
      this.incomeLv.View = System.Windows.Forms.View.Details;
      // 
      // IncomeName
      // 
      this.IncomeName.Text = "Name";
      this.IncomeName.Width = 86;
      // 
      // IncomeAmount
      // 
      this.IncomeAmount.Text = "Amount";
      // 
      // IncomeFreq
      // 
      this.IncomeFreq.Text = "Freq";
      this.IncomeFreq.Width = 51;
      // 
      // IncomeDepositAccount
      // 
      this.IncomeDepositAccount.Text = "DepositAccount";
      this.IncomeDepositAccount.Width = 89;
      // 
      // accountsLv
      // 
      this.accountsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountsName,
            this.AccountType,
            this.AccountBalance});
      this.accountsLv.HideSelection = false;
      this.accountsLv.Location = new System.Drawing.Point(16, 28);
      this.accountsLv.Name = "accountsLv";
      this.accountsLv.Size = new System.Drawing.Size(294, 97);
      this.accountsLv.TabIndex = 5;
      this.accountsLv.UseCompatibleStateImageBehavior = false;
      this.accountsLv.View = System.Windows.Forms.View.Details;
      // 
      // AccountsName
      // 
      this.AccountsName.Text = "Name";
      this.AccountsName.Width = 137;
      // 
      // AccountType
      // 
      this.AccountType.Text = "Type";
      this.AccountType.Width = 87;
      // 
      // AccountBalance
      // 
      this.AccountBalance.Text = "Balance";
      // 
      // accountCms
      // 
      this.accountCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccount,
            this.deleteAccount});
      this.accountCms.Name = "accountCms";
      this.accountCms.Size = new System.Drawing.Size(181, 70);
      // 
      // addAccount
      // 
      this.addAccount.Name = "addAccount";
      this.addAccount.Size = new System.Drawing.Size(107, 22);
      this.addAccount.Text = "Add";
      this.addAccount.Click += new System.EventHandler(this.addAccount_Click);
      // 
      // deleteAccount
      // 
      this.deleteAccount.Name = "deleteAccount";
      this.deleteAccount.Size = new System.Drawing.Size(107, 22);
      this.deleteAccount.Text = "Delete";
      this.deleteAccount.Click += new System.EventHandler(this.deleteAccount_Click);
      // 
      // incomeCms
      // 
      this.incomeCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomeAdd,
            this.incomeDelete,
            this.incomeEdit});
      this.incomeCms.Name = "incomeCms";
      this.incomeCms.Size = new System.Drawing.Size(108, 70);
      // 
      // incomeAdd
      // 
      this.incomeAdd.Name = "incomeAdd";
      this.incomeAdd.Size = new System.Drawing.Size(107, 22);
      this.incomeAdd.Text = "Add";
      this.incomeAdd.Click += new System.EventHandler(this.incomeAdd_Click);
      // 
      // incomeDelete
      // 
      this.incomeDelete.Name = "incomeDelete";
      this.incomeDelete.Size = new System.Drawing.Size(107, 22);
      this.incomeDelete.Text = "Delete";
      this.incomeDelete.Click += new System.EventHandler(this.incomeDelete_Click);
      // 
      // incomeEdit
      // 
      this.incomeEdit.Name = "incomeEdit";
      this.incomeEdit.Size = new System.Drawing.Size(107, 22);
      this.incomeEdit.Text = "Edit";
      this.incomeEdit.Click += new System.EventHandler(this.incomeEdit_Click);
      // 
      // loadYearBtn
      // 
      this.loadYearBtn.Location = new System.Drawing.Point(16, 508);
      this.loadYearBtn.Name = "loadYearBtn";
      this.loadYearBtn.Size = new System.Drawing.Size(75, 23);
      this.loadYearBtn.TabIndex = 6;
      this.loadYearBtn.Text = "Load Year";
      this.loadYearBtn.UseVisualStyleBackColor = true;
      this.loadYearBtn.Click += new System.EventHandler(this.loadYearBtn_Click);
      // 
      // saveYearBtn
      // 
      this.saveYearBtn.Location = new System.Drawing.Point(97, 508);
      this.saveYearBtn.Name = "saveYearBtn";
      this.saveYearBtn.Size = new System.Drawing.Size(75, 23);
      this.saveYearBtn.TabIndex = 7;
      this.saveYearBtn.Text = "Save Year";
      this.saveYearBtn.UseVisualStyleBackColor = true;
      this.saveYearBtn.Click += new System.EventHandler(this.saveYearBtn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(339, 11);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(86, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Annual Summary";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(339, 28);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(51, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Hard Bills";
      // 
      // annualHbLv
      // 
      this.annualHbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AnnualHbName,
            this.AnnualHbAmount,
            this.AnnualHbDay,
            this.AnnualHbPaymentAccount});
      this.annualHbLv.HideSelection = false;
      this.annualHbLv.Location = new System.Drawing.Point(342, 44);
      this.annualHbLv.Name = "annualHbLv";
      this.annualHbLv.Size = new System.Drawing.Size(321, 97);
      this.annualHbLv.TabIndex = 10;
      this.annualHbLv.UseCompatibleStateImageBehavior = false;
      this.annualHbLv.View = System.Windows.Forms.View.Details;
      // 
      // AnnualHbName
      // 
      this.AnnualHbName.Text = "Name";
      this.AnnualHbName.Width = 113;
      // 
      // AnnualHbAmount
      // 
      this.AnnualHbAmount.Text = "Amount";
      this.AnnualHbAmount.Width = 48;
      // 
      // AnnualHbDay
      // 
      this.AnnualHbDay.Text = "Pay Day";
      this.AnnualHbDay.Width = 52;
      // 
      // AnnualHbPaymentAccount
      // 
      this.AnnualHbPaymentAccount.Text = "Payment Account";
      this.AnnualHbPaymentAccount.Width = 99;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(339, 147);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(47, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Soft Bills";
      // 
      // annualSbLv
      // 
      this.annualSbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AnnualSbName,
            this.AnnualSbAmount});
      this.annualSbLv.HideSelection = false;
      this.annualSbLv.Location = new System.Drawing.Point(342, 164);
      this.annualSbLv.Name = "annualSbLv";
      this.annualSbLv.Size = new System.Drawing.Size(321, 97);
      this.annualSbLv.TabIndex = 12;
      this.annualSbLv.UseCompatibleStateImageBehavior = false;
      this.annualSbLv.View = System.Windows.Forms.View.Details;
      // 
      // AnnualSbName
      // 
      this.AnnualSbName.Text = "Name";
      this.AnnualSbName.Width = 245;
      // 
      // AnnualSbAmount
      // 
      this.AnnualSbAmount.Text = "Amount";
      // 
      // annualHbCms
      // 
      this.annualHbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annualHbAdd,
            this.annualHbDelete,
            this.annualHbEdit});
      this.annualHbCms.Name = "annualHbCms";
      this.annualHbCms.Size = new System.Drawing.Size(108, 70);
      // 
      // annualHbAdd
      // 
      this.annualHbAdd.Name = "annualHbAdd";
      this.annualHbAdd.Size = new System.Drawing.Size(107, 22);
      this.annualHbAdd.Text = "Add";
      this.annualHbAdd.Click += new System.EventHandler(this.annualHbAdd_Click);
      // 
      // annualHbDelete
      // 
      this.annualHbDelete.Name = "annualHbDelete";
      this.annualHbDelete.Size = new System.Drawing.Size(107, 22);
      this.annualHbDelete.Text = "Delete";
      this.annualHbDelete.Click += new System.EventHandler(this.annualHbDelete_Click);
      // 
      // annualHbEdit
      // 
      this.annualHbEdit.Name = "annualHbEdit";
      this.annualHbEdit.Size = new System.Drawing.Size(107, 22);
      this.annualHbEdit.Text = "Edit";
      this.annualHbEdit.Click += new System.EventHandler(this.annualHbEdit_Click);
      // 
      // annualSbCms
      // 
      this.annualSbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annualSbAdd,
            this.annualSbDelete,
            this.annualSbEdit});
      this.annualSbCms.Name = "annualHbCms";
      this.annualSbCms.Size = new System.Drawing.Size(108, 70);
      // 
      // annualSbAdd
      // 
      this.annualSbAdd.Name = "annualSbAdd";
      this.annualSbAdd.Size = new System.Drawing.Size(107, 22);
      this.annualSbAdd.Text = "Add";
      this.annualSbAdd.Click += new System.EventHandler(this.annualSbAdd_Click_1);
      // 
      // annualSbDelete
      // 
      this.annualSbDelete.Name = "annualSbDelete";
      this.annualSbDelete.Size = new System.Drawing.Size(107, 22);
      this.annualSbDelete.Text = "Delete";
      this.annualSbDelete.Click += new System.EventHandler(this.annualSbDelete_Click_1);
      // 
      // annualSbEdit
      // 
      this.annualSbEdit.Name = "annualSbEdit";
      this.annualSbEdit.Size = new System.Drawing.Size(107, 22);
      this.annualSbEdit.Text = "Edit";
      this.annualSbEdit.Click += new System.EventHandler(this.annualSbEdit_Click_1);
      // 
      // monthlySbLv
      // 
      this.monthlySbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.monthlySbLv.HideSelection = false;
      this.monthlySbLv.Location = new System.Drawing.Point(342, 427);
      this.monthlySbLv.Name = "monthlySbLv";
      this.monthlySbLv.Size = new System.Drawing.Size(321, 97);
      this.monthlySbLv.TabIndex = 17;
      this.monthlySbLv.UseCompatibleStateImageBehavior = false;
      this.monthlySbLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 245;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Amount";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(339, 410);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(47, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "Soft Bills";
      // 
      // monthlyHbLv
      // 
      this.monthlyHbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
      this.monthlyHbLv.HideSelection = false;
      this.monthlyHbLv.Location = new System.Drawing.Point(342, 307);
      this.monthlyHbLv.Name = "monthlyHbLv";
      this.monthlyHbLv.Size = new System.Drawing.Size(321, 97);
      this.monthlyHbLv.TabIndex = 15;
      this.monthlyHbLv.UseCompatibleStateImageBehavior = false;
      this.monthlyHbLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Name";
      this.columnHeader3.Width = 105;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Amount";
      this.columnHeader4.Width = 50;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Pay Day";
      this.columnHeader5.Width = 54;
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "Payment Account";
      this.columnHeader6.Width = 99;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(339, 291);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(51, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = "Hard Bills";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(339, 274);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(90, 13);
      this.label8.TabIndex = 13;
      this.label8.Text = "Monthly Summary";
      // 
      // monthlyHbCms
      // 
      this.monthlyHbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyHbAdd,
            this.monthlyHbDelete,
            this.monthlyHbEdit});
      this.monthlyHbCms.Name = "annualHbCms";
      this.monthlyHbCms.Size = new System.Drawing.Size(108, 70);
      // 
      // monthlyHbAdd
      // 
      this.monthlyHbAdd.Name = "monthlyHbAdd";
      this.monthlyHbAdd.Size = new System.Drawing.Size(107, 22);
      this.monthlyHbAdd.Text = "Add";
      this.monthlyHbAdd.Click += new System.EventHandler(this.monthlyHbAdd_Click);
      // 
      // monthlyHbDelete
      // 
      this.monthlyHbDelete.Name = "monthlyHbDelete";
      this.monthlyHbDelete.Size = new System.Drawing.Size(107, 22);
      this.monthlyHbDelete.Text = "Delete";
      this.monthlyHbDelete.Click += new System.EventHandler(this.monthlyHbDelete_Click);
      // 
      // monthlyHbEdit
      // 
      this.monthlyHbEdit.Name = "monthlyHbEdit";
      this.monthlyHbEdit.Size = new System.Drawing.Size(107, 22);
      this.monthlyHbEdit.Text = "Edit";
      this.monthlyHbEdit.Click += new System.EventHandler(this.monthlyHbEdit_Click);
      // 
      // monthlySbCms
      // 
      this.monthlySbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlySbAdd,
            this.monthlySbDelete,
            this.monthlySbEdit});
      this.monthlySbCms.Name = "annualHbCms";
      this.monthlySbCms.Size = new System.Drawing.Size(108, 70);
      // 
      // monthlySbAdd
      // 
      this.monthlySbAdd.Name = "monthlySbAdd";
      this.monthlySbAdd.Size = new System.Drawing.Size(107, 22);
      this.monthlySbAdd.Text = "Add";
      this.monthlySbAdd.Click += new System.EventHandler(this.monthlySbAdd_Click);
      // 
      // monthlySbDelete
      // 
      this.monthlySbDelete.Name = "monthlySbDelete";
      this.monthlySbDelete.Size = new System.Drawing.Size(107, 22);
      this.monthlySbDelete.Text = "Delete";
      this.monthlySbDelete.Click += new System.EventHandler(this.monthlySbDelete_Click);
      // 
      // monthlySbEdit
      // 
      this.monthlySbEdit.Name = "monthlySbEdit";
      this.monthlySbEdit.Size = new System.Drawing.Size(107, 22);
      this.monthlySbEdit.Text = "Edit";
      this.monthlySbEdit.Click += new System.EventHandler(this.monthlySbEdit_Click);
      // 
      // manageMonthsBtn
      // 
      this.manageMonthsBtn.Location = new System.Drawing.Point(178, 508);
      this.manageMonthsBtn.Name = "manageMonthsBtn";
      this.manageMonthsBtn.Size = new System.Drawing.Size(75, 23);
      this.manageMonthsBtn.TabIndex = 18;
      this.manageMonthsBtn.Text = "Manage Months";
      this.manageMonthsBtn.UseVisualStyleBackColor = true;
      this.manageMonthsBtn.Click += new System.EventHandler(this.manageMonthsBtn_Click);
      // 
      // ManageYearFrom
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1035, 543);
      this.Controls.Add(this.manageMonthsBtn);
      this.Controls.Add(this.monthlySbLv);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.monthlyHbLv);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.annualSbLv);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.annualHbLv);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.saveYearBtn);
      this.Controls.Add(this.loadYearBtn);
      this.Controls.Add(this.accountsLv);
      this.Controls.Add(this.incomeLv);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "ManageYearFrom";
      this.Text = "ManageYearFrom";
      this.accountCms.ResumeLayout(false);
      this.incomeCms.ResumeLayout(false);
      this.annualHbCms.ResumeLayout(false);
      this.annualSbCms.ResumeLayout(false);
      this.monthlyHbCms.ResumeLayout(false);
      this.monthlySbCms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView incomeLv;
    private System.Windows.Forms.ListView accountsLv;
    private System.Windows.Forms.ColumnHeader AccountsName;
    private System.Windows.Forms.ColumnHeader AccountType;
    private System.Windows.Forms.ColumnHeader AccountBalance;
    private System.Windows.Forms.ContextMenuStrip accountCms;
    private System.Windows.Forms.ToolStripMenuItem addAccount;
    private System.Windows.Forms.ToolStripMenuItem deleteAccount;
        private System.Windows.Forms.ColumnHeader IncomeName;
        private System.Windows.Forms.ColumnHeader IncomeAmount;
        private System.Windows.Forms.ColumnHeader IncomeFreq;
        private System.Windows.Forms.ColumnHeader IncomeDepositAccount;
        private System.Windows.Forms.ContextMenuStrip incomeCms;
        private System.Windows.Forms.ToolStripMenuItem incomeAdd;
        private System.Windows.Forms.ToolStripMenuItem incomeDelete;
        private System.Windows.Forms.ToolStripMenuItem incomeEdit;
        private System.Windows.Forms.Button loadYearBtn;
        private System.Windows.Forms.Button saveYearBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView annualHbLv;
        private System.Windows.Forms.ColumnHeader AnnualHbName;
        private System.Windows.Forms.ColumnHeader AnnualHbAmount;
        private System.Windows.Forms.ColumnHeader AnnualHbDay;
        private System.Windows.Forms.ColumnHeader AnnualHbPaymentAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView annualSbLv;
        private System.Windows.Forms.ColumnHeader AnnualSbName;
        private System.Windows.Forms.ColumnHeader AnnualSbAmount;
        private System.Windows.Forms.ContextMenuStrip annualHbCms;
        private System.Windows.Forms.ToolStripMenuItem annualHbAdd;
        private System.Windows.Forms.ToolStripMenuItem annualHbDelete;
        private System.Windows.Forms.ToolStripMenuItem annualHbEdit;
        private System.Windows.Forms.ContextMenuStrip annualSbCms;
        private System.Windows.Forms.ToolStripMenuItem annualSbAdd;
        private System.Windows.Forms.ToolStripMenuItem annualSbDelete;
        private System.Windows.Forms.ToolStripMenuItem annualSbEdit;
        private System.Windows.Forms.ListView monthlySbLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView monthlyHbLv;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip monthlyHbCms;
        private System.Windows.Forms.ToolStripMenuItem monthlyHbAdd;
        private System.Windows.Forms.ToolStripMenuItem monthlyHbDelete;
        private System.Windows.Forms.ToolStripMenuItem monthlyHbEdit;
        private System.Windows.Forms.ContextMenuStrip monthlySbCms;
        private System.Windows.Forms.ToolStripMenuItem monthlySbAdd;
        private System.Windows.Forms.ToolStripMenuItem monthlySbDelete;
        private System.Windows.Forms.ToolStripMenuItem monthlySbEdit;
        private System.Windows.Forms.Button manageMonthsBtn;
    }
}