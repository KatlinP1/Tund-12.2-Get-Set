using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MovieGetterSetters
{
    class Program
    {

        class Movie
        {
            string title;
            string director;
            string ratings;
            int userRating;
            
            //kellel film mõeldud on: G, PG, PG-13, R, undefined
            //userRating not higher than 10 and no lower than 0
            //saab muuta userratingut hiljem pärast filmi vaatamist 

            public Movie(string _title, string _director, string _ratings, int _userRating)
            {
                title = _title;
                director = _director;
                Ratings = _ratings;
                UserRating = _userRating;


            }

            public string Title
            {
                get { return title; }
            }

            public string Director
            {
                get { return director; }
            }

            public string Ratings
            {
                get { return ratings; }
                set
                {
                    if (value == "G" || value == "PG" || value == "PG-13" || value == "R")
                    {
                        ratings = value;
                    }
                    else
                    {
                        ratings = "undefined";
                    }
                }
            }

            public int UserRating
            {
                get { return userRating; }
                set
                {
                    if (value >=0 && value <=10)
                    {
                        userRating = value;
                    }
                    else
                    {
                        userRating = 0;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {

            string filePath = @"/Users/katlinpaju/Demo/movies";
            List<string> listFromFile = File.ReadAllLines(filePath).ToList();
            List<Movie> listOfMovies=new List<Movie>();

            foreach (string line in listFromFile)
            {
                string[] tempArray = line.Split('/');
                string tempTitel = tempArray[0];
                string tempDir = tempArray[1];
                string tempRating = tempArray[2];
                int tempUserRating = int.Parse(tempArray[3]);
                
                Movie tempMovieObject=new Movie(tempTitel, tempDir, tempRating, tempUserRating);
                listOfMovies.Add(tempMovieObject);
            }

            int i = 1;
            foreach (Movie movieObject in listOfMovies)
            {
                Console.WriteLine($"Item {i}: {movieObject.Title} directed by {movieObject.Director} ");
                i++;
            }

            bool movieFound = false;
            
            Console.WriteLine("Enter the key word: ");
            string userSearch = Console.ReadLine().ToLower();
            
            List<Movie> searchResult= new List<Movie>();
            

            //int searchResult = 0;
            foreach (Movie movieObject in listOfMovies)
            {
                if (movieObject.Title.ToLower().Contains(userSearch))
                {
                    searchResult.Add(movieObject);
                    //Console.WriteLine($"{movieObject.Title} directed by {movieObject.Director}");
                    //searchResult++;
                }
            }
            
            Console.WriteLine($"{searchResult.Count} movies found");

            foreach (Movie movieObject in searchResult)
            {
                Console.WriteLine($"{movieObject.Title} directed by {movieObject.Director}");
            }
            
            
            




            /*Movie avangersEndgame=new Movie("Avangers:Endgame", "Anthony Russo", "PG-13", 8 );
            Console.WriteLine($"A movie: {avangersEndgame.Title}");
            Console.WriteLine($"Movie directors name: {avangersEndgame.Director}");
            Console.WriteLine($"Movie rating: {avangersEndgame.Ratings}");
            Console.WriteLine($"Movie user rating: {avangersEndgame.UserRating}");*/


        }
    }
}