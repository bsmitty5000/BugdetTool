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
      this.monthlySbCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.monthlySbAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.monthlySbEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.purchasesAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.purchasesEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.doneBtn = new System.Windows.Forms.Button();
      this.monthlySbCms.SuspendLayout();
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
      this.monthlySbLv.Location = new System.Drawing.Point(18, 129);
      this.monthlySbLv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.monthlySbLv.Name = "monthlySbLv";
      this.monthlySbLv.Size = new System.Drawing.Size(295, 147);
      this.monthlySbLv.TabIndex = 19;
      this.monthlySbLv.UseCompatibleStateImageBehavior = false;
      this.monthlySbLv.View = System.Windows.Forms.View.Details;
      // 
      // SoftBillsName
      // 
      this.SoftBillsName.Text = "Name";
      this.SoftBillsName.Width = 83;
      // 
      // SoftBillsStarting
      // 
      this.SoftBillsStarting.Text = "Starting";
      // 
      // SoftBillsCurrent
      // 
      this.SoftBillsCurrent.Text = "Current";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(14, 103);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(71, 20);
      this.label6.TabIndex = 18;
      this.label6.Text = "Soft Bills";
      // 
      // currentMonthLbl
      // 
      this.currentMonthLbl.AutoSize = true;
      this.currentMonthLbl.Location = new System.Drawing.Point(18, 20);
      this.currentMonthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.currentMonthLbl.Name = "currentMonthLbl";
      this.currentMonthLbl.Size = new System.Drawing.Size(175, 20);
      this.currentMonthLbl.TabIndex = 20;
      this.currentMonthLbl.Text = "Current Month: xxxxxxxx";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(345, 103);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 20);
      this.label2.TabIndex = 21;
      this.label2.Text = "Purchases";
      // 
      // purchasesLv
      // 
      this.purchasesLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PurchasesMerchant,
            this.PurchasesAmount});
      this.purchasesLv.HideSelection = false;
      this.purchasesLv.Location = new System.Drawing.Point(350, 129);
      this.purchasesLv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.purchasesLv.Name = "purchasesLv";
      this.purchasesLv.Size = new System.Drawing.Size(358, 147);
      this.purchasesLv.TabIndex = 22;
      this.purchasesLv.UseCompatibleStateImageBehavior = false;
      this.purchasesLv.View = System.Windows.Forms.View.Details;
      // 
      // PurchasesMerchant
      // 
      this.PurchasesMerchant.Text = "Merchant";
      this.PurchasesMerchant.Width = 83;
      // 
      // PurchasesAmount
      // 
      this.PurchasesAmount.Text = "Amount";
      // 
      // prevBtn
      // 
      this.prevBtn.Location = new System.Drawing.Point(22, 45);
      this.prevBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.prevBtn.Name = "prevBtn";
      this.prevBtn.Size = new System.Drawing.Size(112, 35);
      this.prevBtn.TabIndex = 23;
      this.prevBtn.Text = "Prev";
      this.prevBtn.UseVisualStyleBackColor = true;
      this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
      // 
      // nextBtn
      // 
      this.nextBtn.Location = new System.Drawing.Point(154, 45);
      this.nextBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.nextBtn.Name = "nextBtn";
      this.nextBtn.Size = new System.Drawing.Size(112, 35);
      this.nextBtn.TabIndex = 24;
      this.nextBtn.Text = "Next";
      this.nextBtn.UseVisualStyleBackColor = true;
      this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
      // 
      // monthlySbCms
      // 
      this.monthlySbCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.monthlySbCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlySbAdd,
            this.monthlySbDelete,
            this.monthlySbEdit});
      this.monthlySbCms.Name = "annualHbCms";
      this.monthlySbCms.Size = new System.Drawing.Size(135, 94);
      // 
      // monthlySbAdd
      // 
      this.monthlySbAdd.Name = "monthlySbAdd";
      this.monthlySbAdd.Size = new System.Drawing.Size(134, 30);
      this.monthlySbAdd.Text = "Add";
      this.monthlySbAdd.Click += new System.EventHandler(this.monthlySbAdd_Click);
      // 
      // monthlySbDelete
      // 
      this.monthlySbDelete.Name = "monthlySbDelete";
      this.monthlySbDelete.Size = new System.Drawing.Size(134, 30);
      this.monthlySbDelete.Text = "Delete";
      this.monthlySbDelete.Click += new System.EventHandler(this.monthlySbDelete_Click);
      // 
      // monthlySbEdit
      // 
      this.monthlySbEdit.Name = "monthlySbEdit";
      this.monthlySbEdit.Size = new System.Drawing.Size(134, 30);
      this.monthlySbEdit.Text = "Edit";
      this.monthlySbEdit.Click += new System.EventHandler(this.monthlySbEdit_Click);
      // 
      // purchasesCms
      // 
      this.purchasesCms.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.purchasesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesAdd,
            this.purchasesDelete,
            this.purchasesEdit});
      this.purchasesCms.Name = "annualHbCms";
      this.purchasesCms.Size = new System.Drawing.Size(135, 94);
      // 
      // purchasesAdd
      // 
      this.purchasesAdd.Name = "purchasesAdd";
      this.purchasesAdd.Size = new System.Drawing.Size(134, 30);
      this.purchasesAdd.Text = "Add";
      this.purchasesAdd.Click += new System.EventHandler(this.purchasesAdd_Click);
      // 
      // purchasesDelete
      // 
      this.purchasesDelete.Name = "purchasesDelete";
      this.purchasesDelete.Size = new System.Drawing.Size(134, 30);
      this.purchasesDelete.Text = "Delete";
      this.purchasesDelete.Click += new System.EventHandler(this.purchasesDelete_Click);
      // 
      // purchasesEdit
      // 
      this.purchasesEdit.Name = "purchasesEdit";
      this.purchasesEdit.Size = new System.Drawing.Size(134, 30);
      this.purchasesEdit.Text = "Edit";
      this.purchasesEdit.Click += new System.EventHandler(this.purchasesEdit_Click);
      // 
      // doneBtn
      // 
      this.doneBtn.Location = new System.Drawing.Point(22, 318);
      this.doneBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.doneBtn.Name = "doneBtn";
      this.doneBtn.Size = new System.Drawing.Size(112, 35);
      this.doneBtn.TabIndex = 25;
      this.doneBtn.Text = "Done";
      this.doneBtn.UseVisualStyleBackColor = true;
      this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
      // 
      // ManageMonthsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1200, 692);
      this.Controls.Add(this.doneBtn);
      this.Controls.Add(this.nextBtn);
      this.Controls.Add(this.prevBtn);
      this.Controls.Add(this.purchasesLv);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.currentMonthLbl);
      this.Controls.Add(this.monthlySbLv);
      this.Controls.Add(this.label6);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "ManageMonthsForm";
      this.Text = "ManageMonthsForm";
      this.monthlySbCms.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip monthlySbCms;
        private System.Windows.Forms.ToolStripMenuItem monthlySbAdd;
        private System.Windows.Forms.ToolStripMenuItem monthlySbDelete;
        private System.Windows.Forms.ToolStripMenuItem monthlySbEdit;
        private System.Windows.Forms.ContextMenuStrip purchasesCms;
        private System.Windows.Forms.ToolStripMenuItem purchasesAdd;
        private System.Windows.Forms.ToolStripMenuItem purchasesDelete;
        private System.Windows.Forms.ToolStripMenuItem purchasesEdit;
        private System.Windows.Forms.Button doneBtn;
    }
}