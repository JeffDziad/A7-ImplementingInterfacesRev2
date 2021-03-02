using System;
using A6_MediaLibrary.Models;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using ConsoleTables;
using System.Linq;

namespace A6_MediaLibrary.Data
{

    public static class MediaManager
    {

        private static readonly string moviesPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "movies.csv");
        private static readonly string showsPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "shows.csv");
        private static readonly string videosPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "videos.csv");

        private static List<Media> mediaList;

        private static bool checkPath(string path)
        {
            if(!File.Exists(path))
            {
                return false;
            }else{
                return true;
            }
        }

        public static string getPath(string path)
        {
            switch(path)
            {
                case "movie":
                    return moviesPath;
                case "show":
                    return showsPath;
                default:
                    return videosPath;
            }
        }
        
        public static void printMovies()
        {
            mediaList = new List<Media>();
            if(checkPath(moviesPath))
            {
                TextFieldParser parser = new TextFieldParser(moviesPath);
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                string[] fields;
                if(!parser.EndOfData)
                {
                    parser.ReadLine();
                }
                while(!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    Movie movie = new Movie();
                    movie.ID = Convert.ToInt32(fields[0]);
                    movie.Title = fields[1];
                    movie.genres = fields[2].Split("|");
                    mediaList.Add(movie);
                }
                if(mediaList.Count > 0)
                {
                    moviesToConsoleTable(mediaList);
                }else
                {
                    Console.Clear();
                    Log.logX("movies.csv is empty!");
                }
            }else
            {
                Console.Clear();
                Log.logX($"The file, \"{moviesPath}\" could not be found!");
            }   
        }

        public static void moviesToConsoleTable(List<Media> media)
        {
            var moviesTable = new ConsoleTable("ID", "Title", "Genres");
            foreach(Movie movie in media)
            {
                moviesTable.AddRow(movie.ID, movie.Title, String.Join(",", movie.genres));
            }
            moviesTable.Write();
        }

        public static void printShows()
        {
            mediaList = new List<Media>();
            if(checkPath(showsPath))
            {
                TextFieldParser parser = new TextFieldParser(showsPath);
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                string[] fields;
                if(!parser.EndOfData)
                {
                    parser.ReadLine();
                }
                while(!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    Show show = new Show();
                    show.ID = Convert.ToInt32(fields[0]);
                    show.Title = fields[1];
                    show.season = Convert.ToInt32(fields[2]);
                    show.episode = Convert.ToInt32(fields[3]);
                    show.writers = fields[4].Split("|");
                    mediaList.Add(show);
                }
                if(mediaList.Count > 0)
                {
                    showsToConsoleTable(mediaList);
                }else
                {
                    Console.Clear();
                    Log.logX("shows.csv is empty!");
                }
            }else
            {
                Console.Clear();
                Log.logX($"The file, \"{showsPath}\" could not be found!");
            }   
        }

        public static void showsToConsoleTable(List<Media> media)
        {
            var showsTable = new ConsoleTable("ID", "Title", "Season", "Episode", "Writers");
            foreach(Show show in media)
            {
                showsTable.AddRow(show.ID, show.Title, show.season, show.episode, String.Join(",", show.writers));
            }
            showsTable.Write();
        }

        public static void printVideos()
        {
            mediaList = new List<Media>();
            if(checkPath(videosPath))
            {
                TextFieldParser parser = new TextFieldParser(videosPath);
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                string[] fields;
                if(!parser.EndOfData)
                {
                    parser.ReadLine();
                }
                while(!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    Video video = new Video();
                    video.ID = Convert.ToInt32(fields[0]);
                    video.Title = fields[1];
                    video.format = fields[2].Replace("|", ",");
                    video.length = Convert.ToInt32(fields[3]);
                    video.regions = Array.ConvertAll(fields[4].Split("|"), v => int.Parse(v));
                    mediaList.Add(video);
                }
                if(mediaList.Count > 0)
                {
                    videosToConsoleTable(mediaList);
                }else
                {
                    Console.Clear();
                    Log.logX("videos.csv is empty!");
                }
            }else
            {
                Console.Clear();
                Log.logX($"The file, \"{videosPath}\" could not be found!");
            }   
        }

        public static void videosToConsoleTable(List<Media> media)
        {
            var videosTable = new ConsoleTable("ID", "Title", "Format", "Length (Minutes)", "Regions");
            foreach(Video video in media)
            {
                videosTable.AddRow(video.ID, video.Title, video.format, video.length, String.Join(",", video.regions));
            }
            videosTable.Write();
        }

        public static int getLineNum(string path)
        {
            int lineNum = 0;
            TextFieldParser parser;
            switch(path)
            {
                case "movie":
                    parser = new TextFieldParser(moviesPath);
                    break;
                case "show":
                    parser = new TextFieldParser(showsPath);
                    break;
                default:
                    parser = new TextFieldParser(videosPath);
                    break;
            }
            if(!parser.EndOfData)
            {
                parser.ReadLine();
            }
            while(!parser.EndOfData)
            {
                parser.ReadLine();
                lineNum++;
            }
            return lineNum;
        }

    }

}