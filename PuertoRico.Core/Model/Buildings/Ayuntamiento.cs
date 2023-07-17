namespace PuertoRico.Core.Model
{
    public class Ayuntamiento : Edificio
    {
        public Ayuntamiento() : base("Ayuntamiento", 10, 4, 1, "1 PV por cada edificio violeta") { }
        public override bool EsGrande => true;
    }
}
