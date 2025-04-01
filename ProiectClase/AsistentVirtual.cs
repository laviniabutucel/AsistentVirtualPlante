using System;
using LibrarieModele;

namespace AsistentVirtualPlante
{
    public class AsistentVirtual
    {
        public string InteractioneazaCuUtilizatorul(Planta planta)
        {
            string rezultat = planta.VerificaStarePlanta();

            Console.WriteLine("Vrei să uzi planta? (da/nu)");
            if (Console.ReadLine()?.ToLower() == "da")
            {
                rezultat += "\n" + planta.UdaPlanta();
            }

            Console.WriteLine("Vrei să muți planta într-un loc mai luminos? (da/nu)");
            if (Console.ReadLine()?.ToLower() == "da")
            {
                rezultat += "\n" + planta.MutaPlantaLocMaiLuminos();
            }

            return rezultat;
        }
    }
}
