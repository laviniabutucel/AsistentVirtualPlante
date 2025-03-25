using System;
using System.IO;
using NivelStocareDate;
using LibrarieModele;
using AsistentVirtualPlante;

namespace AsistentVirtualPlante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AdministrarePlante_Memorie adminMemorie = new AdministrarePlante_Memorie();
            string numeFisier = "plante.txt";
            AdministrarePlante_FisierText adminFisier = new AdministrarePlante_FisierText("plante.txt");

            Console.Write("Câte plante vrei să adaugi? ");
            int nrPlante = int.Parse(Console.ReadLine());

            for (int i = 0; i < nrPlante; i++)
            {
                Console.Write("Introduceți numele plantei: ");
                string nume = Console.ReadLine();

                Console.Write("Introduceți zilele necesare pentru udare: ");
                int nevoieApa = int.Parse(Console.ReadLine());

                Console.Write("Introduceți orele de lumină necesare pe zi: ");
                int nevoieLumina = int.Parse(Console.ReadLine());

                TipSol tipSol;
                bool validInput = false;

                do
                {
                    Console.WriteLine("Alegeți tipul de sol:");
                    Console.WriteLine("1 - Nisipos");
                    Console.WriteLine("2 - Cernoziom");
                    Console.WriteLine("3 - Argilos");
                    string input = Console.ReadLine();

                    validInput = Enum.TryParse<TipSol>(input, out tipSol) && Enum.IsDefined(typeof(TipSol), tipSol);
                    if (!validInput)
                    {
                        Console.WriteLine("Opțiunea introdusă nu este validă. Reîncercați.");
                    }
                } while (!validInput);



                CaracteristiciPlanta caracteristici = CaracteristiciPlanta.Niciuna;
                bool caracteristiciValide = false;

                do
                {
                    Console.WriteLine("Alegeți caracteristicile plantei (puteți alege mai multe opțiuni separate prin virgulă):");
                    Console.WriteLine("1 - Fructiferă");
                    Console.WriteLine("2 - Decorativă");
                    Console.WriteLine("4 - Medicinală");
                    Console.WriteLine("8 - Aromatică");

                    string[] optiuni = Console.ReadLine().Split(',');
                    caracteristiciValide = true;

                    foreach (string opt in optiuni)
                    {
                        if (int.TryParse(opt.Trim(), out int valoare) && Enum.IsDefined(typeof(CaracteristiciPlanta), valoare))
                        {
                            caracteristici |= (CaracteristiciPlanta)valoare;
                        }
                        else
                        {
                            caracteristiciValide = false;
                            Console.WriteLine($"Caracteristica {opt} nu este validă.");
                            break;
                        }
                    }
                } while (!caracteristiciValide);

                Planta planta = new Planta(nume, nevoieApa, nevoieLumina, tipSol, caracteristici);

                adminMemorie.AddPlanta(planta);
                adminFisier.AddPlanta(planta);
            }


            Console.WriteLine("\nPlantele înregistrate (din memorie):");
            int nrPlanteMemorie;
            Planta[] planteMemorie = adminMemorie.GetPlante(out nrPlanteMemorie);

            for (int i = 0; i < nrPlanteMemorie; i++)
            {
                Console.WriteLine(planteMemorie[i].VerificaStarePlanta());
            }

            Console.WriteLine("\nPlantele înregistrate (din fișier):");
            int nrPlanteFisier;
            Planta[] planteFisier = adminFisier.GetPlante(out nrPlanteFisier);

            for (int i = 0; i < nrPlanteFisier; i++)
            {
                Console.WriteLine(planteFisier[i].VerificaStarePlanta());
            }

            Console.Write("\nIntroduceți numele unei plante pentru a o verifica: ");
            string numeCautat = Console.ReadLine();

            Planta plantaGasita = adminMemorie.CautaPlantaDupaNume(numeCautat);

            if (plantaGasita == null)
            {
                plantaGasita = adminFisier.CautaPlantaDupaNume(numeCautat);
            }

            if (plantaGasita != null)
            {
                AsistentVirtual asistent = new AsistentVirtual();
                string rezultatInteracțiune = asistent.InteractioneazaCuUtilizatorul(plantaGasita);
                Console.WriteLine(rezultatInteracțiune);

                // Actualizarea memoriei
                for (int i = 0; i < nrPlanteMemorie; i++)
                {
                    if (planteMemorie[i].Nume.Equals(plantaGasita.Nume, StringComparison.OrdinalIgnoreCase))
                    {
                        planteMemorie[i] = plantaGasita;
                        break;
                    }
                }

                // Actualizarea fișierului
                adminFisier.ActualizeazaFisier(planteMemorie, nrPlanteMemorie);
            }
            else
            {
                Console.WriteLine("Planta nu a fost găsită.");
            }

            Console.WriteLine("\nStarea finală a plantelor (din memorie):");
            for (int i = 0; i < nrPlanteMemorie; i++)
            {
                Console.WriteLine(planteMemorie[i].VerificaStarePlanta());
            }
           
            // Declară variabilele o singură dată
            Console.WriteLine("\nStarea finală a plantelor din fișier:");
            //int nrPlanteFisier;
            //Planta[] planteFisier = adminFisier.GetPlante(out nrPlanteFisier);

            for (int i = 0; i < nrPlanteFisier; i++)
            {
                Console.WriteLine(planteFisier[i].VerificaStarePlanta());
            }

            Console.ReadKey();
        }
    }
}
