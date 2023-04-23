using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieManagement
    {
        public void CreateMovie()
        {
            using (var context = new MovieContext())
            {
                var movie = new Movie();
                DateTime parsedDate;

                Console.WriteLine("Enter a Movie Title ");
                var movieTitle = Console.ReadLine();



                Console.WriteLine("how many genres");
                var genre = Convert.ToInt32(Console.ReadLine());
                var genres = new List<MovieGenre>();
                
                for(var i = 0; i < genre; i++)
                {
                    DisplayGenres();
                    Console.WriteLine(" What genre would you like to add (enter the ID):");
                    var genreId = Convert.ToInt64(Console.ReadLine());
                    var movieGenre = new MovieGenre();
                    movieGenre.Movie = movie;
                    movieGenre.Genre = context.Genres.Where(g => g.Id == genreId).First();
                    genres.Add(movieGenre);
                    context.MovieGenres.Add(movieGenre);





                }
               
                Console.WriteLine("Enter a date (mm/dd/yyyy)");
                var date = Console.ReadLine();
                var isValidDate = DateTime.TryParse(date,out parsedDate);
                while (!isValidDate)
                {
                    Console.WriteLine("That was not a valid date please enter the date with this format(mm/dd/yyyy): ");
                    isValidDate = DateTime.TryParse(date, out parsedDate);

                }

                
                movie.Title = movieTitle;
                movie.ReleaseDate = parsedDate;
                movie.MovieGenres = genres;

                context.Movies.Add(movie);
                context.SaveChanges();
                Console.WriteLine("Movie created.");

            }
        }

        public void VeiwMovies()
        {
            using (var context = new MovieContext())
            {

                var moviesList = context.Movies.ToList();

                Console.WriteLine("Would you like \n1) all records\n2) A select number of records ");
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        moviesList.ForEach(m => Console.WriteLine(m.Title));
                        break;
                    case 2:
                        Console.WriteLine("how many Movies would you like to see ");
                        var amount = Convert.ToInt32(Console.ReadLine());
                        while (amount > moviesList.Count)
                        {
                            if (amount > moviesList.Count)
                            {
                                Console.WriteLine($"There are only {moviesList.Count} Movies please enter a valid amount: ");
                                amount = Convert.ToInt32(Console.ReadLine());
                            }

                        }
                        var loop = moviesList.Count - amount;

                        Console.WriteLine("Your Movies: ");
                        for (var i = loop; i < moviesList.Count(); i++)
                        {
                            Console.WriteLine(moviesList[i].Title);
                        }
                        break;
                }



            }
        }
        public void VeiwMoviesById()
        {
            using (var context = new MovieContext())
            {

                var MoviesList = context.Movies.ToList();
                Console.WriteLine("Your Movies: \n");
                foreach (var movie in MoviesList)
                {
                    Console.WriteLine($"Movie ID:{movie.Id} Movie Name:{movie.Title}\n");
                }



            }
        }
        public void EditMovie()
        {
            using (var context = new MovieContext())
            {
                Console.WriteLine("What Movie Would you like to Edit?(Enter Movie ID)");
                VeiwMoviesById();
                var movieId = Convert.ToInt32(Console.ReadLine());

                var movieToUpdate = context.Movies.Where(m => m.Id == movieId).First();
                var oldMovie = movieToUpdate.Title;
                Console.WriteLine($"Your Choice is : {movieToUpdate.Title}");

                Console.WriteLine("What do you want to name the Movie?");
                var updatedTitle = Console.ReadLine();
                movieToUpdate.Title = updatedTitle;
                context.SaveChanges();
                Console.WriteLine($"{oldMovie} is now titled {movieToUpdate.Title}");


            }
        }

        public void DeleteMovie()
        {
            using (var context = new MovieContext())
            {
                Console.WriteLine("What Movie Would you like to remove?(Enter Movie ID)");
                VeiwMoviesById();
                var MovieId = Convert.ToInt32(Console.ReadLine());

                var movieToUpdate = context.Movies.Where(m => m.Id == MovieId).First();

                Console.WriteLine($"Your Choice is {movieToUpdate.Title} Are you sure you want to remove this Movie (Y)Yes or (N)No");
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "Y")
                {
                    context.Remove(movieToUpdate);
                    context.SaveChanges();
                    Console.WriteLine("Movie removed");

                }
                else
                {
                    Console.WriteLine("Movies left Unchanged");
                }


            }


        }

        public void SearchMovie()
        { 


            using (var context = new MovieContext()) { 
           
                
                
                Console.WriteLine("What Movie(s) are you looking for?");
                var search = Console.ReadLine();

                var moviesList = context.Movies.ToList();
               var results = moviesList.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();

               // Console.WriteLine(string.Join(" ", context.MovieGenres.Where(m => m.Movie.Id == 1339)));  


                if (results.Count > 0)
            {
                Console.WriteLine($"{results.Count} Result(s) found Your Media:");
                    results.ForEach(m => Console.WriteLine($" ID: {m.Id} {m.Title} {string.Join(",", context.MovieGenres.Where(l => l.Movie.Id == m.Id))})"));
                    
                }
                else
            {
                Console.WriteLine("Sorry we could not find a match to your search");
            }
               }
        }
        public void DisplayGenres() 
        {

            using (var context = new MovieContext())
            {

                var genresList = context.Genres.ToList();
                genresList.ForEach(m => Console.WriteLine($"ID:{m.Id} Type: {m.Name}"));


            }
        }

        public void ChangeUser()
        {
           
        }






    }
}
