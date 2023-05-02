namespace Core
{
    public class ErreurDate
    {
        public const string ANNEE_INVALIDE = " ne peut pas être inférieure à l'année actuelle, soit ";
        public const string JOUR_INVALIDE = "Impossible de valider le jour puisque votre mois est invalide";


        public static string AjouterEspacesFin(int tailleColMax, string chaine)
        {
            int nbEspaces = tailleColMax - chaine.Length;
            string espaces = "";
            for (int i = 0; i < nbEspaces; i++)
            {
                espaces += " ";
            }
            return espaces;
        }

        public static string AjouterEspacesDebut(int tailleColMax, string chaine)
        {
            int nbEspaces = (tailleColMax - chaine.Length) / 2;
            string espaces = "";
            for (int i = 0; i < nbEspaces; i++)
            {
                espaces += " ";
            }
            return espaces;
        }

        public static string AjouterCaractereGauche(char car, int longueur, string ch)
        {
            String rep = "";
            int nbCar = longueur - ch.Length;
            for (int i = 1; i <= nbCar; i++)
            {
                rep += car;
            }
            return rep + ch;
        }
    }
}
