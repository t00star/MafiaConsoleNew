using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Models
{
    public class PieceModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Period { get; set; }
        public int Tempo { get; set; }
        public string TimeSignature { get; set; }

        public override string ToString()
        {
            return $"Piece ID: {Id}\nName: {Name} \nComposer: {Composer}\nPeriod: {Period}\nTempo: {Tempo}\nTime Signature: {TimeSignature}\n";
        }
    }
}
