using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Football_Team_Generator
{
    public class FootballTeam
    {
        private string teamname;
        private IList<Player> players;

        public FootballTeam(string teamname)
        {
            this.Teamname = teamname;
            this.players = new List<Player>();
        }

        public string Teamname
        {
            get { return this.teamname; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty");
                }
                this.teamname = value;
            }
        }
        private IList<Player> Players
        {
            get { return this.players;}
            set { this.players = value; }
        }
        private int RatingCalculator()
        {
            if (this.players.Any())
            {
                return (int)Math.Round(this.players.Average(p => p.GetStats()));
            }
            else 
            {
                return 0;
            }
        }
        public int RatingGet
        {
            get { return RatingCalculator(); }
        }
        public void Addplayer(Player x)
        {
            this.players.Add(x);
        }
        public void RemovePlayer(string pl)
        {
            if (!this.players.Any(p => p.Name == pl))
            {
                throw new ArgumentException($"Player {pl} is not in {this.Teamname} team. ");
            }
            Player player = this.players.FirstOrDefault(x => x.Name == pl);
            this.players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.teamname} - {this.RatingGet}";
        }
    }
}
