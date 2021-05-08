using System.Collections.Generic;
using Visitor.AntivirusSystem;

namespace Visitor.FileSystem
{
    /// <summary>
    /// Элемент файловой системы
    /// </summary>
    public interface IFileSystemElement
    {
        /// <summary>
        /// Имя элемента файловой системы
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Путь до элемента файловой системы
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Размер элемента файловой системы
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Метод для двойной диспетчеризации
        /// </summary>
        /// <see cref="ISystemScanner"/>
        public IList<Suspect> Accept(ISystemScanner scanner);
    }
}
