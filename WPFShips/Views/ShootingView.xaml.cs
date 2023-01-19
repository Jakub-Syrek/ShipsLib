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
using ShipsLib;

namespace WPFShips.Views
{
    /// <summary>
    /// Interaction logic for ShootingView.xaml
    /// </summary>
    public partial class ShootingView : UserControl
    {
        private Board newBoard;

        //private void ShotButtonClick(object sender, RoutedEventArgs e)
        //{
        //    var button = sender as CustomButton;
        //    var x = button.X;
        //    var y = button.Y;

        //    var pointExtraction =
        //        ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent)
        //        .PointExtraction;
        //    string lastPlacement =
        //        ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent)
        //        .LastPlacement;

        //    if (!pointExtraction)
        //    {
        //        return;
        //    }

        //    if (!Validate(x, y, lastPlacement, button))
        //    {
        //        return;
        //    }
        //    counter++;
        //    button.Background = Brushes.Blue;

        //    if (lastPlacement == TileValue.Destroyer.ToString())
        //    {
        //        var mainW = ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent);

        //        if (mainW.AddDestroyer.IsEnabled)
        //        {

        //            mainW.AddDestroyer.IsEnabled = false;
        //            lastX = -1;
        //            lastY = -1;
        //        }
        //        else if (mainW.AddDestroyer1.IsEnabled)
        //        {
        //            mainW.AddDestroyer1.IsEnabled = false;
        //            lastX = -1;
        //            lastY = -1;
        //        }
        //        else if (mainW.AddDestroyer2.IsEnabled)
        //        {
        //            mainW.AddDestroyer2.IsEnabled = false;
        //            lastX = -1;
        //            lastY = -1;
        //        }
        //        else if (mainW.AddDestroyer3.IsEnabled)
        //        {
        //            mainW.AddDestroyer3.IsEnabled = false;
        //            lastX = -1;
        //            lastY = -1;
        //        }
        //        ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent)
        //            .PointExtraction = false;

        //        return;
        //    }

        //    if (lastX == -1 || lastY == -1)
        //    {
        //        lastX = x;
        //        lastY = y;

        //    }
        //    else
        //    {
        //        int xFrom = Math.Min(lastX, x);
        //        int xTo = Math.Max(lastX, x);
        //        int yFrom = Math.Min(lastY, y);
        //        int yTo = Math.Max(lastY, y);

        //        var columnBased = xTo - xFrom > 0;
        //        var rowBased = yTo - yFrom > 0;

        //        if (columnBased && rowBased)
        //        {
        //            return;
        //        }

        //        if (!columnBased && !rowBased)
        //        {
        //            return;
        //        }

        //        if (columnBased)
        //        {
        //            for (int i = xFrom; i < xTo; i++)
        //            {
        //                var uiElementCollection = MainGrid.Children;
        //                foreach (UIElement uiElement in uiElementCollection)
        //                {
        //                    var butt = (CustomButton)uiElement;
        //                    if (butt.X == i && butt.Y == yTo)
        //                    {
        //                        butt.Background = Brushes.Blue;
        //                        var tile = this.newBoard.GetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)yTo));
        //                        switch (lastPlacement)
        //                        {
        //                            case "Carrier":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)yTo), TileValue.Carrier);
        //                                break;
        //                            case "Battleship":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)yTo), TileValue.Battleship);
        //                                break;
        //                            case "Cruiser":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)yTo), TileValue.Cruiser);
        //                                break;
        //                            case "Destroyer":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)yTo), TileValue.Destroyer);
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (rowBased)
        //        {
        //            for (int i = yFrom; i < yTo; i++)
        //            {
        //                var uiElementCollection = MainGrid.Children;
        //                foreach (UIElement uiElement in uiElementCollection)
        //                {
        //                    var butt = (CustomButton)uiElement;
        //                    if (butt.X == xTo && butt.Y == i)
        //                    {
        //                        butt.Background = Brushes.Blue;
        //                        var tile = this.newBoard.GetTile(new TileDimension((BoardVertical)xTo, (BoardHorizontal)i));
        //                        switch (lastPlacement)
        //                        {
        //                            case "Carrier":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)xTo, (BoardHorizontal)i), TileValue.Carrier);
        //                                break;
        //                            case "Battleship":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)xTo, (BoardHorizontal)i), TileValue.Battleship);
        //                                break;
        //                            case "Cruiser":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)xTo, (BoardHorizontal)i), TileValue.Cruiser);
        //                                break;
        //                            case "Destroyer":
        //                                this.newBoard.SetTile(new TileDimension((BoardVertical)xTo, (BoardHorizontal)i), TileValue.Destroyer);
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //        }


        //        lastX = x;
        //        lastY = y;


        //        if (lastPlacement == TileValue.Carrier.ToString())
        //        {
        //            ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent).AddCarr.IsEnabled = false;
        //            lastX = -1;
        //            lastY = -1;
        //        }
        //        if (lastPlacement == TileValue.Battleship.ToString())
        //        {
        //            var mainW = ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent);

        //            if (mainW.AddBatt.IsEnabled)
        //            {

        //                mainW.AddBatt.IsEnabled = false;
        //                lastX = -1;
        //                lastY = -1;
        //            }
        //            else
        //            {
        //                if (mainW.AddBatt1.IsEnabled)
        //                {
        //                    mainW.AddBatt1.IsEnabled = false;
        //                    lastX = -1;
        //                    lastY = -1;
        //                }
        //            }
        //        }
        //        if (lastPlacement == TileValue.Cruiser.ToString())
        //        {
        //            var mainW = ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent);

        //            if (mainW.AddCruiser.IsEnabled)
        //            {

        //                mainW.AddCruiser.IsEnabled = false;
        //                lastX = -1;
        //                lastY = -1;
        //            }
        //            else if (mainW.AddCruiser1.IsEnabled)
        //            {
        //                mainW.AddCruiser1.IsEnabled = false;
        //                lastX = -1;
        //                lastY = -1;
        //            }
        //            else if (mainW.AddCruiser2.IsEnabled)
        //            {
        //                mainW.AddCruiser2.IsEnabled = false;
        //                lastX = -1;
        //                lastY = -1;
        //            }
        //        }

        //        ((MainWindow)((Grid)((StackPanel)((BoardView)((Grid)button.Parent).Parent).Parent).Parent).Parent)
        //            .PointExtraction = false;
        //        //newBoard.SetTile(new TileDimension(BoardHorizontal.A, BoardVertical.B), TileValue.Battleship);
        //        //var neighbours = newBoard.GetNeighbours(new TileDimension(BoardHorizontal.J, BoardVertical.J));
        //        //Console.WriteLine(newBoard.ToString());
        //    }
        //}

        //private bool Validate(int x, int y, string lastPlacement, CustomButton senderButton)
        //{
        //    int xFrom = Math.Min(lastX, x);
        //    int xTo = Math.Max(lastX, x);
        //    int yFrom = Math.Min(lastY, y);
        //    int yTo = Math.Max(lastY, y);

        //    var dim = new TileDimension((BoardVertical)senderButton.X, (BoardHorizontal)senderButton.Y);
        //    var neighborsList = newBoard.GetNeighbours(dim);
        //    if (neighborsList.Exists(x => x.IsOccupied))
        //    {
        //        return false;
        //    }

        //    switch (lastPlacement)
        //    {
        //        case "Carrier":

        //            break;
        //        case "Battleship":

        //            break;
        //        case "Cruiser":

        //            break;
        //        case "Destroyer":

        //            break;
        //    }



        //    return true;
        //}
        private void ShotButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as CustomButton;
            var x = button.X;
            var y = button.Y;

          
                var uiElementCollection = MainGrid.Children;
                foreach (UIElement uiElement in uiElementCollection)
                {
                    var butt = (CustomButton)uiElement;
                    if (butt.X == x && butt.Y == y)
                    {
                        if (butt.HiddenTileValue == TileValue.Hit || butt.HiddenTileValue == TileValue.Miss)
                        {
                            return;
                        }
                        if (butt.HiddenTileValue != TileValue.Hit && butt.HiddenTileValue != TileValue.Miss &&
                            butt.HiddenTileValue != TileValue.Empty)
                        {
                            butt.TileValue = TileValue.Hit;
                            butt.Background = Brushes.Red;
                            butt.Name = butt.HiddenTileValue.ToString();
                            //butt.Visibility = Visibility.Collapsed;
                            //butt.IsEnabled = false;
                        }
                        if (butt.HiddenTileValue == TileValue.Empty )
                        {
                            butt.TileValue = TileValue.Miss;
                            butt.Background = Brushes.Gray;
                            butt.Name = butt.HiddenTileValue.ToString();
                            //butt.Visibility = Visibility.Collapsed;
                            //butt.IsEnabled = false;

                        }
                    }
                }
           

        }
        public ShootingView()
        {
            InitializeComponent();
            newBoard = new Board();
            newBoard.PopulateRandomly();

            int count = 1;

            foreach (BoardVertical rowName in Enum.GetValues(typeof(BoardVertical)))
            {
                var i = (int)rowName;
                //var nameVertical = EnumExtensionMethods.GetEnumDescription((TileValue)(BoardVertical)i);
                var nameVerticalEnum = (BoardVertical)i;
                foreach (BoardHorizontal columnName in Enum.GetValues(typeof(BoardHorizontal)))
                {
                    var j = (int)columnName;
                    //var nameHorizontal = EnumExtensionMethods.GetEnumDescription((TileValue)(BoardHorizontal)j);
                    var nameHorizontalEnum = j;

                    var button = new CustomButton();
                    button.Content = $"{nameVerticalEnum}{nameHorizontalEnum}";
                    button.HorizontalAlignment = HorizontalAlignment.Stretch;
                    //button.TileValue = TileValue.Empty;
                    button.TileValue = newBoard.GetTile(new TileDimension((BoardVertical)i, (BoardHorizontal)j))!.Value; 
                    button.HiddenTileValue = newBoard.GetTile(new TileDimension((BoardVertical) i, (BoardHorizontal) j))!.Value;
                    button.Name = $"{nameVerticalEnum}{nameHorizontalEnum}{button.HiddenTileValue}";

                    button.X = i;
                    button.Y = j;

                    button.Click += new RoutedEventHandler(ShotButtonClick);

                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);
                    MainGrid.Children.Add(button);

                    count++;
                }
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            foreach (BoardVertical rowName in Enum.GetValues(typeof(BoardVertical)))
            {
                var i = (int)rowName;
                //var nameVertical = EnumExtensionMethods.GetEnumDescription((TileValue)(BoardVertical)i);
                var nameVerticalEnum = (BoardVertical)i;
                foreach (BoardHorizontal columnName in Enum.GetValues(typeof(BoardHorizontal)))
                {
                    var j = (int)columnName;
                    //var nameHorizontal = EnumExtensionMethods.GetEnumDescription((TileValue)(BoardHorizontal)j);
                    var nameHorizontalEnum = j;

                    var uiElementCollection = MainGrid.Children;
                    foreach (UIElement uiElement in uiElementCollection)
                    {
                        var butt = (CustomButton)uiElement;
                        if (butt.X == i && butt.Y == j)
                        {
                            butt.TileValue = butt.HiddenTileValue;

                            if (butt.HiddenTileValue == TileValue.Hit || butt.HiddenTileValue == TileValue.Miss)
                            {
                                return;
                            }
                            if (butt.HiddenTileValue != TileValue.Hit && butt.HiddenTileValue != TileValue.Miss &&
                                butt.HiddenTileValue != TileValue.Empty)
                            {
                                butt.TileValue = TileValue.Hit;
                                butt.Background = Brushes.Red;
                                butt.Name = butt.HiddenTileValue.ToString();
                                //butt.Visibility = Visibility.Collapsed;
                                //butt.IsEnabled = false;
                            }
                            if (butt.HiddenTileValue == TileValue.Empty)
                            {
                                butt.TileValue = TileValue.Miss;
                                butt.Background = Brushes.Gray;
                                butt.Name = butt.HiddenTileValue.ToString();
                                //butt.Visibility = Visibility.Collapsed;
                                //butt.IsEnabled = false;

                            }
                        }
                    }


                }
            }
        }
    }
}
