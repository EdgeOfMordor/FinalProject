using System;
using System.Collections.Generic;
using System.Text;

namespace AppliancesLibrary.Appliances
{
    public class WashingMachine : Appliance
    {
        #region Properties
        /// <summary>
        /// Name of washing machine.
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Manufacturer of washing machine.
        /// </summary>
        public override string Manufacturer { get; set; }
        /// <summary>
        /// Price of washing machine.
        /// </summary>
        public override double Price { get; set; }
        /// <summary>
        /// Number of washing machine programs
        /// </summary>
        public int NumberOfPrograms { get; set; }
        /// <summary>
        /// Capacity of washing machine.
        /// </summary>
        public int Capacity { get; set; }
        #endregion

        /// <summary>
        /// Create new washing machine
        /// </summary>
        public WashingMachine() { }

        /// <summary>
        /// Create new washing machine.
        /// </summary>
        /// <param name="name">Name of washing machine.</param>
        /// <param name="manufacturer">Manufacturer of washing machine.</param>
        /// <param name="price">Price of washing machine.</param>
        /// <param name="numberOfPrograms">Number of washing machine programs.</param>
        /// <param name="capacity">Capacity of washing machine.</param>
        public WashingMachine(string name, string manufacturer, double price, int numberOfPrograms, int capacity) : base(name, manufacturer, price)
        {
            #region CheckData
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
            if (numberOfPrograms <= 0)
            {
                throw new ArgumentNullException("Кількість програм не може дорівнювати нулю", nameof(numberOfPrograms));
            }
            if (capacity <= 0)
            {
                throw new ArgumentNullException("Потужність присторою не може дорівнювати нулю", nameof(capacity));
            }
            #endregion

            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.NumberOfPrograms = numberOfPrograms;
            this.Capacity = capacity;
        }
        public override string ToString()
        {
            return $"{Name}, {Manufacturer}, {Price}$, {NumberOfPrograms} programs, {Capacity}L";
        }
    }
}
