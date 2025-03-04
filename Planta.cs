using System;

namespace AsistentVirtualPlante
{
    public class Planta
    {
        private string nume;
        private int nevoieApa;
        private int luminaPrimita;
        private int nevoieLuminaMinima;

        public Planta()
        {
            nume = "Necunoscut";
            nevoieApa = -1;
            luminaPrimita = -1;
            nevoieLuminaMinima = -1;
        }

        public Planta(string _nume, int _nevoieApa, int _luminaPrimita, int _nevoieLuminaMinima)
        {
            nume = _nume;
            nevoieApa = _nevoieApa;
            luminaPrimita = _luminaPrimita;
            nevoieLuminaMinima = _nevoieLuminaMinima;
        }

        // Metodă care returnează informațiile despre plantă
        public string Info()
        {
            if (nume == "Necunoscut")
                return "Nu există date despre această plantă.";
            return $"Planta: {nume}, Nevoie de apă: {nevoieApa} zile, Lumină primită: {luminaPrimita} ore/zi, Nevoie minimă de lumină: {nevoieLuminaMinima} ore/zi";
        }

        // Getteri pentru a accesa valorile din afara clasei
        public string GetNume() => nume;
        public int GetNevoieApa() => nevoieApa;
        public int GetLuminaPrimita() => luminaPrimita;
        public int GetNevoieLuminaMinima() => nevoieLuminaMinima;
    }
}
