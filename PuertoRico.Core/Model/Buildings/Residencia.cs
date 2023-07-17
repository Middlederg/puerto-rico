namespace PuertoRico.Core.Model
{
    public class Residencia : Edificio
    {
        public Residencia() : base("Residencia", 10, 4, 1, "PV por casillas llenas en la isla (plantaciones y canteras, ocupadas o no):\n\t9- -> 4 PV\n\t10 -> 5 PV\n\t11 -> 6 PV\n\t12 -> 7 PV\n\t)") { }
        public override bool EsGrande => true;
    }
}
