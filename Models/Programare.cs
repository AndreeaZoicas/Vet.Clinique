﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Clinique.Models
{
    public class Programare
    {
        public int ID { get; set; } 
        public DateTime DataProgramarii { get; set; }
        public int PacientID { get; set; } 
        public int VeterinarID { get; set; } 
    }
}
