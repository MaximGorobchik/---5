using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Football_Team_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var team = new List<FootballTeam>();
            var inputline = string.Empty;
            while((inputline = Console.ReadLine()) != "END")
            {
                var info = inputline.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                var check = info[0];
                try
                {
                    switch (check)
                    {
                        case "Team": team.Add(new FootballTeam(info[1])); break;
                        case "team": team.Add(new FootballTeam(info[1])); break;
                        case "Add":
                            if (!team.Any(x => x.Teamname == info[1]))
                            {
                                throw new ArgumentException($"Team {info[1]} does not exist");
                            }
                            else
                            {
                                var Team = team.First(x => x.Teamname == info[1]);
                                Team.Addplayer(new Player(info[2], int.Parse(info[3]), int.Parse(info[4]), int.Parse(info[5]), int.Parse(info[6]), int.Parse(info[7])));
                            }
                            break;
                        case "add":
                            if (!team.Any(x => x.Teamname == info[1]))
                            {
                                throw new ArgumentException($"Team {info[1]} does not exist");
                            }
                            else
                            {
                                var Team = team.First(x => x.Teamname == info[1]);
                                Team.Addplayer(new Player(info[2], int.Parse(info[3]), int.Parse(info[4]), int.Parse(info[5]), int.Parse(info[6]), int.Parse(info[7])));
                            }
                            break;
                        case "Remove":
                            if (!team.Any(x => x.Teamname == info[1]))
                            {
                                throw new ArgumentException($"Team {info[1]} does not exist");
                            }
                            else
                            {
                                var r = team.First(x => x.Teamname == info[1]);
                                r.RemovePlayer(info[2]);
                            }
                            break;
                        case "remove":
                            var s = team.First(x => x.Teamname == info[1]);
                            s.RemovePlayer(info[2]);
                            break;
                        case "Rating":
                            if (!team.Any(x => x.Teamname == info[1]))
                            {
                                throw new ArgumentException($"Team {info[1]} does not exist");
                            }
                            else
                            {
                                Console.WriteLine(team.First(x => x.Teamname == info[1]).ToString());
                            }
                            break;
                        case "rating":
                            if (!team.Any(x => x.Teamname == info[1]))
                            {
                                throw new ArgumentException($"Team {info[1]} does not exist");
                            }
                            else
                            {
                                Console.WriteLine(team.First(x => x.Teamname == info[1]).ToString());
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
