using System;

namespace AsistentVirtualPlante
{
    public class AsistentVirtual
    {
        // Metodă care verifică planta și returnează un mesaj
        public string VerificaPlanta(Planta planta)
        {
            string mesaj = $"\nVerific plantă: {planta.GetNume()}\n";

            if (planta.GetNevoieApa() <= 1)
            {
                mesaj += "Este timpul să uzi planta!\n";
            }
            else
            {
                mesaj += $"Nu este nevoie să uzi planta înca. Asteapta {planta.GetNevoieApa()} zile.\n";
            }

            if (planta.GetLuminaPrimita() < planta.GetNevoieLuminaMinima())
            {
                mesaj += "Planta nu primeste suficienta lumina si are nevoie de mai multa.\n";
            }
            else
            {
                mesaj += "Planta primeste suficienta lumina.\n";
            }

            return mesaj;
        }
    }
}
