namespace BudgetToolGui
{
  partial class EditAccountForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.nameTb = new System.Windows.Forms.TextBox();
      this.balanceTb = new System.Windows.Forms.TextBox();
      this.saveBtn = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.typeCb = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 45);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Balance";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 70);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Type";
      // 
      // nameTb
      // 
      this.nameTb.Location = new System.Drawing.Point(98, 12);
      this.nameTb.Name = "nameTb";
      this.nameTb.Size = new System.Drawing.Size(100, 20);
      this.nameTb.TabIndex = 3;
      this.nameTb.TextChanged += new System.EventHandler(this.nameTb_TextChanged);
      // 
      // balanceTb
      // 
      this.balanceTb.Location = new System.Drawing.Point(98, 38);
      this.balanceTb.Name = "balanceTb";
      this.balanceTb.Size = new System.Drawing.Size(100, 20);
      this.balanceTb.TabIndex = 4;
      this.balanceTb.TextChanged += new System.EventHandler(this.balanceTb_TextChanged);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(15, 99);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 6;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(123, 99);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 7;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // typeCb
      // 
      this.typeCb.FormattingEnabled = true;
      this.typeCb.Location = new System.Drawing.Point(98, 67);
      this.typeCb.Name = "typeCb";
      this.typeCb.Size = new System.Drawing.Size(121, 21);
      this.typeCb.TabIndex = 8;
      this.typeCb.SelectedIndexChanged += new System.EventHandler(this.typeCb_SelectedIndexChanged);
      // 
      // EditAccountForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(251, 163);
      this.Controls.Add(this.typeCb);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.balanceTb);
      this.Controls.Add(this.nameTb);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditAccountForm";
      this.Text = "Edit Account";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox balanceTb;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox typeCb;
    }
}