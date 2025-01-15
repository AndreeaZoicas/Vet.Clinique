using Vet.Clinique;
using Vet.Clinique.Models;

namespace VetClinique
{
    public partial class ProgramarePage : ContentPage
    {
        public ProgramarePage()
        {
            InitializeComponent();
        }

        private async void OnSaveProgramareClicked(object sender, EventArgs e)
        {
            var programare = new Programare
            {
                PacientID = int.Parse(PacientIDEntry.Text),
                VeterinarID = int.Parse(VeterinarIDEntry.Text),
                DataProgramarii = DataProgramariiPicker.Date
            };

            await App.Database.SaveProgramareAsync(programare); // Salvează în baza de date

            await DisplayAlert("Succes", "Programarea a fost salvată!", "OK");

            // Resetare câmpuri
            PacientIDEntry.Text = string.Empty;
            VeterinarIDEntry.Text = string.Empty;

            await Navigation.PushAsync(new ProgramariPage());

        }

    }
}
