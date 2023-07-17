using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Negocio;
using System;
using System.Linq;

namespace PuertoRico.Core.Model
{
    public static class ColonizadorExtensions
    {
        /// <summary>
        /// Determina si un jugador puede plantar un campo o construir una cantera
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="campo">Campo</param>
        /// <returns></returns>
        public static bool CampoPlantable(this Player p, ICampo campo)
        {
            if (campo.EsCantera())
                return p.Canteras < 4;
            return p.Campos.Count() < 12;
        }

        /// <summary>
        /// Planta el campo o cantera seleccionado
        /// </summary>
        /// <param name="p"></param>
        /// <param name="campo"></param>
        /// <param name="quedanColonos"></param>
        /// <returns></returns>
        public static bool ColonizarCampo(this Player p, ICampo campo, bool quedanColonos)
        {
            if (!p.CampoPlantable(campo))
                throw new Exception($"{p.ToString()} no puede plantar el campo {campo.ToString()}");

            if (p.EdificioActivo(ObjectFactory.Hospicio) && quedanColonos)
                campo.Ocupado = true;
            p.Campos.Add(campo);
            return campo.Ocupado;
        }
    }
}
