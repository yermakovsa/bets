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
    public partial class MatchItem : UserControl
    {
        public MatchItem()
        {
            InitializeComponent();
        }
        public void setMatchName(String matchName)
        {
            matchNameLabel.Text = matchName;
        }
        public void setLeagueName(String leagueName)
        {
            leagueNameLabel.Text = leagueName;
        }
        public void setStartDate(String startDate)
        {
            startDateLabel.Text = startDate;
        }
        public void setBookmakerName(String bookmakerName)
        {
            bookmakerNameLabel.Text = bookmakerName;
        }
        private void MatchItem_Load(object sender, EventArgs e)
        {

        }
    }
}
