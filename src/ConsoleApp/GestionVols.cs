using Core;

namespace ConsoleApp
{
    public class GestionVols
    {
        //static Dictionary<string, Vol> isteVols = new Dictionary<string, Vol>();
        public static bool rechercherVol(int numeroVol, string fichier)
        {
            var tabVols = chargerVol(fichier);
            foreach (Vol vol in tabVols)
            {
                if (vol.NumeroVol.Equals(numeroVol))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Vol> chargerVol(string nomFichier)
        {
            string ligne;
            string[] tabVols;
            var listeVols = new List<Vol>();
            StreamReader fichier = new StreamReader(nomFichier);
            while ((ligne = fichier.ReadLine()) != null)
            {
                var valeurs = ligne.Split(';');
                var categorie = valeurs[0];
                if (categorie == "1")
                {
                    listeVols.Add(new VolRegulier(valeurs));
                }
                else if (categorie == "2")
                {
                    listeVols.Add(new VolBasPrix(valeurs));
                }
                else if (categorie == "3")
                {
                    listeVols.Add(new VolCharter(valeurs));
                }
                else if (categorie == "4")
                {
                    listeVols.Add(new VolPrive(valeurs));
                }
            }
            fichier.Close();
            return listeVols;
        }
        public static void insererVols(string nomFichier)
        {
            Console.WriteLine("\nQuelle categorie de vol voulez vous? (Regulier = 1 || BasPrix = 2 || Charter = 3 || Prive = 4)");
            int reponse = int.Parse(Console.ReadLine());
            while (reponse != 1 && reponse != 2 && reponse != 3 && reponse != 4)
            {
                Console.WriteLine("Mauvaise entree, veuillez reesayer");
                Console.WriteLine("\nQuelle categorie de vol voulez vous? (Regulier = 1 || BasPrix = 2 || Charter = 3 || Prive = 4)");
                reponse = int.Parse(Console.ReadLine());
            }
            Vol? vol = null;
            if (reponse == 1)
            {
                var volReg = new VolRegulier();
                Console.WriteLine("Avez vous besoin de repas? (Oui = 1 || Non = 0)");
                int reponseRepas = int.Parse(Console.ReadLine());
                while (reponseRepas != 1 && reponseRepas != 0)
                {
                    Console.WriteLine("Mauvaise entree, veuillez reesayer");
                    Console.WriteLine("Avez vous besoin de repas? (Oui = 1 || Non = 0)");
                    reponseRepas = int.Parse(Console.ReadLine());
                }
                volReg.Repas = reponseRepas == 1;

                vol = volReg;

            }
            if (reponse == 2)
            {
                var basPrix = new VolBasPrix();
                Console.WriteLine("Quelle est votre bas prix?");
                basPrix.Prix = int.Parse(Console.ReadLine());

                vol = basPrix;
            }
            if (reponse == 3)
            {
                var charter = new VolCharter();
                //          Service Bar
                Console.WriteLine("Avez vous besoin d un service de bar? (Oui = 1 || Non = 0)");
                int reponseBar = int.Parse(Console.ReadLine());
                while (reponseBar != 1 && reponseBar != 0)
                {
                    Console.WriteLine("Mauvaise entree, veuillez reesayer");
                    Console.WriteLine("Avez vous besoin d un service de bar? (Oui = 1 || Non = 0)");
                    reponseBar = int.Parse(Console.ReadLine());
                }
                charter.ServiceBar = reponseBar == 1;
                //          Divertissement
                Console.WriteLine("Avez vous besoin d un divertissement? (Oui = 1 || Non = 0)");
                int reponseDiver = int.Parse(Console.ReadLine());
                while (reponseDiver != 1 && reponseDiver != 0)
                {
                    Console.WriteLine("Mauvaise entree, veuillez reesayer");
                    Console.WriteLine("Avez vous besoin d un divertissement? (Oui = 1 || Non = 0)");
                    reponseDiver = int.Parse(Console.ReadLine());
                }
                charter.Divertissement = reponseDiver == 1;

                vol = charter;
            }
            if (reponse == 4)
            {
                var prive = new VolPrive();
                Console.WriteLine("Avez vous besoin de wifi? (Oui = 1 || Non = 0)");
                int reponseWifi = int.Parse(Console.ReadLine());
                while (reponseWifi != 1 && reponseWifi != 0)
                {
                    Console.WriteLine("Mauvaise entree, veuillez reesayer");
                    Console.WriteLine("Avez vous besoin de wifi? (Oui = 1 || Non = 0)");
                    reponseWifi = int.Parse(Console.ReadLine());
                }
                prive.WiFi = reponseWifi == 1;

                vol = prive;
            }
            Console.WriteLine("\nEntrez le numero de vol: ");
            vol.NumeroVol = int.Parse(Console.ReadLine());
            bool testNumVol = rechercherVol(vol.NumeroVol, nomFichier);
            StreamWriter nouveauVol = new StreamWriter(nomFichier, true);
            if (testNumVol == false)
            {
                //          Type Avion
                Console.WriteLine("Entrez le type davion desirer (Avion daffaire = 1 || Avion leger = 2 || Avion Ultra Leger = 3)");
                int reponseAvion = int.Parse(Console.ReadLine());
                while (reponseAvion != 1 && reponseAvion != 2 && reponseAvion != 3)
                {
                    Console.WriteLine("Mauvaise entree, veuillez reesayer");
                }
                if (reponseAvion == 1)
                {
                    vol.Avion = new AvionAffaire();
                }
                if (reponseAvion == 2)
                {
                    vol.Avion = new AvionLeger();
                }
                if (reponseAvion == 3)
                {
                    vol.Avion = new AvionUltraLeger();
                }
                //          Inserer Info
                Console.WriteLine("Entrez la Destination: ");
                vol.Destination = Console.ReadLine();
                Console.WriteLine("Entrez le jour du vol (JJ/MM/AAAA) : ");
                vol.DateVol = new Date(Console.ReadLine());
                Console.WriteLine("Entrez le nombre de reservation: ");
                vol.Reservation = int.Parse(Console.ReadLine());
                nouveauVol.WriteLine(vol);
            }
            else
            {
                Console.WriteLine("** !! Le numero de vol existe deja !! ** \n\n");
            }
            nouveauVol.Close();
        }

        public static void retirerVol(string nomFichier)
        {
            Console.WriteLine("\nQuelle est le numero du vol que vous voulez supprimer?");
            int numeroDelete = int.Parse(Console.ReadLine());
            bool numeroVol = rechercherVol(numeroDelete, nomFichier);
            var tabVols = chargerVol(nomFichier);
            ConsoleKey keyPressed;

            if (numeroVol == true)
            {
                Console.WriteLine("Voulez vous vraiment supprimer ce vol? \n");
                Console.WriteLine("Repondez par (O ou N)");
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.O)
                {
                    StreamWriter write = new StreamWriter(nomFichier);
                    foreach (Vol vol in tabVols)
                    {
                        if (vol.NumeroVol != numeroDelete)
                        {
                            write.Write(vol.NumeroVol + ";");
                            write.Write(vol.Destination + ";");
                            write.Write(vol.DateVol + ";");
                            write.Write(vol.Reservation + ";");
                            write.Write(vol.Avion + "\n");
                        }

                    }
                    write.Close();
                }
            }
            else
            {
                Console.WriteLine("** !! Il y a aucun vol avec ce numero  !! ** \n\n");
            }
        }

        public static void modifierDate(string nomFichier)
        {
            Console.WriteLine("\nQuelle est le numero du vol que vous voulez modifier?");
            int numeroModifier = int.Parse(Console.ReadLine());
            bool numeroVol = rechercherVol(numeroModifier, nomFichier);
            var tabVols = chargerVol(nomFichier);
            ConsoleKey keyPressed;
            if (numeroVol == true)
            {
                Console.WriteLine("Voulez vous vraiment modifier la date de ce vol?\n");
                Console.WriteLine("Repondez par (O ou N)");
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.O)
                {
                    StreamWriter write = new StreamWriter(nomFichier);
                    foreach (Vol vol in tabVols)
                    {
                        if (vol.NumeroVol == numeroModifier)
                        {
                            Console.WriteLine("\nEntrez la nouvelle date de depart? (JJ/MM/AAAA) : ");
                            vol.DateVol = new Date(Console.ReadLine());
                            write.Write(vol.NumeroVol + ";");
                            write.Write(vol.Destination + ";");
                            write.Write(vol.DateVol + ";");
                            write.Write(vol.Reservation + ";");
                            write.Write(vol.Avion + "\n");
                        }
                        else
                        {
                            write.Write(vol.NumeroVol + ";");
                            write.Write(vol.Destination + ";");
                            write.Write(vol.DateVol + ";");
                            write.Write(vol.Reservation + ";");
                            write.Write(vol.Avion + "\n");
                        }
                    }
                    write.Close();
                }
            }
            else
            {
                Console.WriteLine("** !! Il y a aucun vol avec ce numero  !! ** \n\n");
            }
        }

        public static void reserverVol(string nomFichier)
        {
            const int MAX_PLACES = 340;
            Console.WriteLine("\nQuelle est le numero de vol que vous voulez partir?");
            int numeroReservation = int.Parse(Console.ReadLine());
            bool numeroVol = rechercherVol(numeroReservation, nomFichier);
            var tabVols = chargerVol(nomFichier);

            if (numeroVol == true)
            {
                StreamWriter write = new StreamWriter(nomFichier);
                foreach (Vol vol in tabVols)
                {
                    if (vol.NumeroVol == numeroReservation)
                    {
                        Console.WriteLine("Combien de voyageurs serez vous?");
                        int nbVoyageurs = int.Parse(Console.ReadLine());
                        int nbVoyageursTotal = nbVoyageurs + vol.Reservation;
                        if (nbVoyageursTotal > MAX_PLACES)
                        {
                            Console.WriteLine("Il y a plus assez de place de disponibles.");
                            Console.WriteLine("Veuillez regarder pour un autre vol.");
                            Console.WriteLine("Merci de votre comprehension.\n\n\n");
                        }
                        else
                        {
                            write.Write(vol.NumeroVol + ";");
                            write.Write(vol.Destination + ";");
                            write.Write(vol.DateVol + ";");
                            write.Write(nbVoyageursTotal + "\n");
                        }
                    }
                    else
                    {
                        write.Write(vol.NumeroVol + ";");
                        write.Write(vol.Destination + ";");
                        write.Write(vol.DateVol + ";");
                        write.Write(vol.Reservation + "\n");
                    }
                }
                write.Close();
            }
            else
            {
                Console.WriteLine("** !! Il y a aucun vol avec ce numero  !! ** \n\n");
            }
        }

        public static List<Vol> listeVols(string nomFichier, int categorie)
        {
            var vols = chargerVol(nomFichier);
            Console.WriteLine("\n{0,6}\t{1,15}\t\t{2,10}\t{3,12}\t{4,15}", "Numero", "Destination", "Depart", "Reservation", "Avion");
            foreach (Vol vol in vols)
            {
                if (vol.Categorie == categorie)
                {
                    Console.WriteLine("{0,6}\t{1,15}\t\t{2,10}\t{3,12}\t{4,15}", vol.NumeroVol, vol.Destination, vol.DateVol, vol.Reservation, vol.Avion.Type);
                }
                else if (categorie == 5)
                {
                    Console.WriteLine("{0,6}\t{1,15}\t\t{2,10}\t{3,12}\t{4,15}", vol.NumeroVol, vol.Destination, vol.DateVol, vol.Reservation, vol.Avion.Type);
                }
            }
            return vols;
        }

        public static void Menu()
        {
            Console.WriteLine("\tAIR RELAX\n");
            Console.WriteLine("  Gestion des vols");
            Console.WriteLine("1. Liste des vols");
            Console.WriteLine("2. Ajout d'un vol");
            Console.WriteLine("3. Retrait d'un vol");
            Console.WriteLine("4. Modification de la date de depart");
            Console.WriteLine("5. Reservation d'un vol");
            Console.WriteLine("0. Terminer");
            Console.WriteLine("\t Faites votre choix:\n");
        }
    }
}
