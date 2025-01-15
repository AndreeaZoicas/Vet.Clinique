using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Clinique.Models
{
    public class Pacient
    {
        public int ID { get; set; } // Cheie primară
        public string Nume { get; set; }
        public string Specie { get; set; } // Ex: câine, pisică
        public string Rasa { get; set; }
    }
}
