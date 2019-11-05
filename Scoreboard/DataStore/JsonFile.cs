using Newtonsoft.Json;
using Scoreboard.Models;
using System.Collections.Generic;
using System.IO;

namespace Scoreboard.DataStore
{
    public class JsonFile : IFile
    {
        public IEnumerable<Consoleboard> GetFileContent()
        {
            List<Consoleboard> oldConsoles;
            using (StreamReader reader = new StreamReader(@"./DataStore/old_consoles.json"))
            {
                string json = reader.ReadToEnd();
                oldConsoles = JsonConvert.DeserializeObject<List<Consoleboard>>(json);
            }

            return oldConsoles ?? new List<Consoleboard>();
        }

        public void WriteFileContent(IEnumerable<Consoleboard> boards)
        {
            File.WriteAllText(@"./DataStore/old_consoles.json", JsonConvert.SerializeObject(boards));
        }
    }
}
