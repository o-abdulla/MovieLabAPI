using Newtonsoft.Json;
using System.Net;

namespace OMDB_API_Lab.Models
{
    public class MovieSearchDAL
    {
        public static MovieModel GetMovie(string title) //Adjust here
        {
            //Adjust
            //Setup
            string url = $"https://www.omdbapi.com/?t={title}&apikey=c003bd99";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Converting to json
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to c#
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}
