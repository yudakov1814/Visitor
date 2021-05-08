using System.Collections.Generic;
using Visitor.FileSystem;

namespace Visitor.AntivirusSystem
{
    /// <summary>
    /// Сканер для быстрой проверки системы
    /// </summary>
    /// <see cref="ISystemScanner"/>
    public class QuickScanner : ISystemScanner
    {
        private readonly IList<Virus> Viruses;

        /// <summary>
        /// Инициализирует сканер для быстрой проверки системы
        /// </summary>
        public QuickScanner()
        {
            Viruses = new List<Virus>
            {
                new Virus
                {
                    Name = "Обычный вирус",
                    Signature = "I'm a virus"
                },
                new Virus
                {
                    Name = "Очень опасный вирус",
                    Signature = "I am a very dangerous virus"
                },
            };
        }

        /// <summary>
        /// Сканирует <see cref="IFileSystemElement"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(IFileSystemElement element)
        {
            return element.Accept(this);
        }

        /// <summary>
        /// Сканирует <see cref="File"/> на самые распространенные вирусы
        /// Пропускает файлы с размером более 60
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(File file)
        {
            if (file.Size > 60)
            {
                return new List<Suspect>();
            }

            List<Suspect> suspects = new();

            foreach (var virus in Viruses)
            {
                if (file.Data.Contains(virus.Signature))
                {
                    suspects.Add(new Suspect
                    {
                        Name = virus.Name,
                        Path = file.Path
                    });
                }
            }

            return suspects;
        }

        /// <summary>
        /// Сканирует <see cref="Folder"/> на самые распространенные вирусы
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(Folder folder)
        {
            List<Suspect> suspects = new();

            foreach (var element in folder.Elements)
            {
                suspects.AddRange(Scan(element));
            }

            return suspects;
        }
    }
}
