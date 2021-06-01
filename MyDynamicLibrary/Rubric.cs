using System;
using System.Collections.Generic;

namespace MyDynamicLibrary
{
    public class Rubric
    {
        private List<News> rubric;
        public Rubric()
        {
            rubric = new List<News> { };
        }
        public Rubric(List<News> rubric)
        {
            this.rubric = rubric;
        }

        private bool RubricIsEmpty()
        {
            if (rubric.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Рубрика пуста!");
                Console.ResetColor();
                return false;
            }
            else
                return true;
        }

        public void ShowRubric()
        {
            if (RubricIsEmpty())
                foreach (News i in rubric)
                    i.Show();
        }
        public void AddNews(News somenews) { rubric.Add(somenews); }
        public void RemoveNews(int index) { rubric.RemoveAt(index); }
        public void Clear() { rubric.Clear(); }
        public int Count() { return rubric.Count; }
        public void ShowNewsTopics()
        {          
            if (RubricIsEmpty())
            { 
                int k = 0;
                foreach (News i in rubric)
                {
                    Console.ResetColor();
                    Console.Write((k + 1) + " - ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(i.Topic);
                    k++; Console.ResetColor();
                }
            }
        }
        public News GetNews(int index) { return rubric[index]; }
        public void ShowNewsTags()
        {
            if (RubricIsEmpty())
            {
                for (int i = 0; i < rubric.Count; i++)
                {
                    Console.Write("Теги новини №" + (i + 1) + ": ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    for (int j = 0; j < rubric[i].Tags.Count; j++)
                    {
                        if (j != rubric[i].Tags.Count - 1)
                            Console.Write(rubric[i].Tags[j] + ", ");
                        else
                            Console.Write(rubric[i].Tags[j]);
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
        }
        public void ShowNewsTime()
        {
            if (RubricIsEmpty())
            {
                for (int i = 0; i < rubric.Count; i++)
                {
                    Console.Write("Час добавлення новини №" + (i + 1) + ": ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(rubric[i].Time);
                    Console.ResetColor();
                }
            }
        }
        public void ShowNewsAuthor()
        {
            if (RubricIsEmpty())
            {
                for (int i = 0; i < rubric.Count; i++)
                {
                    Console.Write("Автор новини новини №" + (i + 1) + ": ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(rubric[i].Author);
                    Console.ResetColor();
                }
            }
        }
    }
}
