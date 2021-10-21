using BlazorServerDemo.Net6.MovieRatings.Models;

namespace BlazorServerDemo.Net6.MovieRatings.DataAccessLayer
{
    public static class Movies
    {
        public static async Task<List<Movie>> GetMoviesAsync()
        {
            return CreateDemoMovies();
        }

        private static List<Movie> CreateDemoMovies()
        {
            return new List<Movie>
            {
                new Movie(1, "Film", "Genre"),
                new Movie(2, "Zack and Miri Make a Porno", "Romance"),
                new Movie(3, "Youth in Revolt", "Comedy"),
                new Movie(4, "You Will Meet a Tall Dark Stranger", "Comedy"),
                new Movie(5, "When in Rome", "Comedy"),
                new Movie(6, "What Happens in Vegas", "Comedy"),
                new Movie(7, "Water For Elephants", "Drama"),
                new Movie(8, "WALL-E", "Animation"),
                new Movie(9, "Waitress", "Romance"),
                new Movie(10, "Waiting For Forever", "Romance"),
                new Movie(11, "Valentine's Day", "Comedy"),
                new Movie(12, "Tyler Perry's Why Did I get Married", "Romance"),
                new Movie(13, "Twilight: Breaking Dawn", "Romance"),
                new Movie(14, "Twilight", "Romance"),
                new Movie(15, "The Ugly Truth", "Comedy"),
                new Movie(16, "The Twilight Saga: New Moon", "Drama"),
                new Movie(17, "The Time Traveler's Wife", "Drama"),
                new Movie(18, "The Proposal", "Comedy"),
                new Movie(19, "The Invention of Lying", "Comedy"),
                new Movie(20, "The Heartbreak Kid", "Comedy"),
                new Movie(21, "The Duchess", "Drama"),
                new Movie(22, "The Curious Case of Benjamin Button", "Fantasy"),
                new Movie(23, "The Back-up Plan", "Comedy"),
                new Movie(24, "Tangled", "Animation"),
                new Movie(25, "Something Borrowed", "Romance"),
                new Movie(26, "She's Out of My League", "Comedy"),
                new Movie(27, "Sex and the City Two", "Comedy"),
                new Movie(28, "Sex and the City 2", "Comedy"),
                new Movie(29, "Sex and the City", "Comedy"),
                new Movie(30, "Remember Me", "Drama"),
                new Movie(31, "Rachel Getting Married", "Drama"),
                new Movie(32, "Penelope", "Comedy"),
                new Movie(33, "P.S. I Love You", "Romance"),
                new Movie(34, "Over Her Dead Body", "Comedy"),
                new Movie(35, "Our Family Wedding", "Comedy"),
                new Movie(36, "One Day", "Romance"),
                new Movie(37, "Not Easily Broken", "Drama"),
                new Movie(38, "No Reservations", "Comedy"),
                new Movie(39, "Nick and Norah's Infinite Playlist", "Comedy"),
                new Movie(40, "New Year's Eve", "Romance"),
                new Movie(41, "My Week with Marilyn", "Drama"),
                new Movie(42, "Music and Lyrics", "Romance"),
                new Movie(43, "Monte Carlo", "Romance"),
                new Movie(44, "Miss Pettigrew Lives for a Day", "Comedy"),
                new Movie(45, "Midnight in Paris", "Romence"),
                new Movie(46, "Marley and Me", "Comedy"),
                new Movie(47, "Mamma Mia!", "Comedy"),
                new Movie(48, "Mamma Mia!", "Comedy"),
                new Movie(49, "Made of Honor", "Comdy"),
                new Movie(50, "Love Happens", "Drama"),
                new Movie(51, "Love & Other Drugs", "Comedy"),
                new Movie(52, "Life as We Know It", "Comedy"),
                new Movie(53, "License to Wed", "Comedy"),
                new Movie(54, "Letters to Juliet", "Comedy"),
                new Movie(55, "Leap Year", "Comedy"),
                new Movie(56, "Knocked Up", "Comedy"),
                new Movie(57, "Killers", "Action"),
                new Movie(58, "Just Wright", "Comedy"),
                new Movie(59, "Jane Eyre", "Romance"),
                new Movie(60, "It's Complicated", "Comedy"),
                new Movie(61, "I Love You Phillip Morris", "Comedy"),
                new Movie(62, "High School Musical 3: Senior Year", "Comedy"),
                new Movie(63, "He's Just Not That Into You", "Comedy"),
                new Movie(64, "Good Luck Chuck", "Comedy"),
                new Movie(65, "Going the Distance", "Comedy"),
                new Movie(66, "Gnomeo and Juliet", "Animation"),
                new Movie(67, "Gnomeo and Juliet", "Animation"),
                new Movie(68, "Ghosts of Girlfriends Past", "Comedy"),
                new Movie(69, "Four Christmases", "Comedy"),
                new Movie(70, "Fireproof", "Drama"),
                new Movie(71, "Enchanted", "Comedy"),
                new Movie(72, "Dear John", "Drama"),
                new Movie(73, "Beginners", "Comedy"),
                new Movie(74, "Across the Universe", "romance"),
                new Movie(75, "A Serious Man", "Drama"),
                new Movie(76, "A Dangerous Method", "Drama"),
                new Movie(77, "27 Dresses", "Comedy"),
                new Movie(78, "(500) Days of Summer", "comedy")
            };
        }
    }
}