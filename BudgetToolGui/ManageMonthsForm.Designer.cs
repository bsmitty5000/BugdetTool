namespace BudgetToolGui
{
  partial class ManageMonthsForm
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
      this.monthlySbLv = new System.Windows.Forms.ListView();
      this.SoftBillsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SoftBillsStarting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SoftBillsCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label6 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.purchasesLv = new System.Windows.Forms.ListView();
      this.PurchasesMerchant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PurchasesAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.purchasesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.purchasesAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.doneBtn = new System.Windows.Forms.Button();
      this.accountsLv = new System.Windows.Forms.ListView();
      this.AccountsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AccountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AccountBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.todayDtp = new System.Windows.Forms.DateTimePicker();
      this.annualSbLv = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label4 = new System.Windows.Forms.Label();
      this.showAllPurchasesCb = new System.Windows.Forms.CheckBox();
      this.accountCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.manualCredit = new System.Windows.Forms.ToolStripMenuItem();
      this.manualDebit = new System.Windows.Forms.ToolStripMenuItem();
      this.addAnnual = new System.Windows.Forms.ToolStripMenuItem();
      this.label5 = new System.Windows.Forms.Label();
      this.monthlySbRemainingTb = new System.Windows.Forms.TextBox();
      this.annualSbRemainingTb = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.totalSbSnapshotTb = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.purchasesCms.SuspendLayout();
      this.accountCms.SuspendLayout();
      this.SuspendLayout();
      // 
      // monthlySbLv
      // 
      this.monthlySbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoftBillsName,
            this.SoftBillsStarting,
            this.SoftBillsCurrent});
      this.monthlySbLv.HideSelection = false;
      this.monthlySbLv.Location = new System.Drawing.Point(15, 84);
      this.monthlySbLv.Name = "monthlySbLv";
      this.monthlySbLv.Size = new System.Drawing.Size(279, 304);
      this.monthlySbLv.TabIndex = 19;
      this.monthlySbLv.UseCompatibleStateImageBehavior = false;
      this.monthlySbLv.View = System.Windows.Forms.View.Details;
      // 
      // SoftBillsName
      // 
      this.SoftBillsName.Text = "Name";
      this.SoftBillsName.Width = 146;
      // 
      // SoftBillsStarting
      // 
      this.SoftBillsStarting.Text = "Starting";
      this.SoftBillsStarting.Width = 82;
      // 
      // SoftBillsCurrent
      // 
      this.SoftBillsCurrent.Text = "Current";
      this.SoftBillsCurrent.Width = 93;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 67);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(87, 13);
      this.label6.TabIndex = 18;
      this.label6.Text = "Monthly Soft Bills";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(598, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(57, 13);
      this.label2.TabIndex = 21;
      this.label2.Text = "Purchases";
      // 
      // purchasesLv
      // 
      this.purchasesLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PurchasesMerchant,
            this.PurchasesAmount,
            this.PurchaseDate});
      this.purchasesLv.HideSelection = false;
      this.purchasesLv.Location = new System.Drawing.Point(601, 84);
      this.purchasesLv.Name = "purchasesLv";
      this.purchasesLv.Size = new System.Drawing.Size(319, 304);
      this.purchasesLv.TabIndex = 22;
      this.purchasesLv.UseCompatibleStateImageBehavior = false;
      this.purchasesLv.View = System.Windows.Forms.View.Details;
      // 
      // PurchasesMerchant
      // 
      this.PurchasesMerchant.Text = "Merchant";
      this.PurchasesMerchant.Width = 120;
      // 
      // PurchasesAmount
      // 
      this.PurchasesAmount.Text = "Amount";
      this.PurchasesAmount.Width = 92;
      // 
      // PurchaseDate
      // 
      this.PurchaseDate.Text = "Date";
      this.PurchaseDate.Width = 85;
      // 
      // purchasesCms
      // 
      this.purchasesCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.purchasesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesAdd,
            this.addAnnual,
            this.purchasesDelete,
            this.purchasesEdit});
      this.purchasesCms.Name = "annualHbCms";
      this.purchasesCms.Size = new System.Drawing.Size(145, 92);
      // 
      // purchasesAdd
      // 
      this.purchasesAdd.Name = "purchasesAdd";
      this.purchasesAdd.Size = new System.Drawing.Size(144, 22);
      this.purchasesAdd.Text = "Add Monthly";
      this.purchasesAdd.Click += new System.EventHandler(this.purchasesAdd_Click);
      // 
      // purchasesDelete
      // 
      this.purchasesDelete.Name = "purchasesDelete";
      this.purchasesDelete.Size = new System.Drawing.Size(144, 22);
      this.purchasesDelete.Text = "Delete";
      this.purchasesDelete.Click += new System.EventHandler(this.purchasesDelete_Click);
      // 
      // purchasesEdit
      // 
      this.purchasesEdit.Name = "purchasesEdit";
      this.purchasesEdit.Size = new System.Drawing.Size(144, 22);
      this.purchasesEdit.Text = "Edit";
      this.purchasesEdit.Click += new System.EventHandler(this.purchasesEdit_Click);
      // 
      // doneBtn
      // 
      this.doneBtn.Location = new System.Drawing.Point(12, 585);
      this.doneBtn.Name = "doneBtn";
      this.doneBtn.Size = new System.Drawing.Size(75, 23);
      this.doneBtn.TabIndex = 25;
      this.doneBtn.Text = "Done";
      this.doneBtn.UseVisualStyleBackColor = true;
      this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
      // 
      // accountsLv
      // 
      this.accountsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountsName,
            this.AccountType,
            this.AccountBalance});
      this.accountsLv.HideSelection = false;
      this.accountsLv.Location = new System.Drawing.Point(12, 472);
      this.accountsLv.Name = "accountsLv";
      this.accountsLv.Size = new System.Drawing.Size(282, 90);
      this.accountsLv.TabIndex = 27;
      this.accountsLv.UseCompatibleStateImageBehavior = false;
      this.accountsLv.View = System.Windows.Forms.View.Details;
      // 
      // AccountsName
      // 
      this.AccountsName.Text = "Name";
      this.AccountsName.Width = 82;
      // 
      // AccountType
      // 
      this.AccountType.Text = "Type";
      this.AccountType.Width = 87;
      // 
      // AccountBalance
      // 
      this.AccountBalance.Text = "Balance";
      this.AccountBalance.Width = 95;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 455);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 13);
      this.label1.TabIndex = 26;
      this.label1.Text = "Account Snapshot";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 13);
      this.label3.TabIndex = 28;
      this.label3.Text = "Today\'s Date:";
      // 
      // todayDtp
      // 
      this.todayDtp.Location = new System.Drawing.Point(88, 6);
      this.todayDtp.Name = "todayDtp";
      this.todayDtp.Size = new System.Drawing.Size(200, 20);
      this.todayDtp.TabIndex = 29;
      this.todayDtp.ValueChanged += new System.EventHandler(this.todayDtp_ValueChanged);
      // 
      // annualSbLv
      // 
      this.annualSbLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.annualSbLv.HideSelection = false;
      this.annualSbLv.Location = new System.Drawing.Point(300, 84);
      this.annualSbLv.Name = "annualSbLv";
      this.annualSbLv.Size = new System.Drawing.Size(279, 304);
      this.annualSbLv.TabIndex = 31;
      this.annualSbLv.UseCompatibleStateImageBehavior = false;
      this.annualSbLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 146;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Starting";
      this.columnHeader2.Width = 82;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Current";
      this.columnHeader3.Width = 93;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(294, 67);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(83, 13);
      this.label4.TabIndex = 30;
      this.label4.Text = "Annual Soft Bills";
      // 
      // showAllPurchasesCb
      // 
      this.showAllPurchasesCb.AutoSize = true;
      this.showAllPurchasesCb.Location = new System.Drawing.Point(661, 61);
      this.showAllPurchasesCb.Name = "showAllPurchasesCb";
      this.showAllPurchasesCb.Size = new System.Drawing.Size(67, 17);
      this.showAllPurchasesCb.TabIndex = 32;
      this.showAllPurchasesCb.Text = "Show All";
      this.showAllPurchasesCb.UseVisualStyleBackColor = true;
      this.showAllPurchasesCb.CheckedChanged += new System.EventHandler(this.showAllPurchasesCb_CheckedChanged);
      // 
      // accountCms
      // 
      this.accountCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.accountCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualCredit,
            this.manualDebit});
      this.accountCms.Name = "annualHbCms";
      this.accountCms.Size = new System.Drawing.Size(150, 48);
      // 
      // manualCredit
      // 
      this.manualCredit.Name = "manualCredit";
      this.manualCredit.Size = new System.Drawing.Size(149, 22);
      this.manualCredit.Text = "Manual Credit";
      this.manualCredit.Click += new System.EventHandler(this.manualCredit_Click);
      // 
      // manualDebit
      // 
      this.manualDebit.Name = "manualDebit";
      this.manualDebit.Size = new System.Drawing.Size(149, 22);
      this.manualDebit.Text = "Manual Debit";
      this.manualDebit.Click += new System.EventHandler(this.manualDebit_Click);
      // 
      // addAnnual
      // 
      this.addAnnual.Name = "addAnnual";
      this.addAnnual.Size = new System.Drawing.Size(144, 22);
      this.addAnnual.Text = "Add Annual";
      this.addAnnual.Click += new System.EventHandler(this.addAnnual_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(90, 400);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(98, 13);
      this.label5.TabIndex = 33;
      this.label5.Text = "Soft Bill Remaining:";
      // 
      // monthlySbRemainingTb
      // 
      this.monthlySbRemainingTb.Location = new System.Drawing.Point(194, 393);
      this.monthlySbRemainingTb.Name = "monthlySbRemainingTb";
      this.monthlySbRemainingTb.Size = new System.Drawing.Size(100, 20);
      this.monthlySbRemainingTb.TabIndex = 34;
      // 
      // annualSbRemainingTb
      // 
      this.annualSbRemainingTb.Location = new System.Drawing.Point(479, 393);
      this.annualSbRemainingTb.Name = "annualSbRemainingTb";
      this.annualSbRemainingTb.Size = new System.Drawing.Size(100, 20);
      this.annualSbRemainingTb.TabIndex = 36;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(375, 400);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(98, 13);
      this.label7.TabIndex = 35;
      this.label7.Text = "Soft Bill Remaining:";
      // 
      // totalSbSnapshotTb
      // 
      this.totalSbSnapshotTb.Location = new System.Drawing.Point(479, 465);
      this.totalSbSnapshotTb.Name = "totalSbSnapshotTb";
      this.totalSbSnapshotTb.Size = new System.Drawing.Size(100, 20);
      this.totalSbSnapshotTb.TabIndex = 38;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(375, 472);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(93, 13);
      this.label8.TabIndex = 37;
      this.label8.Text = "Soft Bill Snapshot:";
      // 
      // ManageMonthsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1163, 620);
      this.Controls.Add(this.totalSbSnapshotTb);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.annualSbRemainingTb);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.monthlySbRemainingTb);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.showAllPurchasesCb);
      this.Controls.Add(this.annualSbLv);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.todayDtp);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.accountsLv);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.doneBtn);
      this.Controls.Add(this.purchasesLv);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.monthlySbLv);
      this.Controls.Add(this.label6);
      this.Name = "ManageMonthsForm";
      this.Text = "ManageMonthsForm";
      this.purchasesCms.ResumeLayout(false);
      this.accountCms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ListView monthlySbLv;
        private System.Windows.Forms.ColumnHeader SoftBillsName;
        private System.Windows.Forms.ColumnHeader SoftBillsStarting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader SoftBillsCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView purchasesLv;
        private System.Windows.Forms.ColumnHeader PurchasesMerchant;
        private System.Windows.Forms.ColumnHeader PurchasesAmount;
        private System.Windows.Forms.ContextMenuStrip purchasesCms;
        private System.Windows.Forms.ToolStripMenuItem purchasesAdd;
        private System.Windows.Forms.ToolStripMenuItem purchasesDelete;
        private System.Windows.Forms.ToolStripMenuItem purchasesEdit;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.ListView accountsLv;
        private System.Windows.Forms.ColumnHeader AccountsName;
        private System.Windows.Forms.ColumnHeader AccountType;
        private System.Windows.Forms.ColumnHeader AccountBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker todayDtp;
        private System.Windows.Forms.ListView annualSbLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox showAllPurchasesCb;
        private System.Windows.Forms.ColumnHeader PurchaseDate;
        private System.Windows.Forms.ContextMenuStrip accountCms;
        private System.Windows.Forms.ToolStripMenuItem manualCredit;
        private System.Windows.Forms.ToolStripMenuItem manualDebit;
        private System.Windows.Forms.ToolStripMenuItem addAnnual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monthlySbRemainingTb;
        private System.Windows.Forms.TextBox annualSbRemainingTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalSbSnapshotTb;
        private System.Windows.Forms.Label label8;
    }
}