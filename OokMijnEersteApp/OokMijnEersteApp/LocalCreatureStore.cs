using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OokMijnEersteApp
{
    public class LocalCreatureStore : IDataStore<Creature>
    {

        public async Task<bool> CreateItem(Creature item)
        {
            string CreatureAsJsonText = JsonConvert.SerializeObject(item);

            Preferences.Set("MyCreature",CreatureAsJsonText);

            return true;
        }

        public async Task<bool> DeleteItem(Creature item)
        {
            Preferences.Remove("MyCreature");
            return true;
        }

        public async Task<Creature> ReadItem()
        {
            string CreatureAsJsonText = Preferences.Get("MyCreature","");
            Creature CreatureFromJsonText = JsonConvert.DeserializeObject<Creature>(CreatureAsJsonText);
            return CreatureFromJsonText;
        }

        public async Task<bool> UpdateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyCreature"))
            {
                string CreatureAsJsonText = JsonConvert.SerializeObject(item);

                Preferences.Set("MyCreature", CreatureAsJsonText);

                return true;
            }
            return false;
        }
    }
}
