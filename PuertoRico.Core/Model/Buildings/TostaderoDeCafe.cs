using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class TostaderoDeCafe : EdificioProduccion
    {
        public TostaderoDeCafe() : base("Tostadero de café", 6, 3, 3, ObjectFactory.Cafe) { }
    }
}
