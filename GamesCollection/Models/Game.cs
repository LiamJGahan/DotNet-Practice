namespace Collection.Models
{
    public class Game
    {
        public int GameId {get; set;}
        public string Title {get;set;} = "";
        public string[] Tags {get;set;} = Array.Empty<string>();
        public string Platform {get;set;} = "";
    }
} 