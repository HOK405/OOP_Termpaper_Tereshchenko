using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDynamicLibrary
{
    public class Admin : User
    {
        public Admin(List<Rubric> rubrics, List<string> rubric_names, string author) : base(rubrics, rubric_names, author) { }       
        private void CancelAddingNews()
        {
            Console.Clear();
            ShowMenu();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nВи скасували створення новини");
            Console.ResetColor();
        }
        void RemoveNews(int index)
        {
            try
            {
                if (rubrics[index - 1].Count() != 0)
                {
                    rubrics[index - 1].ShowNewsTopics();
                    Console.Write("\nВиберіть індекс новини, яку бажаєте видалити: : ");
                    if (!int.TryParse(Console.ReadLine(), out int choice3))
                        throw new IsNotDigitException();
                    if (choice3 < 0 || rubrics[index - 1].Count() < choice3)
                        throw new OutOfRangeException();
                    if (choice3 == 0)
                    {
                        Console.Clear();
                        ShowMenu(); Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ви скасували видалення новини");
                        Console.ResetColor();
                        Console.Write("Виберіть наступну дію: ");
                    }
                    else
                    {
                        Console.Clear();
                        ShowMenu(); Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Новина \"{rubrics[index - 1].GetNews(choice3 - 1).Topic}\" успішно видалена!");
                        rubrics[index - 1].RemoveNews(choice3 - 1);
                        Console.ResetColor();
                        Console.Write("Виберіть наступну дію: ");
                    }
                }
                else
                {
                    Console.Clear();
                    ShowMenu(); Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Рубрика пуста!");
                    Console.ResetColor();
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
                ShowMenu(); Console.WriteLine();
                CatchIsNotDigitException(e);
            }
        }
        void AddNews(int index)
        {
            Console.Clear();           
            Console.WriteLine("Щоб скасувати створення новини, нажміть \"ENTER\"");
            News tempnew = new News();
            bool flag = true;
            string temp1;
            while (flag)
            {
                Console.Write("Введіть тему новини: "); temp1 = Console.ReadLine();
                if (temp1 == "")
                {
                    CancelAddingNews();
                    break;
                }
                else tempnew.Topic = temp1;
                Console.Clear();
                Console.WriteLine("Щоб закінчити створення новини, нажміть \"ENTER\"");
                Console.WriteLine("Щоб закінчити створення тегів, нажміть два рази \"ENTER\"");
                Console.WriteLine("Введіть теги новини:");
                string temp2 = Console.ReadLine();
                if (temp2 == "")
                {
                    CancelAddingNews();
                    break;
                }
                bool flag2 = true;
                List<string> templist = new List<string>();
                while (flag2)
                {
                    
                    templist.Add(temp2); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Тег успішно добавлений!");
                    Console.ResetColor();
                    temp2 = Console.ReadLine();
                    if (temp2 == "")
                    { Console.Clear(); break; }
                }
                tempnew.Tags = templist;
                tempnew.Author = author;
                Console.WriteLine("Щоб скасувати створення новини, нажміть \"ENTER\"");
                Console.WriteLine("Введіть текст новини: ");
                string temp3 = Console.ReadLine();
                if (temp3 == "")
                {
                    CancelAddingNews();
                    break; }
                else
                {
                    tempnew.Content = temp3;
                    tempnew.Time = DateTime.Now;
                    rubrics[index - 1].AddNews(tempnew);
                    Console.Clear();                   
                    ShowMenu();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nНовина \"{temp1}\" успішно добавлена до рубрики \"{rubric_names[index - 1]}\"!");
                    Console.ResetColor();
                    break;
                }
                
            }
        }
        public override void ShowMenu()
        {
            Console.WriteLine(String.Format("{0,18:0.0}", "Меню програми"));
            Console.WriteLine("0 - вийти із меню автора");
            Console.WriteLine("1 - добавити рубрику");
            Console.WriteLine("2 - добавити новину в рубрику");
            Console.WriteLine("3 - видалити рубрику");
            Console.WriteLine("4 - видалити новину із рубрики");
            Console.WriteLine("5 - переглянути список усіх рубрик");
            Console.WriteLine("6 - переглянути список усіх тем");
            Console.WriteLine("7 - переглянути список усіх тегів");
            Console.WriteLine("8 - переглянути список дат добавлення кожної новини");
            Console.WriteLine("9 - переглянути усіх авторів");
            Console.WriteLine("10 - переглянути певну новину");
            Console.WriteLine("11 - переглянути всі новини всіх рубрик");
            Console.WriteLine("12 - очистити консоль та переглянути це меню");
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
                        ShowMenu();Console.WriteLine();
                        throw new IsNotDigitException();
                    }
                    if (choice < 0 || 12 < choice)
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
                        string name;
                        Console.Clear();
                        ShowMenu(); Console.WriteLine();
                        Console.WriteLine("Щоб скасувати створення рубрики, нажміть \"ENTER\"");
                        Console.Write("\nВведіть назву рубрики: "); 
                        name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.Clear();
                            ShowMenu();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nВи скасували створення рубрики");
                            Console.ResetColor();
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                        else
                        {
                            rubric_names.Add(name);
                            rubrics.Add(new Rubric());
                            Console.Clear();
                            ShowMenu();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\nРубрика \"{name}\" успішно добавлена до списку рубрик!");
                            Console.ResetColor();                         
                            Console.Write("\nВиберіть наступну дію: ");
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            Console.WriteLine();
                            ShowNamesOfRubrics();
                            Console.Write("Введіть номер рубрики: ");
                            try
                            {
                                if (!int.TryParse(Console.ReadLine(), out int choice2))
                                {
                                    Console.Clear();
                                    ShowMenu();
                                    Console.WriteLine();
                                    throw new IsNotDigitException();
                                }
                                if (choice2 < 1 || rubric_names.Count() < choice2)
                                {
                                    Console.Clear();
                                    ShowMenu();
                                    Console.WriteLine();
                                    throw new OutOfRangeException();
                                }
                                AddNews(choice2);
                                Console.Write("\nВиберіть наступну дію: ");
                            }
                            catch (OutOfRangeException e) { CatchOutOfRangeException(e); }
                            catch (IsNotDigitException e) { CatchIsNotDigitException(e); }
                        }
                        else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            Console.WriteLine();
                            ShowNamesOfRubrics();
                            if (rubric_names.Count != 0)
                            {
                                Console.WriteLine("\nЩоб скасувати видалення рубрики, нажміть \"0\"");
                                Console.Write("Введіть індекс рубрики, яку бажаєте видалити: ");
                                try
                                {

                                    if (!int.TryParse(Console.ReadLine(), out int choice2))
                                        throw new IsNotDigitException();
                                    if (choice2 < 0 || rubrics.Count < choice2)
                                        throw new OutOfRangeException();
                                    if (choice2 == 0)
                                    {
                                        Console.Clear();
                                        ShowMenu(); Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ви скасували видалення рубрики");
                                        Console.ResetColor();
                                        Console.Write("Виберіть наступну дію: ");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        ShowMenu(); Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"Рубрика \"{rubric_names[choice2 - 1]}\" успішно видалена!");
                                        Console.ResetColor();
                                        Console.Write("Виберіть наступну дію: ");
                                        rubric_names.RemoveAt(choice2 - 1);
                                        rubrics.RemoveAt(choice2 - 1);
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
                        else Console.Write("\nВиберіть наступну дію: ");

                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        ShowMenu();
                        if (RubricListIsEmpty())
                        {
                            Console.Clear();
                            Console.WriteLine("Щоб скасувати видалення новини, нажміть \"0\"");
                            ShowNamesOfRubrics();
                            if (rubric_names.Count != 0)
                            {
                                Console.Write("\nВведіть індекс рубрики, в якій бажаєте видалити новину: ");
                                try
                                {
                                    if (!int.TryParse(Console.ReadLine(), out int choice2))
                                        throw new IsNotDigitException();
                                    if (choice2 < 0 || rubrics.Count < choice2)
                                    {
                                        Console.Clear();
                                        ShowMenu(); Console.WriteLine();
                                        throw new OutOfRangeException();
                                    }
                                    if (choice2 == 0)
                                    {
                                        Console.Clear();
                                        ShowMenu(); Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ви скасували видалення новини");
                                        Console.ResetColor();
                                        Console.Write("Виберіть наступну дію: ");
                                    }
                                    else
                                        RemoveNews(choice2);
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
                                    ShowMenu(); Console.WriteLine();
                                    CatchIsNotDigitException(e);
                                }
                            }
                        }
                        else Console.Write("\nВиберіть наступну дію: ");

                    }
                    else if (choice == 5)
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
                    else if (choice == 6)
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
                        } else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 7)
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
                    else if (choice == 8)
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
                    else if (choice == 9)
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
                        } else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 10)
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
                    else if (choice == 11)
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
                        } else Console.Write("\nВиберіть наступну дію: ");
                    }
                    else if (choice == 12)
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
