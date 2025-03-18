using LibrarieModele;
using System;

namespace NivelStocareDate
{
    public class AdministrarePlante_Memorie
    {
        private const int NR_MAX_PLANTE = 50;
        private Planta[] plante;
        private int nrPlante;

        public AdministrarePlante_Memorie()
        {
            plante = new Planta[NR_MAX_PLANTE];
            nrPlante = 0;
        }

        public void AddPlanta(Planta planta)
        {
            if (nrPlante < NR_MAX_PLANTE)
            {
                plante[nrPlante] = planta;
                nrPlante++;
            }
        }

        public Planta[] GetPlante(out int nrPlante)
        {
            nrPlante = this.nrPlante;
            return plante;
        }

        // Funcția pentru a căuta o plantă după nume
        public Planta CautaPlantaDupaNume(string numeCautat)
        {
            return Array.Find(plante, p => p != null && p.Nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase));
        }
    }
}
