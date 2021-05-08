using System.Collections.Generic;
using Visitor.FileSystem;

namespace Visitor.AntivirusSystem
{
    /// <summary>
    /// Сканер для полной проверки системы
    /// </summary>
    /// <see cref="ISystemScanner"/>
    public class FullScanner : ISystemScanner
    {
        private readonly IList<Virus> Viruses;

        /// <summary>
        /// Инициализирует сканер для полной проверки системы
        /// </summary>
        public FullScanner()
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
                    Name = "Скрытный вирус",
                    Signature = "I'm a hidden virus"
                },
                new Virus
                {
                    Name = "Очень опасный вирус",
                    Signature = "I am a very dangerous virus"
                },
            };
        }

        /// <summary>
        /// Полностью сканирует <see cref="IFileSystemElement"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(IFileSystemElement element)
        {
            return element.Accept(this);
        }

        /// <summary>
        /// Полностью сканирует <see cref="File"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(File file)
        {
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
        /// Полностью сканирует <see cref="Folder"/>
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
