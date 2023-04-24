
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json ;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ApiProject
{
    class PopularMovie
    {
        public List<string> popularMovies ;
        
        private readonly string _apiKey ;
        public HttpClient _httpClient ;

        public PopularMovie( string apiKey , HttpClient httpClient ) 
        {
            _apiKey = apiKey ;
            _httpClient = httpClient ;
            popularMovies = new List<string>();
        }
        public async Task<List<string>> GetPopularMovies()
        {
        

            var popularMovieResponse = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&language=en-US&page=1");

            var result = _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&language=en-US&page=1").Result ;

          
            var json = JsonConvert.DeserializeObject<JsonObject>(result);

           int i=0; 
           try{
                while(!json.results[i].title.Equals(""))   
                {
                
                    popularMovies.Add(json.results[i].title);
                    i++;
                }  
           }   
           catch(Exception ex)
           {
                Console.WriteLine("All movies are iterated in Popular category");
           }  

           var popularMovieResponseContent = await popularMovieResponse.Content.ReadAsStringAsync();

         
          Console.WriteLine("The Popular Movies are ");

          foreach(string movie in popularMovies)
          {
            Console.Write($"{movie}, ");
          }

            return popularMovies;
            

        } 
        
        
        
    }

}