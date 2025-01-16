using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Clinique.Models
{
    public class Pacient
    {
        public int ID { get; set; } 
        public string NumePacient { get; set; } = string.Empty;
        public string Specie { get; set; } = string.Empty;
        public string Rasa { get; set; } = string.Empty;
    }
}
