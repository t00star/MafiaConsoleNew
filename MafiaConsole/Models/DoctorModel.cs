using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    class DoctorModel : PlayerModel
    {
        public void Save(PlayerModel player)
        {
            if(player.AtRisk)
            {
                player.AtRisk = false;
            }
        }
    }
}
