using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Clinique.Models
{
    public class Veterinar
    {
        public int ID { get; set; } 
        public string NumeMedic { get; set; } =string.Empty;
        public string Specializare { get; set; } = string.Empty;
    }

}
