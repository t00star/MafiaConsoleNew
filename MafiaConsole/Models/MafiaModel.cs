using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    class MafiaModel : PlayerModel
    {
        public void DiscussHit(string message)
        {
            //add code to send string
        }

        public void VoteHit(PlayerModel player, bool vote)
        {
            if(vote) { player.VoteFor(); }
        }

        public void TargetPlayer(PlayerModel player)
        {
            player.Target();
        }

        public void TargetRemove(PlayerModel player)
        {
            player.TargetRemove();
        }
    }
}
