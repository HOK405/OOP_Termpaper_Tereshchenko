using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDynamicLibrary
{
    abstract public class User
    {
        protected List<Rubric> rubrics;
        protected List<string> rubric_names;
        protected string author;
        public User(List<Rubric> rubrics, List<string> rubric_names,string author)
        {
            this.rubrics = rubrics;
            this.rubric_names = rubric_names;
            this.author = author;
        }
        abstract public void ShowMenu();
        abstract public void Menu();
        protected bool RubricListIsEmpty()
        {
            if (rubrics.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНа сайті немає рубрик!");
                Console.ResetColor();
                return false;
            }
            else
                return true;
        }
        public void ShowNamesOfRubrics()
        {
            if (rubric_names.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("На сайті немає рубрик!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Перелік усіх рубрик сайту:");
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < rubric_names.Count(); i++)
                    Console.WriteLine($"{i + 1} - {rubric_names[i]}");
                Console.ResetColor();
            }
        }
       public static void CatchOutOfRangeException(OutOfRangeException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.Write("Виберіть наступну дію: ");
        }
        public static void CatchIsNotDigitException(IsNotDigitException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.Write("Виберіть наступну дію: ");
        }
    }
}
