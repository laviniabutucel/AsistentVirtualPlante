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

            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
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

            using (StreamReader streamReader = new StreamReader(numeFisier, System.Text.Encoding.UTF8))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    string[] datePlanta = linieFisier.Split(',');
                    if (datePlanta.Length == 5)
                    {
                        string nume = datePlanta[0].Trim();
                        int nevoieApa = int.Parse(datePlanta[1].Trim());
                        int nevoieLumina = int.Parse(datePlanta[2].Trim());
                        TipSol tipSol = (TipSol)Enum.Parse(typeof(TipSol), datePlanta[3].Trim());
                        CaracteristiciPlanta caracteristici = (CaracteristiciPlanta)Enum.Parse(typeof(CaracteristiciPlanta), datePlanta[4].Trim());

                        plante[nrPlante++] = new Planta(nume, nevoieApa, nevoieLumina, tipSol, caracteristici);
                    }
                }
            }

            return plante;
        }

        public Planta CautaPlantaDupaNume(string numeCautat)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier, System.Text.Encoding.UTF8))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    string[] datePlanta = linieFisier.Split(',');
                    if (datePlanta.Length == 5)
                    {
                        string nume = datePlanta[0].Trim();
                        if (nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase))
                        {
                            int nevoieApa = int.Parse(datePlanta[1].Trim());
                            int nevoieLumina = int.Parse(datePlanta[2].Trim());
                            TipSol tipSol = (TipSol)Enum.Parse(typeof(TipSol), datePlanta[3].Trim());
                            CaracteristiciPlanta caracteristici = (CaracteristiciPlanta)Enum.Parse(typeof(CaracteristiciPlanta), datePlanta[4].Trim());

                            return new Planta(nume, nevoieApa, nevoieLumina, tipSol, caracteristici);
                        }
                    }
                }
            }

            return null;
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
