using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace bets.UI
{
    public partial class MatchItem : UserControl
    {
        String matchUrl;

        public string MatchUrl { get => matchUrl; set => matchUrl = value; }

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

        private void bookmakerNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(matchUrl);
            PopupNotifier popupNotifier = new PopupNotifier();
            popupNotifier.TitleText = "link copied";
            popupNotifier.Size = new System.Drawing.Size(75, 50);
            popupNotifier.Popup();
        }
    }
}
