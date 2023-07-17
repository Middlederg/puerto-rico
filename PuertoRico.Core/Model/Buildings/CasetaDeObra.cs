using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class CasetaDeObra : Edificio
    {
        public CasetaDeObra() : base("Caseta de obra", 2, 1, 1, "Cantera en vez de plantación", ObjectFactory.Colonizador) { }
    }
}
