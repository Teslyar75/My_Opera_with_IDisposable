/* Завдання 3: Додайте до першого завдання реалізацію інтерфейсу IDisposable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class My_Opera_with_IDisposable : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public My_Opera_with_IDisposable(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Заголовок: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Жанр: {Genre}");
        Console.WriteLine($"Год написания произведения: {Year}");
    }

    public void Dispose()
    {
       
    }
}

class Program
{
    static void Main()
    {
        var plays = new List<My_Opera_with_IDisposable>();

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить пьесу");
            Console.WriteLine("2. Удалить пьесу");
            Console.WriteLine("3. Показать все пьесы");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название пьесы: ");
                    string title = Console.ReadLine();

                    Console.Write("Введите имя автора: ");
                    string author = Console.ReadLine();

                    Console.Write("Введите жанр: ");
                    string genre = Console.ReadLine(); // Используйте ReadLine для всей строки

                    Console.Write("Введите год написания: ");
                    int year = int.Parse(Console.ReadLine());

                    plays.Add(new My_Opera_with_IDisposable(title, author, genre, year));
                    break;

                case "2":
                    Console.Write("Введите название пьесы для удаления: ");
                    string titleToRemove = Console.ReadLine();
                    var playToRemove = plays.Find(p => p.Title == titleToRemove);
                    if (playToRemove != null)
                    {
                        plays.Remove(playToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Пьеса не найдена.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Список всех пьес:");
                    foreach (var play in plays)
                    {
                        play.DisplayInformation();
                        Console.WriteLine();
                    }
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Неверная опция. Повторите выбор.");
                    break;
            }
        }
    }
}

