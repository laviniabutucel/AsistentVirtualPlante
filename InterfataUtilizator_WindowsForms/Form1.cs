using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LibrarieModele; // Clasele pentru plante
using NivelStocareDate; // Administrarea fișierului

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Configurare generală a ferestrei
            this.Text = "Informații despre Plante";
            this.BackColor = Color.LightBlue;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = true;
            this.Size = new Size(800, 600);

            // Citirea și afișarea plantelor
            CurataForma(); // Golește controalele existente
            CitesteSiAfiseazaPlante(); // Recitește și afișează datele actualizate din fișier
        }

       
        /// Elimină toate controalele vechi de pe formă, păstrând doar titlul
        
        private void CurataForma()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                // Eliminează toate controalele, cu excepția titlului
                this.Controls.RemoveAt(i);
            }
        }

        /// Citește datele din fișierul plante.txt și afișează plantele în formă
        private void CitesteSiAfiseazaPlante()
        {
            // Configurarea locației fișierului
            string numeFisier = "plante.txt";
            AdministrarePlante_FisierText adminPlante = new AdministrarePlante_FisierText(numeFisier);

            int nrPlante = 0;
            Planta[] plante = adminPlante.GetPlante(out nrPlante);

            // Afișează un titlu central
            Label lblTitlu = new Label
            {
                Text = "Informații despre Plantele Înregistrate:",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Top = 20,
                Left = this.Width / 2 - 200
            };
            this.Controls.Add(lblTitlu);

            // Verifică dacă există plante în fișier
            if (nrPlante > 0)
            {
                for (int i = 0; i < nrPlante; i++)
                {
                    int topOffset = 60 + i * 150; // Spațiere dinamică între seturile de date

                    // Etichetă pentru nume
                    Label lblNume = new Label
                    {
                        Text = $"Nume: {plante[i].Nume}",
                        Font = new Font("Arial", 12),
                        AutoSize = true,
                        Top = topOffset,
                        Left = 50
                    };
                    this.Controls.Add(lblNume);

                    // Etichetă pentru nevoie de apă
                    Label lblNevoieApa = new Label
                    {
                        Text = $"Nevoie de Apă: {plante[i].NevoieApa} zile",
                        Font = new Font("Arial", 12),
                        AutoSize = true,
                        Top = topOffset + 30,
                        Left = 50
                    };
                    this.Controls.Add(lblNevoieApa);

                    // Etichetă pentru nevoie de lumină
                    Label lblNevoieLumina = new Label
                    {
                        Text = $"Nevoie de Lumină: {plante[i].NevoieLumina} ore",
                        Font = new Font("Arial", 12),
                        AutoSize = true,
                        Top = topOffset + 60,
                        Left = 50
                    };
                    this.Controls.Add(lblNevoieLumina);

                    // Etichetă pentru tipul de sol
                    Label lblTipSol = new Label
                    {
                        Text = $"Tip Sol: {plante[i].TipSol}",
                        Font = new Font("Arial", 12),
                        AutoSize = true,
                        Top = topOffset + 90,
                        Left = 50
                    };
                    this.Controls.Add(lblTipSol);

                    // Etichetă pentru caracteristici
                    Label lblCaracteristici = new Label
                    {
                        Text = $"Caracteristici: {plante[i].Caracteristici}",
                        Font = new Font("Arial", 12),
                        AutoSize = true,
                        Top = topOffset + 120,
                        Left = 50
                    };
                    this.Controls.Add(lblCaracteristici);
                }
            }
            else
            {
                MessageBox.Show("Fișierul nu conține plante înregistrate.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
