using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using AppliancesLibrary.Appliances;

namespace AppliancesLibrary
{
    public static class Controller
    {
        private static readonly List<Appliance> appliances = new List<Appliance>();

        public static List<Appliance> GetData()
        {
            AddData();
            return appliances;
        }

        private static void AddData()
        {
            try
            {
                string path = @"E:\file.txt";
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
                    }
                }
                else throw new FileNotFoundException($"There is no file with path {path}");

            }
            catch (FileNotFoundException ex)
            {
                //TODO:Logging
            }
            catch (Exception ex)
            {
                //TODO:Logging
            }

        }
    }
}
