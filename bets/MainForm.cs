using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bets.Data;
using bets.Service;
using bets.UI;

namespace bets
{
    public partial class MainForm : Form
    {
        Dictionary<String, String> helabetSportIdSportNameMap;
        WebScrapingService webScrapingService = new WebScrapingService();

        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Bookmaker> bookmakers = new List<Bookmaker>();
            bookmakers.Add(webScrapingService.scrapHelabet());
            oddPanel.Controls.Clear();
            foreach (Bookmaker bookmaker in bookmakers)
            {
                foreach (Match match in bookmaker.ListOfMatches)
                {
                    match.MatchName = match.MatchName.Replace("Gaming", "").Replace("Academy", "").Replace("Esports", "").Replace("eSports", "");
                    if (match.ListOfBets.Count > 0)
                    {
                        MatchPanel matchPanel = new MatchPanel(match, bookmaker.Name);
                        oddPanel.Controls.Add(matchPanel);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            helabetSportIdSportNameMap = webScrapingService.getHelabetSportIdSportNameMap();
            sportNameComboBox.Items.AddRange(helabetSportIdSportNameMap.Values.ToArray());
            sportNameComboBox.SelectedIndex = 0;
           /*for (int i = 0; i < 5; i++)
            {   
                List<Bet> bets = new List<Bet>();
                for (int ff = 0; ff < 5; ff++)
                {
                    bets.Add(new Bet(i + "" + ff, i + ff));
                }
                Match match = new Match(i + "", bets);
                match.LeagueName = i + "";
                match.DateTime = DateTime.Now;
                MatchPanel matchPanel = new MatchPanel(match, "Helabet");
                oddPanel.Controls.Add(matchPanel);
            }*/
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //matchItems[0].switchVisibleOfBets();
            //matchItems[0].switchVisibleOfBets();
        }

        private void sportNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sportName = sportNameComboBox.SelectedItem.ToString();
            String sportId = helabetSportIdSportNameMap.FirstOrDefault(x => x.Value == sportName).Key;
            List<Match> matches = webScrapingService.getHelabetMatchesBySportId(sportId);
            oddPanel.Controls.Clear();
            foreach (Match match in matches)
            {
                match.MatchName = match.MatchName.Replace("Gaming", "").Replace("Academy", "").Replace("Esports", "").Replace("eSports", "");
                MatchPanel matchPanel = new MatchPanel(match, "Helabet");
                oddPanel.Controls.Add(matchPanel);
                
            }
        }
    }
}
