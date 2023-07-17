using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class SecaderoDeTabaco : EdificioProduccion
    {
        public SecaderoDeTabaco() : base("Secadero de tabaco", 5, 3, 3, ObjectFactory.Tabaco) { }
    }
}
