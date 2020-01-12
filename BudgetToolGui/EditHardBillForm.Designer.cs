namespace BudgetToolGui
{
  partial class EditHardBillForm
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
      this.accountCb = new System.Windows.Forms.ComboBox();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.nameTb = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.saveBtn = new System.Windows.Forms.Button();
      this.firstBillDueDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.frequencyCb = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // accountCb
      // 
      this.accountCb.FormattingEnabled = true;
      this.accountCb.Location = new System.Drawing.Point(120, 120);
      this.accountCb.Name = "accountCb";
      this.accountCb.Size = new System.Drawing.Size(121, 21);
      this.accountCb.TabIndex = 15;
      this.accountCb.SelectedIndexChanged += new System.EventHandler(this.accountCb_SelectedIndexChanged);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(120, 35);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 14;
      this.amountTb.TextChanged += new System.EventHandler(this.amountTb_TextChanged);
      // 
      // nameTb
      // 
      this.nameTb.Location = new System.Drawing.Point(120, 9);
      this.nameTb.Name = "nameTb";
      this.nameTb.Size = new System.Drawing.Size(100, 20);
      this.nameTb.TabIndex = 13;
      this.nameTb.TextChanged += new System.EventHandler(this.nameTb_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 128);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Deposit Account";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(55, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(63, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Name";
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(190, 165);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 19;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(78, 165);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 18;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // firstBillDueDtp
      // 
      this.firstBillDueDtp.Location = new System.Drawing.Point(120, 92);
      this.firstBillDueDtp.Name = "firstBillDueDtp";
      this.firstBillDueDtp.Size = new System.Drawing.Size(200, 20);
      this.firstBillDueDtp.TabIndex = 21;
      this.firstBillDueDtp.ValueChanged += new System.EventHandler(this.firstBillDueDtp_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(33, 99);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "First Bill Due";
      // 
      // frequencyCb
      // 
      this.frequencyCb.FormattingEnabled = true;
      this.frequencyCb.Location = new System.Drawing.Point(120, 63);
      this.frequencyCb.Name = "frequencyCb";
      this.frequencyCb.Size = new System.Drawing.Size(121, 21);
      this.frequencyCb.TabIndex = 23;
      this.frequencyCb.SelectedIndexChanged += new System.EventHandler(this.frequencyCb_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(41, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 13);
      this.label3.TabIndex = 22;
      this.label3.Text = "Frequency";
      // 
      // EditHardBillForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(360, 213);
      this.Controls.Add(this.frequencyCb);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.firstBillDueDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.accountCb);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.nameTb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditHardBillForm";
      this.Text = "Edit Hard Bill";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ComboBox accountCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DateTimePicker firstBillDueDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox frequencyCb;
        private System.Windows.Forms.Label label3;
    }
}