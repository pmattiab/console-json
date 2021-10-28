using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleJson.BusinessLogic
{
    public class JsonDeserializer
    {
        /// <summary>
        /// Il metodo deserializza il file json partendo dal contenuto del file
        /// </summary>
        /// <typeparam name="T">valore tipizzato che viene tornato dal metodo</typeparam>
        /// <param name="_jsonContent">stringa con il contenuto del json</param>
        /// <returns>ritorna il json tipizzato deserializzato</returns>
        public T DeserializeJson<T>(string _jsonContent)
        {
            // deserializzo partendo dal contenuto del json
            T deserJson = JsonConvert.DeserializeObject<T>(_jsonContent);

            // ritorno il valore tipizzato deserializzato
            return deserJson;
        }

    }
}
