namespace Core
{
    public class VolPrive : Vol
    {
        public bool WiFi;
        public VolPrive()
        {

        }
        public VolPrive(string[] valeurs)
            : base(valeurs)
        {
            this.WiFi = bool.Parse(valeurs[6]);
        }
        public VolPrive(int numeroVol, string destination, Date dateVol, int reservation, Avion avion, bool wiFi)
            : base(numeroVol, destination, dateVol, reservation, avion)
        {
            this.WiFi = wiFi;
        }

        public override int Categorie => 4;

        public override string ToString()
        {
            return $"{base.ToString()};{WiFi}";
        }
    }
}
