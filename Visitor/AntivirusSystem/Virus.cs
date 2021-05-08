namespace Visitor.AntivirusSystem
{
    /// <summary>
    /// Вирис
    /// </summary>
    public class Virus
    {
        /// <summary>
        /// Название вируса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сигнатура вируса для его поиска
        /// </summary>
        public string Signature { get; set; }
    }
}
