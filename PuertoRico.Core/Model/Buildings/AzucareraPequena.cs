using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class AzucareraPequena : EdificioProduccion
    {
        public AzucareraPequena() : base("Azucarera pequeña", 2, 1, 1, ObjectFactory.Azucar) { }
    }
}
