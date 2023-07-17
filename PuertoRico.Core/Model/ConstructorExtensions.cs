using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Negocio;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoRico.Core.Model
{
    public static class ConstructorExtensions
    {
        /// <summary>
        /// Determina si el jugador puede construir el edificio
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="edificio">Edificio</param>
        /// <returns></returns>
        public static bool EdificioConstruible(this Player p, IEdificio edificio)
        {
            //No puedes tener edificios repetidos
            if (p.Edificios.Contains(edificio))
                return false;

            //Te tiene que caber en el espacio
            if ((edificio.Casillas == 2 && p.EspacioEdificado > 10) || (edificio.Casillas == 2 && p.EspacioEdificado > 11))
                return false;

            //Te lo puedes permitir
            if (p.Doblones - p.CosteEdificio(edificio) < 0)
                return false;

            return true;
        }

        /// <summary>
        /// Determina el coste del edificio para ese jugador
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="edificio">Edificio</param>
        /// <returns></returns>
        public static int CosteEdificio(this Player p, IEdificio edificio)
        {
            int precio = edificio.Precio;

            //Descuento por ser el constructor
            if (p.Profesiones.Any() && p.Profesiones.Last().Equals(ObjectFactory.Constructor))
                precio--;

            //Descuento de las canteras
            precio -= Math.Min(p.CanterasActivas, edificio.Puntos);

            //Precio mínimo es 0
            return (precio > 0) ? precio : 0;
        }

        /// <summary>
        /// Construye el edificio seleccionado, y el jugador gasta el importe
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="edificio">Edificio</param>
        /// <param name="quedanColonos">Indica si quedan colonos en la reserva</param>
        /// <returns>Devuelve si se gastó un colono de la reserva, por tener la universidad</returns>
        public static bool Construir(this Player p, IEdificio edificio, bool quedanColonos)
        {
            int precio = p.CosteEdificio(edificio);
            if (precio > p.Doblones)
                throw new Exception($"Imposible construir {p.ToString()} con solo {p.Doblones} doblones");

            if (p.EdificioActivo(ObjectFactory.Universidad) && quedanColonos)
                edificio.ColocarColono();
            p.Edificios.Add(edificio);
            p.Doblones -= precio;
            return edificio.NumColonos() > 0;
        }
    }
}
