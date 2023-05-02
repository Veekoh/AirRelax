namespace Core
{
    public abstract class Vol
    {
        public int NumeroVol;
        public string Destination;
        public Date DateVol;
        public int Reservation;
        public Avion Avion;
        public Vol()
        {

        }
        public Vol(string[] valeurs)
        {
            this.NumeroVol = int.Parse(valeurs[1]);
            this.Destination = valeurs[2];
            this.DateVol = new Date(valeurs[3]);
            this.Reservation = int.Parse(valeurs[4]);
            var typeAvion = valeurs[5];
            if (typeAvion == "Affaire")
            {
                this.Avion = new AvionAffaire();
            }
            else if (typeAvion == "Leger")
            {
                this.Avion = new AvionLeger();
            }
            else if (typeAvion == "Ultra Leger")
            {
                this.Avion = new AvionUltraLeger();
            }
        }
        public Vol(int numeroVol, string destination, Date dateVol, int reservation, Avion avion)
        {
            this.NumeroVol = numeroVol;
            this.Destination = destination;
            this.DateVol = dateVol;
            this.Reservation = reservation;
            this.Avion = avion;
        }
        public abstract int Categorie { get; }
        public override string ToString()
        {
            return $"{Categorie};{NumeroVol};{Destination};{DateVol};{Reservation};{Avion.Type}";
        }
    }
}
