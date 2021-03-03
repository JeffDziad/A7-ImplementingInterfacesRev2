using System;
using A6_MediaLibrary.Data;

namespace A6_MediaLibrary
{

    public static class Menu
    {

        public static Boolean endProgram {get; set;} = false;

        public static void runMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. View Media from File");
            Console.WriteLine("2. Add Media to File");
            Console.WriteLine("3. Exit");
            Console.Write("> ");
            string userInputStr = Console.ReadLine();
            int userInputInt;
            try
            {
                userInputInt = Convert.ToInt32(userInputStr);
                handleMenuInput(userInputInt);
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"\"{userInputStr}\" is not a valid menu option.", fe);
            }
        }

        public static void handleMenuInput(int input)
        {
            switch(input)
            {
                case 1:
                    Console.Clear();
                    viewMedia();
                    break;
                case 2:
                    Console.Clear();
                    addMedia();
                    break;
                case 3:
                    endProgram = true;
                    break;
                default:
                    Console.Clear();
                    Log.log($"{input} is not a valid menu option.", new FormatException());
                    break;
            }
        }

        public static void viewMedia()
        {
            Console.WriteLine("Choose Media Type to view: ");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Show");
            Console.WriteLine("3. Video");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("> ");
            string userInputStr = Console.ReadLine();
            try
            {
                int userInputInt = Convert.ToInt32(userInputStr);
                switch(userInputInt)
                {
                    case 1:
                        Console.Clear();
                        displayMedia(1);
                        break;
                    case 2:
                        Console.Clear();
                        displayMedia(2);
                        break;
                    case 3:
                        Console.Clear();
                        displayMedia(3);
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Log.log($"\"{userInputInt}\" is not a valid menu option.", new FormatException());
                        break;
                }
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"\"{userInputStr}\" is not a valid menu option.", fe);
            }
        }

        public static void displayMedia(int mediaCode)
        {
            Console.WriteLine("View Methods:");
            Console.WriteLine("1. View All");
            Console.WriteLine("2. Search by ID");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("> ");
            string userInputStr = Console.ReadLine();
            try
            {
                int userInputInt = Convert.ToInt32(userInputStr);
                switch(userInputInt)
                {
                    case 1:
                        Console.Clear();
                        MediaManager.print(mediaCode);
                        break;
                    case 2:
                        Console.Clear();
                        MediaManager.searchById(mediaCode);
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Log.log($"\"{userInputInt}\" is not a valid menu option.", new FormatException());
                        break;
                }
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"\"{userInputStr}\" is not a valid menu option.", fe);
            }
        }

        public static void addMedia()
        {
            Console.WriteLine("Choose Media Type to Create:");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Show");
            Console.WriteLine("3. Video");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("> ");
            string userInputStr = Console.ReadLine();
            try
            {
                int userInputInt = Convert.ToInt32(userInputStr);
                switch(userInputInt)
                {
                    case 1:
                        Console.Clear();
                        MediaManipulator.createMovie();
                        break;
                    case 2:
                        Console.Clear();
                        MediaManipulator.createShow();
                        break;
                    case 3:
                        Console.Clear();
                        MediaManipulator.createVideo();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Log.log($"\"{userInputInt}\" is not a valid menu option.", new FormatException());
                        break;
                }
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"\"{userInputStr}\" is not a valid menu option.", fe);
            }
        }

    }

}