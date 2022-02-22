using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    class DetectiveModel : PlayerModel
    {
        public PlayerModel.PlayerType GetRole(PlayerModel player)
        {
            return player.Role;
        }
    }
}
