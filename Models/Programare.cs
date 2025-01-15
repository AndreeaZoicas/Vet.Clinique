using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Clinique.Models
{
    public class Programare
    {
        public int ID { get; set; } // Cheie primară
        public DateTime DataProgramarii { get; set; }
        public int PacientID { get; set; } // FK către Pacient
        public int VeterinarID { get; set; } // FK către Veterinar
    }
}
