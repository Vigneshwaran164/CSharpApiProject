
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json ;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ApiProject
{
    class UpcomingMovie
    {
        public List<string> upcomingMovies ;
        
        private readonly string _apiKey ;
        public HttpClient _httpClient ;

        public UpcomingMovie( string apiKey , HttpClient httpClient ) 
        {
            _apiKey = apiKey ;
            _httpClient = httpClient ;
            upcomingMovies = new List<string>();
        }
        public async Task<List<string>> GetUpcomingMovies()
        {
        

            var popularMovieResponse = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key={_apiKey}&language=en-US&page=1");

            var result = _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key={_apiKey}&language=en-US&page=1").Result ;

          
            var json = JsonConvert.DeserializeObject<JsonObject>(result);

           int i=0; 
           try{
                while(!json.results[i].title.Equals(""))   
                {
                
                    upcomingMovies.Add(json.results[i].title);
                    i++;
                }  
           }   
           catch(Exception ex)
           {
                Console.WriteLine("All movies are iterated in Upcoming category");
           }  

           var popularMovieResponseContent = await popularMovieResponse.Content.ReadAsStringAsync();

         
          Console.WriteLine("The Upcoming Movies are ");

          foreach(string movie in upcomingMovies)
          {
            Console.Write($"{movie}, ");
          }

            return upcomingMovies;
            

        } 
        
        
        
    }

}