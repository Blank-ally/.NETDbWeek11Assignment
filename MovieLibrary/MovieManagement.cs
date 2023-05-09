using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieManagement
    {
        User user;
       // private readonly ILogger<MovieManagement> _logger;

        // change all Convert.int32 to trypase and add ifs 
        //add logging

        // validate input further 
        //  add whiles to searches make it like create movie method and run more tests 

        public MovieManagement(ILogger<MovieManagement> logger)
         {
               // _logger = logger;
            /*
              using (var context = new MovieContext())
             {
                 user = new User();
                 Console.WriteLine("Hello new user !!");

                 Console.WriteLine("Please enter Your Name");
                var name = Console.ReadLine();

                 Console.WriteLine("Please enter Your Age");
                 var age = Convert.ToInt64( Console.ReadLine());

                 Console.WriteLine("Please enter Your gender (M or F)");
                 var gender = Console.ReadLine();

                 Console.WriteLine("Please enter Your zipcode");
                 var zipcode = Console.ReadLine();

                Console.WriteLine("");
                 ViewOcccupationsById();

                 Console.WriteLine("Please enter Your occupation (enter ID) or enter 0 if you do not see you occupation ");
                 var occ = Convert.ToInt32(Console.ReadLine());
               var occupation = context.Occupations.Where(o => o.Id == Convert.ToInt64(occ)).First();
                if (occ == 0) {
                   Console.WriteLine("No Worries we'll just make a new one ");
                     occupation = new Occupation();
                   Console.WriteLine("What is the occupation name");
                   var newOccName = Console.ReadLine();

                 occupation.Name = newOccName;

                context.Occupations.Add(occupation);
                  
                    }
                 user.Name = name;
                 user.Age = age;
                 user.Gender = gender.ToUpper();
                 user.ZipCode = zipcode;
                 user.Occupation = occupation;
              
                 context.Users.Add(user);
                 context.SaveChanges();
                 Console.WriteLine($"user :{user.Name},age: {user.Age}, {user.Gender}, zipcode: {user.ZipCode} occupation: {user.Occupation.Name} has been created");



             }*/
        } //TO DO

        

         public MovieManagement()
        {/*
            var mess = "Hello new user !!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (mess.Length / 2)) + "}", mess));
          
            using (var context = new MovieContext())
             {
                 user = new User();

                 
                 Console.WriteLine("Please enter Your Name");
                  var name = Console.ReadLine();
                 Console.WriteLine("Please enter Your Age");
                var isvalid = int.TryParse(Console.ReadLine(), out var age);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out age);


                }
                Console.WriteLine("Please enter Your gender (M or F)");
                 var gender = Console.ReadLine();
                 Console.WriteLine("Please enter Your zipcode");
                 var zipcode = Console.ReadLine();
                 ViewOcccupationsById();
                 Console.WriteLine("Please enter Your occupation (enter ID) or 0 if you  dont see you occupation ");
                   isvalid = int.TryParse(Console.ReadLine(), out var occ); 

                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out occ);


                }
                if ( occ == 0) { 
                 var occupation = new Occupation();
                
                 Console.WriteLine("Please enter You occupation name");
                 var newoccName = Console.ReadLine();
                 occupation.Name = newoccName;
                 context.Occupations.Add(occupation);
                  context.SaveChanges();
                  occ = (int)occupation.Id;

                }
                
                 user.Name = name;
                 user.Age = age;
                 user.Gender = gender.ToUpper();
                 user.ZipCode = zipcode;
                 user.Occupation = context.Occupations.Where(o => o.Id == Convert.ToInt64(occ)).First();
               var  occName = context.Occupations.Where(o => o.Id == Convert.ToInt64(occ)).First().Name;
                 context.Users.Add(user);
                 context.SaveChanges();
                 Console.WriteLine($"user : {user.Name},age: {user.Age}, {user.Gender}, zipcode: {user.ZipCode} occupation: {occName} has been created");
             }*/
        }
        private void ViewOcccupationsById()
        {
            using (var context = new MovieContext())
            {
                var occupationlist = context.Occupations.ToList();
                Console.WriteLine("Occupations: \n");
                foreach (var occ in occupationlist)
                {
                    Console.WriteLine($"ID:{occ.Id} Occupation Name:{occ.Name}\n");
                }

            }
        }

        public void CreateMovie()
        {
            var genreId = 0;
            var input = 0;

           // _logger.Log(LogLevel.Information, "Creating movie");

            using (var context = new MovieContext())
            {

                Console.ForegroundColor = ConsoleColor.DarkBlue;


                var movie = new Movie();
                DateTime parsedDate;

                Console.WriteLine("\nEnter the title of your movie".Pastel("#124542"));
                var movieTitle = Console.ReadLine();



                Console.WriteLine("\nHow many genres are you looking for?".Pastel("#124542"));
                bool isvalid = int.TryParse(Console.ReadLine(), out var genre);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out genre);
           

                }

                var genres = new List<MovieGenre>();

                for (var i = 0; i < genre; i++)
                {
                    Console.WriteLine("\nWould you like to: \n1) Search genres by name, \n2) See a list of genres".Pastel("#124542"));
                    isvalid = int.TryParse(Console.ReadLine(), out input);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out input);
                      //  _logger.Log(LogLevel.Information, "invalid input ");

                    }
                    if (input == 1)
                    {
                        var sear = SearchGenres();
                        while(sear == 0)
                        {
                            sear = SearchGenres();
                        }
                        Console.WriteLine("\nWhat genre would you like to add? (Please enter the ID):".Pastel("#124542"));
                         isvalid = int.TryParse(Console.ReadLine(), out genreId);
                        while (!isvalid)
                        {
                            Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                            isvalid = int.TryParse(Console.ReadLine(), out genreId);

                        }
                    }
                    else
                    { 
                    DisplayGenres();
                    Console.WriteLine("\nWhat genre(s) would you like to add? (Please enter the ID):".Pastel("#124542"));
                        isvalid = int.TryParse(Console.ReadLine(), out genreId);
                        while (!isvalid)
                        {
                            Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                            isvalid = int.TryParse(Console.ReadLine(), out genreId);

                        }
                    }
                    var movieGenre = new MovieGenre();
                    movieGenre.Movie = movie;
                    movieGenre.Genre = context.Genres.Where(g => g.Id == genreId).First();
                    context.MovieGenres.Add(movieGenre);

                    



                }

                Console.WriteLine("\nEnter a date (mm/dd/yyyy):".Pastel("#124542"));
                
                var isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);
                while (!isValidDate)
                {
                    Console.WriteLine("\nThat is not a valid date, please enter the date with the following format (mm/dd/yyyy): ".Pastel("#b30000"));
                    isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);

                }


                movie.Title = movieTitle;
                movie.ReleaseDate = parsedDate;


                context.Movies.Add(movie);
                context.SaveChanges();
                Console.WriteLine($"\nTitle: {movie.Title.Pastel("#9CDEDA")}, Release date: {movie.ReleaseDate.ToString().Pastel("#9CDEDA")}, Genres: {string.Join(",", movie.MovieGenres.Select(x => x.Genre.Name)).Pastel("#9CDEDA")} created.".Pastel("#124542"));
                

            }
        }

        internal void TopMovies()
        {
            var CountOfRatings = 0;

            using (var context = new MovieContext())
            {
                Console.WriteLine("Would you like to sort the movies by\n1)occupations\n2)ages".Pastel("#7DD3CE"));
               var isvalid = int.TryParse(Console.ReadLine(), out var choice);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out  choice);

                }

                if (choice == 1)
                {
                    Console.WriteLine("What occupation would you like to see the top movie for\n1) A select occpation\n2) All Occupations".Pastel("#7DD3CE"));
                     isvalid = int.TryParse(Console.ReadLine(), out choice);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out choice);

                    }

                    if (choice == 1)
                    {
                        Console.WriteLine("Would you like to\n1)search for occupation\n2)View a list of occupations ".Pastel("#7DD3CE"));
                         isvalid = int.TryParse(Console.ReadLine(), out  choice);
                        while (!isvalid)
                        {
                            Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                            isvalid = int.TryParse(Console.ReadLine(), out choice);

                        }

                        if (choice == 1)
                        {
                            SearchOccupation();
                            Console.WriteLine("please enter the Id of the occupation you would like see the top movie for ".Pastel("#7DD3CE"));
                            isvalid = int.TryParse(Console.ReadLine(), out var occID);
                            while (!isvalid)
                            {
                                Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                                isvalid = int.TryParse(Console.ReadLine(), out occID);

                            }

                            var selectOcc = context.UserMovies.Where(u => u.Rating == 5 && u.User.Occupation.Id == occID).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(), MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First();
                            Console.WriteLine($"Occupation: {context.Occupations.Where(o => o.Id == occID).First().Name.Pastel("#9CDEDA")} Top Rated Movie: {selectOcc.MovieTitle.Pastel("#9CDEDA")}");

                        }
                        else if (choice == 2)
                        {
                            ViewOcccupationsById();
                            Console.WriteLine(" please enter the Id of the occupation you would like see the top movie for ".Pastel("#7DD3CE"));
                            isvalid = int.TryParse(Console.ReadLine(), out var occID);
                            while (!isvalid)
                            {
                                Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                                isvalid = int.TryParse(Console.ReadLine(), out occID);

                            }
                            var selectOcc = context.UserMovies.Where(u => u.Rating == 5 && u.User.Occupation.Id == occID).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(), MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First();
                            Console.WriteLine($"Occupation: {context.Occupations.Where(o => o.Id  == occID).First().Name.Pastel("#9CDEDA")} Top Rated Movie: {selectOcc.MovieTitle.Pastel("#9CDEDA")}");


                        }
                    }
                    else if (choice == 2)
                    {
                        var occ = context.Occupations.ToList();
                        occ.ForEach(o => Console.WriteLine($"occupation: {o.Name.Pastel("#9CDEDA")} Top rated movie :{context.UserMovies.Where(u => u.Rating == 5 && u.User.Occupation.Id == o.Id).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(),  MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First()}\n ".Pastel("#7DD3CE")));
                    }

                }
                else if (choice == 2)
                {
                    // var age = context.UserMovies.ToList().Select(u => u.User.Age).Distinct().ToList();
                    //age.ForEach(a => Console.WriteLine(a));
                    Console.WriteLine("What age range\n1) Rated General(childern up to 13) \n2) Rated PG (Parental guidance for 13 and up)\n3) Rated R (17 and up)".Pastel("#7DD3CE"));
                    isvalid = int.TryParse(Console.ReadLine(), out  choice);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out choice);

                    }
                  
                    if (choice == 1)
                    {
                        var under13 = context.UserMovies.Where(x => x.User.Age < 13 && x.Rating == 5).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(), MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First();
                        Console.WriteLine($"Age Range: childern up to 13 Top Movie: {under13.MovieTitle.Pastel("#9CDEDA")}".Pastel("#7DD3CE"));

                       // Console.WriteLine(under13.Count());
                    }
                    else if (choice == 2)
                    {

                        var upTo13 = context.UserMovies.Where(x => x.User.Age <= 13 && x.Rating == 5).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(), MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First();
                        Console.WriteLine($"Age Range: 13 and up Top Movie: {upTo13.MovieTitle.Pastel("#9CDEDA")}".Pastel("#7DD3CE"));
                    }

                    else if (choice == 3)
                    {
                        var over13 = context.UserMovies.Where(x => x.User.Age > 17 && x.Rating == 5).GroupBy(x => x.Movie.Title).Select(x => new { CountOfRatings = x.Count(), MovieTitle = x.Key }).OrderByDescending(x => x.CountOfRatings).First();
                        Console.WriteLine($"Age Range: 17 and up Top Movie: {over13.MovieTitle.Pastel("#9CDEDA")}".Pastel("#7DD3CE"));
                    }
                   
                }
                else
                {
                    Console.WriteLine("Invalid input please enter 1 or 2 ".Pastel("#b30000"));
                    TopMovies();
                }
            }
        }

        public void VeiwMovies()
        {
            using (var context = new MovieContext())
            {

                var moviesList = context.Movies.ToList();

                Console.WriteLine("Would you like \n1) all records\n2) A select number of records ".Pastel("#185C58"));
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        moviesList.ForEach(m => Console.WriteLine(m.Title));
                        break;
                    case 2:
                        Console.WriteLine("how many Movies would you like to see ".Pastel("#185C58"));
                        var amount = Convert.ToInt32(Console.ReadLine());
                        while (amount > moviesList.Count)
                        {
                            if (amount > moviesList.Count)
                            {
                                Console.WriteLine($"There are only {moviesList.Count} Movies please enter a valid amount: ".Pastel("#b30000"));
                                amount = Convert.ToInt32(Console.ReadLine());
                            }

                        }
                        var loop = moviesList.Count - amount;

                        Console.WriteLine("Your Movies: ".Pastel("#185C58"));
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
            var movieId = 0;
            using (var context = new MovieContext())
            {
               
                Console.WriteLine("Would you like to\n1) search movie by title \n2)See list".Pastel("#20B2AA"));
                var isvalid = int.TryParse(Console.ReadLine(), out var input);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out input);

                }
                if (input == 1)
                {
                    SearchMovie();
                    Console.WriteLine("What Movie Would you like to Edit?(Enter Movie ID)".Pastel("#20B2AA"));
                    isvalid = int.TryParse(Console.ReadLine(), out  movieId);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out movieId);

                    }
                }
                else { 
                VeiwMoviesById();
                Console.WriteLine("What Movie Would you like to Edit?(Enter Movie ID)".Pastel("#20B2AA"));
                    isvalid = int.TryParse(Console.ReadLine(), out movieId);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out movieId);

                    }
                }
                var movieToUpdate = context.Movies.Where(m => m.Id == movieId).First();
                var oldMovie = movieToUpdate.Title;
                Console.WriteLine($"Your Choice is : {movieToUpdate.Title.Pastel("#9CDEDA")} ".Pastel("#20B2AA"));

                Console.WriteLine("What do you want to name the Movie?".Pastel("#20B2AA"));
                var updatedTitle = Console.ReadLine();
                movieToUpdate.Title = updatedTitle;
                context.SaveChanges();
                Console.WriteLine($"{oldMovie} is now titled {movieToUpdate.Title.Pastel("#9CDEDA")}".Pastel("#20B2AA"));


            }
        }

        public void DeleteMovie()
        {
            var movieId = 0;
            using (var context = new MovieContext())
            {
                Console.WriteLine(" would you like to \n1) search for a movie by title\n2)see a list of movies ".Pastel("#248A84"));

                var  input = Console.ReadLine();

                if (input == "1")
                {
                    SearchMovie();
                    Console.WriteLine("What Movie Would you like to remove?(Enter Movie ID)".Pastel("#248A84"));
                   var  isvalid = int.TryParse(Console.ReadLine(), out movieId);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out movieId);

                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("What Movie Would you like to remove?(Enter Movie ID)".Pastel("#248A84"));
                    VeiwMoviesById();
                  var  isvalid = int.TryParse(Console.ReadLine(), out movieId);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out movieId);

                    }
                }

                while (context.Movies.Where(m => movieId == m.Id).ToList().Count == 0)
                {
                    var isvalid = int.TryParse(Console.ReadLine(), out movieId);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out movieId);

                    }

                }


               

                var movieToUpdate = context.Movies.Where(m => m.Id == movieId).First();

                Console.WriteLine($"Your Choice is {movieToUpdate.Title.Pastel("#9CDEDA")} Are you sure you want to remove this Movie (Y)Yes or (N)No".Pastel("#248A84"));
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "Y")
                {
                    context.Remove(movieToUpdate);
                    context.SaveChanges();
                    Console.WriteLine("Movie removed".Pastel("#248A84"));

                }
                else
                {
                    Console.WriteLine("Movies left Unchanged".Pastel("#248A84"));
                }


            }


        }

        public void SearchMovie()
        {


            using (var context = new MovieContext())
            {



                Console.WriteLine("What Movie(s) are you looking for?".Pastel("#1E736E"));
                var search = Console.ReadLine();

                var moviesList = context.Movies.ToList();
                var results = moviesList.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();



                if (results.Count > 0)
                {
                    Console.WriteLine($"{results.Count} Result(s) found Your Media:".Pastel("#1E736E"));
                    results.ForEach(m => Console.WriteLine($" ID: {m.Id.ToString().Pastel("#1E736E")} {m.Title.Pastel("#1E736E")} Genres: {string.Join(",", m.MovieGenres.Select(x => x.Genre.Name)).Pastel("#1E736E")}"));


                }
                else
                {
                    Console.WriteLine("Sorry we could not find a match to your search".Pastel("#b30000"));
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
        public void ViewUsersByID()
        {
            using (var context = new MovieContext())
            {

                var usersList = context.Users.ToList();
                usersList.ForEach(m => Console.WriteLine($"ID:{m.Id} Type: {m.Name}"));
            }
        }

        public void ChangeUser()
        {
            var id = 0;
            using (var context = new MovieContext())
            {

                Console.WriteLine($"current user: {user.Id.ToString().Pastel("#9CDEDA")} {user.Name.Pastel("#9CDEDA")} ".Pastel("#5EC8C2"));

                Console.WriteLine("Would you like to \n1)change to existing\n2)new user ".Pastel("#5EC8C2"));
               var isvalid = int.TryParse(Console.ReadLine(), out var input);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out input);

                }
                if (input == 1)
                {
                    Console.WriteLine("Would you like to\n 1) see a list of existing users\n2)Search for user by name".Pastel("#5EC8C2"));
                    isvalid = int.TryParse(Console.ReadLine(), out var choice);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out choice);

                    }
                    if (choice ==  1) { 
                    ViewUsersByID();

                    Console.WriteLine("Enter the user ID you would like to change to ".Pastel("#5EC8C2"));
                        isvalid = int.TryParse(Console.ReadLine(), out id);
                        while (!isvalid)
                        {
                            Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                            isvalid = int.TryParse(Console.ReadLine(), out id);

                        }
                       
                    }
                    else if (choice == 2)
                    {
                        SearchUsers();
                        Console.WriteLine("Enter the user ID you would like to change to ".Pastel("#5EC8C2"));
                        isvalid = int.TryParse(Console.ReadLine(), out id);
                        while (!isvalid)
                        {
                            Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                            isvalid = int.TryParse(Console.ReadLine(), out id);

                        }
                    }

                    Console.WriteLine("Are you sure you want to change users (Y)es or (N)o".Pastel("#5EC8C2"));
                    var input2 = Console.ReadLine();
                    if (input2.ToUpper() == "Y")
                    {

                        user = context.Users.Where(u => u.Id == id).First();
                    }
                    
                   
                    
                   //FINISH________________________________________________________________________________________________________________
                }
                else if (input == 2)
                {
                    MakeNewUser();
                }

                Console.WriteLine($"current user is now user: {user.Id.ToString().Pastel("#9CDEDA")}, name {user.Name.Pastel("#9CDEDA")}".Pastel("#5EC8C2"));
                // context.SaveChanges();


            }



        }
        public void MakeNewUser()
        {
            var occ = 0;
            using (var context = new MovieContext())
            {
                user = new User();
                Console.WriteLine("Please enter Your Name");
                var name = Console.ReadLine();

                Console.WriteLine("Please enter Your Age");
               var isvalid = int.TryParse(Console.ReadLine(), out var age);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out age);

                }

                Console.WriteLine("Please enter Your gender (M or F)");
                var gender = Console.ReadLine();

                Console.WriteLine("Please enter Your zipcode");
                var zipcode = Console.ReadLine();


                Console.WriteLine("Would you like to \n1) view a list of occupations by name  \n2) search a occupation by name ");
                isvalid = int.TryParse(Console.ReadLine(), out var input);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out input);

                }
                if (input == 1)
                {
                    ViewOcccupationsById();
                    Console.WriteLine("Please enter Your occupation (enter ID)");
                    isvalid = int.TryParse(Console.ReadLine(), out  occ);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out occ);

                    }
                }
                else if (input == 2)
                {
                   var search = SearchOccupation();
                    while ( search == 0) {
                        search = SearchOccupation();
                    }

                    Console.WriteLine("Please enter Your occupation (enter ID)");
                    isvalid = int.TryParse(Console.ReadLine(), out occ);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out occ);

                    }
                }
               

                //   var occupation = new Occupation();

                //occupation.Name = occ;

                // context.Occupations.Add(occupation);


                user.Name = name;
                user.Age = age;
                user.Gender = gender;
                user.ZipCode = zipcode;
                user.Occupation = context.Occupations.Where(o => o.Id == Convert.ToInt64(occ)).First();
                var occName = context.Occupations.Where(o => o.Id == Convert.ToInt64(occ)).First().Name;

                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine($"user : {user.Name},age: {user.Age}, {user.Gender}, zipcode: {user.ZipCode} occupation: {occName} has been created");
            }

        }

        public void RateMovie()
        {
            using (var context = new MovieContext())
            { // add  a are you sure 

               
                VeiwMoviesById();
                Console.WriteLine("What movie would you like to rate (Enter Movies ID)".Pastel("#3FBDB6"));

                var isvalid = int.TryParse(Console.ReadLine(), out var movieId);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out movieId);

                }
                var movie = context.Movies.Where(m => m.Id == movieId).First();
                Console.WriteLine($"what would you like to rate the {movie.Title.Pastel("#9CDEDA")}".Pastel("#3FBDB6"));
                isvalid = int.TryParse(Console.ReadLine(), out var rating);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out rating);

                }
                while (rating > 6)
                {
                    Console.WriteLine("Please enter a rating 1-5 ".Pastel("#3FBDB6"));
                    isvalid = int.TryParse(Console.ReadLine(), out rating);
                    while (!isvalid)
                    {
                        Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                        isvalid = int.TryParse(Console.ReadLine(), out rating);

                    }
                }
                var userMovie = new UserMovie();

                userMovie.User = context.Users.Where(u => u.Id == user.Id).First();
                userMovie.Movie = movie;
                userMovie.Rating = rating;
                userMovie.RatedAt = DateTime.Now;



                Console.WriteLine($"user : {user.Id.ToString().Pastel("#9CDEDA")} {user.Name.Pastel("#9CDEDA")} rated {movie.Title.Pastel("#9CDEDA")}, rating: {rating.ToString().Pastel("#9CDEDA")} stars".Pastel("#3FBDB6"));
                context.UserMovies.Add(userMovie);
                context.SaveChanges();



            }






        }
        public void VeiwUsersById()
        {
            using (var context = new MovieContext())
            {
                var usersList = context.Users.ToList();
                usersList.ForEach(u => Console.WriteLine($"ID:{u.Id} Type: {u.Name}"));
            }

        }
        public void PopulateNames()
        {
            /*
             using the faker. net package to generate names  
            */
            using (var context = new MovieContext())
            {
                var usersList = context.Users.ToList();

                usersList.ForEach(m => m.Name = Faker.Name.First());
                context.SaveChanges();
            }


        }

        public void RemoveUsers()
        {
            using (var context = new MovieContext())
            {
                Console.WriteLine("What user Would you like to remove?(Enter user ID)");
                VeiwUsersById();
               var isvalid = int.TryParse(Console.ReadLine(), out var userId);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out userId);

                }

                var userToRemove = context.Users.Where(u => u.Id == userId).First();

                Console.WriteLine($"Your Choice is {userToRemove.Id} {userToRemove.Name} Are you sure you want to remove this user (Y)Yes or (N)No");
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "Y")
                {
                    context.Remove(userToRemove);
                    context.SaveChanges();
                    Console.WriteLine("user removed");

                }
                else
                {
                    Console.WriteLine("users left Unchanged");
                }

            }
        }
        public void RemoveOccupation()
        {
            using (var context = new MovieContext())
            {
                Console.WriteLine("What user Would you like to remove?(Enter user ID)");
                VeiwUsersById();
               var  isvalid = int.TryParse(Console.ReadLine(), out var userId);
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out userId);

                }

                var userToRemove = context.Users.Where(u => u.Id == userId).First();

                Console.WriteLine($"Your Choice is {userToRemove.Id} {userToRemove.Name} Are you sure you want to remove this user (Y)Yes or (N)No");
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "Y")
                {
                    context.Remove(userToRemove);
                    context.SaveChanges();
                    Console.WriteLine("user removed");

                }
                else
                {
                    Console.WriteLine("users left Unchanged");
                }

            }
        }
        public void SearchUsers()
        {
            using (var context = new MovieContext())
            {



                Console.WriteLine("What user are you looking for?");
                var search = Console.ReadLine();

                var usersList = context.Users.ToList();
                var results = usersList.Where(u => u.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();



                if (results.Count > 0)
                {
                    Console.WriteLine($"{results.Count} User(s) found:");
                    results.ForEach(u => Console.WriteLine($" ID: {u.Id} {u.Name}"));


                }
                else
                {
                    Console.WriteLine("Sorry we could not find a match to your search");
                }
            }
        }
        public int SearchOccupation()
        {
            using (var context = new MovieContext())
            {



                Console.WriteLine("What Occupation(s) are you looking for?");
                var search = Console.ReadLine();

                var occsList = context.Occupations.ToList();
                var results = occsList.Where(o => o.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();



                if (results.Count > 0)
                {
                    Console.WriteLine($"{results.Count} Occuption(s) Found:");
                    results.ForEach(o => Console.WriteLine($" ID: {o.Id} {o.Name}"));


                }
                else
                {
                    Console.WriteLine("Sorry we could not find a match to your search");
                }
                return results.Count();
            }
            
        }
        public int SearchGenres()
        {
            using (var context = new MovieContext())
            {



                Console.WriteLine("What Genre(s) are you looking for?");
                var search = Console.ReadLine();

                var genreList = context.Genres.ToList();
                var results = genreList.Where(g => g.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();



                if (results.Count > 0)
                {
                    Console.WriteLine($"{results.Count} Result(s) found Your Media:");
                    results.ForEach(g => Console.WriteLine($" ID: {g.Id} {g.Name}"));


                }
                else
                {
                    Console.WriteLine("Sorry we could not find a match to your search");
                }

                return results.Count;
            }
        }


    }
}

