namespace Core
{
    public class VolCharter : Vol
    {
        public bool ServiceBar;
        public bool Divertissement;
        public VolCharter()
        {

        }
        public VolCharter(string[] valeurs)
            : base(valeurs)
        {
            this.ServiceBar = bool.Parse(valeurs[6]);
            this.Divertissement = bool.Parse(valeurs[7]);
        }
        public VolCharter(int numeroVol, string destination, Date dateVol, int reservation, in Avion avion, bool serviceBar, bool divertissement)
            : base(numeroVol, destination, dateVol, reservation, avion)
        {
            this.ServiceBar = serviceBar;
            this.Divertissement = divertissement;
        }

        public override int Categorie => 3;

        public override string ToString()
        {
            return $"{base.ToString()};{ServiceBar};{Divertissement}";
        }
    }
}
