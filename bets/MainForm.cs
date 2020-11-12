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
using bet.Functions;

namespace bets
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task3 = Task.Run(Helabet.Start);
            task3.Wait();
            List<Bookmaker> bookmakers = new List<Bookmaker>();
            bookmakers.Add(Helabet.GetHelabet());
            foreach (Bookmaker bookmaker in bookmakers)
            {
                listBox1.Items.Add(bookmaker.Name);
                listBox1.Items.Add(bookmaker.ListOfMatches.Count);
                foreach (Match match in bookmaker.ListOfMatches)
                {
                    match.MatchName = match.MatchName.Replace("Gaming", "").Replace("Academy", "").Replace("Esports", "").Replace("eSports", "");
                    listBox1.Items.Add(match.MatchName + " " + match.DateTime.ToString());
                    foreach (Bet bet in match.ListOfBets)
                    {
                        listBox1.Items.Add(bet.Name + " " + bet.Coef);
                    }
                }
            }
        }
    }
}
