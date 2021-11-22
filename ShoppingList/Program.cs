using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {         
            string rootDirectoy = @"C:\Users\SS\Samples";
            string newDirectory = @"ShoppingList";
            string fileName = @"myShoppingList.txt";
            Directory.CreateDirectory($"{rootDirectoy}\\{newDirectory}");

            if (Directory.Exists($"{rootDirectoy}\\{newDirectory}") && File.Exists($"{rootDirectoy}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and file exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectoy}\\{newDirectory}");
                File.Create($"{rootDirectoy}\\{newDirectory}\\{fileName}");
            }

            Console.Clear();

            string fileLocation = @"C:\Users\SS\Samples\ShoppingList";
            string FileName = @"\\myShoppingList.txt";

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{FileName}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a wish? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your wish:");
                    string userWish = Console.ReadLine();
                    myShoppingList.Add(userWish);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Goodbye!");
                }
            }

            Console.Clear();

            foreach (string wish in myShoppingList)
            {
                Console.WriteLine($"Your wish: {wish}");
            }

            File.WriteAllLines($"{fileLocation}{FileName}", myShoppingList);
        }
    }
}
