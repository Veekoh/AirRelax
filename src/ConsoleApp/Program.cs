namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string leFichier = "../../../donnee/Cie_Air_Relax.txt ";

            ConsoleKey keyPressed;
            do
            {
                GestionVols.Menu();
                keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.D1)
                {
                    int reponse;
                    Console.WriteLine("Quelle categorie de vol voulez vous lister? (Regulier = 1 || BasPrix = 2 || Charter = 3 || Prive = 4 || TOUS = 5) ?");
                    reponse = int.Parse(Console.ReadLine());
                    if (reponse == 1)
                    {
                        GestionVols.listeVols(leFichier, 1);
                    }
                    else if (reponse == 2)
                    {
                        GestionVols.listeVols(leFichier, 2);
                    }
                    else if (reponse == 3)
                    {
                        GestionVols.listeVols(leFichier, 3);
                    }
                    else if (reponse == 4)
                    {
                        GestionVols.listeVols(leFichier, 4);
                    }
                    else
                    {
                        GestionVols.listeVols(leFichier, 5);
                    }
                    Console.WriteLine("\n\n\n\n\n");
                }
                else if (keyPressed == ConsoleKey.D2)
                {
                    GestionVols.insererVols(leFichier);
                }
                else if (keyPressed == ConsoleKey.D3)
                {
                    GestionVols.retirerVol(leFichier);
                }
                else if (keyPressed == ConsoleKey.D4)
                {
                    GestionVols.modifierDate(leFichier);
                }
                else if (keyPressed == ConsoleKey.D5)
                {
                    GestionVols.reserverVol(leFichier);
                }
                else if (keyPressed == ConsoleKey.D0)
                {
                    Console.WriteLine("\nMerci et bonne journee\n");
                }
                else
                {
                    Console.WriteLine("\nVous devez taper un chiffre entre 0 a 5");
                }
            } while (keyPressed != ConsoleKey.D0);
            Console.WriteLine("Appuyez une touche pour terminer\n\n");
        }
    }
}
