using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Azucarera : EdificioProduccion
    {
        public Azucarera() : base("Azucarera", 4, 2, 3, ObjectFactory.Azucar) { }
    }
}
