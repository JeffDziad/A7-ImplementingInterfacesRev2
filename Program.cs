using System;

namespace A6_MediaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("|  Media Library v2 |");
            Console.WriteLine("---------------------");
            do
            {
                Menu.runMenu();
            }while(!Menu.endProgram);
            Console.WriteLine("Thanks for using Media Library v2!");
        }
    }
}
