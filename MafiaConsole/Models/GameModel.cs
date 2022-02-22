using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    class GameModel
    {
        public List<PlayerModel> allPlayers = new List<PlayerModel>();
        public List<MafiaModel> MafiaPlayers = new List<MafiaModel>();
        public List<DetectiveModel> DetectivePlayers = new List<DetectiveModel>();
        public List<DoctorModel> DoctorPlayers = new List<DoctorModel>();

        List<string> PlayersToLoad = new List<string>();
        private int _playerCount = 0;

        public GameModel()
        {
            _playerCount = 12;
        }

        public GameModel(int playerCount)
        {
            _playerCount = playerCount;
        }

        public DoctorModel Doctor { get; set; }
        public DetectiveModel Detective { get; set; }


        public void AddPlayer (int count)
        {
            Console.WriteLine($"Enter name for player #{count + 1}");
            PlayersToLoad.Add(Console.ReadLine());
        }

        public void BuildPlayerList()
        {
            for (int i = 0; i < _playerCount; i++) { AddPlayer(i); }
        }

        public void AssignRoles()
        {
            Random random = new Random();

            //add mafia
            for (int i = 0; i < 3; i++) //maxValue may need future revisions
            {
                int mafia = random.Next(0, PlayersToLoad.Count);
                MafiaModel mafiaPlayer = new MafiaModel();

                mafiaPlayer.Name = PlayersToLoad[mafia];
                mafiaPlayer.Role = PlayerModel.PlayerType.Mafia;

                MafiaPlayers.Add(mafiaPlayer);
                allPlayers.Add(mafiaPlayer);

                PlayersToLoad.RemoveAt(mafia);
            }

            //set doctor(s)
            for(int i = 0; i < 1; i++)
            {
                int doc = random.Next(0, PlayersToLoad.Count);
                DoctorModel doctorPlayer = new DoctorModel();

                doctorPlayer.Name = PlayersToLoad[doc];
                doctorPlayer.Role = PlayerModel.PlayerType.Doctor;

                DoctorPlayers.Add(doctorPlayer);
                allPlayers.Add(doctorPlayer);

                PlayersToLoad.RemoveAt(doc);
            }

            //set detectives(s)
            for(int i = 0; i < 1; i++)
            {
                int det = random.Next(0, PlayersToLoad.Count);
                DetectiveModel detectivePlayer = new DetectiveModel();

                detectivePlayer.Name = PlayersToLoad[det];
                detectivePlayer.Role = PlayerModel.PlayerType.Detective;

                DetectivePlayers.Add(detectivePlayer);
                allPlayers.Add(detectivePlayer);

                PlayersToLoad.RemoveAt(det);
            }

            foreach(string p in PlayersToLoad)
            {
                PlayerModel player = new PlayerModel();
                player.Name = p;
                player.Role = PlayerModel.PlayerType.Civilian;

                allPlayers.Add(player);
            }
        }
    }
}
