
namespace bets.UI
{
    partial class MatchPanel
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
            this.oddPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.matchItem = new bets.UI.MatchItem();
            this.oddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oddPanel
            // 
            this.oddPanel.AutoSize = true;
            this.oddPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.oddPanel.Controls.Add(this.matchItem);
            this.oddPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oddPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.oddPanel.Location = new System.Drawing.Point(0, 0);
            this.oddPanel.Name = "oddPanel";
            this.oddPanel.Size = new System.Drawing.Size(473, 101);
            this.oddPanel.TabIndex = 0;
            // 
            // matchItem
            // 
            this.matchItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.matchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchItem.Location = new System.Drawing.Point(0, 0);
            this.matchItem.Margin = new System.Windows.Forms.Padding(0);
            this.matchItem.MatchUrl = null;
            this.matchItem.Name = "matchItem";
            this.matchItem.Size = new System.Drawing.Size(473, 101);
            this.matchItem.TabIndex = 0;
            this.matchItem.Load += new System.EventHandler(this.matchItem_Load);
            this.matchItem.Paint += new System.Windows.Forms.PaintEventHandler(this.matchItem_Paint);
            this.matchItem.DoubleClick += new System.EventHandler(this.matchItem_DoubleClick);
            // 
            // MatchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.oddPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MatchPanel";
            this.Size = new System.Drawing.Size(473, 101);
            this.Load += new System.EventHandler(this.MatchPanel_Load);
            this.oddPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel oddPanel;
        private MatchItem matchItem;
    }
}
