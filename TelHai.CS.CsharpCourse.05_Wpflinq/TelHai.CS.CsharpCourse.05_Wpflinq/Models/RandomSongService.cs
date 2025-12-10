
namespace TelHai.CS.CsharpCourse._05_Wpflinq.Models
{
    public class RandomSongService : ISongService
    {
        private static RandomSongService _instance;

        private readonly string[] _artists =
        {
            "The Beatles", "Adele", "Queen", "Ed Sheeran", "Taylor Swift",
            "Bruno Mars", "Coldplay", "Drake", "Eminem", "Rihanna"
        };

        private readonly string[] _titles =
        {
            "Yesterday", "Hello", "Bohemian Rhapsody", "Shape of You", "Love Story",
            "Uptown Funk", "Yellow", "God's Plan", "Lose Yourself", "Umbrella"
        };

        // Obj to generate random numbers
        private Random _random = new Random();

        public static RandomSongService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RandomSongService();
                }
                return _instance;
            }
        }
        private RandomSongService()
        {
        }

        public List<Song> GenerateSongs(int count)
        {
            List<Song> generatedSongs = new List<Song>();
            for (int i = 0; i < count; i++)
            {
                // Randomly select an Artist
                int artistIndex = _random.Next(_artists.Length);
                string randomArtist = _artists[artistIndex];

                // Randomly select a Song Title
                int titleIndex = _random.Next(_titles.Length);
                string randomTitle = _titles[titleIndex];

                // Generate random duration (between 2.0 and 10.0 minutes)
                double randomDuration = 2.0 + (_random.NextDouble() * 8.0);

                // Create the Song object and add it to the list
                Song newSong = new Song
                {
                    Artist = randomArtist,
                    Title = randomTitle,
                    Duration = Math.Round(randomDuration, 2) // Round 2
                };
                generatedSongs.Add(newSong);
            }

            return generatedSongs;
        }
    }
}
