using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DadJokesLibrary
{
    public class JokeGenerator
    {
        public async Task<string> GetRandomJokeAsync()
        {
            HttpClient client = new HttpClient();
            string dj = await client.GetStringAsync("https://icanhazdadjoke.com/slack");
            Gag gag = JsonConvert.DeserializeObject<Gag>(dj);

            string returnString = string.Empty;

            for (int i = 0; i < gag.attachments.Count; i++)
            {
                returnString = gag.attachments[i].text;
            }
            return returnString;
        }


       
    }
}

