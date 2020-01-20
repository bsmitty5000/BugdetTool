namespace BudgetToolApp
{
  partial class EditIncomeForm
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
      this.cancelBtn = new System.Windows.Forms.Button();
      this.saveBtn = new System.Windows.Forms.Button();
      this.firstDepositDtp = new System.Windows.Forms.DateTimePicker();
      this.accountCb = new System.Windows.Forms.ComboBox();
      this.frequencyCb = new System.Windows.Forms.ComboBox();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.nameTb = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(183, 170);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 25;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click_1);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(71, 170);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 24;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click_1);
      // 
      // firstDepositDtp
      // 
      this.firstDepositDtp.Location = new System.Drawing.Point(114, 134);
      this.firstDepositDtp.Name = "firstDepositDtp";
      this.firstDepositDtp.Size = new System.Drawing.Size(200, 20);
      this.firstDepositDtp.TabIndex = 23;
      // 
      // accountCb
      // 
      this.accountCb.FormattingEnabled = true;
      this.accountCb.Location = new System.Drawing.Point(114, 104);
      this.accountCb.Name = "accountCb";
      this.accountCb.Size = new System.Drawing.Size(121, 21);
      this.accountCb.TabIndex = 22;
      // 
      // frequencyCb
      // 
      this.frequencyCb.FormattingEnabled = true;
      this.frequencyCb.Location = new System.Drawing.Point(114, 72);
      this.frequencyCb.Name = "frequencyCb";
      this.frequencyCb.Size = new System.Drawing.Size(121, 21);
      this.frequencyCb.TabIndex = 21;
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(114, 45);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 20;
      // 
      // nameTb
      // 
      this.nameTb.Location = new System.Drawing.Point(114, 12);
      this.nameTb.Name = "nameTb";
      this.nameTb.Size = new System.Drawing.Size(100, 20);
      this.nameTb.TabIndex = 19;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 140);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(91, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "First Deposit Date";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 112);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 13);
      this.label4.TabIndex = 17;
      this.label4.Text = "Deposit Account";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 13);
      this.label3.TabIndex = 16;
      this.label3.Text = "Frequency";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(54, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(62, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Name";
      // 
      // EditIncomeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(346, 237);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.firstDepositDtp);
      this.Controls.Add(this.accountCb);
      this.Controls.Add(this.frequencyCb);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.nameTb);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditIncomeForm";
      this.Text = "Income";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DateTimePicker firstDepositDtp;
        private System.Windows.Forms.ComboBox accountCb;
        private System.Windows.Forms.ComboBox frequencyCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}