using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Puerto : Edificio
    {
        public Puerto() : base("Puerto", 8, 3, 1, "+1 PV po embarcar mercancías", ObjectFactory.Capitan) { }
    }
}
