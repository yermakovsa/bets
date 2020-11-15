
namespace bets.UI
{
    partial class BetItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.betNameLabel = new System.Windows.Forms.Label();
            this.betCoefLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // betNameLabel
            // 
            this.betNameLabel.AutoSize = true;
            this.betNameLabel.Location = new System.Drawing.Point(33, 11);
            this.betNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.betNameLabel.Name = "betNameLabel";
            this.betNameLabel.Size = new System.Drawing.Size(76, 20);
            this.betNameLabel.TabIndex = 0;
            this.betNameLabel.Text = "BetName";
            this.betNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // betCoefLabel
            // 
            this.betCoefLabel.AutoSize = true;
            this.betCoefLabel.Location = new System.Drawing.Point(360, 11);
            this.betCoefLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.betCoefLabel.Name = "betCoefLabel";
            this.betCoefLabel.Size = new System.Drawing.Size(68, 20);
            this.betCoefLabel.TabIndex = 1;
            this.betCoefLabel.Text = "BetCoef";
            // 
            // BetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.betCoefLabel);
            this.Controls.Add(this.betNameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BetItem";
            this.Size = new System.Drawing.Size(449, 46);
            this.Load += new System.EventHandler(this.BetItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label betNameLabel;
        private System.Windows.Forms.Label betCoefLabel;
    }
}
