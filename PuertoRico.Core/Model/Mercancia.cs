using PuertoRico.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using PuertoRico.Core.Enums;
using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Mercancia : IRuta
    {
        private Campo campo;
        public string Nombre => campo.Nombre;
        public int Precio => campo.PrecioBase;
        public int TotalMercancias => campo.TotalMercancias;
        public TipoRecurso Recurso => campo.Recurso;

        public Mercancia(Campo c)
        {
            campo = c;
        }

        public Mercancia(TipoRecurso recurso)
        {
            campo = ObjectFactory.Create(recurso);
        }

        public Campo CampoGenerador() => campo;

        public IEnumerable<Mercancia> ListaMercancias(int num)
        {
            foreach (int i in Enumerable.Range(0, num))
                yield return this;
        }

        public static IEnumerable<Mercancia> ListaMercancias(Mercancia m, int num)
        {
            foreach (int i in Enumerable.Range(0, num))
                yield return m;
        }

        public string GetRuta() => "Barril" + Nombre.QuitarAcentos().Replace("ñ", "n");

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Mercancia)obj).campo.Equals(campo);
        }
        public override int GetHashCode() => campo.GetHashCode();

    
    }
}
