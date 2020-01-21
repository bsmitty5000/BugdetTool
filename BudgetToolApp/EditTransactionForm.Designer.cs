namespace BudgetToolApp
{
  partial class EditTransactionForm
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
      this.label3 = new System.Windows.Forms.Label();
      this.softBillSplitTpl = new System.Windows.Forms.TableLayoutPanel();
      this.dateDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.cancelAndCloseBtn = new System.Windows.Forms.Button();
      this.saveAndCloseBtn = new System.Windows.Forms.Button();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.descriptionTb = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.accountCb = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.annualPurchaseCb = new System.Windows.Forms.CheckBox();
      this.resetBtn = new System.Windows.Forms.Button();
      this.logAndNewBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(333, 52);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 15);
      this.label3.TabIndex = 55;
      this.label3.Text = "Soft Bill Split";
      // 
      // softBillSplitTpl
      // 
      this.softBillSplitTpl.AutoSize = true;
      this.softBillSplitTpl.ColumnCount = 3;
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.33333F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.66667F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
      this.softBillSplitTpl.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.softBillSplitTpl.Location = new System.Drawing.Point(336, 72);
      this.softBillSplitTpl.Name = "softBillSplitTpl";
      this.softBillSplitTpl.RowCount = 2;
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.softBillSplitTpl.Size = new System.Drawing.Size(444, 55);
      this.softBillSplitTpl.TabIndex = 54;
      // 
      // dateDtp
      // 
      this.dateDtp.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateDtp.Location = new System.Drawing.Point(120, 105);
      this.dateDtp.Name = "dateDtp";
      this.dateDtp.Size = new System.Drawing.Size(200, 20);
      this.dateDtp.TabIndex = 53;
      this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 112);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 15);
      this.label5.TabIndex = 52;
      this.label5.Text = "Transaction Date";
      // 
      // cancelAndCloseBtn
      // 
      this.cancelAndCloseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancelAndCloseBtn.Location = new System.Drawing.Point(15, 198);
      this.cancelAndCloseBtn.Name = "cancelAndCloseBtn";
      this.cancelAndCloseBtn.Size = new System.Drawing.Size(110, 28);
      this.cancelAndCloseBtn.TabIndex = 51;
      this.cancelAndCloseBtn.Text = "Cancel and Close";
      this.cancelAndCloseBtn.UseVisualStyleBackColor = true;
      this.cancelAndCloseBtn.Click += new System.EventHandler(this.cancelAndCloseBtn_Click);
      // 
      // saveAndCloseBtn
      // 
      this.saveAndCloseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.saveAndCloseBtn.Location = new System.Drawing.Point(15, 164);
      this.saveAndCloseBtn.Name = "saveAndCloseBtn";
      this.saveAndCloseBtn.Size = new System.Drawing.Size(110, 28);
      this.saveAndCloseBtn.TabIndex = 50;
      this.saveAndCloseBtn.Text = "Save and Close";
      this.saveAndCloseBtn.UseVisualStyleBackColor = true;
      this.saveAndCloseBtn.Click += new System.EventHandler(this.saveAndCloseBtn_Click);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(120, 44);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 49;
      this.amountTb.TextChanged += new System.EventHandler(this.amountTb_TextChanged);
      // 
      // descriptionTb
      // 
      this.descriptionTb.Location = new System.Drawing.Point(120, 14);
      this.descriptionTb.Name = "descriptionTb";
      this.descriptionTb.Size = new System.Drawing.Size(660, 20);
      this.descriptionTb.TabIndex = 48;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 15);
      this.label2.TabIndex = 46;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 15);
      this.label1.TabIndex = 45;
      this.label1.Text = "Description";
      // 
      // accountCb
      // 
      this.accountCb.FormattingEnabled = true;
      this.accountCb.Location = new System.Drawing.Point(120, 74);
      this.accountCb.Name = "accountCb";
      this.accountCb.Size = new System.Drawing.Size(121, 23);
      this.accountCb.TabIndex = 57;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(12, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(94, 15);
      this.label4.TabIndex = 56;
      this.label4.Text = "Purchase Account";
      // 
      // annualPurchaseCb
      // 
      this.annualPurchaseCb.AutoSize = true;
      this.annualPurchaseCb.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.annualPurchaseCb.Location = new System.Drawing.Point(17, 139);
      this.annualPurchaseCb.Name = "annualPurchaseCb";
      this.annualPurchaseCb.Size = new System.Drawing.Size(108, 19);
      this.annualPurchaseCb.TabIndex = 58;
      this.annualPurchaseCb.Text = "Annual Purchase";
      this.annualPurchaseCb.UseVisualStyleBackColor = true;
      this.annualPurchaseCb.CheckedChanged += new System.EventHandler(this.annualPurchaseCb_CheckedChanged);
      // 
      // resetBtn
      // 
      this.resetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.resetBtn.Location = new System.Drawing.Point(15, 234);
      this.resetBtn.Name = "resetBtn";
      this.resetBtn.Size = new System.Drawing.Size(110, 27);
      this.resetBtn.TabIndex = 59;
      this.resetBtn.Text = "Reset";
      this.resetBtn.UseVisualStyleBackColor = true;
      this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
      // 
      // logAndNewBtn
      // 
      this.logAndNewBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.logAndNewBtn.Location = new System.Drawing.Point(15, 267);
      this.logAndNewBtn.Name = "logAndNewBtn";
      this.logAndNewBtn.Size = new System.Drawing.Size(110, 28);
      this.logAndNewBtn.TabIndex = 60;
      this.logAndNewBtn.Text = "Log and New";
      this.logAndNewBtn.UseVisualStyleBackColor = true;
      this.logAndNewBtn.Click += new System.EventHandler(this.logAndNewBtn_Click);
      // 
      // EditTransactionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 519);
      this.Controls.Add(this.logAndNewBtn);
      this.Controls.Add(this.resetBtn);
      this.Controls.Add(this.annualPurchaseCb);
      this.Controls.Add(this.accountCb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.softBillSplitTpl);
      this.Controls.Add(this.dateDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cancelAndCloseBtn);
      this.Controls.Add(this.saveAndCloseBtn);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.descriptionTb);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "EditTransactionForm";
      this.Text = "EditTransactionForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel softBillSplitTpl;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelAndCloseBtn;
        private System.Windows.Forms.Button saveAndCloseBtn;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox descriptionTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox accountCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox annualPurchaseCb;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button logAndNewBtn;
    }
}