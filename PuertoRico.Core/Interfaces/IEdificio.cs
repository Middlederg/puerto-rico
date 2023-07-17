using PuertoRico.Core.Enums;
using PuertoRico.Core.Model;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PuertoRico.Core.Interfaces
{
    public interface IEdificio
    {
        string Nombre { get; }
        string Descripcion { get; }
        TipoEdificio Tipo { get; }
        int Precio { get; }
        int Puntos { get; }
        List<bool> ContenedorColonos { get; }
        Mercancia Genera { get; }
        Profesion FaseActivacion { get; }
        int Casillas { get; }
        string FaseActivacionText();

        IEnumerable<Mercancia> PuedeGenerar();
        int NumColonos();
        int NumHuecosVacios();
        void ColocarColono();
        void QuitarColono();
    }
}
