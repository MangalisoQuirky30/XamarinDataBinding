using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisJokesLibrary
{
    public class JokeGenerator
    {
        public async Task<string> GetRandomJoke()
        {
            var client = new HttpClient() ;
            string randomJoke = await client.GetStringAsync("https://api.chucknorris.io/jokes/random");
            // this return a string found in that url... its a json text in a string format
            var joke = JsonConvert.DeserializeObject<Joke>(randomJoke);
            // this converts  the json in string form (randomJoke) to csharp cstructure specified in 'joke.cs'-class
            // take json, turn it to csharp
            return joke.value;
        }

        public Task<string> GetRandomJokeAsync()
        {
            throw new NotImplementedException();
        }



        public async Task<string[]> GetCategories()
        {
            var categories = new HttpClient();
            string categoriesstring = await categories.GetStringAsync("https://api.chucknorris.io/jokes/categories");

            var categoriesStrArr = JsonConvert.DeserializeObject<string[]>(categoriesstring);
            return categoriesStrArr;
        }

       



       




    }
}




    /*[ 
        "animal",
        "career",
        "celebrity",
        "dev",
        "explicit",
        "fashion",
        "food",
        "history",
        "money",
        "movie",
        "music",
        "political",
        "religion",
        "science",
        "sport",
        "travel"
    ] */