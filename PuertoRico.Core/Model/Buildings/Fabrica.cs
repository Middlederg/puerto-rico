using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Fabrica : Edificio
    {
        public Fabrica() : base("Fábrica", 7, 3, 1, "+0/1/2/3/5 doblones por tipo de mercancía", ObjectFactory.Capataz) { }
    }
}
