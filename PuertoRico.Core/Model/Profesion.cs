using PuertoRico.Core.Interfaces;
using System;

namespace PuertoRico.Core.Model
{
    public class Profesion : IRuta
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; set; }
        public string Beneficio { get; set; }
        public bool EsBuscadorOro => Id == 7 || Id == 8;

        public Profesion(int id, string nombre, string descripcion, string beneficio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Beneficio = beneficio;
        }

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Profesion)obj).Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();

        public string GetRuta() => EsBuscadorOro ? "buscadordeoro" : Nombre.ToLower();
    }
}
