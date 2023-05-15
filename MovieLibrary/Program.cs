using Pastel;
using System.Drawing;

namespace MovieLibrary
{
    internal class Program
    {

       

        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            int input;
            string title = @"    __  ___           _         _   __            _             __            
   /  |/  /___ _   __(_)__     / | / /___ __   __(_)___ _____ _/ /_____  _____
  / /|_/ / __ \ | / / / _ \   /  |/ / __ `/ | / / / __ `/ __ `/ __/ __ \/ ___/
 / /  / / /_/ / |/ / /  __/  / /|  / /_/ /| |/ / / /_/ / /_/ / /_/ /_/ / /    
/_/  /_/\____/|___/_/\___/  /_/ |_/\__,_/ |___/_/\__, /\__,_/\__/\____/_/     
                                                /____/";


            

            MovieManagement manage = new MovieManagement();
            logger.Info("Program started");

            do
            {
                
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine($"{title}");

                // Console.ForegroundColor = ConsoleColor.;
                Console.WriteLine($"1) Create a Movie".Pastel("#124542"));
                Console.WriteLine("2) View Movies".Pastel("#185C58"));
                Console.WriteLine("3) Search Movie".Pastel("#1E736E"));
                Console.WriteLine("4) Delete Movie".Pastel("#248A84"));
                Console.WriteLine("5) Edit Movie".Pastel("#20B2AA"));
                Console.WriteLine("6) Rate Movie".Pastel("#3FBDB6"));
                Console.WriteLine("7) Change User ".Pastel("#5EC8C2"));
                Console.WriteLine("8) View top Movies ".Pastel("#7DD3CE"));

            
                Console.Write("\nEnter any other key to exit >> ".Pastel("#9CDEDA") );
                // stored user  input 
                bool isvalid = int.TryParse(Console.ReadLine(),out input );
                while (!isvalid)
                {
                    Console.WriteLine("Please enter a valid number option".Pastel("#b30000"));
                    isvalid = int.TryParse(Console.ReadLine(), out input);

                }

                switch (input)
                {
                    case 1:
                       
                        manage.CreateMovie();
                        logger.Info("Movie created");
                        break;

                    case 2:
                        
                        manage.VeiwMovies();
                        logger.Info("Movies listed");
                        break;

                    case 3:
                        
                        manage.SearchMovie();
                        logger.Info("Successful search");
                        break;
                    case 4:
                        
                        manage.DeleteMovie();
                        logger.Info("Movie removed");
                        break;
                    case 5:
                        manage.EditMovie();
                        logger.Info("Movie editied");
                        break;
                    case 6:
                        manage.RateMovie();
                        logger.Info("Movie rated");
                        break;
                    case 7:
                        manage.ChangeUser();
                        logger.Info("user changed");
                        break;
                    case 8:
                        manage.TopMovies();
                        logger.Info("Top content displayed");
                        break;
                   /* case 9:
                        manage.ViewUsersByID();
                        break;
                    case 10:
                         manage.RemoveUsers();
                        break;
                    case 11:
                        manage.RemoveOccupation();
                        break;*/
                }


            } while (input <= 8 && input > 0);
        }
    }
}