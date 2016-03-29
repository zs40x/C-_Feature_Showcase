namespace _02_autoprops
{
    partial class MainWnd
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
            this.tbMoneyIn = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMoneyTotal = new System.Windows.Forms.TextBox();
            this.tbOperator = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMoneyIn
            // 
            this.tbMoneyIn.Location = new System.Drawing.Point(18, 49);
            this.tbMoneyIn.Name = "tbMoneyIn";
            this.tbMoneyIn.Size = new System.Drawing.Size(153, 31);
            this.tbMoneyIn.TabIndex = 0;
            this.tbMoneyIn.Text = "1,00 EUR";
            this.tbMoneyIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMoneyIn_KeyDown);
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(13, 21);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(64, 25);
            this.lbInput.TabIndex = 2;
            this.lbInput.Text = "Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total";
            // 
            // tbMoneyTotal
            // 
            this.tbMoneyTotal.Location = new System.Drawing.Point(203, 49);
            this.tbMoneyTotal.Name = "tbMoneyTotal";
            this.tbMoneyTotal.ReadOnly = true;
            this.tbMoneyTotal.Size = new System.Drawing.Size(182, 31);
            this.tbMoneyTotal.TabIndex = 4;
            // 
            // tbOperator
            // 
            this.tbOperator.Location = new System.Drawing.Point(177, 49);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.Size = new System.Drawing.Size(20, 31);
            this.tbOperator.TabIndex = 5;
            this.tbOperator.Text = "+";
            this.tbOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMoneyIn_KeyDown);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 92);
            this.Controls.Add(this.tbOperator);
            this.Controls.Add(this.tbMoneyTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.tbMoneyIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWnd";
            this.Text = "Money Counter";
            this.Shown += new System.EventHandler(this.MainWnd_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMoneyIn;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMoneyTotal;
        private System.Windows.Forms.TextBox tbOperator;
    }
}

