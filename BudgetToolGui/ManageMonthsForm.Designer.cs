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
      this.currentMonthLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.purchasesLv = new System.Windows.Forms.ListView();
      this.PurchasesMerchant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PurchasesAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.prevBtn = new System.Windows.Forms.Button();
      this.nextBtn = new System.Windows.Forms.Button();
      this.purchasesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.purchasesAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.doneBtn = new System.Windows.Forms.Button();
      this.purchasesCms.SuspendLayout();
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
      this.monthlySbLv.Size = new System.Drawing.Size(279, 240);
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
      this.label6.Size = new System.Drawing.Size(47, 13);
      this.label6.TabIndex = 18;
      this.label6.Text = "Soft Bills";
      // 
      // currentMonthLbl
      // 
      this.currentMonthLbl.AutoSize = true;
      this.currentMonthLbl.Location = new System.Drawing.Point(12, 13);
      this.currentMonthLbl.Name = "currentMonthLbl";
      this.currentMonthLbl.Size = new System.Drawing.Size(120, 13);
      this.currentMonthLbl.TabIndex = 20;
      this.currentMonthLbl.Text = "Current Month: xxxxxxxx";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(319, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(57, 13);
      this.label2.TabIndex = 21;
      this.label2.Text = "Purchases";
      // 
      // purchasesLv
      // 
      this.purchasesLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PurchasesMerchant,
            this.PurchasesAmount});
      this.purchasesLv.HideSelection = false;
      this.purchasesLv.Location = new System.Drawing.Point(322, 84);
      this.purchasesLv.Name = "purchasesLv";
      this.purchasesLv.Size = new System.Drawing.Size(319, 240);
      this.purchasesLv.TabIndex = 22;
      this.purchasesLv.UseCompatibleStateImageBehavior = false;
      this.purchasesLv.View = System.Windows.Forms.View.Details;
      // 
      // PurchasesMerchant
      // 
      this.PurchasesMerchant.Text = "Merchant";
      this.PurchasesMerchant.Width = 190;
      // 
      // PurchasesAmount
      // 
      this.PurchasesAmount.Text = "Amount";
      this.PurchasesAmount.Width = 144;
      // 
      // prevBtn
      // 
      this.prevBtn.Location = new System.Drawing.Point(15, 29);
      this.prevBtn.Name = "prevBtn";
      this.prevBtn.Size = new System.Drawing.Size(75, 23);
      this.prevBtn.TabIndex = 23;
      this.prevBtn.Text = "Prev";
      this.prevBtn.UseVisualStyleBackColor = true;
      this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
      // 
      // nextBtn
      // 
      this.nextBtn.Location = new System.Drawing.Point(103, 29);
      this.nextBtn.Name = "nextBtn";
      this.nextBtn.Size = new System.Drawing.Size(75, 23);
      this.nextBtn.TabIndex = 24;
      this.nextBtn.Text = "Next";
      this.nextBtn.UseVisualStyleBackColor = true;
      this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
      // 
      // purchasesCms
      // 
      this.purchasesCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.purchasesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesAdd,
            this.purchasesDelete,
            this.purchasesEdit});
      this.purchasesCms.Name = "annualHbCms";
      this.purchasesCms.Size = new System.Drawing.Size(108, 70);
      // 
      // purchasesAdd
      // 
      this.purchasesAdd.Name = "purchasesAdd";
      this.purchasesAdd.Size = new System.Drawing.Size(107, 22);
      this.purchasesAdd.Text = "Add";
      this.purchasesAdd.Click += new System.EventHandler(this.purchasesAdd_Click);
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
      this.purchasesEdit.Name = "purchasesEdit";
      this.purchasesEdit.Size = new System.Drawing.Size(107, 22);
      this.purchasesEdit.Text = "Edit";
      this.purchasesEdit.Click += new System.EventHandler(this.purchasesEdit_Click);
      // 
      // doneBtn
      // 
      this.doneBtn.Location = new System.Drawing.Point(15, 374);
      this.doneBtn.Name = "doneBtn";
      this.doneBtn.Size = new System.Drawing.Size(75, 23);
      this.doneBtn.TabIndex = 25;
      this.doneBtn.Text = "Done";
      this.doneBtn.UseVisualStyleBackColor = true;
      this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
      // 
      // ManageMonthsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.doneBtn);
      this.Controls.Add(this.nextBtn);
      this.Controls.Add(this.prevBtn);
      this.Controls.Add(this.purchasesLv);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.currentMonthLbl);
      this.Controls.Add(this.monthlySbLv);
      this.Controls.Add(this.label6);
      this.Name = "ManageMonthsForm";
      this.Text = "ManageMonthsForm";
      this.purchasesCms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ListView monthlySbLv;
        private System.Windows.Forms.ColumnHeader SoftBillsName;
        private System.Windows.Forms.ColumnHeader SoftBillsStarting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentMonthLbl;
        private System.Windows.Forms.ColumnHeader SoftBillsCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView purchasesLv;
        private System.Windows.Forms.ColumnHeader PurchasesMerchant;
        private System.Windows.Forms.ColumnHeader PurchasesAmount;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ContextMenuStrip purchasesCms;
        private System.Windows.Forms.ToolStripMenuItem purchasesAdd;
        private System.Windows.Forms.ToolStripMenuItem purchasesDelete;
        private System.Windows.Forms.ToolStripMenuItem purchasesEdit;
        private System.Windows.Forms.Button doneBtn;
    }
}