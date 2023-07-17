using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Oficina : Edificio
    {
        public Oficina() : base("Oficina", 5, 2, 1, "Vende un tipo de mercancia repetido", ObjectFactory.Mercader) { }
    }
}
