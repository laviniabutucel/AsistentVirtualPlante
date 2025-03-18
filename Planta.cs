using System;

namespace LibrarieModele
{
    public class Planta
    {
        public string Nume { get; set; }
        public int NevoieApa { get; set; }
        public int NevoieLumina { get; set; }

        // Constructor cu parametri
        public Planta(string nume, int nevoieApa, int nevoieLumina)
        {
            Nume = nume;
            NevoieApa = Limiteaza(nevoieApa, 1, 10);  // Limitează nevoia de apă între 1 și 10
            NevoieLumina = Limiteaza(nevoieLumina, 1, 10);  // Limitează nevoia de lumină între 1 și 10
        }

        // Metoda care verifică starea plantei
        public string VerificaStarePlanta()
        {
            return $"Planta {Nume} are nevoie de {NevoieApa} zile de apă și {NevoieLumina} ore de lumină pe zi.";
        }

        // Metoda pentru udarea plantei
        public string UdaPlanta()
        {
            // Reducem nevoia de apă, dar o limităm între 1 și 10
            NevoieApa = Limiteaza(NevoieApa - 1, 1, 10);
            return $"{Nume} a fost udată. Nevoia de apă este acum {NevoieApa} zile.";
        }

        // Metoda pentru mutarea plantei într-un loc mai luminos
        public string MutaPlantaLocMaiLuminos()
        {
            // Crește nevoia de lumină, dar o limităm între 1 și 10
            NevoieLumina = Limiteaza(NevoieLumina + 1, 1, 10);
            return $"{Nume} a fost mutată într-un loc mai luminos. Nevoia de lumină este acum {NevoieLumina} ore pe zi.";
        }

        // Funcția care limitează valorile între minim și maxim
        private int Limiteaza(int valoare, int minim, int maxim)
        {
            if (valoare < minim)
                return minim;  // Dacă valoarea este mai mică decât minim, setează la minim
            if (valoare > maxim)
                return maxim;  // Dacă valoarea este mai mare decât maxim, setează la maxim
            return valoare;  // Altfel, lasă valoarea neschimbată
        }
        public string ConversieLaSir_PentruFisier()
{
    return $"Nume: {Nume}, Nevoie de apa: {NevoieApa} zile/saptamana, Nevoie de lumina: {NevoieLumina} ore/zi";
}

    }
}
