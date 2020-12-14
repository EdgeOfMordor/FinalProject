using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using AppliancesLibrary.Appliances;

namespace AppliancesLibrary
{
    class Controller
    {
        private List<Appliance> appliances;
        public void AddData()
        {
            string path = $"{Directory.GetCurrentDirectory()}" + "file.txt";
            if (File.Exists(path))
            {
                List<string> lists = File.ReadAllLines(path).ToList();
                foreach(string line in lists)
                {
                    if (line.ToLower().Contains("kitchen unit"))
                    {
                        string[] entries = line.Split(',');

                        appliances.Add(new KitchenUnit(entries[1], entries[2], Convert.ToDouble(entries[3]), Convert.ToInt32(entries[4]), Convert.ToInt32(entries[5])));
                    }
                    if (line.ToLower().Contains("vacuum cleaner"))
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
        }
    }
}
