namespace BudgetToolApp
{
  partial class ManageBudget
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
      this.accountsLv = new System.Windows.Forms.ListView();
      this.AccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.dateDtp = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.transactionsLv = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.softBillsLbl = new System.Windows.Forms.Label();
      this.softBillsLv = new System.Windows.Forms.ListView();
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.editBudgetBtn = new System.Windows.Forms.Button();
      this.logPurchaseBtn = new System.Windows.Forms.Button();
      this.logDepositBtn = new System.Windows.Forms.Button();
      this.allAccountsCb = new System.Windows.Forms.CheckBox();
      this.allDatesCb = new System.Windows.Forms.CheckBox();
      this.showAnnualCb = new System.Windows.Forms.CheckBox();
      this.accountInfoLv = new System.Windows.Forms.ListView();
      this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.purchasesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.purchasesDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.hardBillsLv = new System.Windows.Forms.ListView();
      this.AnnualHbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AnnualHbAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.NextDueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label5 = new System.Windows.Forms.Label();
      this.hbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.hbPay = new System.Windows.Forms.ToolStripMenuItem();
      this.sbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.sbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.sbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.sbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.purchasesCms.SuspendLayout();
      this.hbCms.SuspendLayout();
      this.sbCms.SuspendLayout();
      this.SuspendLayout();
      // 
      // accountsLv
      // 
      this.accountsLv.CheckBoxes = true;
      this.accountsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountName});
      this.accountsLv.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.accountsLv.FullRowSelect = true;
      this.accountsLv.HideSelection = false;
      this.accountsLv.Location = new System.Drawing.Point(12, 78);
      this.accountsLv.Name = "accountsLv";
      this.accountsLv.Size = new System.Drawing.Size(145, 97);
      this.accountsLv.TabIndex = 0;
      this.accountsLv.UseCompatibleStateImageBehavior = false;
      this.accountsLv.View = System.Windows.Forms.View.Details;
      // 
      // AccountName
      // 
      this.AccountName.Text = "Name";
      this.AccountName.Width = 132;
      // 
      // dateDtp
      // 
      this.dateDtp.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateDtp.Location = new System.Drawing.Point(12, 32);
      this.dateDtp.Name = "dateDtp";
      this.dateDtp.Size = new System.Drawing.Size(200, 20);
      this.dateDtp.TabIndex = 1;
      this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Date";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(13, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(46, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "Account";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(377, 11);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 15);
      this.label3.TabIndex = 4;
      this.label3.Text = "Transactions";
      // 
      // transactionsLv
      // 
      this.transactionsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
      this.transactionsLv.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.transactionsLv.FullRowSelect = true;
      this.transactionsLv.HideSelection = false;
      this.transactionsLv.Location = new System.Drawing.Point(380, 32);
      this.transactionsLv.Name = "transactionsLv";
      this.transactionsLv.Size = new System.Drawing.Size(380, 284);
      this.transactionsLv.TabIndex = 7;
      this.transactionsLv.UseCompatibleStateImageBehavior = false;
      this.transactionsLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Description";
      this.columnHeader1.Width = 138;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Amount";
      this.columnHeader2.Width = 80;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Account";
      this.columnHeader3.Width = 79;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Date";
      this.columnHeader4.Width = 71;
      // 
      // softBillsLbl
      // 
      this.softBillsLbl.AutoSize = true;
      this.softBillsLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.softBillsLbl.Location = new System.Drawing.Point(13, 199);
      this.softBillsLbl.Name = "softBillsLbl";
      this.softBillsLbl.Size = new System.Drawing.Size(87, 15);
      this.softBillsLbl.TabIndex = 9;
      this.softBillsLbl.Text = "Soft Bills Month:";
      // 
      // softBillsLv
      // 
      this.softBillsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
      this.softBillsLv.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.softBillsLv.HideSelection = false;
      this.softBillsLv.Location = new System.Drawing.Point(12, 224);
      this.softBillsLv.Name = "softBillsLv";
      this.softBillsLv.Size = new System.Drawing.Size(341, 223);
      this.softBillsLv.TabIndex = 8;
      this.softBillsLv.UseCompatibleStateImageBehavior = false;
      this.softBillsLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Name";
      this.columnHeader5.Width = 114;
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "Starting Amount";
      this.columnHeader6.Width = 99;
      // 
      // columnHeader7
      // 
      this.columnHeader7.Text = "Amount Remaining";
      this.columnHeader7.Width = 111;
      // 
      // editBudgetBtn
      // 
      this.editBudgetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.editBudgetBtn.Location = new System.Drawing.Point(380, 403);
      this.editBudgetBtn.Name = "editBudgetBtn";
      this.editBudgetBtn.Size = new System.Drawing.Size(75, 23);
      this.editBudgetBtn.TabIndex = 11;
      this.editBudgetBtn.Text = "Edit Budget";
      this.editBudgetBtn.UseVisualStyleBackColor = true;
      this.editBudgetBtn.Click += new System.EventHandler(this.editBudgetBtn_Click);
      // 
      // logPurchaseBtn
      // 
      this.logPurchaseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.logPurchaseBtn.Location = new System.Drawing.Point(380, 322);
      this.logPurchaseBtn.Name = "logPurchaseBtn";
      this.logPurchaseBtn.Size = new System.Drawing.Size(90, 23);
      this.logPurchaseBtn.TabIndex = 12;
      this.logPurchaseBtn.Text = "Log Purchase";
      this.logPurchaseBtn.UseVisualStyleBackColor = true;
      this.logPurchaseBtn.Click += new System.EventHandler(this.logPurchaseBtn_Click);
      // 
      // logDepositBtn
      // 
      this.logDepositBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.logDepositBtn.Location = new System.Drawing.Point(485, 322);
      this.logDepositBtn.Name = "logDepositBtn";
      this.logDepositBtn.Size = new System.Drawing.Size(90, 23);
      this.logDepositBtn.TabIndex = 13;
      this.logDepositBtn.Text = "Log Deposit";
      this.logDepositBtn.UseVisualStyleBackColor = true;
      // 
      // allAccountsCb
      // 
      this.allAccountsCb.AutoSize = true;
      this.allAccountsCb.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.allAccountsCb.Location = new System.Drawing.Point(451, 7);
      this.allAccountsCb.Name = "allAccountsCb";
      this.allAccountsCb.Size = new System.Drawing.Size(86, 19);
      this.allAccountsCb.TabIndex = 14;
      this.allAccountsCb.Text = "All Accounts";
      this.allAccountsCb.UseVisualStyleBackColor = true;
      this.allAccountsCb.CheckedChanged += new System.EventHandler(this.allAccountsCb_CheckedChanged);
      // 
      // allDatesCb
      // 
      this.allDatesCb.AutoSize = true;
      this.allDatesCb.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.allDatesCb.Location = new System.Drawing.Point(543, 7);
      this.allDatesCb.Name = "allDatesCb";
      this.allDatesCb.Size = new System.Drawing.Size(70, 19);
      this.allDatesCb.TabIndex = 15;
      this.allDatesCb.Text = "All Dates";
      this.allDatesCb.UseVisualStyleBackColor = true;
      this.allDatesCb.CheckedChanged += new System.EventHandler(this.allDatesCb_CheckedChanged);
      // 
      // showAnnualCb
      // 
      this.showAnnualCb.AutoSize = true;
      this.showAnnualCb.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.showAnnualCb.Location = new System.Drawing.Point(265, 199);
      this.showAnnualCb.Name = "showAnnualCb";
      this.showAnnualCb.Size = new System.Drawing.Size(88, 19);
      this.showAnnualCb.TabIndex = 16;
      this.showAnnualCb.Text = "Show Annual";
      this.showAnnualCb.UseVisualStyleBackColor = true;
      this.showAnnualCb.CheckedChanged += new System.EventHandler(this.showAnnualCb_CheckedChanged);
      // 
      // accountInfoLv
      // 
      this.accountInfoLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader8});
      this.accountInfoLv.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.accountInfoLv.HideSelection = false;
      this.accountInfoLv.Location = new System.Drawing.Point(145, 78);
      this.accountInfoLv.Name = "accountInfoLv";
      this.accountInfoLv.Size = new System.Drawing.Size(208, 97);
      this.accountInfoLv.TabIndex = 17;
      this.accountInfoLv.UseCompatibleStateImageBehavior = false;
      this.accountInfoLv.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader9
      // 
      this.columnHeader9.Text = "Amount";
      this.columnHeader9.Width = 95;
      // 
      // purchasesCms
      // 
      this.purchasesCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.purchasesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesDelete,
            this.purchasesEdit});
      this.purchasesCms.Name = "annualHbCms";
      this.purchasesCms.Size = new System.Drawing.Size(108, 48);
      // 
      // purchasesDelete
      // 
      this.purchasesDelete.Name = "purchasesDelete";
      this.purchasesDelete.Size = new System.Drawing.Size(107, 22);
      this.purchasesDelete.Text = "Delete";
      this.purchasesDelete.Click += new System.EventHandler(this.purchasesDelete_Click);
      // 
      // purchasesEdit
      // 
      this.purchasesEdit.Enabled = false;
      this.purchasesEdit.Name = "purchasesEdit";
      this.purchasesEdit.Size = new System.Drawing.Size(107, 22);
      this.purchasesEdit.Text = "Edit";
      this.purchasesEdit.Click += new System.EventHandler(this.purchasesEdit_Click);
      // 
      // hardBillsLv
      // 
      this.hardBillsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AnnualHbName,
            this.AnnualHbAmount,
            this.NextDueDate});
      this.hardBillsLv.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F);
      this.hardBillsLv.FullRowSelect = true;
      this.hardBillsLv.HideSelection = false;
      this.hardBillsLv.Location = new System.Drawing.Point(766, 32);
      this.hardBillsLv.Name = "hardBillsLv";
      this.hardBillsLv.Size = new System.Drawing.Size(319, 284);
      this.hardBillsLv.TabIndex = 46;
      this.hardBillsLv.UseCompatibleStateImageBehavior = false;
      this.hardBillsLv.View = System.Windows.Forms.View.Details;
      // 
      // AnnualHbName
      // 
      this.AnnualHbName.Text = "Name";
      this.AnnualHbName.Width = 107;
      // 
      // AnnualHbAmount
      // 
      this.AnnualHbAmount.Text = "Amount";
      this.AnnualHbAmount.Width = 98;
      // 
      // NextDueDate
      // 
      this.NextDueDate.Text = "Next Due Date";
      this.NextDueDate.Width = 90;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(763, 11);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(54, 15);
      this.label5.TabIndex = 47;
      this.label5.Text = "Hard Bills";
      // 
      // hbCms
      // 
      this.hbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hbPay});
      this.hbCms.Name = "annualHbCms";
      this.hbCms.Size = new System.Drawing.Size(94, 26);
      // 
      // hbPay
      // 
      this.hbPay.Name = "hbPay";
      this.hbPay.Size = new System.Drawing.Size(93, 22);
      this.hbPay.Text = "Pay";
      this.hbPay.Click += new System.EventHandler(this.hbPay_Click);
      // 
      // sbCms
      // 
      this.sbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAdd,
            this.sbDelete,
            this.sbEdit});
      this.sbCms.Name = "annualHbCms";
      this.sbCms.Size = new System.Drawing.Size(108, 70);
      // 
      // sbAdd
      // 
      this.sbAdd.Name = "sbAdd";
      this.sbAdd.Size = new System.Drawing.Size(107, 22);
      this.sbAdd.Text = "Add";
      this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
      // 
      // sbDelete
      // 
      this.sbDelete.Name = "sbDelete";
      this.sbDelete.Size = new System.Drawing.Size(107, 22);
      this.sbDelete.Text = "Delete";
      this.sbDelete.Click += new System.EventHandler(this.sbDelete_Click);
      // 
      // sbEdit
      // 
      this.sbEdit.Name = "sbEdit";
      this.sbEdit.Size = new System.Drawing.Size(107, 22);
      this.sbEdit.Text = "Edit";
      this.sbEdit.Click += new System.EventHandler(this.sbEdit_Click);
      // 
      // columnHeader8
      // 
      this.columnHeader8.Text = "Start Date";
      this.columnHeader8.Width = 95;
      // 
      // ManageBudget
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1097, 450);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.hardBillsLv);
      this.Controls.Add(this.accountInfoLv);
      this.Controls.Add(this.showAnnualCb);
      this.Controls.Add(this.allDatesCb);
      this.Controls.Add(this.allAccountsCb);
      this.Controls.Add(this.logDepositBtn);
      this.Controls.Add(this.logPurchaseBtn);
      this.Controls.Add(this.editBudgetBtn);
      this.Controls.Add(this.softBillsLbl);
      this.Controls.Add(this.softBillsLv);
      this.Controls.Add(this.transactionsLv);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dateDtp);
      this.Controls.Add(this.accountsLv);
      this.Name = "ManageBudget";
      this.Text = "ManageBudget";
      this.purchasesCms.ResumeLayout(false);
      this.hbCms.ResumeLayout(false);
      this.sbCms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ListView accountsLv;
        private System.Windows.Forms.ColumnHeader AccountName;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView transactionsLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label softBillsLbl;
        private System.Windows.Forms.ListView softBillsLv;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button editBudgetBtn;
        private System.Windows.Forms.Button logPurchaseBtn;
        private System.Windows.Forms.Button logDepositBtn;
        private System.Windows.Forms.CheckBox allAccountsCb;
        private System.Windows.Forms.CheckBox allDatesCb;
        private System.Windows.Forms.CheckBox showAnnualCb;
    private System.Windows.Forms.ListView accountInfoLv;
    private System.Windows.Forms.ColumnHeader columnHeader9;
    private System.Windows.Forms.ContextMenuStrip purchasesCms;
    private System.Windows.Forms.ToolStripMenuItem purchasesDelete;
    private System.Windows.Forms.ToolStripMenuItem purchasesEdit;
        private System.Windows.Forms.ListView hardBillsLv;
        private System.Windows.Forms.ColumnHeader AnnualHbName;
        private System.Windows.Forms.ColumnHeader AnnualHbAmount;
        private System.Windows.Forms.ColumnHeader NextDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip hbCms;
        private System.Windows.Forms.ToolStripMenuItem hbPay;
        private System.Windows.Forms.ContextMenuStrip sbCms;
        private System.Windows.Forms.ToolStripMenuItem sbAdd;
        private System.Windows.Forms.ToolStripMenuItem sbDelete;
        private System.Windows.Forms.ToolStripMenuItem sbEdit;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}