using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AppliancesLibrary.Appliances
{
    [Serializable]
    [KnownType(typeof(KitchenUnit))]
    [KnownType(typeof(WashingMachine))]
    [KnownType(typeof(VacuumCleaner))]
    public abstract class Appliance : IComparable
    {
        #region Properties
        /// <summary>
        /// Name of appliance.
        /// </summary>
        [DataMember]
        public abstract string Name { get; set; }
        /// <summary>
        /// Manufacturer of appliance.
        /// </summary>
        [DataMember]
        public abstract string Manufacturer { get; set; }
        /// <summary>
        /// Price of appliance.
        /// </summary>
        [DataMember]
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
            return $"Appliance: {Name}, Made by {Manufacturer},Its price: {Price}$";
        }

        public virtual int CompareTo(object o)
        {
            if (o is Appliance a)
            {
                return this.Name.CompareTo(a.Name);
            }
            else
            {
                throw new Exception("An error has occured while sorting");
            }
        }
    }
}
