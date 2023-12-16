using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите источник для скачивания изображений:");
        Console.WriteLine("1. Ввод ссылок с клавиатуры");
        Console.WriteLine("2. Чтение ссылок из файла");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                DownloadImagesFromKeyboardInput();
                break;
            case 2:
                DownloadImagesFromFile();
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }

        Console.WriteLine("Завершение программы.");
    }

    static void DownloadImagesFromKeyboardInput()
    {
        Console.WriteLine("Введите ссылки на изображения (каждую ссылку в новой строке). Введите 'готово' для завершения:");

        string input;
        while ((input = Console.ReadLine()) != "готово")
        {
            DownloadImage(input);
        }
    }

    static void DownloadImagesFromFile()
    {
        Console.WriteLine("Введите путь к файлу, содержащему ссылки на изображения:");

        string filePath = Console.ReadLine();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Указанный файл не существует.");
            return;
        }

        string[] imageUrls = File.ReadAllLines(filePath);
        foreach (string url in imageUrls)
        {
            DownloadImage(url);
        }
    }

    static void DownloadImage(string imageUrl)
    {
        string savePath = "C:\\Users\\igorc\\OneDrive\\Рабочий стол\\kartinka.jpg"; 

        using (WebClient client = new WebClient())
        {
            try
            {
                client.DownloadFile(imageUrl, savePath);
                Console.WriteLine($"Изображение ({imageUrl}) успешно скачано и сохранено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при скачивании изображения ({imageUrl}): " + ex.Message);
            }
        }
    }
}
