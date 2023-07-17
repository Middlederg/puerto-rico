namespace PuertoRico.Core.Model
{
    public class Cofradia : Edificio
    {
        public Cofradia() : base("Cofradía", 10, 4, 1, "2 PV por cada dificio de producción normal y 1 PV por cada edificio de producción pequeño (ocupados o sin ocupar)") { }
        public override bool EsGrande => true;
    }
}
