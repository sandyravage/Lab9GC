using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9GC
{
    class Program
    {
        public static int student;
        public static int decision;
        public static string choice;
        public static int choice1;
        public static string choice2;
        public static string choice3;
        public static string choice4;

        public static List<List<string>> students = new List<List<string>> {
                new List<string> { "Stephanie... I... I think","Pizza","Meming","the Northern Flicker"},
                new List<string> {"Tracy McAllistair", "Chicken", "Surfing","the Eastern Wild Turkey"},
                new List<string> {"Topher-B", "Jelly Beans", "Pumpkin Carving","the Boops Boops"},
                new List<string> {"Yolsworth Pennymoney", "Defeat", "Lawn Bowling","the Nene"},
                new List<string> {"Yeezus", "the YAMS", "Coin Collecting","the Cockroach"},
                new List<string> {"Geoff Diggum", "The Sun's Rays", "Drinking","a slightly rumpled paper plane"},
                new List<string> {"El Tigre", "Pocket Lint", "Stealing Stop Signs","Mother Russia"},
                new List<string> {"XV889", "Pineapple Upside-Down Cake", "Chiropracty","the penguin"},
                new List<string> {"Yousif", "Phytoplankton", "Yeezus","Giraffe"},
                new List<string> {"[B]eter", "Protein Bars/Muscle Milk", "Chainsaw Juggling","Air Force 1"},
                new List<string> {"XWing@Aliciousness", "The Void", "defeating the enemy","flying Gatorade Caps"},
                new List<string> {"Newt Gingrich", "Infinite Loops", "defending his country","the noble house fly"},
                new List<string> {"Steve(2)", "Canada", "Ego tripping at the edge of the universe","[INSERT BIRD]"} };
        
        static void Main()
        {
            Console.Write("Welcome to our C# class. Which student " +
                "would you like to learn more about? (Enter a number between " +
                $"1-{students.Count}):");

            Prompter();

            Console.WriteLine("\nStudent {0} is {1}. What would you like to know about {1}? " +
                "(enter a choice or \"options\" for available options):", student + 1, students[student][0]);

            SearchConverter();

        }
        static void SearchConverter()
        {
            decision = 0;
            choice = "";
            Console.WriteLine("");
            choice = Console.ReadLine().ToString().ToLower();
            if (choice == "favorite food")
            {
                decision = 1;
                Console.WriteLine("\n{0}'s favorite food is {1}.", students[student][0], students[student][decision]);
                AskAgain();
            }
            else if (choice == "favorite pass-time")
            {
                decision = 2;
                Console.WriteLine("\n{0}'s favorite pass-time is {1}.", students[student][0], students[student][decision]);
                AskAgain();
            }
            else if (choice == "favorite state bird")
            {
                decision = 3;
                Console.WriteLine("\n{0}'s favorite state bird is {1}.", students[student][0], students[student][decision]);
                AskAgain();
            }
            else if (choice == "options")
            {
                Console.WriteLine("\nEnter \"favorite food\", \"favorite pass-time\", or \"favorite state bird\"");
                SearchConverter();
            }
            else
            {
                Console.WriteLine("That's not a valid choice. Please try again.\n");
                SearchConverter();
            }
        }
        static void Prompter()
        {
            choice1 = 0;
            Console.WriteLine("");
            try
            {
                choice1 = int.Parse(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Not even a number bud.");
                Prompter();
            }
            if (choice1 < students.Count && choice1 >= 0)
            {
                student = choice1;
            }
            else
            {
                Console.WriteLine($"There are only {students.Count} students in the class. Please try again\n");
                Prompter();
            }
        }
        static void AskAgain()
        {
            choice2 = "";
            Console.WriteLine("\nWould you like to know anything " +
                "else about this student? (y / n)");
            choice2 = Console.ReadLine().ToString().ToLower();
            if (choice2 == "y")
            {
                Asker();
            }
            else if (choice2 == "n")
            {
                Repeat();
            }
            else
            {
                Console.WriteLine("That's not a valid choice. Please try again");
            }
        }
        static void Asker()
        {
            Console.WriteLine("What would you like to know about {0}?" +
                "(enter a choice or \"options\" for available options)", students[student][0]);
            SearchConverter();
        }
        static void Repeat()
        {
            choice3 = "";
            Console.WriteLine("\nWould you like to know about another student? (y/n)");
            choice3 = Console.ReadLine().ToString().ToLower();
            if (choice3 == "y")
            {
                Console.Clear();
                Main();
            }
            else if (choice3 == "n")
            { 
                AddStudent();
            }
            else
            {
                Console.WriteLine("Sorry, not a valid choice. Please try again.");
                Repeat();
            }
        }
        static void AddStudent()
        {
            Console.WriteLine("\nWould you like to add another student to the class? (\"y\" for yes, \"n\", to " +
                "exit program, or \"s\" to ask about another student).");
            choice4 = "";
            choice4 = Console.ReadLine().ToString().ToLower();

            if (choice4 == "y")
            {
                Console.Write("\nPlease enter a name: ");
                string name = Validation(Console.ReadLine());
                Console.Write("\nPlease enter a favorite food: ");
                string favoritefood = Validation(Console.ReadLine());
                Console.Write("\nPlease enter a favorite pass time: ");
                string favoritepass = Validation(Console.ReadLine());
                Console.Write("\nPlease enter a favorite state bird: ");
                string favoritebird = Validation(Console.ReadLine());
                students.Add(StudentAdder(name, favoritefood, favoritepass, favoritebird));
                students.OrderBy(t => t.First().ToList());
                AddStudent();
            }
            else if (choice4 == "n")
            {
                Environment.Exit(0);
            }
            else if (choice4 == "s")
            {
                Console.Clear();
                Main();
            }
            else
            {
                Console.WriteLine("That's not a valid choice. Please try again");
                AddStudent();
            }
        }
        static List<string> StudentAdder(string name, string favoritefood, string favoritepass, string favebird)
        {
            List<string> sublist = new List<string> { name, favoritefood, favoritepass, favebird };
            return sublist;
        }
        static string Validation(string input)
        {
            while(Regex.IsMatch(input,@"^[ ]+$"))
            {
                Console.WriteLine("\nInvalid input. Please try again.\n");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
