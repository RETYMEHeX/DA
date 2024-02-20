using System.Runtime.CompilerServices;

namespace C;

public class Location()
{
    // Создает поле
    public static string[,] Give(int y, int x)
    {
        x = x*3;
        string[,] location = new string[y, x];

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (i == 0 || i == y-1 || j == 0 || j == x-1)
                {
                    location[i,j] = "#";
                }
                else
                {
                    location[i,j] = " ";
                }
            }
        }
        return location;
    }

    // Вывод поля на экран
    public static void Render(string[,] location)
    {
        for (int i = 0; i < location.GetLength(0); i++)
        {
            for (int j = 0; j < location.GetLength(1); j++)
            {
                Console.Write($"{location[i,j]}");
            }
            Console.WriteLine(" ");
        }
    }
}

public class Player()
{
    public const string icon_player = "@";
    public static int[] coordinates = new int[2];

    // Задает начальные координаты
    public static void Palce(string[,] location)
    {
        int x = location.GetLength(0) / 2;
        int y = location.GetLength(1) /  2;
        coordinates[0] = x;
        coordinates[1] = y;
    }

    // Добавляет игрока на локацию
    public static void Render(string[,] location)
    {
        int y = coordinates[0], x = coordinates[1];

        location[y,x] = icon_player;
    }
    // Убирает игрока
    public static void UnRender(string[,] location)
    {
        int y = coordinates[0], x = coordinates[1];

        location[y,x] = " ";
    }
}

class Program
{

    // Что бы меньше писать
    public static void Render_map(string[,] location)
    {
        Player.Render(location);
        Console.Clear();
        Location.Render(location);
    }

    static void Main(string[] args)
    {
        // Создание локации и помещение туда игрока
        var coordinates = Player.coordinates;
        string[,] location = Location.Give(7,7);
        Player.Palce(location);

        // Отрисовка
        Render_map(location);
        while (true){
            // Обработка управления игроком
            ConsoleKey ReadedKey = Console.ReadKey().Key;
            
            if (ReadedKey == ConsoleKey.W & location[coordinates[0]-1,coordinates[1]] != "#"){
                Player.UnRender(location);
                coordinates[0] -= 1;
                Render_map(location);
            }
            if (ReadedKey == ConsoleKey.S & location[coordinates[0]+1,coordinates[1]] != "#"){
                Player.UnRender(location);
                coordinates[0] += 1;
                Render_map(location);
            }
            if (ReadedKey == ConsoleKey.A & location[coordinates[0],coordinates[1]-1] != "#"){
                Player.UnRender(location);
                coordinates[1] -= 1;
                Render_map(location);
            }
            if (ReadedKey == ConsoleKey.D & location[coordinates[0],coordinates[1]+1] != "#"){
                Player.UnRender(location);
                coordinates[1] += 1;
                Render_map(location);
            }
        }
    }
}
