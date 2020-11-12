using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets.Data
{
    class Bet
    {
        private string name;
        private double coef;

        public Bet(string name, double coef)
        {
            this.name = name;
            this.coef = coef;
        }

        public double Coef { get => coef; set => coef = value; }
        public string Name { get => name; set => name = value; }
    }
}
