using ChuckNorrisJokesLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisJokeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categories : ContentPage
    {

        public IList<Category> CategoriesList { get; set; }


        public Categories()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            JokeGenerator jkG = new JokeGenerator();
            string[] categoriesArr = await jkG.GetCategories();

            CategoriesList = new List<Category>();

            for (int i = 0; i < categoriesArr.Length; i++)
            {

                CategoriesList.Add(new Category
                {
                    CategoryName = categoriesArr[i]
                });

            }

            BindingContext = this;

        }

        public async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            var localCategory = e.Item as Category;

            if (localCategory != null)
            {

                string x = localCategory.CategoryName;

                HttpClient client = new HttpClient();




                string joking = await client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category={x}");
                var jokes = JsonConvert.DeserializeObject<Joke>(joking);

                await DisplayAlert(x, jokes.value, "cancel");

            }
        }
    }
}

