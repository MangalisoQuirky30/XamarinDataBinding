using DadJokesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisJokeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DadJokes : ContentPage
    {
        public string joke { get; set; }
        public DadJokes()
        {
            InitializeComponent();
        }

        private async void JokeButton_Clicked(object sender, EventArgs e)
        {
            JokeGenerator jokeG = new JokeGenerator();
            joke = await jokeG.GetRandomJokeAsync();

            DadJokeLabel.Text = joke;
        }
    }
}
