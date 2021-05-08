using System.Collections.Generic;
using Visitor.AntivirusSystem;

namespace Visitor.FileSystem
{
    /// <summary>
    /// Файл в файловой системе
    /// </summary>
    /// <see cref="IFileSystemElement"/>
    public class File : IFileSystemElement
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь до файла
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Размер файла
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Данные файла
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Метод для двойной диспетчеризации файлов
        /// </summary>
        /// <see cref="ISystemScanner"/>
        public IList<Suspect> Accept(ISystemScanner scanner)
        {
            return scanner.Scan(this);
        }
    }
}
