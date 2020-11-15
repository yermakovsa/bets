
namespace bets.UI
{
    partial class MatchItem
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
            this.matchNameLabel = new System.Windows.Forms.Label();
            this.leagueNameLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.bookmakerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // matchNameLabel
            // 
            this.matchNameLabel.AutoSize = true;
            this.matchNameLabel.Location = new System.Drawing.Point(22, 11);
            this.matchNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.matchNameLabel.Name = "matchNameLabel";
            this.matchNameLabel.Size = new System.Drawing.Size(127, 20);
            this.matchNameLabel.TabIndex = 0;
            this.matchNameLabel.Text = "Navi vs VirtusPro";
            // 
            // leagueNameLabel
            // 
            this.leagueNameLabel.AutoSize = true;
            this.leagueNameLabel.Location = new System.Drawing.Point(22, 40);
            this.leagueNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leagueNameLabel.Name = "leagueNameLabel";
            this.leagueNameLabel.Size = new System.Drawing.Size(138, 20);
            this.leagueNameLabel.TabIndex = 1;
            this.leagueNameLabel.Text = "International 2020";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(22, 70);
            this.startDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(148, 20);
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "11.15.2020 9:00AM";
            // 
            // bookmakerNameLabel
            // 
            this.bookmakerNameLabel.AutoSize = true;
            this.bookmakerNameLabel.Location = new System.Drawing.Point(311, 11);
            this.bookmakerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookmakerNameLabel.Name = "bookmakerNameLabel";
            this.bookmakerNameLabel.Size = new System.Drawing.Size(65, 20);
            this.bookmakerNameLabel.TabIndex = 3;
            this.bookmakerNameLabel.Text = "Helabet";
            // 
            // MatchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.bookmakerNameLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.leagueNameLabel);
            this.Controls.Add(this.matchNameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MatchItem";
            this.Size = new System.Drawing.Size(389, 97);
            this.Load += new System.EventHandler(this.MatchItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label matchNameLabel;
        private System.Windows.Forms.Label leagueNameLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label bookmakerNameLabel;
    }
}
