using System;

namespace LibrarieModele
{
    [Flags]
    public enum CaracteristiciPlanta
    {
        Niciuna = 0,
        Fructifera = 1,
        Decorativa = 2,
        Medicinala = 4,
        Aromatica = 8
    }

    public enum TipSol
    {
        Nisipos = 1,
        Cernoziom = 2,
        Argilos = 3
     
    }
}
