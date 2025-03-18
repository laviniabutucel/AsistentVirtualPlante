using System;
using LibrarieModele;

namespace AsistentVirtualPlante
{
    public class AsistentVirtual
    {
        public string InteractioneazaCuUtilizatorul(Planta planta)
        {
            string rezultat = planta.ConversieLaSir_PentruFisier();

            Console.WriteLine("Vrei sa uzi planta? (da/nu)");
            if (Console.ReadLine()?.ToLower() == "da")
            {
                rezultat += "\nPlanta a fost udata.";
            }

            Console.WriteLine("Vrei sa muti planta intr-un loc mai luminos? (da/nu)");
            if (Console.ReadLine()?.ToLower() == "da")
            {
                rezultat += "\nPlanta a fost mutata intr-un loc mai luminos.";
            }

            return rezultat;
        }
    }
}
