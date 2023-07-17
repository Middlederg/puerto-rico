using PuertoRico.Core.Enums;
using PuertoRico.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuertoRico.Core.Interfaces
{
    public interface ICampo
    {
        TipoRecurso Recurso { get; }
        string Nombre { get; }
        bool Ocupado { get; set; }
        int PrecioBase { get; }
        int TotalReserva { get; set; }
        int TotalMercancias { get; set; }
        Mercancia Genera { get; }
        int Id { get; }

        bool EsCantera();
        bool GeneraMercanciaVendible();
    }
}
