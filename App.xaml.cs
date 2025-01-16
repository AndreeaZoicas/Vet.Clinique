using Vet.Clinique.Models;
using VetClinique;

namespace Vet.Clinique
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetClinique.db");

            Database = new DatabaseHelper(dbPath);

            SeedDatabase();

            MainPage = new NavigationPage(new MainPage());
        }

        private async void SeedDatabase()
        {
            var db = App.Database;

            var pacienti = await db.GetPacientiAsync();
            if (!pacienti.Any())
            {
                System.Diagnostics.Debug.WriteLine("Adaugăm pacienți în baza de date...");
                await db.SavePacientAsync(new Pacient { NumePacient = "Alfi", Specie = "Câine", Rasa = "Labrador" });
                await db.SavePacientAsync(new Pacient { NumePacient = "Tom", Specie = "Pisică", Rasa = "Siameza" });
                await db.SavePacientAsync(new Pacient { NumePacient = "Charlie", Specie = "Pasăre", Rasa = "Cenușiu" });
            }

            var medici = await db.GetMediciAsync();
            if (!medici.Any())
            {
                System.Diagnostics.Debug.WriteLine("Adaugăm medici în baza de date...");
                await db.SaveVeterinarAsync(new Veterinar { NumeMedic = "Dr. Alex Tatar", Specializare = "Chirurgie" });
                await db.SaveVeterinarAsync(new Veterinar { NumeMedic = "Dr. Alina C.", Specializare = "Dermatologie" });
                await db.SaveVeterinarAsync(new Veterinar { NumeMedic = "Dr. Suciu Filip", Specializare = "RMN" });
            }
        }
    }
}
