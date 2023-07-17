using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class AnileriaPequena : EdificioProduccion
    {
        public AnileriaPequena() : base("Añilería pequeña", 1, 1, 1, ObjectFactory.Anil) { }
    }
}
