namespace Core
{
    public class VolBasPrix : Vol
    {
        public int Prix;
        public VolBasPrix()
        {

        }
        public VolBasPrix(string[] valeurs)
            : base(valeurs)
        {
            this.Prix = int.Parse(valeurs[6]);
        }
        public VolBasPrix(int numeroVol, string destination, Date dateVol, int reservation, Avion avion, int prix)
            : base(numeroVol, destination, dateVol, reservation, avion)
        {
            this.Prix = prix;
        }

        public override int Categorie => 2;

        public override string ToString()
        {
            return $"{base.ToString()};{Prix}";
        }
    }
}
