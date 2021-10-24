using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OokMijnEersteApp
{
    class RemoteCreatureStore : IDataStore<Creature>
    {
        private HttpClient client = new HttpClient();
        public async Task<bool> CreateItem(Creature item)
        {
            string CreatureAsJsonText = JsonConvert.SerializeObject(item);
            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(CreatureAsJsonText, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string postedCreatureAsText = await response.Content.ReadAsStringAsync();
                    Creature returnedCreature = JsonConvert.DeserializeObject<Creature>(postedCreatureAsText);
                    int postedCreature = returnedCreature.id;
                    Preferences.Set("MyCreatureID", postedCreature);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItem(Creature item)
        {
            int CreatureID = Preferences.Get("MyCreatureID", 0);
            try
            {
                client.DeleteAsync("https://tamagotchi.hku.nl/api/Creatures/" + CreatureID.ToString());
            }
            catch
            { 
                return false; 
            }
           
            return true;

        }

        public async Task<Creature> ReadItem()
        {
            int CreatureID = Preferences.Get("MyCreatureID", 0);
            if(CreatureID == 0)
            {
                return null;
            }
           var response = await client.GetAsync("https://tamagotchi.hku.nl/api/Creatures/"+ CreatureID.ToString());
            if (response.IsSuccessStatusCode)
            {
                string responceString = await response.Content.ReadAsStringAsync();

                var creature = JsonConvert.DeserializeObject<Creature>(responceString);
                return creature;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> UpdateItem(Creature item)
        {
            int CreatureID = Preferences.Get("MyCreatureID", 0);
            if (CreatureID == 0)
            {
                return false;
            }
            string CreatureAsJsonText = JsonConvert.SerializeObject(item);
            try
            {
                var response = await client.PutAsync("https://tamagotchi.hku.nl/api/Creatures/" + CreatureID.ToString(), new StringContent(CreatureAsJsonText, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string postedCreatureAsText = await response.Content.ReadAsStringAsync();
                    Creature returnedCreature = JsonConvert.DeserializeObject<Creature>(postedCreatureAsText);
                    int postedCreature = returnedCreature.id;
                    Preferences.Set("MyCreatureID", postedCreature);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
