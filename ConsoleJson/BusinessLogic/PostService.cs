using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleJson.Model;
using System.Net;
using System.IO;

namespace ConsoleJson.BusinessLogic
{
    public class PostService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_jsonRelativePath"></param>
        /// <returns></returns>
        public List<PostModel> GetPostListFromJsonWithPath(string _jsonRelativePath)
        {
            //
            string jsonContent = this.ReadJsonFromRelPath(_jsonRelativePath);

            //
            var result = new JsonDeserializer().DeserializeJson<List<PostModel>>(jsonContent);

            //
            if(result == null)
            {
                result = new List<PostModel>();
            }

            //
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_jsonUrl"></param>
        /// <returns></returns>
        public List<PostModel> GetPostListFromJsonWithUrl(string _jsonUrl)
        {
            //
            string stream = this.ReadJsonFromUrl(_jsonUrl);

            //
            var result = new JsonDeserializer().DeserializeJson<List<PostModel>>(stream);

            //
            if (result == null)
            {
                //
                result = new List<PostModel>();
            }

            //
            return result;
        }

        /// <summary>
        /// Il metodo legge lo stream del json partendo dall'url
        /// </summary>
        /// <param name="_url">stringa che indica l'url del json</param>
        /// <returns>ritorna una stringa contenente lo stream letto</returns>
        public string ReadJsonFromUrl(string _url)
        {
            string result = null;

            // crea una richiesta http partendo dall'url
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);

            // ottiene una risposta dalla richiesta
            WebResponse response = request.GetResponse();

            using (Stream streamResponse = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(streamResponse))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            // ritorna una stringa contenente lo stream letto
            return result;

        }

        /// <summary>
        /// Il metodo legge il contenuto del json partendo dal path relativo
        /// </summary>
        /// <param name="relFilePath">stringa che indica il path relativo del file</param>
        /// <returns>ritorna stringa con il contenuto del file json</returns>
        public string ReadJsonFromRelPath(string relFilePath)
        {
            // ottiene la stringa con il path assoluto, partendo da quello relativo
            string absFilePath = Path.GetFullPath(relFilePath);

            // salva in una stringa il contenuto del file json, partendo dal path assoluto
            string fileContent = File.ReadAllText(absFilePath);

            // ritorna una stringa con il contenuto del json
            return fileContent;
        }
    }
}
