using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class MercadoGrande : Edificio
    {
        public MercadoGrande() : base("Mercado grande", 5, 2, 1, "+2 doblones por venta", ObjectFactory.Mercader) { }
    }
}
