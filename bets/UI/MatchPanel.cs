using bets.Data;
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
    public partial class MatchPanel : UserControl
    {
        Match match;
        String bookmakerName;
        bool isBetsShown = false;
        public MatchPanel()
        {
            InitializeComponent();
        }
        public MatchPanel(Match match, String bookmakerName)
        {
            this.match = match;
            this.bookmakerName = bookmakerName;
            InitializeComponent();
        }
        private void hideBets()
        {
            for(int i = 0; i < match.ListOfBets.Count; i++)
            {
                oddPanel.Controls.RemoveAt(1);
            }
        }
        private void showBets()
        {
            foreach(Bet bet in match.ListOfBets)
            {
                BetItem betItem = new BetItem(bet.Name, bet.Coef + "");
                oddPanel.Controls.Add(betItem);
            }
        }

        private void startDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void matchItem_DoubleClick(object sender, EventArgs e)
        {
            if (isBetsShown)
            {
                hideBets();
                isBetsShown = false;
            }
            else
            {
                showBets();
                isBetsShown = true;
            }
        }

        private void matchItem_Load(object sender, EventArgs e)
        {

        }

        private void MatchPanel_Load(object sender, EventArgs e)
        {
            matchItem.setBookmakerName(bookmakerName);
            matchItem.setMatchName(match.MatchName);
            matchItem.setStartDate(match.DateTime.ToShortDateString() + " " + match.DateTime.ToShortTimeString());
            matchItem.setLeagueName(match.LeagueName);
            matchItem.MatchUrl = match.Url;
        }
    }
}
