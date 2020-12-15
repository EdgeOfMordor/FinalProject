﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using AppliancesLibrary.Appliances;

namespace AppliancesLibrary
{
    public static class Controller
    {
        public static List<Appliance> AddData(List<Appliance> appliances)
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
            catch (FileLoadException ex)
            {
                //TODO:Logging
            }
            catch (Exception ex)
            {
                //TODO:Logging
            }
            return appliances;

        }

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
                    //log.Debug("Data is saved!");
                }
            }
            catch (FileNotFoundException ex)
            {
                //TODO:Logging
            }
            catch (FileLoadException ex)
            {
                //TODO:Logging
            }
            catch (Exception ex)
            {
                //TODO:Logging
            }

        }

        public static List<Appliance> Sort(List<Appliance> appliances)
        {
            appliances.Sort();
            return appliances;
        }

        public static List<Appliance> FindApplianceByManufacturer(List<Appliance> appliances, string manufacturer)
        {
            List<Appliance> brandApp = new List<Appliance>();
            foreach(var a in appliances)
            {
                if (manufacturer.ToLower().Equals(a.Manufacturer))
                {
                    brandApp.Add(a);
                }
            }
            return brandApp;
        }
        public static double GetCost(List<Appliance> appliances)
        {
            double value = 0;
            foreach(var a in appliances)
            {
                value += a.Price;
            }
            return value;
        }

    }
}
