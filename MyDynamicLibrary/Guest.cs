using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDynamicLibrary
{
    public class Guest : User
    {
        public Guest(List<Rubric> rubrics, List<string> rubric_names, string author) : base(rubrics, rubric_names, author) { }
        public override void ShowMenu()
        {
            Console.WriteLine(String.Format("{0,18:0.0}", "Меню програми"));
            Console.WriteLine("0 - вийти із меню гостя");
            Console.WriteLine("1 - переглянути список усіх рубрик");
            Console.WriteLine("2 - переглянути список усіх тем");
            Console.WriteLine("3 - переглянути список усіх тегів");
            Console.WriteLine("4 - переглянути список дат добавлення кожної новини");
            Console.WriteLine("5 - переглянути усіх авторів");
            Console.WriteLine("6 - переглянути певну новину");
            Console.WriteLine("7 - переглянути всі новини всіх рубрик");
            Console.WriteLine("8 - очистити консоль та переглянути це меню");
        }
        public override void Menu()
        {
            ShowMenu();
            Console.Write("\nВиберіть одну із перелічених дій: ");
            bool flag = true;
            while (flag)
            {
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.Clear();
                        ShowMenu(); Console.WriteLine();
                        throw new IsNotDigitException();
                    }
                    if (choice < 0 || 8 < choice)
                    {
                        Console.Clear();
                        ShowMenu(); Console.WriteLine();
                        throw new OutOfRangeException();
                    }
                    if (choice == 0)
                    {
                        flag = false;
                    }
                    
                    else if (choice == 1)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            Console.Clear();
                            ShowMenu(); Console.WriteLine();
                            ShowNamesOfRubrics();
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");

                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            for (int i = 0; i < rubric_names.Count(); i++)
                            {
                                Console.WriteLine($"\nПерелік усіх тем новин у рубриці \"{rubric_names[i]}\":");
                                rubrics[i].ShowNewsTopics();
                            }
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            for (int i = 0; i < rubric_names.Count; i++)
                            {
                                Console.WriteLine($"\nРубрика \"{rubric_names[i]}\"");
                                rubrics[i].ShowNewsTags();
                            }
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            for (int i = 0; i < rubric_names.Count; i++)
                            {
                                Console.WriteLine($"\nРубрика \"{rubric_names[i]}\"");
                                rubrics[i].ShowNewsTime();
                            }
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 5)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            for (int i = 0; i < rubric_names.Count; i++)
                            {
                                Console.WriteLine($"\nРубрика \"{rubric_names[i]}\"");
                                rubrics[i].ShowNewsAuthor();
                            }
                            Console.Write("Виберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 6)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            Console.Clear();
                            ShowNamesOfRubrics();
                            Console.WriteLine("\nЩоб скасувати перегляд новини, нажміть \"0\"");
                            Console.Write("Виберіть рубрику: ");
                            try
                            {
                                if (!int.TryParse(Console.ReadLine(), out int choice2))
                                    throw new IsNotDigitException();
                                if (choice2 < 0 || rubric_names.Count() < choice2)
                                    throw new OutOfRangeException();
                                if (choice2 == 0)
                                {
                                    Console.Clear();
                                    ShowMenu(); Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ви скасували перегляд новини");
                                    Console.ResetColor();
                                    Console.Write("Виберіть наступну дію: ");
                                }
                                else
                                {
                                    if (rubrics[choice2 - 1].Count() == 0)
                                    { Console.WriteLine("Рубрика пуста!"); Console.WriteLine("\nВиберіть наступну дію: "); }
                                    else
                                    {
                                        Console.WriteLine("\nВсі теми новин, які присутні у рубриці: ");
                                        rubrics[choice2 - 1].ShowNewsTopics();
                                        Console.Write("\nВиберіть новину: ");
                                        try
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out int choice3))
                                                throw new IsNotDigitException();
                                            if (choice3 < 0 || rubrics[choice2 - 1].Count() < choice3)
                                                throw new OutOfRangeException();
                                            if (choice3 == 0)
                                            {
                                                Console.Clear();
                                                ShowMenu(); Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Ви скасували перегляд новини");
                                                Console.ResetColor();
                                                Console.Write("Виберіть наступну дію: ");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                ShowMenu(); Console.WriteLine();
                                                rubrics[choice2 - 1].GetNews(choice3 - 1).Show();
                                                Console.Write("Виберіть наступну дію: ");
                                            }
                                        }
                                        catch (OutOfRangeException e)
                                        {
                                            Console.Clear();
                                            ShowMenu(); Console.WriteLine();
                                            CatchOutOfRangeException(e);
                                        }
                                        catch (IsNotDigitException e)
                                        {
                                            Console.Clear();
                                            ShowMenu(); Console.WriteLine(); CatchIsNotDigitException(e);
                                        }
                                    }
                                }
                            }
                            catch (OutOfRangeException e)
                            {
                                Console.Clear();
                                ShowMenu(); Console.WriteLine();
                                CatchOutOfRangeException(e);
                            }
                            catch (IsNotDigitException e)
                            {
                                Console.Clear();
                                ShowMenu(); Console.WriteLine(); CatchIsNotDigitException(e);
                            }
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 7)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            for (int i = 0; i < rubric_names.Count; i++)
                            {
                                Console.WriteLine($"\nРубрика \"{rubric_names[i]}\" ");
                                rubrics[i].ShowRubric();
                            }
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 8)
                    {
                        Console.Clear();
                        ShowMenu();
                        Console.Write("\nВиберіть наступну дію: ");
                    }
                }
                catch (OutOfRangeException e) { CatchOutOfRangeException(e); }
                catch (IsNotDigitException e) { CatchIsNotDigitException(e); }
            }
        }
    }
}
