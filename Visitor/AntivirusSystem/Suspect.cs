namespace Visitor.AntivirusSystem
{
    /// <summary>
    /// Подозрительный элемент файловой системы
    /// </summary>
    public class Suspect
    {
        /// <summary>
        /// Название (в чем подозрение)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь к элементу в файловой системе
        /// </summary>
        public string Path { get; set; }
    }
}
