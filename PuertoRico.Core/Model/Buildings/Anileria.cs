using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Anileria : EdificioProduccion
    {
        public Anileria() : base("Añilería", 3, 2, 3, ObjectFactory.Anil) { }
    }
}
