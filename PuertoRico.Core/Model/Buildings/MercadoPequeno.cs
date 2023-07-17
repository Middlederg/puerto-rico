using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class MercadoPequeno : Edificio
    {
        public MercadoPequeno() : base("Mercado pequeño", 2, 1, 1, "+1 doblón por venta", ObjectFactory.Mercader) { }
    }
}
