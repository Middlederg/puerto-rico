using PuertoRico.Core.Enums;
using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Model;
using System.Drawing;

namespace PuertoRico.Core.Model
{
    public abstract class Campo : ICampo, IRuta
    {
        public TipoRecurso Recurso { get; }
        public string Nombre { get; }
        public bool Ocupado { get; set; }
        public int PrecioBase { get; }
        public int TotalReserva { get; set; }
        public int TotalMercancias { get; set; }
        public Mercancia Genera
        {
            get {  return new Mercancia(this); }
        }

        public Campo(TipoRecurso recurso, string nombre, int totalReserva, int totalMercancias = 0, int precioBase = 0)
        {
            Nombre = nombre;
            Ocupado = false;
            PrecioBase = precioBase;
            TotalReserva = totalReserva;
            TotalMercancias = totalMercancias;
        }

        public int Id => ((int)Recurso);
        public bool EsCantera() => GetType().Equals(typeof(Cantera));
        public bool GeneraMercanciaVendible() => !GetType().Equals(typeof(Cantera));

        public string GetRuta()
        {
            var oc = (Ocupado ? "Oc" : "");
            return $"{GetType().Name.ToLower()}{oc}";
        }

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Campo)obj).Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }
}
