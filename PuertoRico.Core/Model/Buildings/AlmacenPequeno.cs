using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class AlmacenPequeno : Edificio
    {
        public AlmacenPequeno() : base("Almacén pequeño", 3, 1, 1, "Almacena 1 tipo de mercancías", ObjectFactory.Capitan) { }
    }
}
