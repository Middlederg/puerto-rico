using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class AlmacenGrande : Edificio
    {
        public AlmacenGrande() : base("Almacén grande", 6, 2, 1, "Almacena 2 tipos de mercancías", ObjectFactory.Capitan) { }
    }
}
