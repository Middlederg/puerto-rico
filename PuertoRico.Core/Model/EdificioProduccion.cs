using PuertoRico.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PuertoRico.Core.Model
{
    public abstract class EdificioProduccion : Edificio
    {
        public bool EsEdificioProduccionGrande => ContenedorColonos.Count > 1;
        public override Profesion FaseActivacion => null;

        protected EdificioProduccion(string nombre, int precio, int puntos, int numColonos, Mercancia genera) : 
            base(nombre, precio, puntos, numColonos, "", null, genera) { }

        public IEnumerable<Mercancia> GetMercancias()
        {
            if (Genera is null) throw new System.Exception("Edificio de producción debe generar alguna mercancia");
            foreach (var i in Enumerable.Range(0, NumColonos()))
                yield return Genera;
        }
    }
}
