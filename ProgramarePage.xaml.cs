using Vet.Clinique;
using Vet.Clinique.Models;
using System.Linq;

namespace VetClinique
{
    public partial class ProgramarePage : ContentPage
    {
        public ProgramarePage()
        {
            InitializeComponent();
            LoadPickerData(); // Încarcă datele în Picker-uri
        }

        private async void LoadPickerData()
        {
            var pacienti = await App.Database.GetPacientiAsync();
            PacientPicker.ItemsSource = pacienti.Select(p => p.NumePacient).ToList(); 

            var medici = await App.Database.GetMediciAsync();
            VeterinarPicker.ItemsSource = medici.Select(m => m.NumeMedic).ToList(); 
        }

        private async void OnSaveProgramareClicked(object sender, EventArgs e)
        {
            if (PacientPicker.SelectedIndex == -1 || VeterinarPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Eroare", "Selectați un pacient și un medic.", "OK");
                return;
            }

            var pacienti = await App.Database.GetPacientiAsync();
            var pacient = pacienti.FirstOrDefault(p => p.NumePacient == PacientPicker.SelectedItem.ToString());

            var medici = await App.Database.GetMediciAsync();
            var medic = medici.FirstOrDefault(m => m.NumeMedic == VeterinarPicker.SelectedItem.ToString());


            var programare = new Programare
            {
                PacientID = pacient?.ID ?? 0, 
                VeterinarID = medic?.ID ?? 0, 
                DataProgramarii = DataProgramariiPicker.Date
            };

            System.Diagnostics.Debug.WriteLine($"Programare: PacientID={programare.PacientID}, VeterinarID={programare.VeterinarID}, Data={programare.DataProgramarii}");

            await App.Database.SaveProgramareAsync(programare);

            await DisplayAlert("Succes", "Programarea a fost salvată!", "OK");

            await Navigation.PushAsync(new ProgramariPage());
        }
    }
}
