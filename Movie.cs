// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ApiProject
{
    class Movie
    {
        public static async Task Main(string[] args)
        {

            string api_key = "a335598510f3d09e74cbf50e8758eafa";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization","Bearer a335598510f3d09e74cbf50e8758eafa");

            //var response = await httpClient.GetAsync("https://api.themoviedb.org/3/movie/550?api_key=a335598510f3d09e74cbf50e8758eafa");
            
            //var responseContent =await response.Content.ReadAsStringAsync();
             //Console.WriteLine(responseContent);
            PopularMovie getPopularMovies = new PopularMovie(api_key,httpClient);
            Task<List<string>> popularMoviesList = getPopularMovies.GetPopularMovies();
            await popularMoviesList;

            UpcomingMovie getUpcomingMovies = new UpcomingMovie(api_key,httpClient);
            Task<List<string>> upcomingMoviesList = getUpcomingMovies.GetUpcomingMovies();
            await upcomingMoviesList;


        
           // Console.WriteLine(result);
          
        }

    }
}
