﻿namespace VetClinique
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddProgramareClicked(object sender, EventArgs e)
        {
            // Navigheaza către pagina de adăugare a programării
            await Navigation.PushAsync(new ProgramarePage());
        }

        private int count = 0;
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++; // Incrementăm contorul
            DisplayAlert("Informație", $"Butonul a fost apăsat de {count} ori.", "OK");
        }

        private async void OnViewProgramariClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgramariPage());
        }


    }
}
