namespace PuertoRico.Core.Model
{
    public class Fortaleza : Edificio
    {
        public Fortaleza() : base("Fortaleza", 10, 4, 1, "1 PV por cada tres colonos") { }
        public override bool EsGrande => true;
    }
}
