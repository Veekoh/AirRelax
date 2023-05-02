using NodaTime;

namespace Core
{
    public class Date
    {
        private int jour;
        private int mois;
        private int annee;

        static public string[] tabMois = { null, "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };
        static public LocalDate dateActuelle = new LocalDate();

        public Date(string value)
        {
            var values = value.Split('/');
            this.jour = int.Parse(values[0]);
            this.mois = int.Parse(values[1]);
            this.annee = int.Parse(values[2]);
        }
        public Date(int jour, int mois, int annee)
        {
            this.jour = jour;
            this.mois = mois;
            this.annee = annee;
        }

        public int Jour
        {
            get { return this.jour; }
            set
            {
                int nbJours = DeterminerNbJoursMois(Mois, Annee);
                if (value > nbJours || value < 1)
                {
                    Console.WriteLine("Jour invalide pour le mois de " + tabMois[Mois].ToLower());
                }
                else { this.jour = value; }
            }
        }
        public int Mois
        {
            get { return this.mois; }
            set
            {
                int nbJours;
                if (value < 1 || value > 12)
                {
                    Console.WriteLine("Mois " + value + " n'est un mois valide [1-12]");
                }
                else
                {
                    nbJours = DeterminerNbJoursMois(value, Annee);
                    if (Jour > nbJours)
                    {
                        Console.WriteLine("Mois " + tabMois[value].ToLower() + " n'est un mois valide pour le jour actuel du vol qu'est " + Jour);
                    }
                    else { this.mois = value; }
                }
            }
        }
        public int Annee
        {
            get { return this.annee; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Année " + value + " ne peut pas être inférieure une année négative");
                }
                else { this.annee = value; }

            }
        }
        //Valider trois 
        public static string ValiderDate(int jour, int mois, int annee, bool[] etat)
        {
            string message = "";//Servira comme message par défaut
            int nbJours = 0;

            //Valider le mois
            if (mois < 1 || mois > 12)
            {
                etat[1] = false;
                message += "Mois " + mois + " n'est un mois valide [1-12]" + "\n";
            }
            else { etat[1] = true; }

            //Valider le jour
            if (etat[1])
            {
                nbJours = DeterminerNbJoursMois(mois, annee);
                if (jour > nbJours || jour <= 0)
                {
                    etat[0] = false;
                    message += "Jour invalide pour le mois de " + tabMois[mois].ToLower() + "\n";
                }
                else { etat[0] = true; }

            }
            else
            {
                message += ErreurDate.JOUR_INVALIDE; //Utilisation des messages définies dans notre classe Utilitaires
            }




            //Valider Année
            int anneActuelle = dateActuelle.Year;
            if (annee < anneActuelle)
            {
                etat[2] = false;
                message += "Année " + annee + ErreurDate.ANNEE_INVALIDE + anneActuelle + "\n";
            }
            else { etat[2] = true; }
            return message;
        }

        public static bool estBissextile(int annee)
        {
            return (annee % 4 == 0 && annee % 100 != 0) || (annee % 400 == 0);
        }

        public static int DeterminerNbJoursMois(int mois, int annee)
        {
            int nbJours;
            int[] tabJrMois = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (mois == 2 && estBissextile(annee))
                nbJours = 29;
            else
                nbJours = tabJrMois[mois];
            return nbJours;
        }

        public override string ToString()
        {
            string leJour, leMois;
            leJour = ErreurDate.AjouterCaractereGauche('0', 2, Jour + "");
            leMois = ErreurDate.AjouterCaractereGauche('0', 2, Mois + "");
            return leJour + "/" + leMois + "/" + Annee;
        }
    }
}
