using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Universidad : Edificio
    {
        public Universidad() : base("Universidad", 8, 3, 1, "+1 colono para edificio", ObjectFactory.Constructor) { }
    }
}
