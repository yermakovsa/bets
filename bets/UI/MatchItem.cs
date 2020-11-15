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
            popupNotifier.TitleText = "Link has been copied";
            popupNotifier.Size = new System.Drawing.Size(150, 75);
            popupNotifier.Popup();
        }

        private void MatchItem_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
              Color.Black, 1, ButtonBorderStyle.None, // left
              Color.Black, 1, ButtonBorderStyle.None, // top
              Color.Black, 1, ButtonBorderStyle.None, // right
              Color.Black, 1, ButtonBorderStyle.Outset);// bottom
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(matchUrl);
            PopupNotifier popupNotifier = new PopupNotifier();
            popupNotifier.TitleText = "Info";
            popupNotifier.ContentText = "Link has been copied";
            popupNotifier.Size = new System.Drawing.Size(150, 75);
            popupNotifier.ContentFont = new Font("Times New Roman", 14.0f);
            popupNotifier.TitleFont = new Font("Times New Roman", 12.0f);
            popupNotifier.Popup();
        }
    }
}
