using ShipsLib;
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

namespace WPFShips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool PointExtraction = false;
        public string LastPlacement = null;

        private void AddCarrier(object sender, RoutedEventArgs e)
        {
            LastPlacement = TileValue.Carrier.ToString();
            GetPointFromUser();
        }
        private void AddBattleship(object sender, RoutedEventArgs e)
        {
            LastPlacement = TileValue.Battleship.ToString();
            GetPointFromUser();
        }
        
        private void GetPointFromUser()
        {
            PointExtraction = true;
        }

        private void AddCruiser_OnClick(object sender, RoutedEventArgs e)
        {
            LastPlacement = TileValue.Cruiser.ToString();
            GetPointFromUser();
        }

        private void AddDestroyer_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            LastPlacement = TileValue.Destroyer.ToString();
            GetPointFromUser();
        }
    }
}
