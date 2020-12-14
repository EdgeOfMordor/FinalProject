using System;
using System.Collections.Generic;
using System.Text;

namespace AppliancesLibrary.Appliances
{
    [Serializable]
    public abstract class Appliance
    {
        #region Properties
        /// <summary>
        /// Name of appliance.
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// Manufacturer of appliance.
        /// </summary>
        public abstract string Manufacturer { get; set; }
        /// <summary>
        /// Price of appliance.
        /// </summary>
        public abstract double Price { get; set; }
        #endregion

        /// <summary>
        /// Create new appliance.
        /// </summary>
        public Appliance() { }

        /// <summary>
        /// Create new appliance.
        /// </summary>
        /// <param name="name">Name of appliance.</param>
        /// <param name="manufacturer">Manufacturer of appliance.</param>
        /// <param name="price">Price of appliance.</param>
        public Appliance(string name, string manufacturer, double price)
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
            #endregion

            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{Name},{Manufacturer},{Price}$";
        }
    }
}
