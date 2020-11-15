
namespace bets
{
    partial class MainForm
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
            this.oddPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sportNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfMatchesLabel = new System.Windows.Forms.Label();
            this.numberOfBetsLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.processTimeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oddPanel
            // 
            this.oddPanel.AutoScroll = true;
            this.oddPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.oddPanel.Location = new System.Drawing.Point(301, 0);
            this.oddPanel.Name = "oddPanel";
            this.oddPanel.Size = new System.Drawing.Size(499, 536);
            this.oddPanel.TabIndex = 2;
            // 
            // sportNameComboBox
            // 
            this.sportNameComboBox.DropDownHeight = 200;
            this.sportNameComboBox.FormattingEnabled = true;
            this.sportNameComboBox.IntegralHeight = false;
            this.sportNameComboBox.Location = new System.Drawing.Point(27, 61);
            this.sportNameComboBox.Name = "sportNameComboBox";
            this.sportNameComboBox.Size = new System.Drawing.Size(176, 28);
            this.sportNameComboBox.TabIndex = 4;
            this.sportNameComboBox.SelectedIndexChanged += new System.EventHandler(this.sportNameComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select sport:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of matches:";
            // 
            // numberOfMatchesLabel
            // 
            this.numberOfMatchesLabel.AutoSize = true;
            this.numberOfMatchesLabel.Location = new System.Drawing.Point(194, 161);
            this.numberOfMatchesLabel.Name = "numberOfMatchesLabel";
            this.numberOfMatchesLabel.Size = new System.Drawing.Size(36, 20);
            this.numberOfMatchesLabel.TabIndex = 7;
            this.numberOfMatchesLabel.Text = "___";
            // 
            // numberOfBetsLabel
            // 
            this.numberOfBetsLabel.AutoSize = true;
            this.numberOfBetsLabel.Location = new System.Drawing.Point(194, 208);
            this.numberOfBetsLabel.Name = "numberOfBetsLabel";
            this.numberOfBetsLabel.Size = new System.Drawing.Size(36, 20);
            this.numberOfBetsLabel.TabIndex = 9;
            this.numberOfBetsLabel.Text = "___";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of bets:";
            // 
            // processTimeLabel
            // 
            this.processTimeLabel.AutoSize = true;
            this.processTimeLabel.Location = new System.Drawing.Point(194, 256);
            this.processTimeLabel.Name = "processTimeLabel";
            this.processTimeLabel.Size = new System.Drawing.Size(36, 20);
            this.processTimeLabel.TabIndex = 11;
            this.processTimeLabel.Text = "___";
            this.processTimeLabel.Click += new System.EventHandler(this.processTimeLabel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Processing time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Size of the data:";
            // 
            // dataSizeLabel
            // 
            this.dataSizeLabel.AutoSize = true;
            this.dataSizeLabel.Location = new System.Drawing.Point(194, 306);
            this.dataSizeLabel.Name = "dataSizeLabel";
            this.dataSizeLabel.Size = new System.Drawing.Size(36, 20);
            this.dataSizeLabel.TabIndex = 13;
            this.dataSizeLabel.Text = "___";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.dataSizeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.processTimeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numberOfBetsLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numberOfMatchesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sportNameComboBox);
            this.Controls.Add(this.oddPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel oddPanel;
        private System.Windows.Forms.ComboBox sportNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numberOfMatchesLabel;
        private System.Windows.Forms.Label numberOfBetsLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label processTimeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dataSizeLabel;
    }
}

