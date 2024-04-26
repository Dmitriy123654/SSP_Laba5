namespace ClientLab5
{
    partial class Form1
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
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnGetPrice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(12, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(200, 20);
            this.txtProductName.TabIndex = 0;
            // 
            // btnGetPrice
            // 
            this.btnGetPrice.Location = new System.Drawing.Point(12, 38);
            this.btnGetPrice.Name = "btnGetPrice";
            this.btnGetPrice.Size = new System.Drawing.Size(75, 23);
            this.btnGetPrice.TabIndex = 1;
            this.btnGetPrice.Text = "Get Price";
            this.btnGetPrice.UseVisualStyleBackColor = true;
            this.btnGetPrice.Click += new System.EventHandler(this.btnGetPrice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 81);
            this.Controls.Add(this.btnGetPrice);
            this.Controls.Add(this.txtProductName);
            this.Name = "Form1";
            this.Text = "Price Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnGetPrice;
    }

   
}

