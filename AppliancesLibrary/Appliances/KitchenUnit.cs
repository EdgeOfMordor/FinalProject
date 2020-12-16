using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AppliancesLibrary.Appliances
{
    [Serializable]
    public class KitchenUnit : Appliance
    {
        #region Properties
        /// <summary>
        /// Name of kitchen unit.
        /// </summary>
        [DataMember]
        public override string Name { get; set; }
        /// <summary>
        /// Manufacturer of kitchen unit.
        /// </summary>
        [DataMember]
        public override string Manufacturer { get; set; }
        /// <summary>
        /// Price of kitchen unit.
        /// </summary>
        [DataMember]
        public override double Price { get; set; }
        /// <summary>
        /// Power of kitchen unit.
        /// </summary>
        [DataMember]
        public int Power { get; set; }
        /// <summary>
        /// Number of kitchen unit programs.
        /// </summary>
        [DataMember]
        public int NumberOfPrograms { get; set; }
        #endregion

        /// <summary>
        /// Create new kitchen unit.
        /// </summary>
        public KitchenUnit() { }
        /// <summary>
        /// Сreate new kitchen unit.
        /// </summary>
        /// <param name="name">Name of kitchen unit.</param>
        /// <param name="manufacturer">Manufacturer of kitchen unit.</param>
        /// <param name="price">Price of kithcen unit.</param>
        /// <param name="power">Power of kitchen unit.</param>
        /// <param name="numberOfPrograms">Number of kitchen unit programs.</param>
        public KitchenUnit(string name, string manufacturer, double price, int power, int numberOfPrograms)
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
            if (power <= 0)
            {
                throw new ArgumentNullException("Потужність не може бути меншою, або дорівнювти нулю", nameof(power));
            }
            if (numberOfPrograms <= 0)
            {
                throw new ArgumentNullException("Кількість програм не може дорівнювати нулю", nameof(numberOfPrograms));
            }
            #endregion

            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Power = power;
            this.NumberOfPrograms = numberOfPrograms;
        }
        public override string ToString()
        {
            return $"Kitchen unit: {Name},Made by {Manufacturer}, Its price {Price}$, Power: {Power}W, It has {NumberOfPrograms} programs";
        }
    }
}
