namespace Core
{
    public class VolRegulier : Vol
    {
        public bool Repas;
        public VolRegulier()
        {

        }
        public VolRegulier(string[] valeurs)
            : base(valeurs)
        {
            this.Repas = bool.Parse(valeurs[6]);
        }
        public VolRegulier(int numeroVol, string destination, Date dateVol, int reservation, in Avion avion, bool repas)
            : base(numeroVol, destination, dateVol, reservation, avion)
        {
            this.Repas = repas;
        }

        public override int Categorie => 1;

        public override string ToString()
        {
            return $"{base.ToString()};{Repas}";
        }
    }
}
