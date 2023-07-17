namespace PuertoRico.Core.Model
{
    public class Aduana : Edificio
    {
        public Aduana() : base("Aduana", 10, 4, 1, "1 PV por cada 4 PV conseguidos durante la partida") { }
        public override bool EsGrande => true;
    }
}
