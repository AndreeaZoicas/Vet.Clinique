using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Vet.Clinique;
using Vet.Clinique.Models;


namespace VetClinique
{
    public partial class ProgramariPage : ContentPage
    {
        public ProgramariPage()
        {
            InitializeComponent();
            LoadProgramari();
        }

        private async void LoadProgramari()
        {
            // Obține toate programările din baza de date
            List<Programare> programari = await App.Database.GetProgramariAsync();

            // Atribuie lista ListView-ului
            ProgramariListView.ItemsSource = programari;
        }
    }
}
