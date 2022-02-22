using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    class PlayerModel
    {
        public enum PlayerType
        {
            Civilian,
            Mafia,
            Detective,
            Doctor
        }

        public string Name { get; set; }

        public PlayerType Role { get; set; }

        public bool Alive { get; set; }

        public bool AtRisk { get; set; }

        public int Targeted { get; set; } //is for mafia

        public int Accused { get; set; } //is for everyone

        public int Votes { get; set; }//used for mafia and whole group

        public int TimesAtRisk { get; set; }


        public void Vote(PlayerModel player)
        {
            player.VoteFor();
        }

        public void VoteFor()
        {
            Votes++;
        }

        public void VoteReset()
        {
            Votes = 0;
        }

        public void Accuse(PlayerModel player)
        {
            player.Accused += 1;
        }

        public void Target()
        {
            Targeted += 1;
        }

        public void TargetRemove()
        {
            Targeted -= 1;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Role: {Role}, Alive: {Alive}, VoteNum: {Votes}";
        }
    }
}
