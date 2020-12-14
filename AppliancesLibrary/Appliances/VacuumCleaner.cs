using System;
using System.Collections.Generic;
using System.Text;

namespace AppliancesLibrary.Appliances
{
    public class VacuumCleaner : Appliance
    {
        #region Properties
        /// <summary>
        /// Name of vacuum cleaner.
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Manufacturer of vacuum cleaner.
        /// </summary>
        public override string Manufacturer { get; set; }
        /// <summary>
        /// Price of vacuum cleaner.
        /// </summary>
        public override double Price { get; set; }
        /// <summary>
        /// Power of vaccum cleaner.
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Color scheme of vacuum cleaner.
        /// </summary>
        public string ColorScheme { get; set; }
        #endregion

        /// <summary>
        /// Create new vacuum cleaner.
        /// </summary>
        public VacuumCleaner() { }
        /// <summary>
        /// Сreate new vacuum cleaner.
        /// </summary>
        /// <param name="name">Name of vacuum cleaner.</param>
        /// <param name="manufacturer">Manufacturer of vacuum cleaner.</param>
        /// <param name="price">Price of vacuum cleaner.</param>
        /// <param name="power">Power of vacuum cleaner.</param>
        /// <param name="colorScheme">Color Scheme of vacuum cleaner.</param>

        public VacuumCleaner(string name, string manufacturer, double price, string colorScheme, int power) : base(name, manufacturer, price)
        {
            #region Check data
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of appliance cannot be null", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                throw new ArgumentNullException("Manufacturer cannot be null", nameof(manufacturer));
            }
            if (price <= 0)
            {
                throw new ArgumentException("Price cant be null or equal to zero", nameof(price));
            }
            if (string.IsNullOrWhiteSpace(colorScheme))
            {
                throw new ArgumentNullException("Колір пристрою не можу бути пустим", nameof(colorScheme));
            }
            if (power <= 0)
            {
                throw new ArgumentNullException("Потужність не може бути меншою, або дорівнювти нулю", nameof(power));
            }
            #endregion

            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.ColorScheme = colorScheme;
            this.Power = power;
        }
        public override string ToString()
        {
            return $"{Name}, {Manufacturer}, {Price}$, {ColorScheme}, {Power}W";
        }
    }
}
