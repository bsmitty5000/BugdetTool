namespace BudgetToolApp
{
  partial class MainLaunch
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
      this.editBudgetBtn = new System.Windows.Forms.Button();
      this.selectedBudgetLbl = new System.Windows.Forms.Label();
      this.newBudgetBtn = new System.Windows.Forms.Button();
      this.logPurchasesBtn = new System.Windows.Forms.Button();
      this.changeSelectedBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // editBudgetBtn
      // 
      this.editBudgetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.editBudgetBtn.Location = new System.Drawing.Point(12, 138);
      this.editBudgetBtn.Name = "editBudgetBtn";
      this.editBudgetBtn.Size = new System.Drawing.Size(159, 31);
      this.editBudgetBtn.TabIndex = 0;
      this.editBudgetBtn.Text = "Edit Budget";
      this.editBudgetBtn.UseVisualStyleBackColor = true;
      this.editBudgetBtn.Click += new System.EventHandler(this.editBudgetBtn_Click);
      // 
      // selectedBudgetLbl
      // 
      this.selectedBudgetLbl.AutoSize = true;
      this.selectedBudgetLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.selectedBudgetLbl.Location = new System.Drawing.Point(19, 18);
      this.selectedBudgetLbl.Name = "selectedBudgetLbl";
      this.selectedBudgetLbl.Size = new System.Drawing.Size(91, 17);
      this.selectedBudgetLbl.TabIndex = 1;
      this.selectedBudgetLbl.Text = "Selected Budget:";
      // 
      // newBudgetBtn
      // 
      this.newBudgetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.newBudgetBtn.Location = new System.Drawing.Point(12, 101);
      this.newBudgetBtn.Name = "newBudgetBtn";
      this.newBudgetBtn.Size = new System.Drawing.Size(159, 31);
      this.newBudgetBtn.TabIndex = 2;
      this.newBudgetBtn.Text = "New Budget";
      this.newBudgetBtn.UseVisualStyleBackColor = true;
      this.newBudgetBtn.Click += new System.EventHandler(this.newBudgetBtn_Click);
      // 
      // logPurchasesBtn
      // 
      this.logPurchasesBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.logPurchasesBtn.Location = new System.Drawing.Point(12, 175);
      this.logPurchasesBtn.Name = "logPurchasesBtn";
      this.logPurchasesBtn.Size = new System.Drawing.Size(159, 31);
      this.logPurchasesBtn.TabIndex = 3;
      this.logPurchasesBtn.Text = "Log Purchases";
      this.logPurchasesBtn.UseVisualStyleBackColor = true;
      // 
      // changeSelectedBtn
      // 
      this.changeSelectedBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.changeSelectedBtn.Location = new System.Drawing.Point(12, 64);
      this.changeSelectedBtn.Name = "changeSelectedBtn";
      this.changeSelectedBtn.Size = new System.Drawing.Size(159, 31);
      this.changeSelectedBtn.TabIndex = 4;
      this.changeSelectedBtn.Text = "Change Selected";
      this.changeSelectedBtn.UseVisualStyleBackColor = true;
      this.changeSelectedBtn.Click += new System.EventHandler(this.changeSelectedBtn_Click);
      // 
      // MainLaunch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(428, 222);
      this.Controls.Add(this.changeSelectedBtn);
      this.Controls.Add(this.logPurchasesBtn);
      this.Controls.Add(this.newBudgetBtn);
      this.Controls.Add(this.selectedBudgetLbl);
      this.Controls.Add(this.editBudgetBtn);
      this.Name = "MainLaunch";
      this.Text = "Welcome";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button editBudgetBtn;
        private System.Windows.Forms.Label selectedBudgetLbl;
        private System.Windows.Forms.Button newBudgetBtn;
        private System.Windows.Forms.Button logPurchasesBtn;
        private System.Windows.Forms.Button changeSelectedBtn;
    }
}