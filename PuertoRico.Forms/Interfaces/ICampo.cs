using PuertoRico.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuertoRico.Core.Interfaces
{
    public interface ICampo
    {
        int Id { get; set; }
        string Nombre { get; set; }
        bool Ocupado { get; set; }
        Mercancia Genera { get; set; }
    }
}
