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
                plante[nrPlante++] = planta;
            }
        }

        public Planta[] GetPlante(out int nrPlante)
        {
            nrPlante = this.nrPlante;
            return plante;
        }

        public Planta CautaPlantaDupaNume(string numeCautat)
        {
            for (int i = 0; i < nrPlante; i++)
            {
                if (plante[i] != null && plante[i].Nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase))
                {
                    return plante[i];
                }
            }
            return null;
        }
    }
}
