using PuertoRico.Core.Negocio;

namespace PuertoRico.Core.Model
{
    public class Hospicio : Edificio
    {
        public Hospicio() : base("Hospicio", 4, 2, 1, "+1 colono para plantación o cantera", ObjectFactory.Colonizador) { }
    }
}
