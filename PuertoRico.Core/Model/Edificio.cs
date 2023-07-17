using PuertoRico.Core.Enums;
using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuertoRico.Core.Model
{
    public abstract class Edificio : IEdificio, IRuta
    {
        public string Nombre { get; private set; }
        public string Descripcion { get; set; }
        public TipoEdificio Tipo => GetType().IsSubclassOf(typeof(EdificioProduccion)) ? TipoEdificio.Produccion : TipoEdificio.Violeta;

        public virtual bool EsGrande => false;

        public int Precio { get; }
        public int Puntos { get; }
        public List<bool> ContenedorColonos { get; private set; }
        public Mercancia Genera { get; }

        public virtual Profesion FaseActivacion { get; }

        public int Casillas => EsGrande ? 2 : 1;

        public string FaseActivacionText()
        {
            if (FaseActivacion != null)
                return $"Fase del {FaseActivacion.ToString()}";
            return "";
        }

        protected Edificio(string nombre, int precio, int puntos, 
            int numColonos, string descripcion = "", Profesion faseActivacion = null, Mercancia genera = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Puntos = puntos;
            ContenedorColonos = Enumerable.Range(0, numColonos).Select(x => false).ToList();
            Genera = genera;
            FaseActivacion = faseActivacion;
        }

        /// <summary>
        /// Lista de mercancias que el edificio puede generar teniendo en cuenta el número de colonos que ocupan el edificio
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Mercancia> PuedeGenerar()
            => Genera.ListaMercancias(NumColonos());

        /// <summary>
        /// Obtiene el numero de colonos que tiene ese edificio
        /// </summary>
        /// <returns></returns>
        public int NumColonos() => ContenedorColonos.Count(x => x);
        
        /// <summary>
        /// Obtiene los huecos sin colono que tiene el edificio
        /// </summary>
        /// <returns></returns>
        public int NumHuecosVacios() => ContenedorColonos.Count(x => !x);

        /// <summary>
        /// Coloca un colono en el edificio
        /// </summary>
        public void ColocarColono()
        {
            if (NumHuecosVacios() < 1)
                throw new Exception("No hay espacio en el edificio para colocar el colono");

            ContenedorColonos[ContenedorColonos.IndexOf(false)] = true;
        }

        /// <summary>
        /// Quita un colono del edificio
        /// </summary>
        public void QuitarColono()
        {
            if (NumColonos() < 1)
                throw new Exception("No hay colonos para quitar en el edificio");

            ContenedorColonos[ContenedorColonos.IndexOf(true)] = false;
        }

        public string GetRuta()
        {
            string name = Nombre.QuitarAcentos().Replace("ñ", "n").ToLower();
            string num = (NumColonos() == 0 ? "" : NumColonos().ToString());
            if (name.Split(' ').Length > 1)
                name = (name.Split(' ').Length > 1) ?
                    name.Split(' ')[0] + name.Split(' ')[1].First().ToString() :
                    name.Split(' ')[0];
            return name + num;
        }

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Edificio)obj).Nombre.Equals(Nombre);
        }
        public override int GetHashCode() => Nombre.GetHashCode();
    }
}
