
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
            this.button1 = new System.Windows.Forms.Button();
            this.oddPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.sportNameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 62);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sportNameComboBox
            // 
            this.sportNameComboBox.DropDownHeight = 200;
            this.sportNameComboBox.FormattingEnabled = true;
            this.sportNameComboBox.IntegralHeight = false;
            this.sportNameComboBox.Location = new System.Drawing.Point(27, 104);
            this.sportNameComboBox.Name = "sportNameComboBox";
            this.sportNameComboBox.Size = new System.Drawing.Size(176, 28);
            this.sportNameComboBox.TabIndex = 4;
            this.sportNameComboBox.SelectedIndexChanged += new System.EventHandler(this.sportNameComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.sportNameComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.oddPanel);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel oddPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox sportNameComboBox;
    }
}

