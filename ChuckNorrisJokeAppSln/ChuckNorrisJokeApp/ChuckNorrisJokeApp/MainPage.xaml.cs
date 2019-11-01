using ChuckNorrisJokesLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChuckNorrisJokeApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void JokeButton_Clicked(object sender, EventArgs e)
        {
            JokeGenerator jokeG = new JokeGenerator();

            string joke = await jokeG.GetRandomJoke();

            JokeLabel.Text = joke;
        }

        private void GoToDadJokes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DadJokes());
        }

        private void CategoriesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Categories());
        }
    }
}
