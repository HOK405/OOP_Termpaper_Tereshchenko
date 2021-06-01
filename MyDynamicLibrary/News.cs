using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDynamicLibrary
{
    public class News
    {
        public string Content { get; set; }
        public string Topic { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public News()
        {
            Content = "null";
            Topic = "null";
            Tags = new List<string>() { "null" };
            Author = "null";
            Time = DateTime.MinValue;
        }
        public News(string content, string topic, List<string> tags, string author, DateTime time)
        {
            Content = content;
            Topic = topic;
            Tags = tags;
            Author = author;
            Time = time;
        }

        public void Show()
        {
            Console.ResetColor();
            Console.Write("Тема: ");             Console.ForegroundColor = ConsoleColor.Blue;   Console.WriteLine("\""+Topic+ "\"");
            Console.ResetColor();
            Console.Write("Автор: ");            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("\"" + Author + "\"");
            Console.ResetColor();
            Console.Write("Час викладення: ");   Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(Time);
            Console.ResetColor();
            Console.Write("Теги: ");             Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < Tags.Count(); i++)
                if (i != Tags.Count() - 1)
                    Console.Write(Tags[i] + ", ");
                else
                    Console.Write(Tags[i]);
            Console.ResetColor();
            Console.Write("\nВміст: ");         Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine(Content);
            Console.WriteLine(); Console.ResetColor();
        }
    }
}
