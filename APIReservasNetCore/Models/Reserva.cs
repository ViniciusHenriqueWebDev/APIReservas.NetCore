﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReservasNetCore.Models
{
    public class Reserva
    {
        public int ReservaId { get; set;  }

        public string Nome { get; set; }

        public string InicioLocacao { get; set; }

        public string FImLocacao { get; set; }

    }
}
