

using System ;

namespace ApiProject
{
    public class JsonObject
    {
        public int page { get; set; }
        public MovieTitle[] results { get; set; }
    }
    public class MovieTitle
    {
        public string title { get; set; }
        // Add other properties as needed
    }
}