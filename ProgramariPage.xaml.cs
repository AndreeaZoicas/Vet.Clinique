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
            List<ProgramareDTO> programari = await App.Database.GetProgramariWithDetailsAsync();


            foreach (var programare in programari)
            {
                System.Diagnostics.Debug.WriteLine($"Pacient: {programare.NumePacient}, Medic: {programare.NumeMedic}, Data: {programare.DataProgramarii}");
            }



            ProgramariListView.ItemsSource = programari;
        }

        private async void OnResetProgramariClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteAllProgramariAsync();

            await DisplayAlert("Succes", "Toate programările au fost șterse.", "OK");

            LoadProgramari();
        }


    }
}
