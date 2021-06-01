using System;
using System.Collections.Generic;
using System.Linq;
using MyDynamicLibrary;

namespace TermPaper_OOP_2021_Tereshchenko_Bohdan
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            List<string> rubric_names = new List<string>() { "Головне", "Політика", "Економіка", "Спорт", "Здоров'я"};
            List<Rubric> rubrics;
            rubrics = FullFillRubrics();
            bool flag = true;
            while (flag)
            {
            Console.Clear();
            Console.WriteLine("Ласкаво просимо на сайт новин \"NewsWorld\"!");
            Console.WriteLine("Будь-ласка, дотримуйтесь умов переміщення по сайту, які буде надавати програма\n");
            string author=null;
            int is_admin = CheckAdmin(ref author);    
            Console.Clear();
                if (is_admin == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ви ввійшли в систему авторів!");
                    Admin admin = new Admin(rubrics, rubric_names, author);
                    Console.ResetColor();
                    admin.Menu();
                }
                else if (is_admin == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ви ввійшли як гість!");
                    Guest guest = new Guest(rubrics, rubric_names, author);
                    Console.ResetColor();
                    guest.Menu();
                }
                else flag = false;
            }
            Console.Clear();
            TheEnd();            
        }
        static public void TheEnd()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════╗ ╔══╗   ╔══╗  ╔══════╗    ╔══════╗  ╔══╗   ╔══╗  ╔═════╗  ");
            Console.WriteLine("║ ╔══╗  ╔══╗ ║ ║  ║   ║  ║  ║  ╔═══╝    ║  ╔═══╝  ║  ║   ║  ║  ║     ║  ");
            Console.WriteLine("╚═╝  ║  ║  ╚═╝ ║  ║   ║  ║  ║  ║        ║  ║      ║  ╚══╗║  ║  ║  ╔╗ ╚╗ ");
            Console.WriteLine("     ║  ║      ║  ╚═══╝  ║  ║  ╚═══╗    ║  ╚═══╗  ║  ╔═╗╚╝  ║  ║  ║╚╗ ╚╗");
            Console.WriteLine("     ║  ║      ║  ╔═══╗  ║  ║  ╔═══╝    ║  ╔═══╝  ║  ║ ╚═╗  ║  ║  ║ ║  ║");
            Console.WriteLine("     ║  ║      ║  ║   ║  ║  ║  ║        ║  ║      ║  ║   ║  ║  ║  ║ ║  ║");
            Console.WriteLine("     ║  ║      ║  ║   ║  ║  ║  ╚═══╗    ║  ╚═══╗  ║  ║   ║  ║  ║  ╚═╝  ║");
            Console.WriteLine("     ║  ║      ╚══╝   ╚══╝  ╚══════╝    ╚══════╝  ╚══╝   ╚══╝  ╚═══════╝");
            Console.WriteLine("     ║  ╚══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("     ╚═════════════════════════════════════════════════════════════════╝");
            Console.ReadKey();
        }
        static List<Rubric> FullFillRubrics()
        {
            List<Rubric> rubrics = new List<Rubric>() {new Rubric(), new Rubric(), new Rubric(), new Rubric(), new Rubric() };
            News tempnew = new News();
            tempnew.Content = "Закарпатські прикордонники втретє затримали поляка-нелегала,\nякий намагався потрапити в Україну, щоб збирати полуницю";
            tempnew.Topic = "Затримання нелегала";
            tempnew.Tags = new List<string> {"нелегал","затримання", "прикордонники" };
            tempnew.Author = "Bohdan";
            tempnew.Time = new DateTime(2020, 7, 20, 18, 30, 25);
            rubrics[0].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "У Києві жінка атакувала водія, бо він налякав її коня, якого вели пастися до школи";
            tempnew.Topic = "Жінка атакувала водія";
            tempnew.Tags = new List<string> { "водій", "жінка", "атака" };
            tempnew.Author = "NewsOne";
            tempnew.Time = new DateTime(2021, 5, 22, 12, 17, 18);
            rubrics[0].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "Україна та НАТО";
            tempnew.Topic = "Україна не братиме участі в саміті НАТО з технічних причин";
            tempnew.Tags = new List<string> { "Україна", "НАТО","причини" };
            tempnew.Author = "NewsOne";
            tempnew.Time = new DateTime(2021, 3, 17, 5, 17, 25);
            rubrics[1].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "Податківцям дозволили штрафувати фірми за порушення при валютних операціях";
            tempnew.Topic = "Штрафи за махінації";
            tempnew.Tags = new List<string> { "податківці", "штраф", "порушення","валюта" };
            tempnew.Author = "UKRNova";
            tempnew.Time = new DateTime(2021, 2, 11, 3, 13, 19);
            rubrics[2].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "У Мінекономіки зобов'язали АЗС знизити ціни на пальне";
            tempnew.Topic = "Зниження цін на пальне";
            tempnew.Tags = new List<string> { "АЗС", "ціна", "пальне", "зниження" };
            tempnew.Author = "UKRNova";
            tempnew.Time = new DateTime(2021, 6, 4, 2, 11, 25);
            rubrics[2].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "Ювентус» оголосив ім'я нового головного тренера.\nМассіміліано Аллегрі призначений новим головним тренером туринського Ювентуса";
            tempnew.Topic = "Головний тренер Ювентуса";
            tempnew.Tags = new List<string> { "Ювентус", "ім'я", "тренер", "Аллегрі" };
            tempnew.Author = "UKRNova";
            tempnew.Time = new DateTime(2021, 2, 11, 3, 13, 25);
            rubrics[3].AddNews(tempnew);

            tempnew = new News();
            tempnew.Content = "Міністерство освіти й науки рекомендувало у 2020/2021 навчальному році закладам освіти утриматися\nвід масових заходів, зокрема випускних вечорів.";
            tempnew.Topic = "Випускний вечір та COVID-19";
            tempnew.Tags = new List<string> { "Вірус", "COVID-19", "школа", "навчання" };
            tempnew.Author = "GoodNews";
            tempnew.Time = new DateTime(2021, 5, 28, 15, 15, 15);
            rubrics[4].AddNews(tempnew);

            return rubrics;
        }
        static int CheckAdmin(ref string author)
        {                   
            while (true)
            {
                Console.WriteLine("Ви автор новин?   Так - 1     Ні - 2    Покинути сайт - 3");
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int n))
                        throw new IsNotDigitException();
                    if (n < 1 || 3 < n)
                        throw new OutOfRangeException();
                    else if (n == 2)
                    {
                        Console.WriteLine("Ви ввійшли як гість");
                        return 2;
                    }
                    else if (n == 1)
                    {
                        List<string> admins = new List<string>()   {"NewsOne", "UKRNova",   "GoodNews"          };
                        List<string> passwords = new List<string>(){ "hardpassword", "ukrainepassword","2jzgte" };
                        string name;
                        string password;
                        Console.Write("Введіть нік автора: ");
                        name = Console.ReadLine();
                        if (admins.Contains(name))
                        {
                            Console.Write($"Введіть пароль автора {name} : ");
                            password = Console.ReadLine();
                            if (password == passwords[admins.IndexOf(name)])
                            {
                                author = name;
                                return 1;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль неправильний!\n");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Автора з таким ніком не існує!\n");
                            Console.ResetColor();
                        }
                    }
                    else return 3;
                }
                catch (OutOfRangeException e) { User.CatchOutOfRangeException(e); Console.WriteLine(); }
                catch (IsNotDigitException e) { User.CatchIsNotDigitException(e); Console.WriteLine(); }
            }   
        }
    }
}
