using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
    }
}
