using LibrarieModele;
using System;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrarePlante_FisierText
    {
        private const int NR_MAX_PLANTE = 50;
        private string numeFisier;

        public AdministrarePlante_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // Se încearcă deschiderea fișierului în modul OpenOrCreate
            // Astfel încât fișierul va fi creat dacă nu există
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddPlanta(Planta planta)
        {
            // Folosim instrucțiunea 'using' pentru a ne asigura că StreamWriter este închis corespunzător
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(planta.ConversieLaSir_PentruFisier());
            }
        }

        public Planta[] GetPlante(out int nrPlante)
        {
            Planta[] plante = new Planta[NR_MAX_PLANTE];
            nrPlante = 0;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Împărțim linia citită pentru a extrage datele plantei
                    string[] datePlanta = linieFisier.Split(new[] { ", " }, StringSplitOptions.None);
                    string nume = datePlanta[0].Split(':')[1].Trim();
                    int nevoieApa = int.Parse(datePlanta[1].Split(':')[1].Trim());
                    int nevoieLumina = int.Parse(datePlanta[2].Split(':')[1].Trim());

                    // Creăm un obiect Planta folosind constructorul corect
                    plante[nrPlante++] = new Planta(nume, nevoieApa, nevoieLumina);
                }
            }

            return plante;
        }
    }
}
