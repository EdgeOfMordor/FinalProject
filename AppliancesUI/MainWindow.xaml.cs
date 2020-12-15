using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppliancesLibrary;
using AppliancesLibrary.Appliances;

namespace AppliancesUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Appliance> appliances = new List<Appliance>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDataButton_Click(object sender, RoutedEventArgs e)
        {
            appliances = Controller.AddData(appliances, @"E:\file.txt");
            countBlock.Text = $"Number of appliances : {appliances.Count()}";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            appliances = Controller.Sort(appliances);
            Controller.SaveData(appliances, @"E:\appliances_new.txt");
        }
    }
}
