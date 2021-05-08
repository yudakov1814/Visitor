using System.Collections.Generic;
using System.Linq;
using Visitor.AntivirusSystem;

namespace Visitor.FileSystem
{
    /// <summary>
    /// Папка в файловой системе
    /// </summary>
    /// <see cref="IFileSystemElement"/>
    public class Folder : IFileSystemElement
    {
        /// <summary>
        /// Элементы файловой системы, которые содержатся внутри папки
        /// </summary>
        public IList<IFileSystemElement> Elements { get; set; }

        /// <summary>
        /// Имя папки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь до папки
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Размер папки (ее содержимого)
        /// </summary>
        public int Size => Elements.Sum(x => x.Size);

        /// <summary>
        /// Метод для двойной диспетчеризации папок
        /// </summary>
        /// <see cref="ISystemScanner"/>
        public IList<Suspect> Accept(ISystemScanner scanner)
        {
            return scanner.Scan(this);
        }
    }
}
