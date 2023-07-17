using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Hacienda : Edificio
    {
        public Hacienda() : base("Hacienda", 2, 1, 1, "+1 plantación de la reserva", ObjectFactory.Colonizador) { }
    }
}
