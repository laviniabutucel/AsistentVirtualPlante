using System;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrarePlante_FisierText
    {
        private string numeFisier;

        public AdministrarePlante_FisierText(string numeFisierInitial)
        {
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisierInitial);
            this.numeFisier = caleCompletaFisier;

            if (!File.Exists(this.numeFisier))
            {
                using (Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate))
                {
                    // Fișierul este creat dacă nu există.
                }
            }
        }

        public void AddPlanta(Planta planta)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, true, System.Text.Encoding.UTF8))
            {
                streamWriter.WriteLine(planta.ConversieLaSir_PentruFisier());
            }
        }

        public Planta[] GetPlante(out int nrPlante)
        {
            Planta[] plante = new Planta[50];
            nrPlante = 0;

            if (File.Exists(numeFisier))
            {
                using (StreamReader streamReader = new StreamReader(numeFisier, System.Text.Encoding.UTF8))
                {
                    string linieFisier;

                    while ((linieFisier = streamReader.ReadLine()) != null)
                    {
                        string[] datePlanta = linieFisier.Split(',');
                        if (datePlanta.Length == 5)
                        {
                            try
                            {
                                string nume = datePlanta[0].Trim();
                                int nevoieApa = int.Parse(datePlanta[1].Trim());
                                int nevoieLumina = int.Parse(datePlanta[2].Trim());
                                TipSol tipSol = (TipSol)Enum.Parse(typeof(TipSol), datePlanta[3].Trim());
                                CaracteristiciPlanta caracteristici = (CaracteristiciPlanta)Enum.Parse(typeof(CaracteristiciPlanta), datePlanta[4].Trim());

                                plante[nrPlante++] = new Planta(nume, nevoieApa, nevoieLumina, tipSol, caracteristici);
                            }
                            catch (Exception ex)
                            {
                                // Ignorăm liniile nevalide sau trimitem un mesaj de diagnosticare
                                Console.WriteLine($"Eroare la citirea plantei: {ex.Message}");
                            }
                        }
                    }
                }
            }

            return plante;
        }

        public void ActualizeazaFisier(Planta[] plante, int nrPlante)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < nrPlante; i++)
                {
                    if (plante[i] != null)
                    {
                        streamWriter.WriteLine(plante[i].ConversieLaSir_PentruFisier());
                    }
                }
            }
        }
    }
}
