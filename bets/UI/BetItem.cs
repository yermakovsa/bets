using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bets.UI
{
    public partial class BetItem : UserControl
    {
        public BetItem(String betName, String coef)
        {
            InitializeComponent();
            betNameLabel.Text = betName;
            betCoefLabel.Text = coef;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BetItem_Load(object sender, EventArgs e)
        {

        }
    }
}
