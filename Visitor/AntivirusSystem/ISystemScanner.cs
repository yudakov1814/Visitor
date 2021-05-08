using System.Collections.Generic;
using Visitor.FileSystem;

namespace Visitor.AntivirusSystem
{
    /// <summary>
    /// Системный сканер
    /// </summary>
    public interface ISystemScanner
    {
        /// <summary>
        /// Сканирует <see cref="IFileSystemElement"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(IFileSystemElement element);

        /// <summary>
        /// Сканирует <see cref="File"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(File file);

        /// <summary>
        /// Сканирует <see cref="Folder"/>
        /// </summary>
        /// <returns>
        /// Список найденных <see cref="Suspect"/>
        /// </returns>
        public IList<Suspect> Scan(Folder folder);
    }
}
