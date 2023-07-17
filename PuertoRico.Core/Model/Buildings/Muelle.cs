using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Muelle : Edificio
    {
        public Muelle() : base("Muelle", 9, 3, 1, "Embarcadero con barco propio", ObjectFactory.Capitan) { }
    }
}
