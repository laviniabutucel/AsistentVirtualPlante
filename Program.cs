using System;
using NivelStocareDate;
using LibrarieModele;
using AsistentVirtualPlante;

namespace AsistentVirtualPlante
{
    class Program
    {
        static void Main(string[] args)
        {
            AdministrarePlante_Memorie adminPlante = new AdministrarePlante_Memorie();

            // Citirea plantelor de la tastatură
            Console.Write("Câte plante vrei să adaugi? ");
            int nrPlante = int.Parse(Console.ReadLine());

            for (int i = 0; i < nrPlante; i++)
            {
                Console.Write("Introduceți numele plantei: ");
                string nume = Console.ReadLine();

                Console.Write("Introduceți zilele necesare pentru udare: ");
                int nevoieApa = int.Parse(Console.ReadLine());

                Console.Write("Introduceți orele de lumina necesare pe zi: ");
                int nevoieLumina = int.Parse(Console.ReadLine());

                adminPlante.AddPlanta(new Planta(nume, nevoieApa, nevoieLumina)); // Aici folosești constructorul corect
            }


            // Afișarea plantelor introduse
            Console.WriteLine("\nPlantele înregistrate:");
            int nrPlanteExistente;
            Planta[] plante = adminPlante.GetPlante(out nrPlanteExistente);

            for (int i = 0; i < nrPlanteExistente; i++)
            {
                Console.WriteLine(plante[i].VerificaStarePlanta());
            }

            // Căutarea unei plante
            Console.Write("\nIntroduceți numele unei plante pentru a o verifica: ");
            string numeCautat = Console.ReadLine();

            Planta plantaGasita = adminPlante.CautaPlantaDupaNume(numeCautat);

            if (plantaGasita != null)
            {
                AsistentVirtual asistent = new AsistentVirtual();
                string rezultatInteracțiune = asistent.InteractioneazaCuUtilizatorul(plantaGasita);
                Console.WriteLine(rezultatInteracțiune);
            }
            else
            {
                Console.WriteLine("Planta nu a fost găsită.");
            }

            // Afișarea stării finale a plantelor după interacțiune
            Console.WriteLine("\nStarea finală a plantelor:");
            for (int i = 0; i < nrPlanteExistente; i++)
            {
                Console.WriteLine(plante[i].VerificaStarePlanta());
            }

            Console.ReadKey();
        }
    }
}
