namespace Vet.Clinique
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();

            // Setează calea bazei de date
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetClinique.db");

            // Inițializează baza de date
            Database = new DatabaseHelper(dbPath);

            // Setează pagina principală a aplicației
            MainPage = new NavigationPage(new VetClinique.MainPage());
        }
    }

}
