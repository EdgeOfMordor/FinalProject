using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using AppliancesLibrary.Appliances;
using System.Runtime.Serialization.Json;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace AppliancesLibrary
{
    public static class Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Add Data to the list of appliances.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns></returns>
        public static List<Appliance> AddData(List<Appliance> appliances, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    List<string> lists = File.ReadAllLines(path).ToList();
                    foreach (string line in lists)
                    {
                        if (line.Contains("kitchen unit"))
                        {
                            string[] entries = line.Split(',');

                            appliances.Add(new KitchenUnit(entries[1], entries[2], Convert.ToDouble(entries[3]), Convert.ToInt32(entries[4]), Convert.ToInt32(entries[5])));
                        }
                        if (line.Contains("vacuum cleaner"))
                        {
                            string[] entries = line.Split(',');

                            appliances.Add(new VacuumCleaner(entries[1], entries[2], Convert.ToDouble(entries[3]), entries[4], Convert.ToInt32(entries[5])));
                        }
                        if (line.ToLower().Contains("washing machine"))
                        {
                            string[] entries = line.Split(',');

                            appliances.Add(new WashingMachine(entries[1], entries[2], Convert.ToDouble(entries[3]), Convert.ToInt32(entries[4]), Convert.ToInt32(entries[5])));
                        }
                        log.Info("Object successfuly created");
                    }
                }
                else throw new FileNotFoundException($"There is no file with path {path}");

            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex.Message);
            }
            catch (FileLoadException ex)
            {
                log.Error(ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return appliances;

        }

        /// <summary>
        /// Saves data to the txt file.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        /// <param name="path">Path of the file.</param>
        public static void SaveData(List<Appliance> appliances, string path)
        {
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine($"**********Appliances**********");
                    int counter = 0;
                    foreach (var a in appliances)
                    {
                        sw.WriteLine(a.ToString());
                        sw.WriteLine();
                        counter++;
                    }
                    sw.WriteLine($"******************************");
                    sw.WriteLine($"Number of appliances : {counter}");
                    sw.WriteLine($"Cost of items on the list : {GetCost(appliances)}");
                    log.Info("Data is saved!");
                }
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex.Message);
            }
            catch (FileLoadException ex)
            {
                log.Error(ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        /// <summary>
        /// Gets cost of all appliances on the list.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        /// <returns></returns>
        private static double GetCost(List<Appliance> appliances)
        {
            double value = 0;
            foreach (var a in appliances)
            {
                value += a.Price;
            }
            return value;
        }

        /// <summary>
        /// Sorts list of appliances.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        /// <returns></returns>
        public static List<Appliance> Sort(List<Appliance> appliances)
        {
            appliances.Sort();
            log.Info("List is sorted!");
            return appliances;
        }

        /// <summary>
        /// Finds every appliance of certain manufacturer.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        /// <param name="manufacturer">Manufacturer of appliances.</param>
        /// <returns></returns>
        public static List<Appliance> FindApplianceByManufacturer(List<Appliance> appliances, string manufacturer)
        {
            List<Appliance> brandApp = new List<Appliance>();
            foreach(var a in appliances)
            {
                if (manufacturer.ToLower().Equals(a.Manufacturer.ToLower()))
                {
                    brandApp.Add(a);
                }
            }
            return brandApp;
        }

        /// <summary>
        /// Serializes list of appliances.
        /// </summary>
        /// <param name="appliances">List of appliances.</param>
        public static void SerializeData(List<Appliance> appliances)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Appliance>));

            try
            {
                using (var file = new FileStream("appliances.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(file, appliances);
                }
                log.Info("Data is serealized");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// Deserialize list of appliances.
        /// </summary>
        /// <returns>List of appliances.</returns>
        public static List<Appliance> DeserializeData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Appliance>));
            List<Appliance> newAppliances = new List<Appliance>();
            try
            {
                using (var file = new FileStream("appliances.json", FileMode.OpenOrCreate))
                {
                    newAppliances = (List<Appliance>)jsonFormatter.ReadObject(file);
                }
                log.Info("Data is deserialized!");
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return newAppliances;
        }

    }
}
