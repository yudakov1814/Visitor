using System;
using System.Collections.Generic;
using System.Linq;
using Visitor.AntivirusSystem;
using Visitor.FileSystem;

namespace Visitor
{
    /// <summary>
    /// Пример программы
    /// </summary>
    public class Program
    {
        static void RunScan(IFileSystemElement fileSystemElement, ISystemScanner scanner)
        {
            var result = scanner.Scan(fileSystemElement);

            Console.WriteLine($"{scanner.GetType()} Result:");
            foreach (var suspect in result)
            {
                Console.WriteLine($"'{suspect.Name}' in '{suspect.Path}'");
            }
            if (!result.Any())
            {
                Console.WriteLine("Вирусов нет");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            IFileSystemElement fileSystemElement = new Folder
            {
                Name = "Главная папка",
                Path = "root",
                Elements = new List<IFileSystemElement>
                {
                    new Folder
                    {
                        Name = "Мои документы",
                        Path = "root\\Мои документы",
                        Elements = new List<IFileSystemElement>
                        {
                            new File
                            {
                                Name = "Договор.docx",
                                Path = "root\\Мои документы\\Договор.docx",
                                Data = "This is my contract to buy a house... I'm a virus))"
                            },
                            new File
                            {
                                Name = "Фото с моря.jpeg",
                                Path = "root\\Мои документы\\Фото с моря.jpeg",
                                Data = "image"
                            },
                            new Folder
                            {
                                Name = "Пустая папка",
                                Path = "root\\Мои документы\\Пустая папка",
                                Elements = new List<IFileSystemElement>()
                            }
                        }
                    },
                    new File
                    {
                        Name = "Точно не вирус.exe",
                        Path = "root\\Мои документы\\Точно не вирус.exe",
                        Data = "I'm a virus; I'm a hidden virus; I am a very dangerous virus."
                    }
                }
            };

            RunScan(fileSystemElement, new QuickScanner());
            RunScan(fileSystemElement, new FullScanner());
        }
    }
}
