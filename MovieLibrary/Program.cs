namespace MovieLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input;

            MovieManagement manage = new MovieManagement();

            do
            {
                Console.WriteLine("1) Create a Movie");
                Console.WriteLine("2) View Movies");
                Console.WriteLine("3) Search Movie");
                Console.WriteLine("4) Delete Movie");
                Console.WriteLine("5) Edit Movie");
                Console.WriteLine("6) Genres ");
                Console.WriteLine("7) Change User ");
                Console.WriteLine("Enter any other key to exit.");
                // stored user  input 
               input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        manage.CreateMovie();
                        break;
                    case 2:
                        manage.VeiwMovies();
                        break;
                    case 3:
                        manage.SearchMovie();
                        break;
                    case 4:
                        manage.DeleteMovie();
                        break;
                    case 5:
                        manage.EditMovie();
                        break;
                    case 6:
                        manage.DisplayGenres();
                        break;
                    case 7:
                        manage.ChangeUser();
                        break;  
                }


            } while (input <= 7 && input > 0);
                }
    }
}